using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Windows.Forms.DataVisualization.Charting;



//THIS IS MY CODE WHICH MY PROGRAM WILL USE WHEN RUNNING THE ARCHIVE FORM, THIS FORM IS USED TO DISPLAY ALL THE DATA FROM THE RECORDS
//FILE TO THE USER IN THE FORMAT OF CHARTS, AS WELL AS GIVING THE USER CERTAIN STATISTICS FROM THIS DATA.
namespace ProgramGUI
{
    public partial class FormArchive : Form
    {
        public FormArchive()
        {
            InitializeComponent();
        }

        //---THESE ARE THE VARIABLES WHICH WILL BE NEEDED WITHIN THIS FORM---
        int counter = 0, counter1 = 0, clickCount = 0;
        double dataSum = 0, dataAve = 0;
        string peakTime, listDate;

        //---CREATING ARRAY WITH ENOUGH SPACE TO STORE ALL OF THE DATA FROM THE RECORDS XML FILE---
        string[,] dataRecords = new string[50000, 6];

        //---THIS LIST WILL BE USED FOR ERROR HANDLING LATER ON, WHEN THE USER IS SEARCHING FOR DATA FROM CERTAIN DATES---
        List<String> datesList = new List<String>();

        //---DECLARING THE SERIES WHICH WILL BE NEEDED TO PLOT DATA ON THE CHART---
        Series series1 = new Series(); 

        //---THIS CODE WILL BE EXECUTED WHEN THE FORM LOADS UP---
        private void FormArchive_Load(object sender, EventArgs e)
        {
            //---ADDING THE DECLARED SERIES TO THE CHART SO THAT DATA CAN BE PLOTTED WITHIN THE CHART---
            chart1.Series.Add(series1);

            //SETTING THE DEFAULT CHART TYPE, THE USER CAN LATER CHANGE THIS IF THEY WISH---
            series1.ChartType = SeriesChartType.Line;

            //---NEW INSTANCE OF XMLDOCUMENT, USED TO LOAD THE RECORDS XML FILE INTO THE PROGRAM---
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Records.xml");

            //MOVING TO THE NODES THAT ARE WITHIN THE RECORDS AND READING NODE, THESE ARE THE ROOT NODES WITHIN THE FILE---
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/records/Reading"); 

            //---FOR EACH NODE WITHIN THE ROOT NODES, PERFORM THE FOLLOWING, BASICALLY ITERATING THROUGH THE FILE---
            foreach (XmlNode xmlNode in xmlNodeList)  
            {
                //---ASSIGN THE DATA STORED WITHIN THE "DATE" NODE TO A VARIABLE AND SAVE THIS INTO THE ARRAY---
                string Date = xmlNode["Date"].InnerText;
                dataRecords[counter, 0] = Date;                                                       

                //---STORING THE DATA WITHIN THE "TIME" NODE INTO THE ARRAY, IN THE NEXT COLLUMN---
                string Time = xmlNode["Time"].InnerText;
                dataRecords[counter, 1] = Time;

                //---STORING THE DATA WITHIN THE "TEMPERATURE" NODE INTO THE NEXT COLLUMN IN THE ARRAY---
                string Temperature = xmlNode["Temperature"].InnerText;
                dataRecords[counter, 2] = Temperature; 

                //---STORING THE HUMIDITY DATA FROM THE FILE INTO THE ARRAY---
                string Humidity = xmlNode["Humidity"].InnerText;
                dataRecords[counter, 3] = Humidity;

                //---STORING THE DATA WITHIN THE "LIGHT" NODE INTO THE CORRESPONDING ARRAY COLLUMN---
                string Light = xmlNode["Light"].InnerText;
                dataRecords[counter, 4] = Light;

                //---STORING THE "NOISE" NODES DATA INTO THE CORRECT COLLUMN WITHIN MY ARRAY---
                string Noise = xmlNode["Noise"].InnerText;
                dataRecords[counter, 5] = Noise;

                //---ADDING 1 TO COUNTER EVERY TIME THE NODES HAVE BEEN SAVED, ALLOWS ME TO MOVE THROUGH THE ARRAY TO STORE DATA CORRECTLY---
                counter = counter + 1; 
            }

            //---BUILDING DATES LIST, THIS GIVES ME A LIST CONTAINING ALL THE DATES THAT DATA HAS BEEN COLLECTED, USED FOR ERROR HANDLING LATER---
            for (int i = 0; i < counter; i++)
            {
                if (dataRecords[i, 0] != listDate)
                {
                    listDate = dataRecords[i, 0];
                    datesList.Add(listDate);
                }
            }           
        }

