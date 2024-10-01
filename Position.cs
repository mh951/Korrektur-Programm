using System;
using System.Collections.Generic;
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
    public partial class Druck_Position : Form
    {
        private Dictionary<TextBox, TextBox> X_Dict = new Dictionary<TextBox, TextBox>();
        private Dictionary<TextBox, TextBox> Y_Dict = new Dictionary<TextBox, TextBox>();
        private Dictionary<TextBox, TextBox> H_Dict = new Dictionary<TextBox, TextBox>();
        private List<TextBox> X_Werte = new List<TextBox> { };
        private List<TextBox> Y_Werte = new List<TextBox> { };
        private List<TextBox> H_Werte = new List<TextBox> { };
        private List<TextBox> Zeichen = new List<TextBox> { };
        private int Schriftgröße;
        private TextBox X_neu, H_neu;


        public Druck_Position(int schriftgröße)
        {
            InitializeComponent();
            Schriftgröße = schriftgröße;
            Zeichen_Ertellen();
            X_Werte_Erstellen();
            Y_Werte_Erstellen();
            H_Werte_Erstellen();
            X_Verknüpfen();
            Y_Verknüpfen();
            H_Verknüpfen();
            Druck_Erfüllen();
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

        private void Druck_Erfüllen()
        {
            string connStr = "server=localhost;user=root;database=movedb;port=3306;password=6540";
            MySqlConnection conn = new(connStr);
            try
            {
                foreach(TextBox t in X_Werte)
                {
                    conn.Open();
                    string c = X_Dict[t].Text;
                    if (string.IsNullOrEmpty(c)) { t.Text = "0"; t.Tag = "0"; continue; }
                    if (c == "\\") { c = "\\\\"; }
                    else if (c == "\'") { c = "\\\'"; }
                    string sql = "select XPos from Tabelle" + Schriftgröße + 
                        " where Zeichen = '" + c + "' COLLATE utf8mb4_bin;";
                    MySqlCommand cmd = new (sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        t.Text = rdr[0].ToString();
                        t.Tag = t.Text;
                    }
                    conn.Close();
                }
                foreach (TextBox t in Y_Werte)
                {
                    conn.Open();
                    string c = Y_Dict[t].Text;
                    if (string.IsNullOrEmpty(c)) { t.Text = "0"; t.Tag = "0"; continue; }
                    if (c == "\\") { c = "\\\\"; }
                    else if (c == "\'") { c = "\\\'"; }
                    string sql = "select YPos from Tabelle" + Schriftgröße + " where Zeichen = '" + c + "' COLLATE utf8mb4_bin;";
                    MySqlCommand cmd = new (sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        t.Text = rdr[0].ToString();
                        t.Tag = t.Text;
                    }
                    conn.Close();
                }
                foreach (TextBox t in H_Werte)
                {
                    conn.Open();
                    string c = H_Dict[t].Text;
                    if (string.IsNullOrEmpty(c)) { t.Text = "0"; t.Tag = "0"; continue; }
                    if (c == "\\") { c = "\\\\"; }
                    else if (c == "\'") { c = "\\\'"; }
                    string sql = "select TischPos from Tabelle" + Schriftgröße + " where Zeichen = '" + c + "' COLLATE utf8mb4_bin;";
                    MySqlCommand cmd = new(sql, conn);
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
        private void X_Verknüpfen()
        {
            X_Dict.Add(textBox3, textBox4);
            X_Dict.Add(textBox7, textBox8);
            X_Dict.Add(textBox11, textBox12);
            X_Dict.Add(textBox15, textBox16);
            X_Dict.Add(textBox19, textBox20);
            X_Dict.Add(textBox23, textBox24);
            X_Dict.Add(textBox27, textBox28);
            X_Dict.Add(textBox31, textBox32);
            X_Dict.Add(textBox35, textBox36);
            X_Dict.Add(textBox39, textBox40);
            X_Dict.Add(textBox43, textBox44);
            X_Dict.Add(textBox47, textBox48);
            X_Dict.Add(textBox51, textBox52);
            X_Dict.Add(textBox55, textBox56);
            X_Dict.Add(textBox59, textBox60);
            X_Dict.Add(textBox63, textBox64);
            X_Dict.Add(textBox67, textBox68);
            X_Dict.Add(textBox71, textBox72);
            X_Dict.Add(textBox75, textBox76);
            X_Dict.Add(textBox79, textBox80);
            X_Dict.Add(textBox83, textBox84);
            X_Dict.Add(textBox87, textBox88);
            X_Dict.Add(textBox91, textBox92);
            X_Dict.Add(textBox95, textBox96);
            X_Dict.Add(textBox99, textBox100);
            X_Dict.Add(textBox103, textBox104);
            X_Dict.Add(textBox107, textBox108);
            X_Dict.Add(textBox111, textBox112);
            X_Dict.Add(textBox115, textBox116);
            X_Dict.Add(textBox119, textBox120);
            X_Dict.Add(textBox123, textBox124);
            X_Dict.Add(textBox127, textBox128);
            X_Dict.Add(textBox131, textBox132);
            X_Dict.Add(textBox135, textBox136);
            X_Dict.Add(textBox139, textBox140);
            X_Dict.Add(textBox143, textBox144);
            X_Dict.Add(textBox147, textBox148);
            X_Dict.Add(textBox151, textBox152);
            X_Dict.Add(textBox155, textBox156);
            X_Dict.Add(textBox159, textBox160);
            X_Dict.Add(textBox163, textBox164);
            X_Dict.Add(textBox167, textBox168);
            X_Dict.Add(textBox171, textBox172);
            X_Dict.Add(textBox175, textBox176);
            X_Dict.Add(textBox179, textBox180);
            X_Dict.Add(textBox183, textBox184);
            X_Dict.Add(textBox187, textBox188);
            X_Dict.Add(textBox191, textBox192);
            X_Dict.Add(textBox195, textBox196);
            X_Dict.Add(textBox199, textBox200);
            X_Dict.Add(textBox203, textBox204);
            X_Dict.Add(textBox207, textBox208);
            X_Dict.Add(textBox211, textBox212);
            X_Dict.Add(textBox215, textBox216);
            X_Dict.Add(textBox219, textBox220);
            X_Dict.Add(textBox223, textBox224);
            X_Dict.Add(textBox227, textBox228);
            X_Dict.Add(textBox231, textBox232);
            X_Dict.Add(textBox235, textBox236);
            X_Dict.Add(textBox239, textBox240);
            X_Dict.Add(textBox243, textBox244);
            X_Dict.Add(textBox247, textBox248);
            X_Dict.Add(textBox251, textBox252);
            X_Dict.Add(textBox255, textBox256);
            X_Dict.Add(textBox259, textBox260);
            X_Dict.Add(textBox263, textBox264);
            X_Dict.Add(textBox267, textBox268);
            X_Dict.Add(textBox271, textBox272);
            X_Dict.Add(textBox275, textBox276);
            X_Dict.Add(textBox279, textBox280);
            X_Dict.Add(textBox283, textBox284);
            X_Dict.Add(textBox287, textBox288);
            X_Dict.Add(textBox291, textBox292);
            X_Dict.Add(textBox295, textBox296);
            X_Dict.Add(textBox299, textBox300);
            X_Dict.Add(textBox303, textBox304);
            X_Dict.Add(textBox307, textBox308);
            X_Dict.Add(textBox311, textBox312);
        }
        private void Y_Verknüpfen()
        {
            Y_Dict.Add(textBox2, textBox4);
            Y_Dict.Add(textBox6, textBox8);
            Y_Dict.Add(textBox10, textBox12);
            Y_Dict.Add(textBox14, textBox16);
            Y_Dict.Add(textBox18, textBox20);
            Y_Dict.Add(textBox22, textBox24);
            Y_Dict.Add(textBox26, textBox28);
            Y_Dict.Add(textBox30, textBox32);
            Y_Dict.Add(textBox34, textBox36);
            Y_Dict.Add(textBox38, textBox40);
            Y_Dict.Add(textBox42, textBox44);
            Y_Dict.Add(textBox46, textBox48);
            Y_Dict.Add(textBox50, textBox52);
            Y_Dict.Add(textBox54, textBox56);
            Y_Dict.Add(textBox58, textBox60);
            Y_Dict.Add(textBox62, textBox64);
            Y_Dict.Add(textBox66, textBox68);
            Y_Dict.Add(textBox70, textBox72);
            Y_Dict.Add(textBox74, textBox76);
            Y_Dict.Add(textBox78, textBox80);
            Y_Dict.Add(textBox82, textBox84);
            Y_Dict.Add(textBox86, textBox88);
            Y_Dict.Add(textBox90, textBox92);
            Y_Dict.Add(textBox94, textBox96);
            Y_Dict.Add(textBox98, textBox100);
            Y_Dict.Add(textBox102, textBox104);
            Y_Dict.Add(textBox106, textBox108);
            Y_Dict.Add(textBox110, textBox112);
            Y_Dict.Add(textBox114, textBox116);
            Y_Dict.Add(textBox118, textBox120);
            Y_Dict.Add(textBox122, textBox124);
            Y_Dict.Add(textBox126, textBox128);
            Y_Dict.Add(textBox130, textBox132);
            Y_Dict.Add(textBox134, textBox136);
            Y_Dict.Add(textBox138, textBox140);
            Y_Dict.Add(textBox142, textBox144);
            Y_Dict.Add(textBox146, textBox148);
            Y_Dict.Add(textBox150, textBox152);
            Y_Dict.Add(textBox154, textBox156);
            Y_Dict.Add(textBox158, textBox160);
            Y_Dict.Add(textBox162, textBox164);
            Y_Dict.Add(textBox166, textBox168);
            Y_Dict.Add(textBox170, textBox172);
            Y_Dict.Add(textBox174, textBox176);
            Y_Dict.Add(textBox178, textBox180);
            Y_Dict.Add(textBox182, textBox184);
            Y_Dict.Add(textBox186, textBox188);
            Y_Dict.Add(textBox190, textBox192);
            Y_Dict.Add(textBox194, textBox196);
            Y_Dict.Add(textBox198, textBox200);
            Y_Dict.Add(textBox202, textBox204);
            Y_Dict.Add(textBox206, textBox208);
            Y_Dict.Add(textBox210, textBox212);
            Y_Dict.Add(textBox214, textBox216);
            Y_Dict.Add(textBox218, textBox220);
            Y_Dict.Add(textBox222, textBox224);
            Y_Dict.Add(textBox226, textBox228);
            Y_Dict.Add(textBox230, textBox232);
            Y_Dict.Add(textBox234, textBox236);
            Y_Dict.Add(textBox238, textBox240);
            Y_Dict.Add(textBox242, textBox244);
            Y_Dict.Add(textBox246, textBox248);
            Y_Dict.Add(textBox250, textBox252);
            Y_Dict.Add(textBox254, textBox256);
            Y_Dict.Add(textBox258, textBox260);
            Y_Dict.Add(textBox262, textBox264);
            Y_Dict.Add(textBox266, textBox268);
            Y_Dict.Add(textBox270, textBox272);
            Y_Dict.Add(textBox274, textBox276);
            Y_Dict.Add(textBox278, textBox280);
            Y_Dict.Add(textBox282, textBox284);
            Y_Dict.Add(textBox286, textBox288);
            Y_Dict.Add(textBox290, textBox292);
            Y_Dict.Add(textBox294, textBox296);
            Y_Dict.Add(textBox298, textBox300);
            Y_Dict.Add(textBox302, textBox304);
            Y_Dict.Add(textBox306, textBox308);
            Y_Dict.Add(textBox310, textBox312);
        }
        private void H_Verknüpfen()
        {
            H_Dict.Add(textBox1, textBox4);
            H_Dict.Add(textBox5, textBox8);
            H_Dict.Add(textBox9, textBox12);
            H_Dict.Add(textBox13, textBox16);
            H_Dict.Add(textBox17, textBox20);
            H_Dict.Add(textBox21, textBox24);
            H_Dict.Add(textBox25, textBox28);
            H_Dict.Add(textBox29, textBox32);
            H_Dict.Add(textBox33, textBox36);
            H_Dict.Add(textBox37, textBox40);
            H_Dict.Add(textBox41, textBox44);
            H_Dict.Add(textBox45, textBox48);
            H_Dict.Add(textBox49, textBox52);
            H_Dict.Add(textBox53, textBox56);
            H_Dict.Add(textBox57, textBox60);
            H_Dict.Add(textBox61, textBox64);
            H_Dict.Add(textBox65, textBox68);
            H_Dict.Add(textBox69, textBox72);
            H_Dict.Add(textBox73, textBox76);
            H_Dict.Add(textBox77, textBox80);
            H_Dict.Add(textBox81, textBox84);
            H_Dict.Add(textBox85, textBox88);
            H_Dict.Add(textBox89, textBox92);
            H_Dict.Add(textBox93, textBox96);
            H_Dict.Add(textBox97, textBox100);
            H_Dict.Add(textBox101, textBox104);
            H_Dict.Add(textBox105, textBox108);
            H_Dict.Add(textBox109, textBox112);
            H_Dict.Add(textBox113, textBox116);
            H_Dict.Add(textBox117, textBox120);
            H_Dict.Add(textBox121, textBox124);
            H_Dict.Add(textBox125, textBox128);
            H_Dict.Add(textBox129, textBox132);
            H_Dict.Add(textBox133, textBox136);
            H_Dict.Add(textBox137, textBox140);
            H_Dict.Add(textBox141, textBox144);
            H_Dict.Add(textBox145, textBox148);
            H_Dict.Add(textBox149, textBox152);
            H_Dict.Add(textBox153, textBox156);
            H_Dict.Add(textBox157, textBox160);
            H_Dict.Add(textBox161, textBox164);
            H_Dict.Add(textBox165, textBox168);
            H_Dict.Add(textBox169, textBox172);
            H_Dict.Add(textBox173, textBox176);
            H_Dict.Add(textBox177, textBox180);
            H_Dict.Add(textBox181, textBox184);
            H_Dict.Add(textBox185, textBox188);
            H_Dict.Add(textBox189, textBox192);
            H_Dict.Add(textBox193, textBox196);
            H_Dict.Add(textBox197, textBox200);
            H_Dict.Add(textBox201, textBox204);
            H_Dict.Add(textBox205, textBox208);
            H_Dict.Add(textBox209, textBox212);
            H_Dict.Add(textBox213, textBox216);
            H_Dict.Add(textBox217, textBox220);
            H_Dict.Add(textBox221, textBox224);
            H_Dict.Add(textBox225, textBox228);
            H_Dict.Add(textBox229, textBox232);
            H_Dict.Add(textBox233, textBox236);
            H_Dict.Add(textBox237, textBox240);
            H_Dict.Add(textBox241, textBox244);
            H_Dict.Add(textBox245, textBox248);
            H_Dict.Add(textBox249, textBox252);
            H_Dict.Add(textBox253, textBox256);
            H_Dict.Add(textBox257, textBox260);
            H_Dict.Add(textBox261, textBox264);
            H_Dict.Add(textBox265, textBox268);
            H_Dict.Add(textBox269, textBox272);
            H_Dict.Add(textBox273, textBox276);
            H_Dict.Add(textBox277, textBox280);
            H_Dict.Add(textBox281, textBox284);
            H_Dict.Add(textBox285, textBox288);
            H_Dict.Add(textBox289, textBox292);
            H_Dict.Add(textBox293, textBox296);
            H_Dict.Add(textBox297, textBox300);
            H_Dict.Add(textBox301, textBox304);
            H_Dict.Add(textBox305, textBox308);
            H_Dict.Add(textBox309, textBox312);
        }

        private void X_Werte_Erstellen()
        {
            X_Werte.Add(textBox3);
            X_Werte.Add(textBox7);
            X_Werte.Add(textBox11);
            X_Werte.Add(textBox15);
            X_Werte.Add(textBox19);
            X_Werte.Add(textBox23);
            X_Werte.Add(textBox27);
            X_Werte.Add(textBox31);
            X_Werte.Add(textBox35);
            X_Werte.Add(textBox39);
            X_Werte.Add(textBox43);
            X_Werte.Add(textBox47);
            X_Werte.Add(textBox51);
            X_Werte.Add(textBox55);
            X_Werte.Add(textBox59);
            X_Werte.Add(textBox63);
            X_Werte.Add(textBox67);
            X_Werte.Add(textBox71);
            X_Werte.Add(textBox75);
            X_Werte.Add(textBox79);
            X_Werte.Add(textBox83);
            X_Werte.Add(textBox87);
            X_Werte.Add(textBox91);
            X_Werte.Add(textBox95);
            X_Werte.Add(textBox99);
            X_Werte.Add(textBox103);
            X_Werte.Add(textBox107);
            X_Werte.Add(textBox111);
            X_Werte.Add(textBox115);
            X_Werte.Add(textBox119);
            X_Werte.Add(textBox123);
            X_Werte.Add(textBox127);
            X_Werte.Add(textBox131);
            X_Werte.Add(textBox135);
            X_Werte.Add(textBox139);
            X_Werte.Add(textBox143);
            X_Werte.Add(textBox147);
            X_Werte.Add(textBox151);
            X_Werte.Add(textBox155);
            X_Werte.Add(textBox159);
            X_Werte.Add(textBox163);
            X_Werte.Add(textBox167);
            X_Werte.Add(textBox171);
            X_Werte.Add(textBox175);
            X_Werte.Add(textBox179);
            X_Werte.Add(textBox183);
            X_Werte.Add(textBox187);
            X_Werte.Add(textBox191);
            X_Werte.Add(textBox195);
            X_Werte.Add(textBox199);
            X_Werte.Add(textBox203);
            X_Werte.Add(textBox207);
            X_Werte.Add(textBox211);
            X_Werte.Add(textBox215);
            X_Werte.Add(textBox219);
            X_Werte.Add(textBox223);
            X_Werte.Add(textBox227);
            X_Werte.Add(textBox231);
            X_Werte.Add(textBox235);
            X_Werte.Add(textBox239);
            X_Werte.Add(textBox243);
            X_Werte.Add(textBox247);
            X_Werte.Add(textBox251);
            X_Werte.Add(textBox255);
            X_Werte.Add(textBox259);
            X_Werte.Add(textBox263);
            X_Werte.Add(textBox267);
            X_Werte.Add(textBox271);
            X_Werte.Add(textBox275);
            X_Werte.Add(textBox279);
            X_Werte.Add(textBox283);
            X_Werte.Add(textBox287);
            X_Werte.Add(textBox291);
            X_Werte.Add(textBox295);
            X_Werte.Add(textBox299);
            X_Werte.Add(textBox303);
            X_Werte.Add(textBox307);
            X_Werte.Add(textBox311);
        }
        private void Y_Werte_Erstellen()
        {
            Y_Werte.Add(textBox2);
            Y_Werte.Add(textBox6);
            Y_Werte.Add(textBox10);
            Y_Werte.Add(textBox14);
            Y_Werte.Add(textBox18);
            Y_Werte.Add(textBox22);
            Y_Werte.Add(textBox26);
            Y_Werte.Add(textBox30);
            Y_Werte.Add(textBox34);
            Y_Werte.Add(textBox38);
            Y_Werte.Add(textBox42);
            Y_Werte.Add(textBox46);
            Y_Werte.Add(textBox50);
            Y_Werte.Add(textBox54);
            Y_Werte.Add(textBox58);
            Y_Werte.Add(textBox62);
            Y_Werte.Add(textBox66);
            Y_Werte.Add(textBox70);
            Y_Werte.Add(textBox74);
            Y_Werte.Add(textBox78);
            Y_Werte.Add(textBox82);
            Y_Werte.Add(textBox86);
            Y_Werte.Add(textBox90);
            Y_Werte.Add(textBox94);
            Y_Werte.Add(textBox98);
            Y_Werte.Add(textBox102);
            Y_Werte.Add(textBox106);
            Y_Werte.Add(textBox110);
            Y_Werte.Add(textBox114);
            Y_Werte.Add(textBox118);
            Y_Werte.Add(textBox122);
            Y_Werte.Add(textBox126);
            Y_Werte.Add(textBox130);
            Y_Werte.Add(textBox134);
            Y_Werte.Add(textBox138);
            Y_Werte.Add(textBox142);
            Y_Werte.Add(textBox146);
            Y_Werte.Add(textBox150);
            Y_Werte.Add(textBox154);
            Y_Werte.Add(textBox158);
            Y_Werte.Add(textBox162);
            Y_Werte.Add(textBox166);
            Y_Werte.Add(textBox170);
            Y_Werte.Add(textBox174);
            Y_Werte.Add(textBox178);
            Y_Werte.Add(textBox182);
            Y_Werte.Add(textBox186);
            Y_Werte.Add(textBox190);
            Y_Werte.Add(textBox194);
            Y_Werte.Add(textBox198);
            Y_Werte.Add(textBox202);
            Y_Werte.Add(textBox206);
            Y_Werte.Add(textBox210);
            Y_Werte.Add(textBox214);
            Y_Werte.Add(textBox218);
            Y_Werte.Add(textBox222);
            Y_Werte.Add(textBox226);
            Y_Werte.Add(textBox230);
            Y_Werte.Add(textBox234);
            Y_Werte.Add(textBox238);
            Y_Werte.Add(textBox242);
            Y_Werte.Add(textBox246);
            Y_Werte.Add(textBox250);
            Y_Werte.Add(textBox254);
            Y_Werte.Add(textBox258);
            Y_Werte.Add(textBox262);
            Y_Werte.Add(textBox266);
            Y_Werte.Add(textBox270);
            Y_Werte.Add(textBox274);
            Y_Werte.Add(textBox278);
            Y_Werte.Add(textBox282);
            Y_Werte.Add(textBox286);
            Y_Werte.Add(textBox290);
            Y_Werte.Add(textBox294);
            Y_Werte.Add(textBox298);
            Y_Werte.Add(textBox302);
            Y_Werte.Add(textBox306);
            Y_Werte.Add(textBox310);
        }
        private void H_Werte_Erstellen()
        {
            H_Werte.Add(textBox1);
            H_Werte.Add(textBox5);
            H_Werte.Add(textBox9);
            H_Werte.Add(textBox13);
            H_Werte.Add(textBox17);
            H_Werte.Add(textBox21);
            H_Werte.Add(textBox25);
            H_Werte.Add(textBox29);
            H_Werte.Add(textBox33);
            H_Werte.Add(textBox37);
            H_Werte.Add(textBox41);
            H_Werte.Add(textBox45);
            H_Werte.Add(textBox49);
            H_Werte.Add(textBox53);
            H_Werte.Add(textBox57);
            H_Werte.Add(textBox61);
            H_Werte.Add(textBox65);
            H_Werte.Add(textBox69);
            H_Werte.Add(textBox73);
            H_Werte.Add(textBox77);
            H_Werte.Add(textBox81);
            H_Werte.Add(textBox85);
            H_Werte.Add(textBox89);
            H_Werte.Add(textBox93);
            H_Werte.Add(textBox97);
            H_Werte.Add(textBox101);
            H_Werte.Add(textBox105);
            H_Werte.Add(textBox109);
            H_Werte.Add(textBox113);
            H_Werte.Add(textBox117);
            H_Werte.Add(textBox121);
            H_Werte.Add(textBox125);
            H_Werte.Add(textBox129);
            H_Werte.Add(textBox133);
            H_Werte.Add(textBox137);
            H_Werte.Add(textBox141);
            H_Werte.Add(textBox145);
            H_Werte.Add(textBox149);
            H_Werte.Add(textBox153);
            H_Werte.Add(textBox157);
            H_Werte.Add(textBox161);
            H_Werte.Add(textBox165);
            H_Werte.Add(textBox169);
            H_Werte.Add(textBox173);
            H_Werte.Add(textBox177);
            H_Werte.Add(textBox181);
            H_Werte.Add(textBox185);
            H_Werte.Add(textBox189);
            H_Werte.Add(textBox193);
            H_Werte.Add(textBox197);
            H_Werte.Add(textBox201);
            H_Werte.Add(textBox205);
            H_Werte.Add(textBox209);
            H_Werte.Add(textBox213);
            H_Werte.Add(textBox217);
            H_Werte.Add(textBox221);
            H_Werte.Add(textBox225);
            H_Werte.Add(textBox229);
            H_Werte.Add(textBox233);
            H_Werte.Add(textBox237);
            H_Werte.Add(textBox241);
            H_Werte.Add(textBox245);
            H_Werte.Add(textBox249);
            H_Werte.Add(textBox253);
            H_Werte.Add(textBox257);
            H_Werte.Add(textBox261);
            H_Werte.Add(textBox265);
            H_Werte.Add(textBox269);
            H_Werte.Add(textBox273);
            H_Werte.Add(textBox277);
            H_Werte.Add(textBox281);
            H_Werte.Add(textBox285);
            H_Werte.Add(textBox289);
            H_Werte.Add(textBox293);
            H_Werte.Add(textBox297);
            H_Werte.Add(textBox301);
            H_Werte.Add(textBox305);
            H_Werte.Add(textBox309);
        }
        private void Zeichen_Ertellen()
        {
            Zeichen.Add(textBox4);
            Zeichen.Add(textBox8);
            Zeichen.Add(textBox12);
            Zeichen.Add(textBox16);
            Zeichen.Add(textBox20);
            Zeichen.Add(textBox24);
            Zeichen.Add(textBox28);
            Zeichen.Add(textBox32);
            Zeichen.Add(textBox36);
            Zeichen.Add(textBox40);
            Zeichen.Add(textBox44);
            Zeichen.Add(textBox48);
            Zeichen.Add(textBox52);
            Zeichen.Add(textBox56);
            Zeichen.Add(textBox60);
            Zeichen.Add(textBox64);
            Zeichen.Add(textBox68);
            Zeichen.Add(textBox72);
            Zeichen.Add(textBox76);
            Zeichen.Add(textBox80);
            Zeichen.Add(textBox84);
            Zeichen.Add(textBox88);
            Zeichen.Add(textBox92);
            Zeichen.Add(textBox96);
            Zeichen.Add(textBox100);
            Zeichen.Add(textBox104);
            Zeichen.Add(textBox108);
            Zeichen.Add(textBox112);
            Zeichen.Add(textBox116);
            Zeichen.Add(textBox120);
            Zeichen.Add(textBox124);
            Zeichen.Add(textBox128);
            Zeichen.Add(textBox132);
            Zeichen.Add(textBox136);
            Zeichen.Add(textBox140);
            Zeichen.Add(textBox144);
            Zeichen.Add(textBox148);
            Zeichen.Add(textBox152);
            Zeichen.Add(textBox156);
            Zeichen.Add(textBox160);
            Zeichen.Add(textBox164);
            Zeichen.Add(textBox168);
            Zeichen.Add(textBox172);
            Zeichen.Add(textBox176);
            Zeichen.Add(textBox180);
            Zeichen.Add(textBox184);
            Zeichen.Add(textBox188);
            Zeichen.Add(textBox192);
            Zeichen.Add(textBox196);
            Zeichen.Add(textBox200);
            Zeichen.Add(textBox204);
            Zeichen.Add(textBox208);
            Zeichen.Add(textBox212);
            Zeichen.Add(textBox216);
            Zeichen.Add(textBox220);
            Zeichen.Add(textBox224);
            Zeichen.Add(textBox228);
            Zeichen.Add(textBox232);
            Zeichen.Add(textBox236);
            Zeichen.Add(textBox240);
            Zeichen.Add(textBox244);
            Zeichen.Add(textBox248);
            Zeichen.Add(textBox252);
            Zeichen.Add(textBox256);
            Zeichen.Add(textBox260);
            Zeichen.Add(textBox264);
            Zeichen.Add(textBox268);
            Zeichen.Add(textBox272);
            Zeichen.Add(textBox276);
            Zeichen.Add(textBox280);
            Zeichen.Add(textBox284);
            Zeichen.Add(textBox288);
            Zeichen.Add(textBox292);
            Zeichen.Add(textBox296);
            Zeichen.Add(textBox300);
            Zeichen.Add(textBox304);
            Zeichen.Add(textBox308);
            Zeichen.Add(textBox312);
        }
        private void Weiß()
        {
            foreach(TextBox t in Zeichen)
            {
                t.BackColor = Color.White;
            }
        } 

        private void beenden_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Check_Änderungen()
        {
            foreach (TextBox t in X_Werte)
            {
                if (t.Text != t.Tag.ToString())
                {
                    string connStr = "server=localhost;user=root;database=movedb;port=3306;password=6540";
                    MySqlConnection conn = new(connStr);
                    try
                    {
                        conn.Open();
                        string c = X_Dict[t].Text;
                        if (c == "\\") { c = "\\\\"; }
                        else if (c == "\'") { c = "\\\'"; }
                        string sql = "update tabelle" + Schriftgröße + " set XPos = " + t.Text + " where Zeichen = '" + c + "' COLLATE utf8mb4_bin;";
                        MySqlCommand cmd = new(sql, conn);
                        cmd.ExecuteNonQuery();
                        if (c == "O") { sql = "update tabelle" + Schriftgröße + " set XPos = " + t.Text + " where Zeichen = \'0\' COLLATE utf8mb4_bin;"; }
                        cmd = new(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            foreach (TextBox t in H_Werte)
            {
                if (t.Text != t.Tag.ToString())
                {
                    string connStr = "server=localhost;user=root;database=movedb;port=3306;password=6540";
                    MySqlConnection conn = new (connStr);
                    try
                    {
                        conn.Open();
                        string c = H_Dict[t].Text;
                        if (c == "\\") { c = "\\\\"; }
                        else if (c == "\'") { c = "\\\'"; }
                        string sql = "update tabelle" + Schriftgröße + " set TischPos = " + t.Text + " where Zeichen = '" + c + "' COLLATE utf8mb4_bin;";
                        MySqlCommand cmd = new(sql, conn);
                        cmd.ExecuteNonQuery();
                        if (c == "O") { sql = "update tabelle" + Schriftgröße + " set TischPos = " + t.Text + " where Zeichen = \'0\' COLLATE utf8mb4_bin;"; }
                        cmd = new(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void Speichern_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Änderung der Druckpositionen speichern?", "Korrektur", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                Check_Änderungen();
            }
            else
            {
                return;
            }
        }
        private void Rechts_Click(object sender, EventArgs e)
        {
            X_neu.Text = (Int32.Parse(X_neu.Text) + 10).ToString();
        }

        private void Links_Click(object sender, EventArgs e)
        {
            X_neu.Text = (Int32.Parse(X_neu.Text) - 10).ToString();
        }

        private void Höher_Click(object sender, EventArgs e)
        {
            H_neu.Text = (Int32.Parse(H_neu.Text) + 10).ToString();
        }

        private void Tiefer_Click(object sender, EventArgs e)
        {
            H_neu.Text = (Int32.Parse(H_neu.Text) - 10).ToString();
        }


        // Click Abschnitt
        private void textBox4_Click(object sender, EventArgs e) { X_neu = textBox3; H_neu = textBox1; Weiß(); textBox4.BackColor = Color.LightGray; }
        private void textBox8_Click(object sender, EventArgs e) { X_neu = textBox7; H_neu = textBox5; Weiß(); textBox8.BackColor = Color.LightGray; }
        private void textBox12_Click(object sender, EventArgs e) { X_neu = textBox11; H_neu = textBox9; Weiß(); textBox12.BackColor = Color.LightGray; }
        private void textBox16_Click(object sender, EventArgs e) { X_neu = textBox15; H_neu = textBox13; Weiß(); textBox16.BackColor = Color.LightGray; }
        private void textBox20_Click(object sender, EventArgs e) { X_neu = textBox19; H_neu = textBox17; Weiß(); textBox20.BackColor = Color.LightGray; }
        private void textBox24_Click(object sender, EventArgs e) { X_neu = textBox23; H_neu = textBox21; Weiß(); textBox24.BackColor = Color.LightGray; }
        private void textBox28_Click(object sender, EventArgs e) { X_neu = textBox27; H_neu = textBox25; Weiß(); textBox28.BackColor = Color.LightGray; }
        private void textBox32_Click(object sender, EventArgs e) { X_neu = textBox31; H_neu = textBox29; Weiß(); textBox32.BackColor = Color.LightGray; }
        private void textBox36_Click(object sender, EventArgs e) { X_neu = textBox35; H_neu = textBox33; Weiß(); textBox36.BackColor = Color.LightGray; }
        private void textBox40_Click(object sender, EventArgs e) { X_neu = textBox39; H_neu = textBox37; Weiß(); textBox40.BackColor = Color.LightGray; }
        private void textBox44_Click(object sender, EventArgs e) { X_neu = textBox43; H_neu = textBox41; Weiß(); textBox44.BackColor = Color.LightGray; }
        private void textBox48_Click(object sender, EventArgs e) { X_neu = textBox47; H_neu = textBox45; Weiß(); textBox48.BackColor = Color.LightGray; }
        private void textBox52_Click(object sender, EventArgs e) { X_neu = textBox51; H_neu = textBox49; Weiß(); textBox52.BackColor = Color.LightGray; }
        private void textBox56_Click(object sender, EventArgs e) { X_neu = textBox55; H_neu = textBox53; Weiß(); textBox56.BackColor = Color.LightGray; }
        private void textBox60_Click(object sender, EventArgs e) { X_neu = textBox59; H_neu = textBox57; Weiß(); textBox60.BackColor = Color.LightGray; }
        private void textBox64_Click(object sender, EventArgs e) { X_neu = textBox63; H_neu = textBox61; Weiß(); textBox64.BackColor = Color.LightGray; }
        private void textBox68_Click(object sender, EventArgs e) { X_neu = textBox67; H_neu = textBox65; Weiß(); textBox68.BackColor = Color.LightGray; }
        private void textBox72_Click(object sender, EventArgs e) { X_neu = textBox71; H_neu = textBox69; Weiß(); textBox72.BackColor = Color.LightGray; }
        private void textBox76_Click(object sender, EventArgs e) { X_neu = textBox75; H_neu = textBox73; Weiß(); textBox76.BackColor = Color.LightGray; }
        private void textBox80_Click(object sender, EventArgs e) { X_neu = textBox79; H_neu = textBox77; Weiß(); textBox80.BackColor = Color.LightGray; }
        private void textBox84_Click(object sender, EventArgs e) { X_neu = textBox83; H_neu = textBox81; Weiß(); textBox84.BackColor = Color.LightGray; }
        private void textBox88_Click(object sender, EventArgs e) { X_neu = textBox87; H_neu = textBox85; Weiß(); textBox88.BackColor = Color.LightGray; }
        private void textBox92_Click(object sender, EventArgs e) { X_neu = textBox91; H_neu = textBox89; Weiß(); textBox92.BackColor = Color.LightGray; }
        private void textBox96_Click(object sender, EventArgs e) { X_neu = textBox95; H_neu = textBox93; Weiß(); textBox96.BackColor = Color.LightGray; }
        private void textBox100_Click(object sender, EventArgs e) { X_neu = textBox99; H_neu = textBox97; Weiß(); textBox100.BackColor = Color.LightGray; }
        private void textBox104_Click(object sender, EventArgs e) { X_neu = textBox103; H_neu = textBox101; Weiß(); textBox104.BackColor = Color.LightGray; }
        private void textBox108_Click(object sender, EventArgs e) { X_neu = textBox107; H_neu = textBox105; Weiß(); textBox108.BackColor = Color.LightGray; }
        private void textBox112_Click(object sender, EventArgs e) { X_neu = textBox111; H_neu = textBox109; Weiß(); textBox112.BackColor = Color.LightGray; }
        private void textBox116_Click(object sender, EventArgs e) { X_neu = textBox115; H_neu = textBox113; Weiß(); textBox116.BackColor = Color.LightGray; }
        private void textBox120_Click(object sender, EventArgs e) { X_neu = textBox119; H_neu = textBox117; Weiß(); textBox120.BackColor = Color.LightGray; }
        private void textBox124_Click(object sender, EventArgs e) { X_neu = textBox123; H_neu = textBox121; Weiß(); textBox124.BackColor = Color.LightGray; }
        private void textBox128_Click(object sender, EventArgs e) { X_neu = textBox127; H_neu = textBox125; Weiß(); textBox128.BackColor = Color.LightGray; }
        private void textBox132_Click(object sender, EventArgs e) { X_neu = textBox131; H_neu = textBox129; Weiß(); textBox132.BackColor = Color.LightGray; }
        private void textBox136_Click(object sender, EventArgs e) { X_neu = textBox135; H_neu = textBox133; Weiß(); textBox136.BackColor = Color.LightGray; }
        private void textBox140_Click(object sender, EventArgs e) { X_neu = textBox139; H_neu = textBox137; Weiß(); textBox140.BackColor = Color.LightGray; }
        private void textBox144_Click(object sender, EventArgs e) { X_neu = textBox143; H_neu = textBox141; Weiß(); textBox144.BackColor = Color.LightGray; }
        private void textBox148_Click(object sender, EventArgs e) { X_neu = textBox147; H_neu = textBox145; Weiß(); textBox148.BackColor = Color.LightGray; }
        private void textBox152_Click(object sender, EventArgs e) { X_neu = textBox151; H_neu = textBox149; Weiß(); textBox152.BackColor = Color.LightGray; }
        private void textBox156_Click(object sender, EventArgs e) { X_neu = textBox155; H_neu = textBox153; Weiß(); textBox156.BackColor = Color.LightGray; }
        private void textBox160_Click(object sender, EventArgs e) { X_neu = textBox159; H_neu = textBox157; Weiß(); textBox160.BackColor = Color.LightGray; }
        private void textBox164_Click(object sender, EventArgs e) { X_neu = textBox163; H_neu = textBox161; Weiß(); textBox164.BackColor = Color.LightGray; }
        private void textBox168_Click(object sender, EventArgs e) { X_neu = textBox167; H_neu = textBox165; Weiß(); textBox168.BackColor = Color.LightGray; }
        private void textBox172_Click(object sender, EventArgs e) { X_neu = textBox171; H_neu = textBox169; Weiß(); textBox172.BackColor = Color.LightGray; }
        private void textBox176_Click(object sender, EventArgs e) { X_neu = textBox175; H_neu = textBox173; Weiß(); textBox176.BackColor = Color.LightGray; }
        private void textBox180_Click(object sender, EventArgs e) { X_neu = textBox179; H_neu = textBox177; Weiß(); textBox180.BackColor = Color.LightGray; }
        private void textBox184_Click(object sender, EventArgs e) { X_neu = textBox183; H_neu = textBox181; Weiß(); textBox184.BackColor = Color.LightGray; }
        private void textBox188_Click(object sender, EventArgs e) { X_neu = textBox187; H_neu = textBox185; Weiß(); textBox188.BackColor = Color.LightGray; }
        private void textBox192_Click(object sender, EventArgs e) { X_neu = textBox191; H_neu = textBox189; Weiß(); textBox192.BackColor = Color.LightGray; }
        private void textBox196_Click(object sender, EventArgs e) { X_neu = textBox195; H_neu = textBox193; Weiß(); textBox196.BackColor = Color.LightGray; }
        private void textBox200_Click(object sender, EventArgs e) { X_neu = textBox199; H_neu = textBox197; Weiß(); textBox200.BackColor = Color.LightGray; }
        private void textBox204_Click(object sender, EventArgs e) { X_neu = textBox203; H_neu = textBox201; Weiß(); textBox204.BackColor = Color.LightGray; }
        private void textBox208_Click(object sender, EventArgs e) { X_neu = textBox207; H_neu = textBox205; Weiß(); textBox208.BackColor = Color.LightGray; }
        private void textBox212_Click(object sender, EventArgs e) { X_neu = textBox211; H_neu = textBox209; Weiß(); textBox212.BackColor = Color.LightGray; }
        private void textBox216_Click(object sender, EventArgs e) { X_neu = textBox215; H_neu = textBox213; Weiß(); textBox216.BackColor = Color.LightGray; }
        private void textBox220_Click(object sender, EventArgs e) { X_neu = textBox219; H_neu = textBox217; Weiß(); textBox220.BackColor = Color.LightGray; }
        private void textBox224_Click(object sender, EventArgs e) { X_neu = textBox223; H_neu = textBox221; Weiß(); textBox224.BackColor = Color.LightGray; }
        private void textBox228_Click(object sender, EventArgs e) { X_neu = textBox227; H_neu = textBox225; Weiß(); textBox228.BackColor = Color.LightGray; }
        private void textBox232_Click(object sender, EventArgs e) { X_neu = textBox231; H_neu = textBox229; Weiß(); textBox232.BackColor = Color.LightGray; }
        private void textBox236_Click(object sender, EventArgs e) { X_neu = textBox235; H_neu = textBox233; Weiß(); textBox236.BackColor = Color.LightGray; }
        private void textBox240_Click(object sender, EventArgs e) { X_neu = textBox239; H_neu = textBox237; Weiß(); textBox240.BackColor = Color.LightGray; }
        private void textBox244_Click(object sender, EventArgs e) { X_neu = textBox243; H_neu = textBox241; Weiß(); textBox244.BackColor = Color.LightGray; }
        private void textBox248_Click(object sender, EventArgs e) { X_neu = textBox247; H_neu = textBox245; Weiß(); textBox248.BackColor = Color.LightGray; }
        private void textBox252_Click(object sender, EventArgs e) { X_neu = textBox251; H_neu = textBox249; Weiß(); textBox252.BackColor = Color.LightGray; }
        private void textBox256_Click(object sender, EventArgs e) { X_neu = textBox255; H_neu = textBox253; Weiß(); textBox256.BackColor = Color.LightGray; }
        private void textBox260_Click(object sender, EventArgs e) { X_neu = textBox259; H_neu = textBox257; Weiß(); textBox260.BackColor = Color.LightGray; }
        private void textBox264_Click(object sender, EventArgs e) { X_neu = textBox263; H_neu = textBox261; Weiß(); textBox264.BackColor = Color.LightGray; }
        private void textBox268_Click(object sender, EventArgs e) { X_neu = textBox267; H_neu = textBox265; Weiß(); textBox268.BackColor = Color.LightGray; }
        private void textBox272_Click(object sender, EventArgs e) { X_neu = textBox271; H_neu = textBox269; Weiß(); textBox272.BackColor = Color.LightGray; }
        private void textBox276_Click(object sender, EventArgs e) { X_neu = textBox275; H_neu = textBox273; Weiß(); textBox276.BackColor = Color.LightGray; }
        private void textBox280_Click(object sender, EventArgs e) { X_neu = textBox279; H_neu = textBox277; Weiß(); textBox280.BackColor = Color.LightGray; }
        private void textBox284_Click(object sender, EventArgs e) { X_neu = textBox283; H_neu = textBox281; Weiß(); textBox284.BackColor = Color.LightGray; }
        private void textBox288_Click(object sender, EventArgs e) { X_neu = textBox287; H_neu = textBox285; Weiß(); textBox288.BackColor = Color.LightGray; }
        private void textBox292_Click(object sender, EventArgs e) { X_neu = textBox291; H_neu = textBox289; Weiß(); textBox292.BackColor = Color.LightGray; }
        private void textBox296_Click(object sender, EventArgs e) { X_neu = textBox295; H_neu = textBox293; Weiß(); textBox296.BackColor = Color.LightGray; }
        private void textBox300_Click(object sender, EventArgs e) { X_neu = textBox299; H_neu = textBox297; Weiß(); textBox300.BackColor = Color.LightGray; }
        private void textBox304_Click(object sender, EventArgs e) { X_neu = textBox303; H_neu = textBox301; Weiß(); textBox304.BackColor = Color.LightGray; }
        private void textBox308_Click(object sender, EventArgs e) { X_neu = textBox307; H_neu = textBox305; Weiß(); textBox308.BackColor = Color.LightGray; }
        private void textBox312_Click(object sender, EventArgs e) { X_neu = textBox311; H_neu = textBox309; Weiß(); textBox312.BackColor = Color.LightGray; }


    }
}
