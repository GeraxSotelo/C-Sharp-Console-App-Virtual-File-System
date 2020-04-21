using Xunit;
using System.Collections.Generic;
using System.Text;
using c_sharp_console_app_virtual_file_system;
using c_sharp_console_app_virtual_file_system.Models;

namespace VirtualFileSystem.Tests
{
    public class GetUserInputShould
    {
        [Fact]
        public void CorrectUserInputCommand()
        {
            string expected = "mkdir";
            Input actual = new FileSystemController().AnalyzeInput("MkDir ");

            Assert.Equal(expected, actual.Command);
        }

        [Fact]
        public void IncorrectUserInputCommand()
        {
            string expected = "Invalid input";
            Input actual = new FileSystemController().AnalyzeInput("abc ");

            Assert.Equal(expected, actual.Command);
        }

        [Fact]
        [Trait("Category", "Directory")]
        public void DirectyNameHasNoSpecialCharacters()
        {
            //NOTE ^(?:[A-Za-z]+)(?:[A-Za-z0-9 _]*)$ for checking first character
            string pattern = @"^[A-Za-z0-9 _]*$";
            //passing in an invalid input in AnalyzeInput() will return the string "Invalid input"
            Input actual1 = new FileSystemController().AnalyzeInput("mkdir test folder");
            Input actual2 = new FileSystemController().AnalyzeInput("mkdir test folder");
            Assert.Matches(pattern, actual1.Option);
            Assert.DoesNotMatch(pattern, actual2.Option);
        }

        [Fact]
        public void FileNameHasNoSpecialCharacters()
        {
            //NOTE ^(?:[A-Za-z]+)(?:[A-Za-z0-9 _]*)$ for checking first character
            string pattern = @"^[A-Za-z0-9 _]*$";
            //passing in an invalid input in AnalyzeInput() will return the string "Invalid input"
            Input actual1 = new FileSystemController().AnalyzeInput("touch test file");
            Input actual2 = new FileSystemController().AnalyzeInput("touch test*file");
            Assert.Matches(pattern, actual1.Option);
            Assert.DoesNotMatch(pattern, actual2.Option);
        }
    }
}
