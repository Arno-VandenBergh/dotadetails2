using Dapper;
using DotaDetails.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.DAL
{
    class ItemRepository : SqlLiteBaseRepository
    {

        public int InsertItem(Item item)
        {
            string sql = "INSERT INTO Item (Name, Url) Values (@Name, @Url);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, item);
            }
        }

        public IEnumerable<Item> GetItems()
        {
            string sql = "SELECT * FROM Item;";

            using (var connection = DbConnectionFactory())
            {
                return connection.Query<Item>(sql);
            }
        }

        public void FillSampleItems(string directory)
        {
            string[] filePaths = Directory.GetFiles(directory);

            for (int i = 0; i < filePaths.Length; i++)
            {
                if (filePaths[i].Contains("Inactive"))
                {
                    continue;
                }
                filePaths[i] = filePaths[i].Substring(50, filePaths[i].IndexOf(".png") - 50);
                Item item = new Item(filePaths[i], "Items/" + filePaths[i] + ".png");
                filePaths[i] = filePaths[i].Replace("_", " ");
                filePaths[i] = filePaths[i].Replace("%27", "'");
                filePaths[i] = filePaths[i].Replace("%28", "(");
                filePaths[i] = filePaths[i].Replace("%29", ")");
                item.Name = filePaths[i];
                InsertItem(item);
            }
        }

        public string GetUrlFromName(string name)
        {
            string sql = string.Format("SELECT Url FROM Item Where Name = \"{0}\";", name);

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.QueryFirst<string>(sql);
            }
        }
    }
}
