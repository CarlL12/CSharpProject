namespace CSharpProject.Interfaces
{
    public interface IFileService
    {
        string GetContentFromFile();
        bool SaveContentToFile(string content);
    }
}