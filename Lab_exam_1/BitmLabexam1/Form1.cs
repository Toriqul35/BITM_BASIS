using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmLabexam1
{
    public partial class Form1 : Form
    {
        List<string> Names = new List<string> { };
        List<string> Ides = new List<string> { };
        List<int> totalTargets = new List<int> { };
        List<double> averages = new List<double> { };
        int identity = 0;
        String listBoxViewDetails = "{0,-20}{1,-20}{2,-20}{3,-20}";

        public Form1()
        {
            InitializeComponent();
           
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveSoldier();
        }
        private void SaveSoldier()
        {
            try
            {
                if(soldierNameTextBox.Text=="" || soldierNoTextBox.Text=="" || target1ScoreTextBox.Text=="" || target2ScoreTextBox4.Text=="" || target3ScoreTextBox5.Text == "" || target4ScoreTextBox6.Text == "")
                {
                    
                    MessageBox.Show("Input Miss Match!");
                    return;
                }
                else
                {
                    if (Ides.Contains(soldierNoTextBox.Text))
                    {
                        MessageBox.Show("Soldier Already Exist!");
                        return;
                    }
                    else
                    {
                        Names.Add(soldierNameTextBox.Text);
                        Ides.Add(soldierNoTextBox.Text);
                        int sum = ((Convert.ToInt32(target1ScoreTextBox.Text)) + (Convert.ToInt32(target2ScoreTextBox4.Text)) + (Convert.ToInt32(target3ScoreTextBox5.Text)) + (Convert.ToInt32(target4ScoreTextBox6.Text)));
                        double average = (Convert.ToDouble(sum / 4));
                        totalTargets.Add(sum);
                        averages.Add(average);
                        soldierNameTextBox.Text = string.Empty;
                        soldierNoTextBox.Text = string.Empty;
                        target1ScoreTextBox.Text = string.Empty;
                        target2ScoreTextBox4.Text = string.Empty;
                        target3ScoreTextBox5.Text = string.Empty;
                        target4ScoreTextBox6.Text = string.Empty;
                        MessageBox.Show("Add successfully done!");
                        identity++;
                        SingleView();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SingleView()
        {
            try
            {
                
                String ID="", Name = "", Average = "", Total = "";
             
                for (int i = 0; i < Ides.Count(); i++)
                {
                    if (i == identity - 1)
                    {
                        ID = Ides[i];
                        Name = Names[i];
                        Average = Convert.ToString(averages[i]);
                        Total = Convert.ToString(totalTargets[i]);

                    }

                }
                viewListBox.Items.Clear();
                viewListBox.Items.Add(String.Format(listBoxViewDetails, "Soldier No.", " Soldier Name", "Average Score", "Total Score"));
                viewListBox.Items.Add(String.Format(listBoxViewDetails, ID, Name, Average, Total));

            }
            catch (Exception)
            {
                MessageBox.Show("Single Show Wrong");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "";
                if (soldierNameRadioButton.Checked == true)
                {
                    if (Names.Contains(searchTextBox.Text))
                    {
                        viewListBox.Items.Clear();
                        for (int i = 0; i < Names.Count(); i++)
                        {
                            if (Names[i].Equals(searchTextBox.Text))
                            {
                                viewListBox.Items.Add(String.Format(listBoxViewDetails, Ides[i], Names[i], Convert.ToString(averages[i]), Convert.ToString(totalTargets[i])));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Input!");
                    }
                }
                else if (soldierNoRadioButton.Checked == true)
                {
                    if (Ides.Contains(searchTextBox.Text))
                    {
                        viewListBox.Items.Clear();
                        for (int i = 0; i < Ides.Count(); i++)
                        {
                            if (Ides[i].Equals(searchTextBox.Text))
                            {
                                viewListBox.Items.Add(String.Format(listBoxViewDetails, Ides[i], Names[i], Convert.ToString(averages[i]), Convert.ToString(totalTargets[i])));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Input!");
                    }
                }
                else
                {
                    MessageBox.Show("Please select radio button.");
                    return;
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showAll_Click(object sender, EventArgs e)
        {
            ShowAllInfo();
        }
        private void ShowAllInfo()
        {
            try
            {
                string maxName = "";
                string avgName = "";
                int max = totalTargets.Max();
                int indexMax = totalTargets.IndexOf(max);
                int avg = Convert.ToInt32(averages.Max());
                int indexAvg = averages.IndexOf(avg);
                viewListBox.Items.Clear();
                viewListBox.Items.Add(String.Format(listBoxViewDetails, "Soldier No.", " Soldier Name", "Average Score", "Total Score"));
                for (int i = 0; i < Ides.Count(); i++)
                 {
                    viewListBox.Items.Add(String.Format(listBoxViewDetails, Ides[i], Names[i], Convert.ToString(averages[i]), Convert.ToString(totalTargets[i])));
                     if (indexMax == i)
                     {
                         maxName = Names[i];
                     }
                     if (indexAvg == i)
                     {
                         avgName = Names[i];
                     }
                }
                topAverageScoreTextBox.Text = avgName;
                topTotalScoreTextBox.Text = maxName;
            }
            catch (Exception)
            {
                MessageBox.Show("All Show Wrong");
            }
        }
    }
}
