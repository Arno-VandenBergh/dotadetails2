using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.DAL
{
    class PositionRepository : SqlLiteBaseRepository
    {

        public int InsertPosition(string position)
        {
            string sql = string.Format("INSERT INTO Position (Name) Values ('{0}');",position);

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql);
            }
        }

        public void FillSamplePositions()
        {
            InsertPosition("Midlane");
            InsertPosition("Safelane");
            InsertPosition("Offlane");
            InsertPosition("Support");
            InsertPosition("Hard Support");
        }


    }
}