        //---METHOD EXECUTED WHEN THE USER CLICKS THE "SHOW" BUTTON, USED TO DISPLAY CERTAIN STATISTICS FOR A CHOSEN DATE---
        private void btnShow_Click(object sender, EventArgs e)
        {    
            //---ASSIGNING THE DATE THAT THE USER HAS INPUT TO A STRING VARIABLE---
            string date = txtDateStats.Text;

            //---ERROR HANDLING, IF THE INPUT DATE IS WITHIN THE DATES LIST CREATED EARLIER, PERFORM THE FOLLOWING
            //THIS MEANS THAT THERE IS DATA RECORDED FROM THE GIVEN DATE AND THAT THIS CAN BE DISPLAYED TO THE USER---
            if (datesList.Contains(date))
            {
                //---EXECUTE THE STATSHOW METHOD, USED TO DISPLAY ALL THE STATISTICS FOR THE GIVEN DATE TO THE USER---
                statShow(date);
            }
            //---IF THEIR IS NO DATA FOR THE GIVEN DATE, OR AN INVALID INPUT HAS BEEN USED, SHOW AN ERROR MESSAGE INFORMING THE USER---
            else
            {
                MessageBox.Show("Please enter a valid date! (DD/MM/YYYY)");
            }
        }

        //---METHOD FOR DISPLAYING STATISTICS TO THE USER, WHEN CALLED UPON A STRING MUST BE PROVIDED AND IS ASSIGNED TO THE VARIABLE DATE---
        private void statShow(string date)
        {
            //---CALLING UPON THE METHODS FOR FINDING THE MIN,MAX,AVE AND PEAK TIME VALUES RESPECTIVELY
            //AND ASSIGNING THE RETURNED VALUE TO THE TEMPERATURE LABELS---
            lblTempMin.Text = findMinValue(date, 2).ToString();
            lblTempMax.Text = findMaxValue(date, 2).ToString();
            lblTempAve.Text = findAveValue(date, 2).ToString();
            lblTempPeak.Text = findPeakTime(date, 2).ToString();

            //---GATHERING THE STATSTICS FOR THE HUMIDITY DATA AND DISPLAYING THE GATHERED VALUES TO THE USER---
            lblHumMin.Text = findMinValue(date, 3).ToString();
            lblHumMax.Text = findMaxValue(date, 3).ToString();
            lblHumAve.Text = findAveValue(date, 3).ToString();
            lblHumPeak.Text = findPeakTime(date, 3).ToString();

            //---DISPLAYING THE MINIMUM, MAXIMUM AND AVERAGED LIGHT DATA TO THE USER, AND DISPLAYING THE PEAK TIME FOR LIGHT---
            lblLightMin.Text = findMinValue(date, 4).ToString();
            lblLightMax.Text = findMaxValue(date, 4).ToString();
            lblLightAve.Text = findAveValue(date, 4).ToString();
            lblLightPeak.Text = findPeakTime(date, 4).ToString();

            //---USING THE RESPECTIVE METHODS TO ACQUIRE THE CORRECT VALUES FROM THE NOISE DATA AND DISPLAY THEM TO THE USER---
            lblNoiseMin.Text = findMinValue(date, 5).ToString();
            lblNoiseMax.Text = findMaxValue(date, 5).ToString();
            lblNoiseAve.Text = findAveValue(date, 5).ToString();
            lblNoisePeak.Text = findPeakTime(date, 5).ToString();
        }

