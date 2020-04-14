using Xunit;
using System.Collections.Generic;
using System.Text;
using c_sharp_console_app_virtual_file_system;

namespace VirtualFileSystem.Tests
{
    public class GetUserInputShould
    {
        [Fact]
        public void UserInputCommand()
        {
            string expected = "success";
            string actual = new FileSystemController().CheckInput("mkdir ");

            Assert.Equal(expected, actual);
        }
    }
}
