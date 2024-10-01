using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.IO.Ports;
using System.Threading;




namespace Korrektur_Programm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Beenden_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BreiteUndDruck_Click(object sender, EventArgs e)
        {
            if(Schriften.SelectedIndex == -1)
            {
                MessageBox.Show("Keine Schrift ausgewählt!");
                return;
            }
            Druck_Position Breite_Und_Druck = new(Schriften.SelectedIndex + 1);
            Breite_Und_Druck.ShowDialog();
        }

        private void DruckPos_Click(object sender, EventArgs e)
        {
            if (Schriften.SelectedIndex == -1)
            {
                MessageBox.Show("Keine Schrift ausgewählt!");
                return;
            }
            Breite_und_Druck Druck_Position = new(Schriften.SelectedIndex + 1);
            Druck_Position.ShowDialog();
            
        }
    }
}