        //---METHOD EXECUTED WHEN THE USER CLICKS THE PLOT BUTTON, THIS WILL PLOT THE CHOSEN DATA ON THE GRAPH FOR THE USER TO SEE---
        private void btnPlot_Click_1(object sender, EventArgs e)
        {
            //---ASSIGNING THE VALUES OF THE TEXTBOX FOR DATE INPUT AND NUMERICUPDOWN FOR DAY INPUT FROM THE USER, TO VARIABLES---
            string dateInput = txtDateGraph.Text;
            int numberOfDays = Convert.ToInt32(nudDays.Text);

            //---IF THE TEXTBOX USED FOR THE USER TO INPUT A DATE IS ENABLED, DO THE FOLLOWING---
            if (txtDateGraph.Enabled == true)
            {
                //---ERROR HANDLING, IF THE DATE THE USER HAS INPUT IS NOT IN THE DATES LIST, SHOW THE ERROR MESSAGE
                //THIS MEANS THEIR IS NO DATA FOR THE GIVEN DATE, OR IT IS IN AN INVALID FORM AND MUST BE CHANGED---
                if (!datesList.Contains(dateInput))
                {
                    MessageBox.Show("please enter a valid date! (DD/MM/YYYY)");
                }
            }

            //---IF THE USER HAS MADE THIS SELECTION FROM THE COMBOBOX, EXECUTE THE FOLLOWING CODE---
            if (cbChoice.Text == "Temperature Readings for Date")
            {
                //---RUN THE CLEARCHART METHOD, THIS CLEARS THE CHART READY FOR NEW DATA TO BE PLOTTED---
                clearChart();

                //---EXECUTE THE PLOTVALUESDATE METHOD, AND USE THE DATEINPUT AND 2(TEMPERATURE ARRAY COLLUMN) AS THE NEEDED VARIABLES
                plotValuesDate(dateInput, 2);
               
                //---NAME SERIES1 TEMPERATURE SO THE USER KNOWS WHAT HAS BEEN PLOTTED
                series1.Name = "Temperature";                       
            }

            //---IF THE USER WANTS TO SEE THE HUMIDITY READINGS FOR THEIR GIVEN DATE---
            if (cbChoice.Text == "Humidity Readings for Date")
            {
                //--CLEAR THE CHART SO THAT NEW DATA CAN BE PLOTTED---
                clearChart();

                //---USE THIS METHOD TO PLOT THE VALUES ON THE GRAPH---
                plotValuesDate(dateInput, 3); 

                //---NAME THE SERIES HUMIDITY SO THAT THIS SHOWS ON THE LEGEND TO THE USER---
                series1.Name = "Humidity";  
            }

            //---IF THE USER HAS SELECTED LIGHT READINGS FOR DATE FROM THE COMBOBOX BEFORE CLICKING PLOT---
            if (cbChoice.Text == "Light Readings for Date")
            {
                //---CLEAR THE CHART---
                clearChart();

                //---PLOT THE CORRESPONDING VALUES ON THE CHART---
                plotValuesDate(dateInput, 4);

                //---NAME THE SERIES LIGHT---
                series1.Name = "Light";
            }

            //---IF THE USER WISHES TO SEE THE NOISE READINGS FOR THEIR GIVEN DATE---
            if (cbChoice.Text == "Noise Readings for Date")
            {
                //---USE THIS METHOD TO CLEAR THE CHART OF ANY CURRENT DATA---
                clearChart();

                //---USE THIS METHOD TO PLOT THE CORRECT DATA ON THE CHART---
                plotValuesDate(dateInput, 5); 

                //---NAME THE SERIES CORRECTLY CORRESPONDING TO THE DATA THAT HAS BEEN PLOTTED---
                series1.Name = "Noise";
            }

            //---IF THE USER WANTS TO PLOT THE AVERAGE TEMPERATURE FOR THE LAST AMOUNT OF GIVEN DAYS---
            if (cbChoice.Text == "Average Temperature/Day for Last")
            {
                //---CLEAR THE CHART READY TO BE PLOTTED ON---
                clearChart();

                //---ERROR HANDLING, IF THE AMOUNT OF DAYS THE USER HAS SELECTED IS MORE THAN THEIR IS DATA FOR, SHOW THE ERROR MESSAGE---
                if (numberOfDays > datesList.Count)
                {
                    MessageBox.Show("Please select fewer days!");
                }
                //---ELSE, IF THE USER HAS USED A VALID AMOUNT OF DAYS, DO THE FOLLOWING---
                else
                {
                    //---DAYSSELECTION WILL BE THE TOTAL AMOUNT OF DAYS MINUS THE AMOUNT THE USER WISHES TO VIEW
                    //ALLOWS ME TO PLOT THE LAST CERTAIN AMOUNT OF DAYS TO THE USER---
                    int daysSelection = datesList.Count - numberOfDays;

                    //---THE VARIABLE I IS THE VALUE OF DAYSSELECTION (DECLARED ABOVE), WHILE I IS LESS THAN THE TOTAL AMOUNT OF DAYS
                    //EXECUTE THE FOLLOWING AND ADD 1 TO I---
                    for (int i = daysSelection; i < datesList.Count; i++)
                    {
                        //---EXECUTE THE PLOTAVEVALUES METHOD AND PROVIDE THE VARIABLES AS THE DATE STORED IN DATELIST
                        //AND 2 (THE COLLUMN THAT TEMPERATURE DATA IS STORED WITHIN INSIDE THE ARRAY)---
                        plotAveValues(datesList[i], 2);
                    }
                }
            }

            //---IF THE USER WANTS TO SEE THE AVERAGE HUMIDITY FOR A GIVEN AMOUNT OF DAYS---
            if (cbChoice.Text == "Average Humidity/Day for Last")
            {
                //---CLEAR THE CHART---
                clearChart();

                //---ERROR HANDLING, IF THE USER HAS SELECTED TOO MANY DAYS, SHOW THE ERROR MESSAGE ASKING THEM TO SELECT LESS DAYS---
                if (numberOfDays > datesList.Count)
                {
                    MessageBox.Show("Please select fewer days!");
                }
                //---OTHERWISE, EXECUTE THE FOLLOWING CODE---
                else
                {
                    //---USED TO SEARCH THE INDEX OF THE LIST AND FIND THE CORRECT DAYS DATA---
                    int daysSelection = datesList.Count - numberOfDays;

                    //---EXECUTE THIS CODE WHEN I IS STILL LESS THAN THE DATESLIST COUNT---
                    for (int i = daysSelection; i < datesList.Count; i++)
                    {
                        //---USE THIS METHOD TO PLOT THE AVERAGE VALUES FOR THE GIVEN AMOUNT OF DAYS---
                        plotAveValues(datesList[i], 3);
                    }
                }
            }

            //---IF THE USER WANT THE AVERAGE LIGHT FOR THE LAST GIVEN AMOUNT OF DAYS TO BE PLOTTED---
            if (cbChoice.Text == "Average Light/Day for Last")
            {
                //--CLEAR THE CHART USING THIS METHOD---
                clearChart();

                //---IF THE USER WISHES TO PLOT TOO MANY DAYS ON THE CHART INFORM THEM OF THE ERROR---
                if (numberOfDays > datesList.Count)
                {
                    MessageBox.Show("Please select fewer days!");
                }
                //---IF THEY HAVE SELECTED A VALID AMOUNT OF DAYS, EXECUTE THE FOLLOWING CODE---
                else
                {
                    //---DAYSSELECTION EQUALS THE TOTAL COUNT OF THE DATESLIST TAKE AWAY THE AMOUNT OF DAYS THE USER WISHES TO SEE---
                    int daysSelection = datesList.Count - numberOfDays;

                    //---I EQUALS DAYSSELECTION, WHILE THIS IS LESS THAN THE DATESLIST TOTAL COUNT, EXECUTE THE CODE AND ADD 1 TO I---
                    for (int i = daysSelection; i < datesList.Count; i++)
                    {
                        //---USE THIS METHOD TO PLOT THE AVERAGE VALUES FOR EACH REQUIRED DAY FROM THE 4TH ARRAY COLLUMN(LIGHT)---
                        plotAveValues(datesList[i], 4);
                    }
                }
            }

            //---IF THE USER WISHES FOR THE AVERAGE NOISE TO BE PLOTTED FOR THEIR GIVEN AMOUNT OF DAYS, EXECUTE THE FOLLOWING CODE---
            if (cbChoice.Text == "Average Noise/Day for Last")
            {
                //---EXECUTE THIS METHOD, WHICH WILL CLEAR THE CHART---
                clearChart();

                //---IF THE USER WISHES TO MORE DAYS THAN THEIR IS DATA FOR, SHOW THE ERROR MESSAGE---
                if (numberOfDays > datesList.Count)
                {
                    MessageBox.Show("Please select fewer days!");
                }
                //---ELSE, EXECUTE THE FOLLOWING CODE WHICH WILL PLOT THE REQUIRED DATA---
                else
                {
                    //---GETTING THE CORRECT NUMBER USED TO SEARCH THE LIST FOR THE CORRECT DAYS---
                    int daysSelection = datesList.Count - numberOfDays;

                    //---THIS EXECUTES THE FOLLOWING CODE FOR THE CORRECT DAYS TO BE PLOTTED FOR---
                    for (int i = daysSelection; i < datesList.Count; i++)
                    {
                        //---CALL UPON THIS METHOD TO PLOT THE AVERAGE VALUES FOR EACH DAY---
                        plotAveValues(datesList[i], 5);
                    }
                }
            }
        }

