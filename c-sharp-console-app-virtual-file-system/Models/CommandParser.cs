using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Models
{
    class CommandParser
    {
        public Input Input = new Input();

        public Input ParseInput(string input)
        {
            Input.Command = input.Substring(0, input.IndexOf(" ")).ToLower();
            Input.Option = input.Substring(input.IndexOf(" ") + 1).Trim().ToLower();

            return Input;
        }
    }
}
