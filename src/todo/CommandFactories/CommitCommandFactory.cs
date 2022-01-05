﻿using System.Diagnostics.CodeAnalysis;
using Todo.Contracts.Data.Commands;

namespace Todo.CommandFactories;

[SuppressMessage("ReSharper", "UnusedType.Global")]
public class CommitCommandFactory : CommandFactoryBase<CommitCommand>
{
    private static readonly string[] Words = { "commit", "c" };

    public override bool IsDefaultCommandFactory => false;

    public CommitCommandFactory() : base(Words) { }

    public override CommitCommand? TryGetCommand(string commandLine)
    {
        return !IsThisCommand(commandLine, out var restOfCommand)
            ? default : CommitCommand.Of(restOfCommand);
    }
}
