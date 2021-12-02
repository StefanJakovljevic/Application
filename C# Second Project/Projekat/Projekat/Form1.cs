using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Projekat
{
    public partial class Form1 : Form
    {
        Baza baza;
        List<Kategorija> lista;
        ProdavnicaDataSet ds;
        ProdavnicaDataSetTableAdapters.ProizvodTableAdapter proizvod;
        ProdavnicaDataSetTableAdapters.KategorijaTableAdapter kategorija;
        ProdavnicaDataSetTableAdapters.RacunTableAdapter racun;

        public Form1()
        {
            InitializeComponent();
            ds = new ProdavnicaDataSet();
            proizvod = new ProdavnicaDataSetTableAdapters.ProizvodTableAdapter();
            kategorija = new ProdavnicaDataSetTableAdapters.KategorijaTableAdapter();
            racun = new ProdavnicaDataSetTableAdapters.RacunTableAdapter();
            baza = new Baza();
            lista = new List<Kategorija>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //kategorija.Fill(ds.Kategorija);
            // dataGridView1.DataSource = ds.Kategorija;

            proizvod.Fill(ds.Proizvod);
            dataGridView1.DataSource = ds.Proizvod;

            try
            {
                baza.otvoriKonekciju();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM Kategorija";
                OleDbDataReader reader = cmd.ExecuteReader();

                lista.Clear();
                while (reader.Read())
                {
                    Kategorija kat = new Kategorija();
                    kat.Id = int.Parse(reader["id"].ToString());
                    kat.Ime_kategorije = reader["Ime_kategorije"].ToString();



                    lista.Add(kat);
                }

                comboBox1.DataSource = null;
                comboBox1.DisplayMember = "Ime_kategorije";
                comboBox1.ValueMember = "id";
                comboBox1.DataSource = lista;

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




        }

        public void izracunajSelektovaneRedove()
        {




        }

        public void deselektujSve()
        {
            double sum = 0;
            label3.Text = sum.ToString();

            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
        }

        /*
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
           // dataGridView1.CurrentRow.Selected = true;

            MessageBox.Show("Podaci o izabranoj kategoriji se izlistavaju");


            
            //if (dataGridView1.CurrentRow.Selected == true)
            {
               proizvod.Fill(ds.Proizvod);
               dataGridView2.DataSource = ds.Proizvod;
            }
            

            string tekst = "S";
            string tekst1 = "C";


            if (dataGridView1.Rows[0].Selected == true)
            {

                var linq = from x in ds.Proizvod
                           where x.Kat.StartsWith(tekst) orderby ds.Proizvod.Ime_proizvodaColumn
                           select x;

                dataGridView2.DataSource = linq.CopyToDataTable();

            }else
            {
                var linq1 = from x in ds.Proizvod
                            where x.Kat.StartsWith(tekst1) orderby ds.Proizvod.Ime_proizvodaColumn
                            select x;
                dataGridView2.DataSource = linq1.CopyToDataTable();
            }

            /*

            var linq1 = from x in ds.Proizvod
                        where x.Kat.StartsWith(tekst1)
                        select x;

            
        }

        */

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            


        }


        
        private void button2_Click(object sender, EventArgs e)
        {
            int sum = 0;

            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value);
            }
            label3.Text = sum.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deselektujSve();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lista != null && comboBox1.SelectedValue != null)
                foreach (Kategorija s in lista)
                    if (s.Id == int.Parse(comboBox1.SelectedValue.ToString()))
                    {
                        string tekst = "C";
                        var linq = from x in ds.Proizvod
                                   where x.Kat.StartsWith(tekst)
                                   orderby ds.Proizvod.Ime_proizvodaColumn
                                   select x;

                        dataGridView1.DataSource = linq.CopyToDataTable();

                    }
                    else
                    {
                        string tekst1 = "S";
                        var linq = from x in ds.Proizvod
                                   where x.Kat.StartsWith(tekst1)
                                   orderby ds.Proizvod.Ime_proizvodaColumn
                                   select x;

                        dataGridView1.DataSource = linq.CopyToDataTable();
                    }




        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //broji redove u datagridview2
            string br = dataGridView2.Rows.Count.ToString();
            //brise poslednji red posto je prazan ceo
            int br2 = int.Parse(br) - 1;
            int ukupno = 0;
            if (numericUpDown1.Value >= 1)
            {
                //uzima vrednost numericupdown i stavlja ga u kolicina2
                string kolicina = numericUpDown1.Value.ToString();
                int kolicina2 = int.Parse(kolicina);

                string cena = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                int cena2 = int.Parse(cena);


                ukupno = kolicina2 * cena2;

                dataGridView2.Rows.Add();
                //dodaje selektovane redove iz datagridview1 i prebacuje ih u datagridview2
                dataGridView2.Rows[br2].Cells[0].Value = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                dataGridView2.Rows[br2].Cells[1].Value = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                dataGridView2.Rows[br2].Cells[2].Value = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

                dataGridView2.Rows[br2].Cells[3].Value = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                dataGridView2.Rows[br2].Cells[4].Value = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                dataGridView2.Rows[br2].Cells[5].Value = ukupno.ToString();
            }
            else
                MessageBox.Show("Niste uneli kolicinu");



        }

        private void button6_Click(object sender, EventArgs e)
        {
            proizvod.Fill(ds.Proizvod);
            dataGridView1.DataSource = ds.Proizvod;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                String s = textBox1.Text;

                var linq = from x in ds.Proizvod
                           where x.Ime_proizvoda.StartsWith(s)
                           orderby ds.Proizvod.Ime_proizvodaColumn
                           select x;





                if (s.Length <= 0)
                {
                    MessageBox.Show("Unesite tekst!");
                }




                dataGridView1.DataSource = linq.CopyToDataTable();
            }catch(Exception)
            {
                MessageBox.Show("Nema tog naziva u bazi" );
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                baza.otvoriKonekciju();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                DateTime datum = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss";

                String vrednost = label3.Text;

                cmd.CommandText = @"INSERT INTO 
                Racun(datum_vreme,Ukupno)
                 VALUES (@datum_vreme,@ukupno)";

                
                



                cmd.Parameters.AddWithValue("datum_vreme", datum.ToString(format));
                cmd.Parameters.AddWithValue("ukupno",Convert.ToInt32(vrednost));



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
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                baza.zatvoriKonekciju();
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

        private void button9_Click(object sender, EventArgs e)
        {
            int indeks = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows.RemoveAt(indeks);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);

        }
    }
}
