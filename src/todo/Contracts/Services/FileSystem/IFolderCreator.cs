﻿namespace Todo.Contracts.Services.FileSystem;

public interface IFolderCreator
{
    void CreateOutputFolder();

    void CreateArchiveFolder();
}
