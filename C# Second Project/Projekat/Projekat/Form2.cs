using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public partial class Form2 : Form
    {
        Baza baza;
        List<Proizvodi> lista;
        List<Kategorija> list;
        public Form2()
        {
            InitializeComponent();
            baza = new Baza();
            lista = new List<Proizvodi>();
            list = new List<Kategorija>();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                baza.otvoriKonekciju();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM Kategorija";
                OleDbDataReader reader = cmd.ExecuteReader();

                list.Clear();
                while (reader.Read())
                {
                    Kategorija kat = new Kategorija();
                    kat.Id = int.Parse(reader["id"].ToString());
                    kat.Ime_kategorije = reader["Ime_kategorije"].ToString();



                    list.Add(kat);
                }

                comboBox1.DataSource = null;
                comboBox1.DisplayMember = "Ime_kategorije";
                comboBox1.ValueMember = "id";
                comboBox1.DataSource = list;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baza.zatvoriKonekciju();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {
                MessageBox.Show("Molimo vas unesite kod proizvoda!");

            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Molimo vas unesite ime proizvoda!");
            }else if (textBox4.Text == "")
            {
                MessageBox.Show("Molimo vas da unesete cenu proizvoda!");
            }

            else
            {
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;

                    cmd.CommandText = @"INSERT INTO 
                Proizvod(Kod_proizvoda,Ime_proizvoda,Cena,Kat)
                 VALUES (@Kod_proizvoda,@Ime_proizvoda,@Cena,@Kat)";
                    //cmd.Parameters.AddWithValue("id", textBox1.Text);
                    cmd.Parameters.AddWithValue("Kod_proizvoda", textBox2.Text);
                    cmd.Parameters.AddWithValue("Ime_proizvoda", textBox3.Text);
                    cmd.Parameters.AddWithValue("Cena", textBox4.Text);
                    cmd.Parameters.AddWithValue("Kat", comboBox1.Text);







                    int rezultat = cmd.ExecuteNonQuery();
                    if (rezultat == 0)
                        MessageBox.Show("Doslo je do greske");
                    else
                    {
                        MessageBox.Show("Uspesno dodato!");
                    }
                    ocisti();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    baza.zatvoriKonekciju();
                }
            }
        }


        private void ocisti()
        {
            foreach (Control c in Controls)
                if (c is TextBox)
                {
                    TextBox t = c as TextBox;
                    t.Text = "";
                }
        }

       

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "  ^ [0-9]"))
            {
                textBox4.Text = "";
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "  ^ [0-9]"))
            {
                textBox4.Text = "";
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);

        }
    }
}
