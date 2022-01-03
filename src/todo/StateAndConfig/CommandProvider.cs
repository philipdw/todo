﻿using System;
using Todo.Contracts.Data.Commands;
using Todo.Contracts.Services.DateParsing;
using Todo.Contracts.Services.StateAndConfig;

namespace Todo.StateAndConfig
{
    public class CommandProvider : ICommandProvider
    {
        private readonly ICommandLineProvider _commandLineProvider;
        private readonly ICommandIdentifier _commandIdentifier;
        private readonly IDateParser _dateParser;

        public CommandProvider(ICommandLineProvider commandLineProvider, 
            ICommandIdentifier commandIdentifier, IDateParser dateParser)
        {
            _commandLineProvider = commandLineProvider;
            _commandIdentifier = commandIdentifier;
            _dateParser = dateParser;
        }
        
        public CommandBase GetCommand()
        {
            if (_commandIdentifier.TryGetCommandType(out var commandType, out var commitMessage))
            {
                switch (commandType)
                {
                    case ICommandIdentifier.CommandTypeEnum.Sync:
                    return SyncCommand.Of(commitMessage);
                    
                    default: throw new Exception("Command not yet implemented.");
                }
            }

            var commandLine = _commandLineProvider.GetCommandLineMinusAssemblyLocation();
            
            if (_dateParser.TryGetDate(commandLine, out var date))
            {
                return CreateOrShowCommand.Of((DateOnly)date);                
            }

            throw new Exception("Command not recognised");
        }
    }
}