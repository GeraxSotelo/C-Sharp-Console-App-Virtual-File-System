using c_sharp_console_app_virtual_file_system.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Repositories
{
    public class FileRepository
    {
        private readonly string _cs = RepoResource.ConnectionString;
        private MySqlConnection _conn;
        public FileRepository()
        {
            _conn = new MySqlConnection(_cs);
            _conn.Open();
        }

        public void Touch(File data)
        {
            string sql = @"
            INSERT INTO files
            (name, parentDirectoryId)
            VALUES
            (@name, @parentDirectoryId);
            ";
            _conn.Execute(sql, data);
        }
    }
}
