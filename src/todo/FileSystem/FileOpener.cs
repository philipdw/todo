﻿using System.Diagnostics;
using Todo.Contracts.Services.FileSystem;
using Todo.Contracts.Services.StateAndConfig;

namespace Todo.FileSystem;

public class FileOpener : IFileOpener
{
    private readonly IConfigurationProvider _configurationProvider;
    private readonly IPathHelper _pathHelper;
    private string? _textEditorPath;

    public FileOpener(IConfigurationProvider configurationProvider, IPathHelper pathHelper)
    {
        _configurationProvider = configurationProvider;
        _pathHelper = pathHelper;
    }

    private string TextEditorPath => _textEditorPath ?? GetTextEditorPath();

    private string GetTextEditorPath()
    {
        _textEditorPath = _pathHelper.ResolveIfNotRooted(
            _configurationProvider.Config.TextEditorPath.GetPathForThisOs());
        return _textEditorPath;
    }

    public void LaunchFileInDefaultEditor(string path)
    {
        Process.Start(TextEditorPath, path);
    }
}
