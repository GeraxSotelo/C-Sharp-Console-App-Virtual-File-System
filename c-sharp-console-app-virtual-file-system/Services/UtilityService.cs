﻿using c_sharp_console_app_virtual_file_system.Interfaces;
using c_sharp_console_app_virtual_file_system.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Services
{
    class UtilityService
    {
        public List<string> Messages { get; set; }

        //CONSTRUCTOR
        public UtilityService()
        {
            Messages = new List<string>();
        }
        
        public void Help()
        {
            Messages.Add("\nmkdir     Creates a directory.");
            Messages.Add("ls        Lists files in current working directory");
            Messages.Add("touch     Create a file without any content");
            Messages.Add("rm        Remove a file");
            Print();
        }

        public void Ls(IDirectory currentDirectory)
        {
            Messages.Add("Ls method");

            Print();
        }

        public void Print()
        {
            foreach (string msg in Messages)
            {
                Console.WriteLine(msg);
            }
            Messages.Clear();
        }

    }
}