        //---THIS METHOD, WHEN EXECUTED, WILL FIND THE MINIMUM VALUE WITHIN A GIVEN PART OF THE ARRAY---
        public double findMinValue(string date, int choice)
        {
            //---VARIABLE FOR MINIMUM VALUE SET AS 10000, SO THERE WILL BE NO VALUES HIGHER THAN THIS IN THE ARRAY---
            double minValue = 10000; 

            //---TRY AND EXECUTE THE FOLLOWING CODE---
            try
            {
                //---FOR EVERY TIME I IS LESS THAN THE VALUE OF COUNTER, EXECUTE THE CODE WITHIN THE LOOP AND ADD 1 TO I---
                for (int i = 1; i < counter; i++)
                {
                    //---CONVERTING THE CORRECT PIECES OF DATA TO A DOUBLE AND A STRING RESPECTIVELY---
                    double dataValue = double.Parse(dataRecords[i, choice]); 
                    string dateValue = dataRecords[i, 0];

                    //---IF THE DATE RETRIEVED FROM THE ARRAY MATCHES THE DATE ASSIGNED TO THE VARIABLE WHEN THIS METHOD WAS CALLED UPON---
                    if (dateValue == date) 
                    {
                        //---IF THE CURRENT VALUE OF DATAVALUE IS LESS THAN THE CURRENT VALUE OF MINVALUE---
                        if (dataValue < minValue)
                        {
                            //---THEN SET THE VALUE OF MINVALUE TO THE SAME CURRENT VALUE OF DATAVALE---
                            minValue = dataValue;
                        }
                    }
                }
            }
            //---IF THE PREVIOUS CODE COULD NOT BE EXECUTED, THEN CATCH THE EXCEPTION, AND DISPLAY THE ERROR MESSAGE---
            catch
            {
                MessageBox.Show("Minimum value can't be found, please try again");
            }

            //---RETURN THE RETRIEVE MINIMUM VALUE TO THE LOCATION THAT THE METHOD WAS CALLED UPON FROM---
            return minValue;
        }
    
