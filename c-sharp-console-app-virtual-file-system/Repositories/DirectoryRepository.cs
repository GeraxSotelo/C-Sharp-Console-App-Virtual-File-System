using c_sharp_console_app_virtual_file_system.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Resources;
using System.Collections.Generic;
using System.Text;
using System;

namespace c_sharp_console_app_virtual_file_system.Repositories
{
    class DirectoryRepository
    {
        private readonly string _cs = RepoResource.ConnectionString;
        private MySqlConnection _conn;

        //CONSTRUCTOR
        public DirectoryRepository()
        {
            _conn = new MySqlConnection(_cs);
            _conn.Open();
        }

        internal RootDirectory GetRootDirectory ()
        {
            string sql = "SELECT * FROM rootDirectory WHERE name = 'root'";
            return _conn.QueryFirstOrDefault<RootDirectory>(sql);
        }

        internal int CreateRootDirectory(RootDirectory root)
        {
            string sql = @"
            INSERT INTO rootDirectory (name) VALUES (@Name);
            SELECT LAST_INSERT_ID();";
            return _conn.ExecuteScalar<int>(sql, root);
        }

        internal int Mkdir(Directory data)
        {
            string sql = @"
            INSERT INTO directories
            (name, parentId)
            VALUES
            (@name, @parentId);
            SELECT LAST_INSERT_ID();";
            int id = _conn.ExecuteScalar<int>(sql, data);
            return id;
        }
    }
}
