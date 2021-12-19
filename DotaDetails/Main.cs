using DotaDetails.Model;
using DotaDetails.Presenter;
using DotaDetails.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotaDetails
{
    public partial class Main : Form, IPlayerId, IBuild
    {
        public string AccountID { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string Hero { get { return comboBox1.Text; } set { comboBox1.Text = value; } }
        public string Item { get { return comboBox2.Text; } set { comboBox2.Text = value; } }

        public List<FlowLayoutPanel> builds { get; set; }
        public List<FlowLayoutPanel> itemContainers { get; set; }

        public Main()
        {
            InitializeComponent();
            builds = new List<FlowLayoutPanel>(); 
            itemContainers = new List<FlowLayoutPanel>();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = "Welkom " + Global.Player.Name;
            createNewBuild();
            SortedSet<Hero> heroes = new SortedSet<Hero>(Global.Db.Hero.GetHeroes());
            SortedSet<Item> items = new SortedSet<Item>(Global.Db.Item.GetItems());

            foreach (Hero hero in heroes)
            {
                comboBox1.Items.Add(hero.Name);
            }
            foreach (Item item in items)
            {
                comboBox2.Items.Add(item.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerPresenter presenter = new PlayerPresenter(this);
            presenter.FindGames();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show(String.Format("Kies een held!"), "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox1.Enabled)
            {
                printHeroImage();
                printItemContainer();
            }
            if (String.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show(String.Format("Kies een item!"), "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            printItemImage();



        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            if(comboBox1.Enabled == false)
            {
                createNewBuild();
            }
            comboBox1.Enabled = true;
        } 



        //Hulp functies
        
        private void createNewBuild()
        {
            FlowLayoutPanel pn = new FlowLayoutPanel();
            pn.Anchor = AnchorStyles.Left;
            pn.Size = new Size(353, 85);
            pn.BackColor = Color.LightGray;
            pn.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(pn);
            builds.Add(pn);
        }     
        private void printHeroImage()
        {
            comboBox1.Enabled = false;
            PictureBox img = new PictureBox();
            img.SizeMode = PictureBoxSizeMode.StretchImage;
            img.Size = new Size(125, 70);
            img.Load(Global.Db.Hero.GetUrlFromName(comboBox1.Text));
            builds[^1].Controls.Add(img);
        }

        private void printItemContainer()
        {
            FlowLayoutPanel pn = new FlowLayoutPanel();
            pn.BorderStyle = BorderStyle.FixedSingle;
            pn.Size = new Size(210, 76);
            builds[^1].Controls.Add(pn);
            itemContainers.Add(pn);
        }
        private void printItemImage()
        {
            PictureBox img = new PictureBox();
            img.SizeMode = PictureBoxSizeMode.StretchImage;
            img.Size = new Size(62, 35);
            img.Load(Global.Db.Item.GetUrlFromName(comboBox2.Text));
            Debug.WriteLine("test");
            itemContainers[^1].Controls.Add(img);
        }
    }
}
