using System;

namespace c_sharp_console_app_virtual_file_system
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            FileSystemController fsc = new FileSystemController();
            fsc.Run();
        }
    }
}
