using c_sharp_console_app_virtual_file_system.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Models
{
    public class FileSystem : IFileSystem
    {
        public IDirectory CurrentDirectory { get; set; }
        
        public void Setup()
        {
            RootDirectory Root = new RootDirectory("root");

            Directory TestDirectory = new Directory("test directory.jpg");

            File TestFile = new File("test file.txt");

            Root.Directories.Add(TestDirectory);
            Root.Files.Add(TestFile);

            CurrentDirectory = Root;

            Console.WriteLine("Welcome to the Virtual File System application.\n");
        }

        //CONSTRUCTOR
        public FileSystem()
        {
            Setup();
        }
    }
}
