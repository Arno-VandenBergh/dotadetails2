using Dapper;
using DotaDetails.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotaDetails.DAL
{
    class PlayerRepository : SqlLiteBaseRepository
    {
        public int InsertPlayer(Player player)
        {
            string sql = "INSERT INTO Player (Id, Name, Password) Values (@Id, @Name, @Password);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                int response = 0;
                try { 
                    response = connection.Execute(sql, player);
                }
                catch (SqliteException er)
                {
                    MessageBox.Show("Er bestaat al een account met dit Id.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
                return response;
            }
        }

        public Player GetPlayer(Player player)
        {
            string sql = "SELECT * FROM Player WHERE Name = @Name AND Password = @Password;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                
                try { 
                    
                    return connection.QueryFirst<Player>(sql, player);
                }
                catch (InvalidOperationException err)
                {
                    Debug.WriteLine("{0}, {1}, {2}", player.Id, player.Name, player.Password);
                    MessageBox.Show("Gebruikersnaam of wachtwoord is niet correct.", "Onvolledig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new Player();
                }
            }
        }
    }
}
