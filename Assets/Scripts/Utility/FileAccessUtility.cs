using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FileAccessUtility
{
    private static string defaultPath;

    static FileAccessUtility()
    {
        defaultPath = Application.persistentDataPath;
    }

    public static string GetDataFromFile()
    {
        defaultPath = FileDialog.OpenFilePanel("Поиск файла", defaultPath, ".txt");

        return File.ReadAllText(defaultPath);
    }
}
