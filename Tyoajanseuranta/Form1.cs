using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;

namespace Tyoajanseuranta
{
    public partial class Form1 : Form
    {
        Program.TimerClass firstTimer;
        Program.TimerClass secondTimer;

        public Form1()
        {
            InitializeComponent();
            firstTimer = new Program.TimerClass();      //formiin timeri program.cs:stä voidaan, lisätä timereitä haluttu määrä
            secondTimer = new Program.TimerClass();
        }

        public void setLabel1Text(string text)
        {
            label1.Text = text;
        }


        private void button1_Click(object sender, EventArgs e)      //"nimi1" nappi, radio buttonilla valitaan ensin tila ja työntekijä klikkaa sen jälkeen omaa nimeään
        {
            if (radioButton1.Checked)
            {
                button1.BackColor = Color.LawnGreen;                //jos työmtekijä kirjaa itsensä sisään muuttuu nappi nimen kohdalta vihreäksi.   
                firstTimer.StartTimer();                            //työaikalaskuri käynistyy.
            }

            if (radioButton2.Checked)
            {
                button1.BackColor = Color.Yellow;                   //työntekijä kirjaa itsensä tauolle, laskuri seisahtuu.
                firstTimer.StopTimer();
            }

            if (radioButton3.Checked)
            {
                button1.BackColor = Color.White;                    //työntekijä lähtee töistä, laskuri nollaantuu.
                firstTimer.KillTimer();
            }
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            this.label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button2_Click(object sender, EventArgs e)      //"nimi2" nappi, radio buttonilla valitaan ensin tila ja työntekijä klikkaa sen jälkeen omaa nimeään
        {
            if (radioButton1.Checked)
            {
                button2.BackColor = Color.LawnGreen;
                secondTimer.StartTimer();
            }

            if (radioButton2.Checked)
            {
                button2.BackColor = Color.Yellow;
                secondTimer.StopTimer();
            }

            if (radioButton3.Checked)
            {
                button2.BackColor = Color.White;
                secondTimer.KillTimer();
            }
        }

        private void button3_Click(object sender, EventArgs e)      //työajan tarkistus, nähdään kuinka kauan kukin henkilö on ollu töissä.
        {
            if (textBox1.Text == "nimi1")
            {
                label4.Text = ("työaika: " + firstTimer.elapsedTime);
            }

            else if(textBox1.Text == "nimi2")
            {
                label4.Text = ("työaika: " + secondTimer.elapsedTime);                               
            }

            else
            {
                label4.Text = ("syötä nimi1 tai nimi2.");
            }
        }
    }

    
}
