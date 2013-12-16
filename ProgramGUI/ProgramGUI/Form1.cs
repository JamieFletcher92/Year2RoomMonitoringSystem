using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;



//THIS IS THE CODE FOR MY FORM WHICH THE USER WILL BE PRESENTED WITH WHEN THEY FIRST OPEN MY PROGRAM, THIS FORM ALSO READS IN ALL 
//THE REQUIRED DATA NEEDED FOR MY PROGRAM TO BE ABLE TO RUN AND EXECUTE ALL MY WRITTEN CODE EFFICIENTLY. THE GATHERED DATA WITHIN
//THIS FORM IS ALSO MADE AVAILABLE FOR USE ON THE OTHER FORMS WITHIN MY PROGRAM.
namespace ProgramGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //---THE VARIABLES WHICH WILL BE USED WITHIN THIS FORM---
        public int fileCounter = 0, counter = 0;

        //---THESE ARE THE LISTS THAT WILL BE USED TO STORE ALL THE DATA THAT IS IN THE RECORDS FILE WHEN THE PROGRAM IS LOADED---
        List<string> archiveListDate = new List<string>();
        List<string> archiveListTime = new List<string>();
        List<string> archiveListTemp = new List<string>();
        List<string> archiveListLight = new List<string>();
        List<string> archiveListNoise = new List<string>();
        List<string> archiveListHum = new List<string>();

        //---METHOD FOR RUNNING THE LIVE FORM---
        public static void ThreadProc()
        {
            Application.Run(new FormLive());
        }

        //---METHOD FOR RUNNING THE ARCHIVE FORM---
        public static void ThreadProc1()
        {
            Application.Run(new FormArchive());
        }

        //---THIS METHOD IS EXECUTED WHEN THE FORM IS LOADED BY THE USER, THE RECORDS FILE IS LOADED INTO THE PROGRAM---
        public void Form1_Load(object sender, EventArgs e)
        {
            //---DECLARING A NEW XMLDOCUMENT, AND USING IT TO LOAD THE RECORDS XML FILE READY FOR DATA HANDLING---
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Records.XML");

            //---LOOKING WITHIN THE ROOT AND ROW NODES IN ORDER TO ACCESS THE DATA WITHIN THESE NODES EASILY---
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/root/row");

            //---FOR EACH NODE WITHIN THE ROOT AND ROW NODES, EXECUTE THE FOLLOWING---
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                //---ADD 1 TO FILECOUNTER, ALLOWS ME TO KNOW HOW LARGE THE FILE IS, USEFUL FOR CREATING ARRAY---
                fileCounter = fileCounter + 1;
            }

            //---FOR EACH NODE WITHIN THE ROOT AND ROW NODES, EXECUTE THE FOLLOWING---
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                //---ASSIGN THE DATA WITHIN THE "DATE" NODE TO A STRING, AND STORE THIS IN THE CORRESPONDING LIST---
                string date = xmlNode["Date"].InnerText;
                archiveListDate.Add(date);

                //---ASSIGN THE DATA WITHIN THE "TIME" NODE TO A STRING, AND STORE THIS IN THE CORRESPONDING LIST---
                string time = xmlNode["Time"].InnerText;
                archiveListTime.Add(time);

                //---ASSIGN THE DATA WITHIN THE "TEMPERATURE" NODE TO A STRING, AND STORE THIS IN THE CORRESPONDING LIST---
                string temp = xmlNode["Temperature"].InnerText;
                archiveListTemp.Add(temp);

                //---ASSIGN THE DATA WITHIN THE "HUMIDIITY" NODE TO A STRING, AND STORE THIS IN THE CORRESPONDING LIST---
                string hum = xmlNode["Humidity"].InnerText;
                archiveListHum.Add(hum);

                //---ASSIGN THE DATA WITHIN THE "LIGHT" NODE TO A STRING, AND STORE THIS IN THE CORRESPONDING LIST---
                string light = xmlNode["Light"].InnerText;
                archiveListLight.Add(light);

                //---ASSIGN THE DATA WITHIN THE "NOISE" NODE TO A STRING, AND STORE THIS IN THE CORRESPONDING LIST---
                string noise = xmlNode["Noise"].InnerText;
                archiveListNoise.Add(noise);

                //---COUNTER USED TO STORE THE SIZE OF THE RECORDS FILE---
                counter = counter + 1;
            }
        }

        //---METHOD WHICH IS EXECUTED WHEN THE USER CLICKS THE "LIVE" BUTTON---
        private void btnLive_Click(object sender, EventArgs e)
        {
            //---EXECUTING EARLIER METHOD AND USING THIS TO START THE LIVE FORM---
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
        }

        //---METHOD WHICH IS EXECUTED WHEN THE USER CLICKS THE "ARCHIVE" BUTTON---
        private void btnArchive_Click(object sender, EventArgs e)
        {
            //---EXECUTING EARLIER METHOD AND USING THIS TO START THE ARCHIVE FORM---
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc1));
            t.Start();
        }

        //---PUBLIC METHOD WHICH CAN CALLED UPON FROM OTHER FORMS, WHEN EXECUTED RETURNS THE LIST CONTAINING ALL OF THE "DATE" DATA---
        public List<String> GetListDate()
        {
            return archiveListDate;
        }

        //---PUBLIC METHOD USED FOR RETURNING ALL OF THE DATA WITHIN THE "TIME" LIST---
        public List<String> GetListTime()
        {
            return archiveListTime;
        }

        //---PUBLIC METHOD USED FOR RETURNING THE TEMPERATURE DATA FROM THE RECORDS FILE, WHICH IS SAVED WITHIN THE TEMPERATURE LIST---
        public List<String> GetListTemp()
        {
            return archiveListTemp;
        }

        //---PUBLIC METHOD USED FOR RETURNING ALL OF THE LIGHT DATA---
        public List<String> GetListLight()
        {
            return archiveListLight;
        }

        //---PUBLIC METHOD USED FOR RETURNING ALL OF THE NOISE DATA TO WHERE THE METHOD WAS CALLED UPON---
        public List<String> GetListNoise()
        {
            return archiveListNoise;
        }

        //---PUBLIC METHOD USED FOR RETURNING THE HUMIDITY DATA FOR USE WITH WHERE THE METHOD WAS CALLED UPON---
        public List<String> GetListHum()
        {
            return archiveListHum;
        }

    }
}