        //---METHOD WHICH, WHEN CALLED UPON, WILL LOCATE THE MAXIMUM VALUE WITHIN A GIVEN PART OF THE ARRAY---
        public double findMaxValue(string date, int choice)
        {
            //---ASSIGN MAXVALUE VARIABLE AS 0, SO THEIR WILL BE NO VALUES LOWER THAN THIS WITHIN THE ARRAY---
            double maxValue = 0;
            //---TRY AND EXECUTE THE FOLLOWING CODE---
            try
            {
                //---VALUE OF I IS 1, WHEN I IS LESS THAN THE VALUE OF COUNTER(LENGTH OF ARRAY), EXECUTE THE CODE AND ADD 1 TO I---
                for (int i = 1; i < counter; i++)
                {
                    //---VARIABLES WHICH WILL CONTAIN THE VALUES OF THE GIVEN DATA AND THE DATE WITHIN THE ARRAY---
                    double dataValue = double.Parse(dataRecords[i, choice]);
                    string dateValue = dataRecords[i, 0];  

                    //---IF THE VALUE OF DATEVALUE(FROM THE ARRAY) MATCHES THE VALUE OF DATE (GIVEN WHEN METHOD IS CALLED UPON)---
                    if (dateValue == date)
                    {
                        //---IF THE VALUE IN THE ARRAY IS MORE THAN THE CURRENT VALUE OF MAXVALUE---
                        if (dataValue > maxValue)
                        {
                            //---THEN THE NEW VALUE OF MAXVALUE IS THE CURRENT VALUE FROM THE ARRAY---
                            maxValue = dataValue;
                        }
                    }
                }
            }
            //---CATCH ANY EXCEPTIONS AND SHOW THE GIVEN ERROR MESSAGE IF THE PREVIOUS CODE CAN'T BE EXECUTED---
            catch
            {
                MessageBox.Show("Maximum value can't be found, please try again");
            }
            
            //---RETURN THE VALUE OF MAXVALUE TO WHERE THE METHOD WAS CALLED FROM---
            return maxValue;   
        }

