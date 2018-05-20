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
    static class Program
    {
        static Form1 myForm;                                                            //alustetaan Form1 myFormiksi
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            myForm = new Form1();                                                     //luodaan Form1:stä uusi form
            Application.Run(myForm);                                                  //käsketään ohjelman ajaa "myForm"
        }

        public class TimerClass                                                       //luodaan ajastimelle luokka
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();     //luodaan itse timer
            Stopwatch stopwatch = new Stopwatch();                                    //käytetään stopwatchia timerissä, timeriin tarvittavien ominaisuuksien takia

            public TimeSpan workingtime;                                              //alustetaan working time myöhempää käyttöä varten
            public string elapsedTime;
            public void StartTimer()                                                  //timerin aloituksen contruktuuri
            {
                timer1.Interval = 1000;                                               //timer interval, eli määritetään kuinka useasti timer tikittää (sekunnin välein)
                timer1.Enabled = true;                                                // timerin käynnistys komento
                stopwatch.Start();
                timer1.Tick += timer1_Tick;                                           //timer jatkaa laskemista ylöspäin
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                myForm.setLabel1Text(stopwatch.ElapsedMilliseconds.ToString());       //timerin tikittäessä päivittää joka tikin formiin label1:seen
            }
            public void StopTimer()                                                   //Pysäytetään timer
            {
                stopwatch.Stop();
                timer1.Enabled = false;
            }
            public void KillTimer()                                                   //timerin sulkeminen kun työntekijä lähtee töistä, tallentaa timerin workingtimeen
            {
                workingtime = stopwatch.Elapsed;                                      //asetetaan työaika luettavaan muotoon käyttäjälle
                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                workingtime.Hours, workingtime.Minutes, workingtime.Seconds);
                stopwatch.Reset();
                timer1.Dispose();
                myForm.setLabel1Text("bye");
            }
        }
    }
}
