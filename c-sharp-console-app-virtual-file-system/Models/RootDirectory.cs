﻿using c_sharp_console_app_virtual_file_system.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Models
{
    class RootDirectory : IRootDirectory
    {
        public string Name { get; set; }
    }
}