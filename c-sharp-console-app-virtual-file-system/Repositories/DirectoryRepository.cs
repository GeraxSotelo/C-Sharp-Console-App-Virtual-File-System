using c_sharp_console_app_virtual_file_system.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Resources;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Repositories
{
    class DirectoryRepository
    {
        private readonly string _cs = RepoResource.ConnectionString;
        private MySqlConnection _conn { get; }

        //CONSTRUCTOR
        public DirectoryRepository()
        {
            _conn = new MySqlConnection(_cs);
            _conn.Open();
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
