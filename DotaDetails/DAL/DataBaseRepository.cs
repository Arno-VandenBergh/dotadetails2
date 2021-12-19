using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.DAL
{
    class DataBaseRepository : SqlLiteBaseRepository
    {
        public BuildRepository Build { get; set; }
        public HeroRepository Hero { get; set; }
        public ItemRepository Item { get; set; }
        public PositionRepository Position { get; set; }
        public TeamRepository Team { get; set; }
        public PlayerRepository Player { get; set; }

        public DataBaseRepository()
        {
            Build = new BuildRepository();
            Hero = new HeroRepository();
            Item = new ItemRepository();
            Position = new PositionRepository();
            Team = new TeamRepository();
            Player = new PlayerRepository();
            if (!DatabaseExists())
            {
                CreateDatabase();
                Team.FillSampleTeams();
                Hero.FillSampleHeroes(@"C:\Thomas More\2APPAI\DevOps\Python Scraper\heroes");
                Item.FillSampleItems(@"C:\Thomas More\2APPAI\DevOps\Python Scraper\items");
                Position.FillSamplePositions();
            }
            
        }
    }
}
