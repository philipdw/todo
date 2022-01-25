﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Todo.Contracts.Data.Commands;
using Todo.Contracts.Data.FileSystem;
using Todo.Contracts.Services.Execution;
using Todo.Contracts.Services.FileSystem;
using Todo.Contracts.Services.Git;
using Todo.Contracts.Services.StateAndConfig;

namespace Todo.Execution;

[SuppressMessage("ReSharper", "UnusedType.Global")]
public class ArchiveCommandExecutor : CommandExecutorBase<ArchiveCommand>, IArchiveCommandExecutor
{
    private readonly IConfigurationProvider _configurationProvider;
    private readonly IGitInterface _gitInterface;
    private readonly IDateListPathResolver _dateListPathResolver;

    public ArchiveCommandExecutor(IConfigurationProvider configurationProvider,
        IGitInterface gitInterface, IDateListPathResolver dateListPathResolver)
    {
        _configurationProvider = configurationProvider;
        _gitInterface = gitInterface;
        _dateListPathResolver = dateListPathResolver;
    }

    public override void Execute(ArchiveCommand command)
    {
        if (_configurationProvider.Config.UseGit) Archive(command, GitArchive);
        else Archive(command, FileArchive);
    }

    private void Archive(ArchiveCommand command, Action<FilePathInfo, FilePathInfo> archiveOp)
    {
        var sourcePathInfo = _dateListPathResolver.GetFilePathFor(command.DateOfFileToArchive, FileTypeEnum.Markdown);
        var destinationPathInfo = _dateListPathResolver.GetArchiveFilePathFor(command.DateOfFileToArchive, FileTypeEnum.Markdown);

        archiveOp(sourcePathInfo, destinationPathInfo);
    }

    private void GitArchive(FilePathInfo sourcePathInfo, FilePathInfo destinationPathInfo)
        => _gitInterface.RunGitCommand($"mv {sourcePathInfo.Path} {destinationPathInfo.Path}");

    private static void FileArchive(FilePathInfo sourcePathInfo, FilePathInfo destinationPathInfo)
        => File.Move(sourcePathInfo.Path, destinationPathInfo.Path);
}
