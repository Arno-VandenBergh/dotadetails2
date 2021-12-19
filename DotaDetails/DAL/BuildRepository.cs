using Dapper;
using DotaDetails.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.DAL
{
    class BuildRepository : SqlLiteBaseRepository
    {

        public int InsertBuild(Build build)
        {
            string sql = string.Format(@"INSERT INTO Build (PlayerID, HeroID, PositionID, StoreDate) Values (
                (SELECT Id FROM Player      WHERE Id    = {0}),
                (SELECT Id FROM Hero        Where Name  = '{1}'),
                (SELECT Id FROM Position    Where Name  = '{2}'),
                '{3}'
            );",build.Player.Id,build.Hero.Name,build.Position,build.Date.ToString("G", new CultureInfo("fr-FR")));
            foreach (Item item in build.Items)
            {
                sql += string.Format(@"INSERT INTO ItemBuild (ItemID, BuildID) Values (
                    (SELECT Id FROM Item        Where Name = '{0}'),
                    (SELECT Id FROM Build       Where StoreDate = '{1}')
                );",item.Name,build.Date.ToString("G", new CultureInfo("fr-FR")));
            }

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql);
            }
        }
    }
}
