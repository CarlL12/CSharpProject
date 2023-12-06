
using CSharpProject.Interfaces;
using CSharpProject.Services;

namespace CSharpProject.Tests;

public class FileService_Tests
{
    
    [Fact]

    public void SaveContentToFileShould_SaveContentToFile()
    {
        // Arrange
        FileService fileService = new FileService(@"D:\CSharpProjects\content.json");
        string content = "Test content";

        //Act

        bool result = fileService.SaveContentToFile(content);

        //Assert
        Assert.True(result);
    }
    [Fact]
    public void GetContentFromFileShould_GetCOntentFromFile()
    {
        // Arrange
        FileService fileService = new FileService(@"D:\CSharpProjects\content.json");

        //Act
        string result = fileService.GetContentFromFile();

        //Assert

        Assert.NotEmpty(result);
    }

}