        //---METHOD OR FINDING THE AVERAGE VALUE OF DATA FROM A GIVEN PART OF THE ARRAY---
        public double findAveValue(string date, int choice)
        {
            //---THIS VARIABLE WILL BE USED TO STORE ALL VALUES AND FIND THE SUM OF THESE VALUES---
            double dataSum1 = 0;

            //---TRY AND EXECUTE THE FOLLOWING CODE---
            try
            {
                //---USING I AND THE VALUE OF COUNTER TO ITERATE THROUGH THE ARRAY---
                for (int i = 1; i < counter; i++)
                {
                    //---ASSIGNING THE VALUES OF THE DATE COLLUMN AND THE COLLUMN OF CHOICE(EG TEMP, DECLARED WHEN METHOD IS CALLED UPON)---
                    string dateValue = dataRecords[i, 0];
                    double dataChoice = double.Parse(dataRecords[i, choice]); 

                    //---IF THE VALUE OF DATEVALUE(FROM THE ARRAY) MATCHES THAT OF DATE(ASSIGNED WHEN METHOD IS CALLED UPON)---
                    if (dateValue == date)
                    {
                        //---ADD 1 TO THE VALUE OF COUNTER1, USED TO DIVIDE THE SUM BY, TO GET AVERAGE---
                        counter1++;

                        //---ADDING THE VALUE FROM THE CORRECT PART OF THE ARRAY TO THE CURRENT VALUE OF DATASUM1---
                        dataSum1 = dataSum1 + dataChoice;

                        //---THE AVERAGE WILL NOW BE DATASUM1(TOTAL SUM OF VALUES) DIVIDED BY COUNTER1(TOTAL NUMBER OF VALUES)---
                        dataAve = dataSum1 / counter1;
                    }
                }
            }
            //---IF THE ABOVE CODE CAN'T BE EXECUTED FOR WHATEVER REASON, SHOW THE USER THE ERROR MESSAGE BELOW---
            catch
            {
                MessageBox.Show("Average value can't be found, please try again!");
            }
            //---RESETTING VARIABLE VALUES, READY FOR WHEN THE METHOD IS NEXT CALLED UPON---
            dataSum1 = 0;
            counter1 = 0;

            //---RETURNING THE RETRIEVED AVERAGE TO WHERE METHOD WAS CALLED UPON, AND ROUNDING TO 2 DECIMAL PLACES, FOR PRESENTATION PURPOSES---
            return Math.Round(dataAve, 2);
        }

