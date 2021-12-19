using DotaDetails.Model;
using DotaDetails.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.Presenter
{
    class BuildPresenter
    {
        IBuild Build;

        public BuildPresenter(IBuild build)
        {
            Build = build;
        }

        internal void FillComboboxes()
        {
            SortedSet<Hero> heroes =  new SortedSet<Hero>(Global.Db.Hero.GetHeroes());
            SortedSet<Item> items = new SortedSet<Item>(Global.Db.Item.GetItems());

            foreach (Hero hero in heroes)
            {

            }
        }
    }
}
