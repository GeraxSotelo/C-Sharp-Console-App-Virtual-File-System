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
        public void NoSpecialCharacters()
        {
            //NOTE ^(?:[A-Za-z]+)(?:[A-Za-z0-9 _]*)$ for checking first character
            string pattern = @"^[A-Za-z0-9 _]*$";
            //passing in an invalid input in AnalyzeInput() will return the string "Invalid input"
            Input actual = new FileSystemController().AnalyzeInput("mkdir test folder");
            Assert.Matches(pattern, actual.Option);
        }

        [Fact]
        public void IncorrectUserInputCommand()
        {
            string expected = "Invalid input";
            Input actual = new FileSystemController().AnalyzeInput("abc ");

            Assert.Equal(expected, actual.Command);
        }
    }
}
