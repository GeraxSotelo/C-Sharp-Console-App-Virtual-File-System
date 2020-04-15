using c_sharp_console_app_virtual_file_system.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Repositories
{
    class DirectoryRepository
    {
        private readonly string _cs = @"server=den1.mysql1.gear.host;userid=filesystem;password=Vm4Bb6z2ai__;database=filesystem";
        private MySqlConnection _con { get; }

        public DirectoryRepository()
        {
            _con = new MySqlConnection(_cs);
            _con.Open();
        }

        internal int Mkdir(Directory data)
        {
            string sql = @"
            INSERT INTO directories
            (name, parentId)
            VALUES
            (@name, @parentId);
            SELECT LAST_INSERT_ID();";
            int id = _con.ExecuteScalar<int>(sql, data);
            return id;
        }
    }
}
