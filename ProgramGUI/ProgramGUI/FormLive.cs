using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Collections;
using System.Xml;

//THIS IS THE CODE FOR MY FORM WHICH WILL PRESENT THE USER WITH LIVE DATA FEEDBACK FROM THE ARDUINO
//DEVICE AND SHOW CERTAIN STATISTICS GATHERED FROM THE RECEIVED DATA, AS WELL AS GIVING THE USER
//THE OPTION TO SAVE THE GATHERED DATA TO THE PROGRAMS XML RECORDS FILE FOR FUTURE ANALYSIS.

namespace ProgramGUI
{
    public partial class FormLive : Form
    {
        public FormLive()
        {
            InitializeComponent();
        }

        //---VARIABLES FOR USE WITHIN THIS FORM
        int counter = 0, fileCounter = 0;
        int count = 0, countArray = 0, countCSV = 0, XMLCount = 0, countSeconds = 0, countMinutes = 0, countHours = 0;
        int csvLength = 0;

        //---NEW INSTANCE OF FORM1, USED TO GATHER DATA FROM XML RECORDS FILE---
        Form1 Form1 = new Form1();

        //---LISTS USED FOR STORING DATA, MAKES IT EASIER TO SAVE TO XML---
        List<String> liveListDate = new List<String>();
        List<String> liveListTime = new List<String>();
        List<double> liveListTemp = new List<double>();  //LIST FOR LIVE RECORDS BEING READ IN ****WRITE TO ARRAY SO ALL DATA IS STORED TOGETHER BUT CALCULATE CURRENT LIVE VALUES FROM THIS***
        List<double> liveListLight = new List<double>();
        List<double> liveListNoise = new List<double>();
        List<double> liveListHum = new List<double>();

        //---NEW INSTANCE OF XMLDOCUMENT, USED TO LOAD AND SAVE TO THE XML RECORDS FILE---
        XmlDocument addDoc = new XmlDocument();

        //---METHOD EXECUTED WHEN USER CLICKS THE START BUTTON, THE TIMER AND SERIAL PORT ARE ENABLED, EXECUTING THOSE METHODS---
        private void btnStart_Click_1(object sender, EventArgs e)
        {
            //---STARTING TIMER AND OPENING SERIAL PORT TO READ IN DATA---
            timer1.Enabled = true;
            serialPort1.Open();
        }

        //---METHOD EXECUTED WHEN USER CLICKS THE STOP BUTTON, TIMER AND SERIAL PORT ARE DISABLED, STOPPING THE EXECUTION OF THOSE METHODS---
        private void btnStop_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            serialPort1.Close();
        }

