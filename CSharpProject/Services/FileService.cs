
using System.Diagnostics;
using CSharpProject.Interfaces;
using CSharpProject.Models;
namespace CSharpProject.Services;

public class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath;

    // Sparar filen
    public bool SaveContentToFile(string content)
    {
        try
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
    // hämtar filen
    public string GetContentFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using (var sr = new StreamReader(_filePath))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        {
            return null!;

        }
    }
}
