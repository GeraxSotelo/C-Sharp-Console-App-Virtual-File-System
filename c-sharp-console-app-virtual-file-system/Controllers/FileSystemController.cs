using c_sharp_console_app_virtual_file_system.Interfaces;
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
        public RootDirectory Root { get; }
        private FileSystem fileSystem { get; set; }
        private UtilityService _us { get; set; }
        private DirectoryService _ds { get; set; }

        //CONSTRUCTOR
        public FileSystemController()
        {
            _us = new UtilityService();
            _ds = new DirectoryService();
            Root = GetRootDirectory();
            fileSystem = new FileSystem(Root);
        }

        public RootDirectory GetRootDirectory()
        {
            return _ds.GetRootDirectory();
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
            string input = Console.ReadLine() + " ";
            CheckInput(input);
        }

        public string CheckInput(string input)
        {
            input = input.ToLower();
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
                    try
                    {
                        _ds.Mkdir(data);
                        Console.WriteLine("Successfully created");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                   
                    break;
                default:
                    input = "Invalid input";
                    Console.WriteLine(input);
                    break;
            }
            return input;
        }

    }
}