        //---METHOD EXECUTED WHEN USER CLICKS THE SAVE BUTTON---
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //---SAVING THE GATHERED DATA BY CALLING UPON THIS METHOD---
            saveData();
        }

        //---METHOD CONTAINING CODE TO BE EXECUTED EACH TIME THE TIMER TICKS(EVERY 1000 MILLISECONDS)---
        private void timer1_Tick(object sender, EventArgs e)
        {
            //---DISPLAYING THE CURRENT RUN TIME OF PROGRAM TO THE USER---
            lblSeconds.Text = countSeconds.ToString();
            lblMinutes.Text = countMinutes.ToString();
            lblHours.Text = countHours.ToString();

            //---COUNT IS INCREASED BY 1 EVERY SECONDS(TIMER TICK)---
            count = count + 1;
            countSeconds = countSeconds + 1;

            //---EVERY 60 SECONDS, RESET THE SECONDS COUNT AND INCREASE MINUTES COUNT BY 1---
            if (countSeconds == 60)
            {
                countSeconds = 0;
                countMinutes = countMinutes + 1;

                //---EVERY 60 MINUTES, RESET THE MINUTES COUNT AND INCREASE HOURS COUNT BY 1---
                if (countMinutes == 60)
                {
                    countMinutes = 0;
                    countHours = countHours + 1;
                }
            }

            //---TRY AND EXECUTE THE FOLLOWING CODE---
            try
            {
                //---CONVERT THE DATA RECEIVED FROM THE ARDUINO INTO A DOUBLE, AND ASSIGN IT TO THE VARIABLE---
                double readIn = Convert.ToDouble(serialPort1.ReadLine());

                //---GETTING THE CURRENT DATE AND TIME AND ASSIGNING IT TO VARIABLES AND LABELS FOR THE USER TO SEE---
                string dateNow = DateTime.Now.ToShortDateString();
                string timeNow = DateTime.Now.ToLongTimeString();
                lblDateNow.Text = dateNow.ToString();
                lblTimeNow.Text = timeNow.ToString();

                //---ADDING THE CURRENT DATE AND TIME TO THE LISTS, TO BE STORED INTO XML IF USER NEEDS SAVES DATA---
                liveListDate.Add(dateNow);
                liveListTime.Add(timeNow);

                //---IF RECEIVED DATA IS LESS THAN 1000(THIS IS THE TEMPERATURE SENSOR DATA)---
                if (readIn < 1000)
                {
                    //---VARIABLES FOR USE WITH TEMPERATURE DATA---
                    double tempLive = 0, tempMin = 0, tempMax = 0, tempAve = 0;

                    //---ASSIGNING RECEIVED DATA TO TEMPERATURE VARIABLE---
                    tempLive = readIn;

                    //---DISPLAYING RECEIVED DATA ON THE CHART FOR THE USER TO SEE---
                    chart1.Series["tempSeries"].Points.Add(tempLive);

                    //---ADDING RECEIVED DATA TO LIST, USED TO GET STATISTICS, AND LATER WITH XML---
                    liveListTemp.Add(tempLive); 

                    //---DISPLAYING CURRENT TEMPERATURE TO THE USER---
                    lblLiveTemp.Text = tempLive.ToString();

                    //---GETTING THE MINIMUM TEMPERATURE AND DISPLAYING TO THE USER---
                    tempMin = liveListTemp.Min();
                    lblMinTemp.Text = tempMin.ToString();

                    //---GETTING THE MAXIMUM TEMPERATURE AND DISPLAYING TO THE USER---
                    tempMax = liveListTemp.Max();
                    lblMaxTemp.Text = tempMax.ToString();

                    //---GETTING THE AVERAGE TEMPERATURE AND DISPLAYING TO THE USER---                    
                    tempAve = Math.Round((liveListTemp.Sum() / liveListTemp.Count()), 2);
                    lblTempAve.Text = tempAve.ToString();
                }

                //---IF THE RECEIVED DATA IS BETWEEN 1000 AND 10000(THIS IS THE LIGHT DATA)---
                if (readIn > 1000 && readIn < 10000)
                {
                    //---VARIABLES FOR USE WITH THE LIGHT DATA---
                    double lightLive = 0, lightMin = 0, lightMax = 0, lightAve = 0;

                    //---ASSIGNING RECEIVED DATA TO LIGHT VARIABLES, MINUS 1000 TO GIVE THE USER THE ACCURATE READING---
                    lightLive = readIn - 1000;

                    //---PLOTTING THE LIGHT DATA ON THE CHART IF THE USER WISHES TO SEE IT---
                    chart2.Series["lightSeries"].Points.Add(lightLive); 

                    //---ADDING THE LIGHT DATA TO THE LIGHT LIST, USED FOR CALCULATIONS AND LATER TO SAVE DATA---
                    liveListLight.Add(lightLive);
                    
                    //---DISPLAYING CURRENT LIGT READING TO THE USER---
                    lblLiveLight.Text = lightLive.ToString();

                    //---GATHERING THE MINIMUM LIGHT READ AND DISPLAYING IT TO THE USER---
                    lightMin = liveListLight.Min();
                    lblMinLight.Text = lightMin.ToString();

                    //---GATHERING THE MAXIMUM RECORDED LIGHT AND DISPLAYING TO THE USER---
                    lightMax = liveListLight.Max();
                    lblMaxLight.Text = lightMax.ToString();

                    //---CALCULATING THE AVERAGE OF ALL LIGHT READINGS AND DISPLAYING TO THE USER---
                    lightAve = Math.Round((liveListLight.Sum() / liveListLight.Count()), 2);
                    lblAveLight.Text = lightAve.ToString();
                }

                //---IF RECEIVED DATA IS OVER 10000(THIS IS THE NOISE SENSOR DATA)---
                if (readIn > 10000 && readIn < 100000)
                {
                    //---VARIABLES FOR USER WITH THE NOISE DATA VALUES---
                    double noiseLive = 0, noiseMin = 0, noiseMax = 0, noiseAve = 0;

                    //--ASSIGNING THE RECEIVED DATA TO NOISE VARIABLES, MINUS 10000 THAT I ADDED WITHIN ARDUINO BEFORE SENDING HERE---
                    noiseLive = readIn - 10000;

                    //---PLOTTING NOISE DATA ON THE NOISE CHART---
                    chart3.Series["noiseSeries"].Points.Add(noiseLive);

                    //---ADDING NOISE DATA VALUES TO THE NOISE LIST---
                    liveListNoise.Add(noiseLive);

                    //---DISPLAYING CURRENT NOISE READING TO THE USER---
                    lblLiveNoise.Text = noiseLive.ToString();

                    //---GETTING THE MINIMUM NOISE READING AND DISPLAYING IT TO THE USER---
                    noiseMin = liveListNoise.Min();
                    lblMinNoise.Text = noiseMin.ToString();

                    //--- GETTING THE MAXIMUM NOISE READING AND DISPLAYING IT TO THE USER---
                    noiseMax = liveListNoise.Max();
                    lblMaxNoise.Text = noiseMax.ToString();
                    
                    //---CALCULATING THE AVERAGE OF THE NOISE VALUES AND DISPLAYING TO THE USER---
                    noiseAve = Math.Round((liveListNoise.Sum() / liveListNoise.Count()), 2);
                    lblAveNoise.Text = noiseAve.ToString();
                }
                //---IF RECEIVED DATA FROM SERIAL PORT IS OVER 100000 (THIS IS THE HUMIDITY DATA)---
                if (readIn > 100000)
                {
                    //---VARIABLES FOR USER WITH THE HUMIDITY DATA VALUES---
                    double humLive = 0, humMin = 0, humMax = 0, humAve = 0;

                    //--ASSIGNING THE RECEIVED DATA TO HUMIDITY VARIABLES, MINUS 100000 THAT I ADDED WITHIN ARDUINO BEFORE SENDING HERE---
                    humLive = readIn - 100000;

                    //---PLOTTING HUMIDITY DATA ON THE NOISE CHART---
                    chart4.Series["humSeries"].Points.Add(humLive);

                    //---ADDING HUMIDITY DATA VALUES TO THE NOISE LIST---
                    liveListHum.Add(humLive);

                    //---DISPLAYING CURRENT HUMDIITY READING TO THE USER---
                    lblLiveHum.Text = humLive.ToString();

                    //---GETTING THE MINIMUM HUMIDITY READING AND DISPLAYING IT TO THE USER---
                    humMin = liveListHum.Min();
                    lblMinHum.Text = humMin.ToString();

                    //--- GETTING THE MAXIMUM HUMIDITY READING AND DISPLAYING IT TO THE USER---
                    humMax = liveListHum.Max();
                    lblMaxHum.Text = humMax.ToString();

                    //---CALCULATING THE AVERAGE OF THE HUMIDITY VALUES AND DISPLAYING TO THE USER---
                    humAve = Math.Round((liveListHum.Sum() / liveListHum.Count()), 2);
                    lblAveHum.Text = humAve.ToString();
                }
            }
            //---IF THAT CODE CAN'T BE EXECUTED, THROW AN EXCEPTION, CLOSE SERIAL PORT AND SHOW ERROR MESSAGE---
            catch (System.IO.IOException)
            {
                serialPort1.Close();
                MessageBox.Show("The Arduino device can't be communicated with");
            }
        }

        //---THIS IS MY METHOD FOR DISPLAYING THE TEMPERATURE CHART TO THE USER---
        private void btnTempChart_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
        }

        //---THIS IS MY METHOD FOR DISPLAYING THE LIGHT CHART TO THE USER---
        private void btnLightChart_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = true;
            chart3.Visible = false;
            chart4.Visible = false;
        }

        //---THIS IS MY METHOD FOR DISPLAYING THE NOISE CHART TO THE USER---
        private void btnNoiseChart_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = true;
            chart4.Visible = false;
        }

        //---THIS IS MY METHOD FOR DISPLAYING THE HUMIDITY CHART TO THE USER---
        private void btnHumChart_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = true;
        }  

        //---METHOD FOR SAVING ALL THE GATHERED DATA TO THE EXISTING RECORDS XML FILE WHEN CALLED UPON---
        private void saveData()
        {
            //---USING FORM1 TO GATHER DATA FROM THE XML RECORDS FILE AND SAVE THE DATA INTO LISTS---
            List<string> archiveListDate = Form1.GetListDate();
            List<string> archiveListTime = Form1.GetListTime();
            List<string> archiveListTemp = Form1.GetListTemp();
            List<string> archiveListLight = Form1.GetListLight();
            List<string> archiveListNoise = Form1.GetListNoise();
            List<string> archiveListHum = Form1.GetListHum();

            //---CREATING LISTS CONTAINING STRINGS OF ALL RECEIVED DATA FROM THIS PROGRAM SESSION---
            List<string> stringListTemp = liveListTemp.ConvertAll<string>(x => x.ToString());
            List<string> stringListLight = liveListLight.ConvertAll<string>(x => x.ToString());
            List<string> stringListNoise = liveListNoise.ConvertAll<string>(x => x.ToString());
            List<string> stringListHum = liveListHum.ConvertAll<string>(x => x.ToString());

            //---COMBINING THE LISTS FROM THE RECORDS FILE WITH LISTS CONTAINING NEW DATA, THAT NEEDS SAVING---
            archiveListDate.AddRange(liveListDate);
            archiveListTime.AddRange(liveListTime);
            archiveListTemp.AddRange(stringListTemp);
            archiveListLight.AddRange(stringListLight);
            archiveListNoise.AddRange(stringListNoise);
            archiveListHum.AddRange(stringListHum);

            //---LIST USED TO GET THE LENGTH OF THE OTHER LISTS COMBINED---
            List<int> listLengthList = new List<int>();

            //---ADDING THE COUNTS OF ALL LISTS TO THE LISTLENGTHLIST LIST---
            listLengthList.Add(archiveListDate.Count);
            listLengthList.Add(archiveListTime.Count);
            listLengthList.Add(archiveListTemp.Count);
            listLengthList.Add(archiveListLight.Count);
            listLengthList.Add(archiveListNoise.Count);
            listLengthList.Add(archiveListHum.Count);

            //---GETTING THE MINIMUM VALUE IN THIS LIST, THIS WILL BE THE LENGTH OF THE SMALLEST LIST USED WITHIN THIS PROCESS---
            int listLength = listLengthList.Min();

            //---USING XMLDOCUMENT TO LOAD THE XML RECORDS FILE---
            addDoc.Load("Records.xml");

            //---FOR LOOP USED TO SAVE ALL THE DATA WITHIN THE LISTS, THIS WILL ITERATE UNTILL THE VALUE OF THE LISTLENGTH, THIS IS SO THERES NO BLANK BITS OF DATA---
            for (int i = 0; i < listLength; i++)
            {
                //---READING INTO THE XML FILE, INTO THE CORRECT NODES WHERE THE DATA NEEDS TO BE SAVED---
                XmlNodeList nodeList = addDoc.SelectNodes("/records/Reading");

                //---ADDING A NEW ELEMENT FOR EACH COLLECTION OF DATA TO BE SAVED---
                XmlElement element1 = addDoc.CreateElement("Reading");
                addDoc.DocumentElement.AppendChild(element1);

                //---CREATING AN ELEMENT CALLED DATE AND SAVING THE VALUE IN THE DATE LIST---
                XmlElement element2 = addDoc.CreateElement("Date");
                element2.InnerText = archiveListDate[i];
                element1.AppendChild(element2);

                //---CREAING AN ELEMENT CALLED TIME AND SAVING THE VALUE IN THE TIME LIST---
                element2 = addDoc.CreateElement("Time");
                element2.InnerText = archiveListTime[i];
                element1.AppendChild(element2);

                //---CREATING AN ELEMENT CALLED TEMPERATURE AND SAVING THE VALUE IN THE TEMPERATURE LIST---
                element2 = addDoc.CreateElement("Temperature");
                element2.InnerText = archiveListTemp[i];
                element1.AppendChild(element2);

                element2 = addDoc.CreateElement("Humidity");
                element2.InnerText = archiveListHum[i];
                element1.AppendChild(element2);

                //---CREATING AN ELEMENT CALLED LIGHT AND SAVING THE VALUE IN THE LIGHT LIST---
                element2 = addDoc.CreateElement("Light");
                element2.InnerText = archiveListLight[i];
                element1.AppendChild(element2);

                //---CREATING AN ELEMENT CALLED NOISE AND SAVING THE VALUE IN THE NOISE LIST---
                element2 = addDoc.CreateElement("Noise");
                element2.InnerText = archiveListNoise[i];
                element1.AppendChild(element2);
            }
            //---SAVING THE NEW, UPDATED, XML FILE TO THE RECORDS FILE---
            addDoc.Save("Records.xml");
        }

        //---METHOD EXECUTED WHEN THE USER SELECTS THE EXIT OPTION FROM THE FILE MENU---
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //---CLOSING THIS FORM---
            this.Close();
        }

        //---METHOD EXECUTED WHEN THE USER SELECTS THE SAVE OPTION FROM THE FILE MENU---
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //---SAVING DATA BY CALLING UPON THIS METHOD TO DO SO---
            saveData();
        }      
    }
}
