using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dog_Race_assign_k
{
    public partial class Form1 : Form
    {
        public int betprice = 0, dog = 0,m=100,g=100,p=100;
        public string nmPlyer = "";
        ground ground = new ground();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this code is used to insert the bet amount 
            for (int y=5;y<=50; y=y+5) {
                cbBet.Items.Add("" + y);
            }
            //here i dispper the button of the rce 
            race_btn.Visible = false;
        }

        // Changing object of first dog 

        private void dog_1_CheckedChanged(object sender, EventArgs e)
        {
            if (dog_1.Checked == true) {
                dog =1;
                dog_2.Checked = false;
                dog_3.Checked = false;
                dog_4.Checked = false;
            }
        }

        // changing object name of dog 2
        private void dog_2_CheckedChanged(object sender, EventArgs e)
        {
            if (dog_2.Checked == true)
            {
                dog = 2;
                dog_1.Checked = false;
                dog_3.Checked = false;
                dog_4.Checked = false;
            }
        }

        //changing object name of dog 3
        private void dog_3_CheckedChanged(object sender, EventArgs e)
        {
            if (dog_3.Checked == true)
            {
                dog = 3;
                dog_2.Checked = false;
                dog_1.Checked = false;
                dog_4.Checked = false;
            }
        }

        private void dog_4_CheckedChanged(object sender, EventArgs e)
        {
            if (dog_4.Checked == true)
            {
                dog = 4;
                dog_2.Checked = false;
                dog_3.Checked = false;
                dog_1.Checked = false;
            }
        }

        // race button starting the time event 
        private void race_btn_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        // random function for win concept
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ground.stp(pictureBox1.Left)==1) {
                timer1.Stop();
                MessageBox.Show("Dog 1 won the race ");
                result(1);
            }

            if (ground.stp(pictureBox2.Left) == 1)
            {
                timer1.Stop();
                MessageBox.Show("Dog 2 won the race ");
                result(2);
            }

            // showing about the dog 3 won

            if (ground.stp(pictureBox3.Left) == 1)
            {
                timer1.Stop();
                MessageBox.Show("Dog 3 won the race ");
                result(3);
            }

            if (ground.stp(pictureBox4.Left) == 1)
            {
                timer1.Stop();
                MessageBox.Show("Dog 4 won the race ");
                result(4);
            }

            pictureBox1.Left += ground.genStep();
            pictureBox2.Left += ground.genStep();
            pictureBox3.Left += ground.genStep();
            pictureBox4.Left += ground.genStep();

        }

        // conversions of numbers according to the winning concept

        public void result(int win) {
            if (marious_lb.Text.Contains("Bet")) {
                String []h = marious_lb.Text.Split(' ');
                //2 price 4 bet
                if (Convert.ToInt32(h[4].ToString()) == win) {
                    m = m + Convert.ToInt32(h[2].ToString());
                }
                else
                {
                    m = m - Convert.ToInt32(h[2].ToString());
                }

                marious_lb.Text = "marious has " + m;
            }
            if (prigal_lb.Text.Contains("Bet"))
            {
                String[] h =prigal_lb.Text.Split(' ');
                //2 price 4 bet
                if (Convert.ToInt32(h[4].ToString()) == win)
                {
                    p = p + Convert.ToInt32(h[2].ToString());
                }
                else {
                    p = p - Convert.ToInt32(h[2].ToString());
                }
                prigal_lb.Text = "prigal has " + p;
            }
            if (gupta_lb.Text.Contains("Bet"))
            {
                String[] h = gupta_lb.Text.Split(' ');
                //2 price 4 bet
                if (Convert.ToInt32(h[4].ToString()) == win)
                {
                    g = g + Convert.ToInt32(h[2].ToString());
                }
                else
                {
                    g = g - Convert.ToInt32(h[2].ToString());
                }

                gupta_lb.Text = "gupta has " + g;
            }
            race_btn.Visible = false;
            
            pictureBox1.Left = 0;
            pictureBox2.Left = 0;
            pictureBox3.Left = 0;
            pictureBox4.Left = 0;
            dog = 0;
            nmPlyer = "";
            dog_1.Checked = false; dog_2.Checked = false; dog_3.Checked = false; dog_4.Checked = false;
            marious_pl.Checked = false;prigal_pl.Checked = false;gupta_pl.Checked = false;

        }

        // button functions working 

        private void marious_pl_CheckedChanged(object sender, EventArgs e)
        {
            if (marious_pl.Checked==true) {
                prigal_pl.Checked = false;
                gupta_pl.Checked = false;
                nmPlyer = "marious";
            }
        }

        private void gupta_pl_CheckedChanged(object sender, EventArgs e)
        {
            if (gupta_pl.Checked == true)
            {
                prigal_pl.Checked = false;
                marious_pl.Checked = false;

                nmPlyer = "gupta";
            }
        }

        private void prigal_pl_CheckedChanged(object sender, EventArgs e)
        {
            if (prigal_pl.Checked == true)
            {
                gupta_pl.Checked = false;
                marious_pl.Checked = false;

                nmPlyer = "prigal";
            }
        }

        // set bet button clicking 

        private void bet_set_btn_Click(object sender, EventArgs e)
        {
            //here we crete the chrt to strt the rce ;
            if (nmPlyer.Equals("prigal") && dog > 0 && p >= Convert.ToInt32(cbBet.SelectedItem.ToString()) && p > 0)
            {
                prigal_lb.Text = "Bet Price " + cbBet.SelectedItem.ToString() + " Dog " + dog;
                race_btn.Visible = true;
            }
            else if (nmPlyer.Equals("gupta") && dog > 0 && g >= Convert.ToInt32(cbBet.SelectedItem.ToString()) && g > 0)
            {
                gupta_lb.Text = "Bet Price " + cbBet.SelectedItem.ToString() + " Dog " + dog;
                race_btn.Visible = true;
            }
            else if (nmPlyer.Equals("marious") && dog > 0 && m >= Convert.ToInt32(cbBet.SelectedItem.ToString()) && m > 0)
            {
                marious_lb.Text = "Bet Price " + cbBet.SelectedItem.ToString() + " Dog " + dog;
                race_btn.Visible = true;
            }
            else {
                MessageBox.Show("Here you need to follow the guidelines ");
            }

            nmPlyer = "";
            dog =0;

        }
    }
}
