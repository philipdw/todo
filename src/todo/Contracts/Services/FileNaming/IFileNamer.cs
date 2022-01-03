﻿using System;
using Todo.FileNaming;

namespace Todo.Contracts.Services.FileNaming;

public interface IFileNamer
{
    string FileNameWithoutExtension(DateOnly dateOnly);

    string FileNameForDate(DateOnly dateOnly, FileTypeEnum fileType);

    string GetFilePath(DateOnly dateOnly, FileTypeEnum fileType);

    string GetArchiveFilePath(DateOnly dateOnly, FileTypeEnum fileType);
}
