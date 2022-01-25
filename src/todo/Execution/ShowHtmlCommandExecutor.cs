﻿using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Todo.Contracts.Data.Commands;
using Todo.Contracts.Data.FileSystem;
using Todo.Contracts.Services.Execution;
using Todo.Contracts.Services.FileSystem;
using Todo.Contracts.Services.StateAndConfig;

namespace Todo.Execution;

[SuppressMessage("ReSharper", "UnusedType.Global")]
public class ShowHtmlCommandExecutor : CommandExecutorBase<ShowHtmlCommand>, IShowHtmlCommandExecutor
{
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

    [DllImport("user32.dll")]
    private static extern int SetForegroundWindow(IntPtr hwnd);

    private readonly IConfigurationProvider _configurationProvider;
    private readonly IDateListPathResolver _dateListPathResolver;

    public ShowHtmlCommandExecutor(IConfigurationProvider configurationProvider, IDateListPathResolver dateListPathResolver)
    {
        _configurationProvider = configurationProvider;
        _dateListPathResolver = dateListPathResolver;
    }

    public override void Execute(ShowHtmlCommand showHtmlCommand)
    {
        var pathInfo = _dateListPathResolver.ResolvePathFor(showHtmlCommand.Date, FileTypeEnum.Html, false);

        var process = Process.Start(_configurationProvider.Config.BrowserPath, pathInfo.Path);

        BringMainWindowToFront(process);
    }

    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private enum ShowWindowEnum
    {
        Hide = 0,
        ShowNormal = 1, ShowMinimized = 2,
        Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
        Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
        Restore = 9, ShowDefault = 10, ForceMinimized = 11
    }

    // ReSharper disable once UnusedMethodReturnValue.Local
    private static int BringMainWindowToFront(Process process)
    {
        // check if the window is hidden / minimized
        if (process.MainWindowHandle == IntPtr.Zero)
        {
            // the window is hidden so try to restore it before setting focus.
            ShowWindow(process.Handle, ShowWindowEnum.ShowDefault);
        }

        // set user the focus to the window
        return SetForegroundWindow(process.MainWindowHandle);
    }
}
