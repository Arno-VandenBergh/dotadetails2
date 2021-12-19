using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.DAL
{
    class TeamRepository : SqlLiteBaseRepository
    {

        public int InsertTeam(string team)
        {
            string sql = string.Format("INSERT INTO Team (Name) Values ('{0}');", team);

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql);
            }
        }

        public void FillSampleTeams()
        {
            InsertTeam("Radiant");
            InsertTeam("Dire");
        }
    }
}
