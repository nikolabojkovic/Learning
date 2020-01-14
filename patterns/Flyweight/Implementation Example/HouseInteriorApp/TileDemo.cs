using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DomainModel;

namespace HouseInteriorApp
{
    public partial class TileDemo : Form
    {
        Random random =  new Random();

        public TileDemo()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {            
            base.OnPaint(e);

            for (int i = 0; i < 20; i++)
            {
                ITile ceramicTile = TileFactory.GetTile("Ceramic");
                ceramicTile.Draw(e.Graphics, GetRandomNumber(), 
                    GetRandomNumber(), GetRandomNumber(), GetRandomNumber());
            }

            for (int i = 0; i < 20; i++)
            {
                ITile stoneTile = TileFactory.GetTile("Stone");
                stoneTile.Draw(e.Graphics, GetRandomNumber(), 
                    GetRandomNumber(), GetRandomNumber(), GetRandomNumber());
            }

            this.toolStripStatusLabel1.Text = "Total Objects Created : " + 
                Convert.ToString(CeramicTile.ObjectCounter 
                + StoneTile.ObjectCounter);
        }

        private int GetRandomNumber()
        {
            return (int)(random.Next(100));
        }       
    }
}