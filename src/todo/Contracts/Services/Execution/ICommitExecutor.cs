﻿using Todo.Contracts.Data.Commands;

namespace Todo.Contracts.Services.Execution;

public interface ICommitExecutor : IExecutor<CommitCommand> { }
