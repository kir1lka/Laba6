using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba6
{
    public partial class Form1 : Form
    {
        int hour, minute, second;
        bool b = false;

        private void button1_Click(object sender, EventArgs e)
        {

            hour = Convert.ToInt32(textBox1.Text);
            minute = Convert.ToInt32(textBox2.Text);
            second = Convert.ToInt32(textBox3.Text);

            if (hour == 0 & minute == 0 & second == 0)
            {
                MessageBox.Show("Введите время!");
                timer2.Stop();
            }

            timer2.Start();
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            second--;
            if (second == -1)
            {
                minute--;
                second = 59;
            }
            if (minute == -1)
            {
                hour--;
                minute = 59;
            }

            string s_h = "", s_m = "", s_s = "";

            if (second < 10) s_s += "0";
            s_s += second;

            if (minute < 10) s_m += "0";
            s_m += minute;

            if (hour < 10) s_h += "0";
            s_h += hour;

            label1.Text = s_h;
            label2.Text = s_m;
            label3.Text = s_s;

            if (hour == 0 && minute == 0 && second == 0)
            {
                timer2.Stop();
                MessageBox.Show("Время вышло");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            textBox1.Text = hour.ToString();
            textBox2.Text = minute.ToString();
            textBox3.Text = second.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            label1.Text = "00";
            label2.Text = "00";
            label3.Text = "00";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button5.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                maskedTextBox1.Enabled = false;
                timer3.Start();
                button4.Text = "Убрать будильник";
                b = true;
            }
            else if (b == true)
            {
                maskedTextBox1.Text = "";
                timer2.Start();
                maskedTextBox1.Enabled = true;
                button4.Text = "Завести будильник";
                b = false;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (label11.Text == maskedTextBox1.Text + ":00")
            {
                button5.Enabled = true;
                MessageBox.Show("ЛялЯЛял");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            maskedTextBox1.Enabled = true;
            button4.Text = "Завести будильник";
            b = false;
        }

        public Form1()
        {
            InitializeComponent();
            timer2.Stop();
            label1.Text = "00";
            label2.Text = "00";
            label3.Text = "00";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;

            string time = "";

            if (h < 10)
                time += "0";
            time += h + ":";

            if (m < 10)
                time += "0";
            time += m + ":";

            if (s < 10)
                time += "0";
            time += s;

            toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
            toolStripStatusLabel3.Text =    time;

            label11.Text = time;

        }

   
    }
}
