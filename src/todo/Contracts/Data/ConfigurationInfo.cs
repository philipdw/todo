﻿using System.Text.Json.Serialization;

namespace Todo.Contracts.Data;

public class ConfigurationInfo
{

    #region Paths to third-party tools

    public string BrowserPath { get; }

    public string TextEditorPath { get; }

    public string GitPath { get; }

    #endregion

    #region Paths to templates

    public string MarkdownTemplatePath { get; }

    public string HtmlTemplatePath { get; }

    #endregion

    #region Paths to folders the app writes to

    public string OutputFolder { get; }

    public string ArchiveFolderName { get; }

    #endregion

    public bool UseGit { get; }

    public bool UseNamesForDays { get; }

    public int ConsoleWidth { get; }

    [JsonConstructor]
    public ConfigurationInfo(
        string browserPath, string textEditorPath, string gitPath,
        string markdownTemplatePath, string htmlTemplatePath,
        string outputFolder, string archiveFolderName,
        bool useNamesForDays, bool useGit, int consoleWidth)
    {
        BrowserPath = browserPath;
        TextEditorPath = textEditorPath;
        GitPath = gitPath;

        MarkdownTemplatePath = markdownTemplatePath;
        HtmlTemplatePath = htmlTemplatePath;

        OutputFolder = outputFolder;
        ArchiveFolderName = archiveFolderName;

        UseGit = useGit;
        UseNamesForDays = useNamesForDays;
        ConsoleWidth = consoleWidth;
    }
}