        //---THIS IS MY METHOD FOR FINDING THE PEAK TIMES FOR GIVEN DATA (THE TIME THAT THE MAXIMUM READING WAS TAKEN)---
        public string findPeakTime(string date, int choice)
        {
            //---VARIABLE USED TO FIND THE MAXIMUM VALUE OF THE GIVEN COLLUMN, SET AS 0 SO THERE ARE NO VALUES LOWER---
            double maxValue = 0;

            //---TRY AND EXECUTE THE FOLLOWING CODE---
            try
            {
                //WHEN I IS LESS THAN COUNTER, EXECUTE THIS CODE AND ADD 1 TO I---
                for (int i = 1; i < counter; i++)
                {
                    //---ASSIGNING VARIABLES WITH THE VALUES OF THE DATE COLLUMN AND THE CHOSEN DATA COLLUMN(GIVEN WHEN METHOD IS CALLED UPON)---
                    double dataValue = double.Parse(dataRecords[i, choice]);
                    string dateValue = dataRecords[i, 0];

                    //---IF THE DATE FROM THE ARRAY MATCHES THAT OF THE DATE GIVEN WHEN METHOD IS CALLED UPON, EXECUTE THE FOLLOWING CODE---
                    if (dateValue == date)
                    {
                        //---IF THE CURRENT VALUE WITHIN THE DATA COLLUMN IS HIGHER THAN THE CURRENT VALUE OF MAXVALUE---
                        if (dataValue > maxValue)
                        {
                            //---SET THIS VALUE AS THE NEW VALUE OF THE MAXVALUE VARIABLE---
                            maxValue = dataValue;

                            //---THE CORRESPONDING TIME OF THIS DATA READING IS NOW ALSO SET AS THE PEAKTIME VARIABLE---
                            peakTime = dataRecords[i, 1];
                        }
                    }
                }
            }
            //---IF THERE IS AN EXCEPTION WITHIN THE PREVIOUS CODE, SHOW THE USER THE FOLLOWING ERROR MESSAGE---
            catch
            {
                MessageBox.Show("Peak time can't be found, please try again!");
            }

            //---RETURN THE RETRIEVED VALUE OF PEAKTIME TO WHEREVER THE METHOD WAS CALLED UPON---
            return peakTime;
        }

        //---THIS IS MY METHOD WHICH, WHEN CALLED UPON, WILL PLOT THE CHOSEN DATA VALUES FOR A GIVEN DATE---
        private void plotValuesDate(string date, int choice)
        {
            //---USING THE VALUES OF I AND COUNTER VARIABLES TO ITERATE THROUGH THE WHOLE ARRAY---
            for (int i = 0; i < counter; i++)
            {
                //---ASSIGNING THE VALUE IN THE DATE COLLUMN OF THE ARRAY TO THE ARRAYDATE VARIABLE---
                string arrayDate = dataRecords[i, 0];

                //---IF THE ARRAYDATE VARIABLE MATCHES THE GIVEN DATE(STATED WHEN METHOD IS CALLED UPON) THEN EXECUTE THE FOLLIWNG CODE---
                if (arrayDate == date)
                {
                    //---PLOT THE DATA FROM THE CORRESPONDING ARRAY COLLUMN TO SERIES1, WHICH HAS BEEN ASSIGNED TO THE CHART1---
                    series1.Points.Add(Convert.ToDouble(dataRecords[i, choice]));
                }
            }
        }

        //---THIS IS MY METHOD FOR PLOTTING THE AVERAGE VALUES OF A GIVEN DATE ONTO THE CHART---
        private void plotAveValues(string date, int choice)
        {
            //---THIS LIST WILL BE USING TO STORE ALL THE ACQUIRED VALUES AND FIND THE AVERAGE OF THESE---
            List<Double> findAverage = new List<Double>();

            //---ITERATING THROUGH THE ARRAY USING THE I AND COUNTER VARIABLES---
            for (int i = 0; i < counter; i++)
            {
                //---IF THE DATE WITHIN THE DATE COLLUMN OF MY ARRAY MATCHES THAT OF THE DATE GIVEN WHEN THE METHOD WAS CALLED UPON---
                if (dataRecords[i, 0] == date)
                {
                    //---ADD THE VALUE FROM THIS DATE WITHIN THE CORRECT COLLUMN OF DATA TO THE FINDAVERAGE LIST---
                    findAverage.Add(Convert.ToDouble(dataRecords[i, choice]));
                }
            }

            //---THE VALUE OF AVEVALUE IS THE SUM OF THE FINDAVERAGE LIST DIVIDED BY THE AMOUNT OF VALUES WITHIN IT, GIVING ME THE AVERAGE---
            double aveValue = findAverage.Sum() / findAverage.Count();

            //---PLOTTING THE CALCULATED AVERAGE FOR THE GIVEN DATE ONTO THE CHART---
            series1.Points.Add(aveValue);
        }

