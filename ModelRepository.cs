using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace AIDemo
{
    // 对应表结构
    public class Model
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }

    public class ModelRepository : IDisposable
    {
        private readonly SQLiteConnection _connection;

        public ModelRepository(string dbPath)
        {
            _connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            _connection.Open();

            // 确保表存在
            string sql = @"
CREATE TABLE IF NOT EXISTS ""model"" (
    ""Id"" INTEGER PRIMARY KEY AUTOINCREMENT,
    ""Title"" TEXT,
    ""Url"" TEXT,
    ""Icon"" TEXT
);";
            using var cmd = new SQLiteCommand(sql, _connection);
            cmd.ExecuteNonQuery();
        }

        // 新增
        public int Add(Model model)
        {
            string sql = "INSERT INTO model (Title, Url, Icon) VALUES (@title, @url, @icon); SELECT last_insert_rowid();";
            using var cmd = new SQLiteCommand(sql, _connection);
            cmd.Parameters.AddWithValue("@title", model.Title);
            cmd.Parameters.AddWithValue("@url", model.Url);
            cmd.Parameters.AddWithValue("@icon", model.Icon ?? "");
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // 更新
        public bool Update(Model model)
        {
            string sql = "UPDATE model SET Title=@title, Url=@url, Icon=@icon WHERE Id=@id";
            using var cmd = new SQLiteCommand(sql, _connection);
            cmd.Parameters.AddWithValue("@title", model.Title);
            cmd.Parameters.AddWithValue("@url", model.Url);
            cmd.Parameters.AddWithValue("@icon", model.Icon ?? "");
            cmd.Parameters.AddWithValue("@id", model.Id);
            return cmd.ExecuteNonQuery() > 0;
        }

        // 删除
        public bool Delete(int id)
        {
            string sql = "DELETE FROM model WHERE Id=@id";
            using var cmd = new SQLiteCommand(sql, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        // 查询所有
        public List<Model> GetAll()
        {
            string sql = "SELECT Id, Title, Url, Icon FROM model";
            using var cmd = new SQLiteCommand(sql, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();

            var list = new List<Model>();
            while (reader.Read())
            {
                list.Add(new Model
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Title = reader["Title"].ToString(),
                    Url = reader["Url"].ToString(),
                    Icon = reader["Icon"].ToString()
                });
            }
            return list;
        }

        // 根据 Id 查询
        public Model GetById(int id)
        {
            string sql = "SELECT Id, Title, Url, Icon FROM model WHERE Id=@id";
            using var cmd = new SQLiteCommand(sql, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Model
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Title = reader["Title"].ToString(),
                    Url = reader["Url"].ToString(),
                    Icon = reader["Icon"].ToString()
                };
            }
            return null;
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}