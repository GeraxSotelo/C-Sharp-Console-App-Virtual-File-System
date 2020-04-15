using c_sharp_console_app_virtual_file_system.Models;
using MySql.Data.MySqlClient;
using System;

namespace c_sharp_console_app_virtual_file_system
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemController fsc = new FileSystemController();
            fsc.Run();
        }
    }
}
