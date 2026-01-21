using UnityEngine;
using System.IO;

public static class FileAccessUtility
{
    public static string DefaultPath { get; private set; }

    static FileAccessUtility()
    {
        DefaultPath = Application.persistentDataPath;
    }

    public static FileAccessResult GetDataFromFile()
    {
        FileAccessResult result = new FileAccessResult();

        string path = FileDialog.OpenFilePanel("Поиск файла", DefaultPath, "txt");

        result.filePath = path;

        if(string.IsNullOrEmpty(path))
        {
            result.success = false;
            result.errorText = "Пустой путь";
        }
        else
        {
            string fileData = File.ReadAllText(path);

            if(ParsingUtility.CheckFileStringFormat(fileData, out string message))
            {
                result.success = true;
                DefaultPath = path;
                result.fileText = fileData;
            }
            else
            {
                result.success = false;
                DefaultPath = path;
                result.fileText = string.Empty;
                result.errorText = message;
            }


        }

        return result;
    }
}

public class FileAccessResult
{
    public bool success;
    public string filePath;
    public string fileText;
    public string errorText;
}