        //---THIS IS MY METHOD WHICH WILL BE USED TO CLEAR THE CHART OF ANY SERIES NAMES AND DATA THAT HAS BEEN PLOTTED WITHIN IT---
        private void clearChart()
        {
            //---IF THE NAME OF SERIES1 IS NOT EMPTY, SO IF IT CURRENTLY HAS ANY NAME---
            if (series1.Name != "") 
            {
                //---THEN RENAME SERIES1 TO NOTHING, SO THAT IT CAN BE RENAMED TO WHAT IS NOW BEING PLOTTED---
                series1.Name = "";  
            }

            //---CLEARING THE SERIES OF ANY VALUES THAT HAVE BEEN PLOTTED WITHIN THEM, SO NEW ONES CAN BE PLOTTED CORRECTLY---
            series1.Points.Clear();  
        }

        //---THIS IS MY METHOD WHICH WILL BE EXECUTED WHEN THE USER MAKES A SELECTION FROM THE COMBOBOX CBCHOICE---
        private void cbChoice_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //---IF THE SELECTION MADE IS EQUAL TO ANY OF THE FOLLOWING POSSIBLE SELECTIONS---
            if (cbChoice.Text == "Temperature Readings for Date" || cbChoice.Text == "Humidity Readings for Date"
                || cbChoice.Text == "Light Readings for Date" || cbChoice.Text == "Noise Readings for Date")
            {
                //---ENABLE THE TEXT BOX ALLOWING THE USER TO INPUT A DATE---
                txtDateGraph.Enabled = true;
                //---DISABLE THE NUMERICUPDOWN, AS THIS IS NOT NEEDED TO PLOT THESE VALUES ON THE CHART---
                nudDays.Enabled = false;
            }

            //---IF THE SELECTION MADE IS EQUAL TO ANY OF THE FOLLOWING OTHER POSSIBLE SELECTIONS---
            if (cbChoice.Text == "Average Temperature/Day for Last" || cbChoice.Text == "Average Humidity/Day for Last"
                || cbChoice.Text == "Average Light/Day for Last" || cbChoice.Text == "Average Noise/Day for Last")
            {
                //---DISABLE THE TEXT BOX, AS THIS IS NOT FOR THESE VALUES TO BE PLOTTED ON THE CHART---
                txtDateGraph.Enabled = false;
                //---ENABLE THE NUMERICUPDOWN SO THAT THE USER CAN SELECT AN AMOUNT OF DAYS TO BE PLOTTED---
                nudDays.Enabled = true;
            }
        }

        //---METHOD EXECUTED WHEN THE USER CLICKS THE LINE GRAPH BUTTON---
        private void btnLineGraph_Click(object sender, EventArgs e)
        {
            //---CHANGING THE SERIES CHART TYPE TO FASTLINE---
            series1.ChartType = SeriesChartType.FastLine;
        }

        //---METHOD TO ALLOW THE USER TO VIEW THE CHART AS A BAR GRAPH---
        private void btnBarGraph_Click(object sender, EventArgs e)
        {
            //---CHANGING THE CHART TYPE TO A COLLUMN(BAR GRAPH)---
            series1.ChartType = SeriesChartType.Column;
        }

        //---METHOD TO CHANGE THE CHART TYPE TO A BOXPLOT CHART---
        private void btnBoxPlotGraph_Click(object sender, EventArgs e)
        {
            //---CHANGING THE CHART TYPE TO A BOXPLOT CHART---
            series1.ChartType = SeriesChartType.BoxPlot;
        }

        //---METHOD WHICH, WHEN THE USER CLICKS THE POINT BUTTON WITHIN CHART OPTIONS, WILL BE EXECUTED---
        private void btnPointGraph_Click(object sender, EventArgs e)
        {
            //---CHANGING THE SERIES CHART TYPE TO A FASTPOINT, SO THAT THE USER WILL BE PRESENTED WITH A POINT CHART---
            series1.ChartType = SeriesChartType.FastPoint;            
        }

        //---METHOD EXECUTED WHEN THE USER SELECTS THE EXIT OPTION FROM THE FILE MENU STRIP---
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //---CLOSES THE PROGRAM---
            this.Close();
        }

    }
}
