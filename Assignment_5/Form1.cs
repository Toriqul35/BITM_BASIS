using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day5
{
    public partial class Information : Form
    {
        List<string> ids = new List<string> { };
        List<string> names = new List<string> { };
        List<string> Mobiles = new List<string> { };
        List<double> Ages = new List<double> { };
        List<string> Address = new List<string> { };
        List<double> Gpas = new List<double> { };

        int identity = 0;

        public Information()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            Addstudentinformation();

        }
        private void Addstudentinformation()
        {
            try
            {
                if (idtxt.Text == "" || nametxt.Text == "" || mobiletxt.Text == "")
                {
                    if (idtxt.Text == "")
                    {
                        idtxt.Text = String.Empty;
                        MessageBox.Show("Input Your id");
                    }
                    else if (nametxt.Text == "")
                    {
                        nametxt.Text = string.Empty;
                        MessageBox.Show("Student name required");
                    }
                    else if (mobiletxt.Text == "")
                    {
                        mobiletxt.Text = string.Empty;
                        MessageBox.Show("Student mobile no required");
                    }

                }
                else
                {
                   
                    int idlength = (idtxt.Text).Length;
                    int namelength = (nametxt.Text).Length;
                    int mobilelength = (mobiletxt.Text).Length;

                    if (idlength == 4 && namelength == 30 && mobilelength == 11 && ids.Contains(idtxt.Text) && Mobiles.Contains(mobiletxt.Text))
                    {
                        ids.Contains(idtxt.Text);
                        names.Add(nametxt.Text);
                        Mobiles.Add(mobiletxt.Text);
                        Ages.Add(Convert.ToInt32(agetxt.Text));
                        Gpas.Add(Convert.ToDouble(gpatxt.Text));
                        Address.Add(addresstxt.Text);

                        identity++;
                        MessageBox.Show("Add valid done ");
                    }
                    else
                    {
                        if (ids.Contains(idtxt.Text))
                        {
                            MessageBox.Show("Invalid Id");
                        }

                        else if (Mobiles.Contains(mobiletxt.Text))
                        {
                            MessageBox.Show(" Invalid Mobile number");
                        }
                        else
                        {
                            MessageBox.Show("Your Input is done");
                        }

                    }
                }
             }


              catch (Exception ex)
             {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
