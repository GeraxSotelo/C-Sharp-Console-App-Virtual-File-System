using c_sharp_console_app_virtual_file_system.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Models
{
    public class FileSystem : IFileSystem
    {
        public RootDirectory Root { get; set; }
        public IDirectory CurrentDirectory { get; set; }
        
        public void Setup()
        {

            Directory TestDirectory = new Directory("test directory.jpg");

            File TestFile = new File("test file.txt");

            CurrentDirectory = Root;

            Console.WriteLine("Welcome to the Virtual File System application.\n");
        }

        //CONSTRUCTOR
        public FileSystem(RootDirectory root)
        {
            this.Root = root;
            Setup();
        }
    }
}
