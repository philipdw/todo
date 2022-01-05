﻿using System;
using System.Diagnostics.CodeAnalysis;
using Todo.Contracts.Data.Commands;
using Todo.Contracts.Services.DateParsing;

namespace Todo.CommandFactories;

[SuppressMessage("ReSharper", "UnusedType.Global")]
public class ShowHtmlCommandFactory : CommandFactoryBase<ShowHtmlCommand>
{
    private static readonly string[] Words = { "showhtml", "html", "h" };

    private readonly IDateParser _dateParser;

    public override bool IsDefaultCommandFactory => false;

    public ShowHtmlCommandFactory(IDateParser dateParser)
        : base(Words)
    {
        _dateParser = dateParser;
    }

    public override ShowHtmlCommand? TryGetCommand(string commandLine)
    {
        if (!IsThisCommand(commandLine, out var restOfCommand)) return default;

        if (!_dateParser.TryGetDate(restOfCommand, out var dateOnly))
            throw new ArgumentException("Date in archive command is not recognised");

        return ShowHtmlCommand.Of(dateOnly);
    }
}
