using c_sharp_console_app_virtual_file_system.Models;
using c_sharp_console_app_virtual_file_system.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system
{
    public class FileSystemController
    {
        private bool _running = true;
        private FileSystem fileSystem { get; set; }
        private UtilityService _us { get; set; }
        private DirectoryService _ds { get; set; }

        //CONSTRUCTOR
        public FileSystemController()
        {
            fileSystem = new FileSystem();
            _us = new UtilityService();
            _ds = new DirectoryService();
        }

        public void Run()
        {
            while (_running)
            {
                Console.WriteLine("\nType a command. Type 'help' for information. Type 'q' or 'e' to exit.\n");
                Console.Write($"{fileSystem.CurrentDirectory.Name}: / ");
                GetUserInput();
            }
        }

        public void GetUserInput()
        {
            string input = Console.ReadLine().ToLower() + " ";
            CheckInput(input);
        }

        public string CheckInput(string input)
        {
            string command = input.Substring(0, input.IndexOf(" "));
            string option = input.Substring(input.IndexOf(" ") + 1).Trim();

            switch (command)
            {
                case "q":
                case "e":
                    _running = false;
                    break;
                case "help":
                    _us.Help();
                    break;
                case "ls":
                    _us.Ls(fileSystem.CurrentDirectory);
                    break;
                case "mkdir":
                    Directory data = new Directory(option) { ParentId = 3 };
                    _ds.Mkdir(data);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            return "success";
        }

    }
}
