﻿using Todo.Contracts.Data.Commands;

namespace Todo.Contracts.Services.Execution;

public interface IWhichTodoCommandExecutor : ICommandExecutor<WhichTodoCommand> { }
