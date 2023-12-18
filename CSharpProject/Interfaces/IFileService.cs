namespace CSharpProject.Interfaces
{
    public interface IFileService
    {

        /// <summary>
        /// Getting file from comp
        /// </summary>
        /// <returns></returns>
        string GetContentFromFile();

        /// <summary>
        /// Saving file to comp
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        bool SaveContentToFile(string content);
    }
}