using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Korrektur_Programm
{
    public partial class Breite_und_Druck : Form
    {
        private bool Zustand = true;
        private int Schriftgröße;
        private Dictionary<TextBox, TextBox> Paar_Verknüpfung = new Dictionary<TextBox, TextBox>();
        private List<TextBox> Werte = new List<TextBox> { };
        public Breite_und_Druck(int Schrift)
        {
            Schriftgröße = Schrift;
            InitializeComponent();
            Paaren();
            Werte_Erstellen();
            Werte_Nullen();
            Breite_Erfüllen();
            Information(Schriftgröße);
            this.Select();

        }

        private void Information(int Schriftgr)
        {
            if (Schriftgr == 1) { Infos.Text = "LSchrift 1"; }
            if (Schriftgr == 2) { Infos.Text = "LSchrift 2"; }
            if (Schriftgr == 3) { Infos.Text = "LSchrift 3"; }
            if (Schriftgr == 4) { Infos.Text = "QSchrift 1"; }
            if (Schriftgr == 5) { Infos.Text = "QSchrift 2"; }
            if (Schriftgr == 6) { Infos.Text = "QSchrift 3"; }
        }

        private void Werte_Nullen()
        {
            foreach(TextBox t in Werte)
            {
                t.Text = "0";
                t.Tag = "0";
            }
        }

        private void Breite_Erfüllen()
        {
            string connStr = "server=localhost;user=root;database=movedb;port=3306;password=6540";
            MySqlConnection conn = new(connStr);
            try
            {
                foreach (TextBox t in Werte)
                {
                    conn.Open();
                    string c = Paar_Verknüpfung[t].Text;
                    if (string.IsNullOrEmpty(c)) { t.Text = "0";  t.Tag = "0";  continue; }    
                    if (c == "\\") { c = "\\\\"; }
                    else if( c == "\'") { c = "\\\'"; }
                    string sql = "select Breite from Tabelle" + Schriftgröße + " where Zeichen = '" + c + "' COLLATE utf8mb4_bin;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        t.Text = rdr[0].ToString();
                        t.Tag = t.Text;
                    }
                    conn.Close();
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Select();

        }

        private void Druck_Erfüllen()
        {
            string connStr = "server=localhost;user=root;database=movedb;port=3306;password=6540";
            MySqlConnection conn = new(connStr);
            try
            {
                foreach (TextBox t in Werte)
                {
                    conn.Open();
                    string c = Paar_Verknüpfung[t].Text;
                    if (string.IsNullOrEmpty(c)) { t.Text = "0"; t.Tag = "0"; continue; }
                    if (c == "\\") { c = "\\\\"; }
                    else if (c == "\'") { c = "\\\'"; }
                    string sql = "select Druck from Tabelle" + Schriftgröße + " where Zeichen = '" + c + "' COLLATE utf8mb4_bin;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        t.Text = rdr[0].ToString();
                        t.Tag = t.Text;
                    }
                    conn.Close();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Werte_Erstellen()
        {
            Werte.Add(textBox1);
            Werte.Add(textBox3);
            Werte.Add(textBox5);
            Werte.Add(textBox7);
            Werte.Add(textBox9);
            Werte.Add(textBox11);
            Werte.Add(textBox13);
            Werte.Add(textBox15);
            Werte.Add(textBox17);
            Werte.Add(textBox19);
            Werte.Add(textBox21);
            Werte.Add(textBox23);
            Werte.Add(textBox25);
            Werte.Add(textBox27);
            Werte.Add(textBox29);
            Werte.Add(textBox31);
            Werte.Add(textBox33);
            Werte.Add(textBox35);
            Werte.Add(textBox37);
            Werte.Add(textBox39);
            Werte.Add(textBox41);
            Werte.Add(textBox43);
            Werte.Add(textBox45);
            Werte.Add(textBox47);
            Werte.Add(textBox49);
            Werte.Add(textBox51);
            Werte.Add(textBox53);
            Werte.Add(textBox55);
            Werte.Add(textBox57);
            Werte.Add(textBox59);
            Werte.Add(textBox61);
            Werte.Add(textBox63);
            Werte.Add(textBox65);
            Werte.Add(textBox67);
            Werte.Add(textBox69);
            Werte.Add(textBox71);
            Werte.Add(textBox73);
            Werte.Add(textBox75);
            Werte.Add(textBox77);
            Werte.Add(textBox79);
            Werte.Add(textBox81);
            Werte.Add(textBox83);
            Werte.Add(textBox85);
            Werte.Add(textBox87);
            Werte.Add(textBox89);
            Werte.Add(textBox91);
            Werte.Add(textBox93);
            Werte.Add(textBox95);
            Werte.Add(textBox97);
            Werte.Add(textBox99);
            Werte.Add(textBox101);
            Werte.Add(textBox103);
            Werte.Add(textBox105);
            Werte.Add(textBox107);
            Werte.Add(textBox109);
            Werte.Add(textBox111);
            Werte.Add(textBox113);
            Werte.Add(textBox115);
            Werte.Add(textBox117);
            Werte.Add(textBox119);
            Werte.Add(textBox121);
            Werte.Add(textBox123);
            Werte.Add(textBox125);
            Werte.Add(textBox127);
            Werte.Add(textBox129);
            Werte.Add(textBox131);
            Werte.Add(textBox133);
            Werte.Add(textBox135);
            Werte.Add(textBox137);
            Werte.Add(textBox139);
            Werte.Add(textBox141);
            Werte.Add(textBox143);
            Werte.Add(textBox145);
            Werte.Add(textBox147);
            Werte.Add(textBox149);
            Werte.Add(textBox151);
            Werte.Add(textBox153);
            Werte.Add(textBox155);
            Werte.Add(textBox157);
            Werte.Add(textBox159);
            Werte.Add(textBox161);
            Werte.Add(textBox163);
            Werte.Add(textBox165);
            Werte.Add(textBox167);
            Werte.Add(textBox169);
            Werte.Add(textBox171);
            Werte.Add(textBox173);
            Werte.Add(textBox175);
            Werte.Add(textBox177);
            Werte.Add(textBox179);
            Werte.Add(textBox181);
            Werte.Add(textBox183);
            Werte.Add(textBox185);
            Werte.Add(textBox187);
            Werte.Add(textBox189);
            Werte.Add(textBox191);
        }

        private void Paaren()
        {
            Paar_Verknüpfung.Add(textBox1, textBox2);
            Paar_Verknüpfung.Add(textBox3, textBox4);
            Paar_Verknüpfung.Add(textBox5, textBox6);
            Paar_Verknüpfung.Add(textBox7, textBox8);
            Paar_Verknüpfung.Add(textBox9, textBox10);
            Paar_Verknüpfung.Add(textBox11, textBox12);
            Paar_Verknüpfung.Add(textBox13, textBox14);
            Paar_Verknüpfung.Add(textBox15, textBox16);
            Paar_Verknüpfung.Add(textBox17, textBox18);
            Paar_Verknüpfung.Add(textBox19, textBox20);
            Paar_Verknüpfung.Add(textBox21, textBox22);
            Paar_Verknüpfung.Add(textBox23, textBox24);
            Paar_Verknüpfung.Add(textBox25, textBox26);
            Paar_Verknüpfung.Add(textBox27, textBox28);
            Paar_Verknüpfung.Add(textBox29, textBox30);
            Paar_Verknüpfung.Add(textBox31, textBox32);
            Paar_Verknüpfung.Add(textBox33, textBox34);
            Paar_Verknüpfung.Add(textBox35, textBox36);
            Paar_Verknüpfung.Add(textBox37, textBox38);
            Paar_Verknüpfung.Add(textBox39, textBox40);
            Paar_Verknüpfung.Add(textBox41, textBox42);
            Paar_Verknüpfung.Add(textBox43, textBox44);
            Paar_Verknüpfung.Add(textBox45, textBox46);
            Paar_Verknüpfung.Add(textBox47, textBox48);
            Paar_Verknüpfung.Add(textBox49, textBox50);
            Paar_Verknüpfung.Add(textBox51, textBox52);
            Paar_Verknüpfung.Add(textBox53, textBox54);
            Paar_Verknüpfung.Add(textBox55, textBox56);
            Paar_Verknüpfung.Add(textBox57, textBox58);
            Paar_Verknüpfung.Add(textBox59, textBox60);
            Paar_Verknüpfung.Add(textBox61, textBox62);
            Paar_Verknüpfung.Add(textBox63, textBox64);
            Paar_Verknüpfung.Add(textBox65, textBox66);
            Paar_Verknüpfung.Add(textBox67, textBox68);
            Paar_Verknüpfung.Add(textBox69, textBox70);
            Paar_Verknüpfung.Add(textBox71, textBox72);
            Paar_Verknüpfung.Add(textBox73, textBox74);
            Paar_Verknüpfung.Add(textBox75, textBox76);
            Paar_Verknüpfung.Add(textBox77, textBox78);
            Paar_Verknüpfung.Add(textBox79, textBox80);
            Paar_Verknüpfung.Add(textBox81, textBox82);
            Paar_Verknüpfung.Add(textBox83, textBox84);
            Paar_Verknüpfung.Add(textBox85, textBox86);
            Paar_Verknüpfung.Add(textBox87, textBox88);
            Paar_Verknüpfung.Add(textBox89, textBox90);
            Paar_Verknüpfung.Add(textBox91, textBox92);
            Paar_Verknüpfung.Add(textBox93, textBox94);
            Paar_Verknüpfung.Add(textBox95, textBox96);
            Paar_Verknüpfung.Add(textBox97, textBox98);
            Paar_Verknüpfung.Add(textBox99, textBox100);
            Paar_Verknüpfung.Add(textBox101, textBox102);
            Paar_Verknüpfung.Add(textBox103, textBox104);
            Paar_Verknüpfung.Add(textBox105, textBox106);
            Paar_Verknüpfung.Add(textBox107, textBox108);
            Paar_Verknüpfung.Add(textBox109, textBox110);
            Paar_Verknüpfung.Add(textBox111, textBox112);
            Paar_Verknüpfung.Add(textBox113, textBox114);
            Paar_Verknüpfung.Add(textBox115, textBox116);
            Paar_Verknüpfung.Add(textBox117, textBox118);
            Paar_Verknüpfung.Add(textBox119, textBox120);
            Paar_Verknüpfung.Add(textBox121, textBox122);
            Paar_Verknüpfung.Add(textBox123, textBox124);
            Paar_Verknüpfung.Add(textBox125, textBox126);
            Paar_Verknüpfung.Add(textBox127, textBox128);
            Paar_Verknüpfung.Add(textBox129, textBox130);
            Paar_Verknüpfung.Add(textBox131, textBox132);
            Paar_Verknüpfung.Add(textBox133, textBox134);
            Paar_Verknüpfung.Add(textBox135, textBox136);
            Paar_Verknüpfung.Add(textBox137, textBox138);
            Paar_Verknüpfung.Add(textBox139, textBox140);
            Paar_Verknüpfung.Add(textBox141, textBox142);
            Paar_Verknüpfung.Add(textBox143, textBox144);
            Paar_Verknüpfung.Add(textBox145, textBox146);
            Paar_Verknüpfung.Add(textBox147, textBox148);
            Paar_Verknüpfung.Add(textBox149, textBox150);
            Paar_Verknüpfung.Add(textBox151, textBox152);
            Paar_Verknüpfung.Add(textBox153, textBox154);
            Paar_Verknüpfung.Add(textBox155, textBox156);
            Paar_Verknüpfung.Add(textBox157, textBox158);
            Paar_Verknüpfung.Add(textBox159, textBox160);
            Paar_Verknüpfung.Add(textBox161, textBox162);
            Paar_Verknüpfung.Add(textBox163, textBox164);
            Paar_Verknüpfung.Add(textBox165, textBox166);
            Paar_Verknüpfung.Add(textBox167, textBox168);
            Paar_Verknüpfung.Add(textBox169, textBox170);
            Paar_Verknüpfung.Add(textBox171, textBox172);
            Paar_Verknüpfung.Add(textBox173, textBox174);
            Paar_Verknüpfung.Add(textBox175, textBox176);
            Paar_Verknüpfung.Add(textBox177, textBox178);
            Paar_Verknüpfung.Add(textBox179, textBox180);
            Paar_Verknüpfung.Add(textBox181, textBox182);
            Paar_Verknüpfung.Add(textBox183, textBox184);
            Paar_Verknüpfung.Add(textBox185, textBox186);
            Paar_Verknüpfung.Add(textBox187, textBox188);
            Paar_Verknüpfung.Add(textBox189, textBox190);
            Paar_Verknüpfung.Add(textBox191, textBox192);
        }

        private void BreitenUndDruckstärke_Click(object sender, EventArgs e)
        {
            if (Zustand)
            {
                BreitenUndDruckstärke.Text = "Typenmaße";
                this.Text = "Druckwerte";
                Zustand = false;
                Druck_Erfüllen();
            }
            else
            {
                BreitenUndDruckstärke.Text = "Druckwerte";
                this.Text = "Typenmaße";

                Zustand = true;
                Breite_Erfüllen();
            }
        }

        private void Beenden_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Check_Änderungen()
        {
            foreach(TextBox t in Werte)
            {
                if (t.Text != t.Tag.ToString())
                {
                    string Wert = Zustand ? "Breite" : "Druck";
                    string connStr = "server=localhost;user=root;database=movedb;port=3306;password=6540";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    try
                    {
                        conn.Open();
                        string c = Paar_Verknüpfung[t].Text;
                        if (c == "\\") { c = "\\\\"; }
                        else if (c == "\'") { c = "\\\'"; }
                        string sql = "update tabelle" + Schriftgröße + " set " + Wert + " = " + t.Text + " where Zeichen = '" + c + "' COLLATE utf8mb4_bin;";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Check_Änderungen();
            MessageBox.Show("fertig!");
        }
    }
}
