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
    class HeroRepository : SqlLiteBaseRepository
    {

        public int InsertHero(Hero hero)
        {
            string sql = "INSERT INTO Hero (Name, Url) Values (@Name, @Url);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, hero);
            }
        }

        public void FillSampleHeroes(string directory)
        {
            string[] filePaths = Directory.GetFiles(directory);

            for (int i = 0; i < filePaths.Length; i++)
            {
                filePaths[i] = filePaths[i].Substring(51, filePaths[i].IndexOf(".png") - 51);
                Hero hero = new Hero(filePaths[i], "Heroes/" + filePaths[i] + ".png");
                filePaths[i] = filePaths[i].Replace("_", " ");
                filePaths[i] = filePaths[i].Replace("%27", "'");
                filePaths[i] = filePaths[i].Replace("%28", "(");
                filePaths[i] = filePaths[i].Replace("%29", ")");
                hero.Name = filePaths[i];
                InsertHero(hero);
            }
        }

        public IEnumerable<Hero> GetHeroes()
        {
            string sql = "SELECT * FROM Hero;";

            using (var connection = DbConnectionFactory())
            {
                return connection.Query<Hero>(sql);
            }
        }

        public string GetUrlFromName(string name)
        {
            string sql = string.Format("SELECT Url FROM Hero Where Name = \"{0}\";",name);

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.QueryFirst<string>(sql);
            }
        }
    }
}
