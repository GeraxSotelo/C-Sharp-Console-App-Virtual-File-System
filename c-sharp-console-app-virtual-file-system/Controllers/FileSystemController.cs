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
        private FileSystem fileSystem;
        private UtilityService _us;
        private DirectoryService _ds;
        private FileService _fs;
        private CommandParser cp = new CommandParser();

        //CONSTRUCTOR
        public FileSystemController()
        {
            _us = new UtilityService();
            _ds = new DirectoryService();
            _fs = new FileService();
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
            string userInput = Console.ReadLine() + " ";
            AnalyzeInput(userInput);
        }

        public Input AnalyzeInput(string input)
        {
            Input parsedInput = cp.ParseInput(input);

            switch (parsedInput.Command)
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
                    Directory directoryData = new Directory(parsedInput.Option) { ParentId = fileSystem.CurrentDirectory.Id };
                    try
                    {
                        _ds.Mkdir(directoryData);
                        Console.WriteLine("Successfully created");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "touch":
                    File fileData = new File(parsedInput.Option) { ParentDirectoryId = fileSystem.CurrentDirectory.Id };
                    _fs.Touch(fileData);
                    break;
                default:
                    parsedInput.Command = "Invalid input";
                    Console.WriteLine(parsedInput.Command);
                    break;
            }
            return parsedInput;
        }

    }
}
