﻿using Todo.Contracts.Data.FileSystem;

namespace Todo.Contracts.Services.StateAndConfig;

public interface ISettingsPathProvider
{
    FilePathInfo SettingsPath { get; }
}
