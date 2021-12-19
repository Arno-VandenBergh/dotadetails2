using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.DAL
{
    class SqlLiteBaseRepository
    {
        public SqlLiteBaseRepository()
        {
        }

        public static SqliteConnection DbConnectionFactory()
        {
            return new SqliteConnection(@"DataSource=DotaDB.sqlite");
        }
        protected static bool DatabaseExists()
        {
            return File.Exists(@"DotaDB.sqlite");
        }

        protected static void CreateDatabase()
        {
            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                connection.Execute(
                    @"CREATE TABLE Position
                    (
                    Id                                  INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name                                VARCHAR(100) NOT NULL UNIQUE
                    );

                    CREATE TABLE Player
                    (
                    Id                                  VARCHAR(20) PRIMARY KEY NOT NULL,
                    Name                                VARCHAR(100) NOT NULL UNIQUE,
                    Password                            VARCHAR(100) NOT NULL
                    );

                    CREATE TABLE Hero
                    (
                    Id                                  INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name                                VARCHAR(100) NOT NULL UNIQUE,
                    Url                                 VARCHAR(300) NOT NULL UNIQUE
                    );

                    CREATE TABLE Item
                    (
                    Id                                  INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name                                VARCHAR(100) NOT NULL UNIQUE,
                    Url                                 VARCHAR(300) NOT NULL UNIQUE
                    );

                    CREATE TABLE Team
                    (
                    Id		                            INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name	                            VARCHAR(100) NOT NULL UNIQUE
                    );

                    CREATE TABLE Build
                    (
                    Id				                    INTEGER PRIMARY KEY AUTOINCREMENT,
                    PlayerID		                    VARCHAR(20) NOT NULL,
                    HeroID			                    INTEGER NOT NULL,
                    PositionID		                    INTEGER,
                    TeamID			                    INTEGER,
                    StoreDate		                    VARCHAR(100) UNIQUE,			
                    FOREIGN KEY (PlayerID)
	                    REFERENCES Player (Id),
                    FOREIGN KEY (HeroID)
	                    REFERENCES Hero (Id),
                    FOREIGN KEY (PositionID)
	                    REFERENCES Position (Id),
                    FOREIGN KEY (TeamID)
	                    REFERENCES Team (Id)
                    );

                    CREATE TABLE ItemBuild
                    (
                    Id			                        INTEGER PRIMARY KEY AUTOINCREMENT,
                    ItemID		                        INTEGER NOT NULL,
                    BuildID		                        INTEGER NOT NULL,
                    FOREIGN KEY (BuildID)
	                    REFERENCES Build (Id),
                    FOREIGN KEY (ItemID)
	                    REFERENCES Item (Id)
                    );");
            }
        }
    }
}
