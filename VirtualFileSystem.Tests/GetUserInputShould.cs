using Xunit;
using System.Collections.Generic;
using System.Text;
using c_sharp_console_app_virtual_file_system;

namespace VirtualFileSystem.Tests
{
    public class GetUserInputShould
    {
        [Fact]
        public void CorrectUserInputCommand()
        {
            string expected = "mkdir ";
            string actual = new FileSystemController().CheckInput("MkDir ");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blah()
        {
            string actual = new FileSystemController().CheckInput("mkdir ");

            Assert.Matches("[a-z]", actual.Substring(0,1));
        }

        [Fact]
        public void IncorrectUserInputCommand()
        {
            string expected = "Invalid input";
            string actual = new FileSystemController().CheckInput("abc ");

            Assert.Equal(expected, actual);
        }
    }
}
