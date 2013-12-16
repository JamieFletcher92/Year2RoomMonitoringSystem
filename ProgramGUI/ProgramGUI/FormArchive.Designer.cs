namespace ProgramGUI
{
    partial class FormArchive
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblHumPeak = new System.Windows.Forms.Label();
            this.lblNoisePeak = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTempPeak = new System.Windows.Forms.Label();
            this.lblLightPeak = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblHumAve = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblHumMax = new System.Windows.Forms.Label();
            this.lblHumMin = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblNoiseAve = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNoiseMax = new System.Windows.Forms.Label();
            this.lblNoiseMin = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblLightAve = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLightMax = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLightMin = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDateStats = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTempAve = new System.Windows.Forms.Label();
            this.lblTempMax = new System.Windows.Forms.Label();
            this.lblTempMin = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.nudDays = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.btnPointGraph = new System.Windows.Forms.Button();
            this.btnBoxPlotGraph = new System.Windows.Forms.Button();
            this.btnBarGraph = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLineGraph = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDateGraph = new System.Windows.Forms.TextBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.cbChoice = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 492);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archive Version";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.btnShow);
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtDateStats);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 461);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected Statistics";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblHumPeak);
            this.groupBox6.Controls.Add(this.lblNoisePeak);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.lblTempPeak);
            this.groupBox6.Controls.Add(this.lblLightPeak);
            this.groupBox6.Location = new System.Drawing.Point(41, 321);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(183, 134);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Peak Times";
            // 
            // lblHumPeak
            // 
            this.lblHumPeak.AutoSize = true;
            this.lblHumPeak.Location = new System.Drawing.Point(91, 53);
            this.lblHumPeak.Name = "lblHumPeak";
            this.lblHumPeak.Size = new System.Drawing.Size(15, 16);
            this.lblHumPeak.TabIndex = 1;
            this.lblHumPeak.Text = "0";
            // 
            // lblNoisePeak
            // 
            this.lblNoisePeak.AutoSize = true;
            this.lblNoisePeak.Location = new System.Drawing.Point(91, 103);
            this.lblNoisePeak.Name = "lblNoisePeak";
            this.lblNoisePeak.Size = new System.Drawing.Size(15, 16);
            this.lblNoisePeak.TabIndex = 1;
            this.lblNoisePeak.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Humidity:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Noise:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Temperature:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Light:";
            // 
            // lblTempPeak
            // 
            this.lblTempPeak.AutoSize = true;
            this.lblTempPeak.Location = new System.Drawing.Point(98, 27);
            this.lblTempPeak.Name = "lblTempPeak";
            this.lblTempPeak.Size = new System.Drawing.Size(15, 16);
            this.lblTempPeak.TabIndex = 1;
            this.lblTempPeak.Text = "0";
            // 
            // lblLightPeak
            // 
            this.lblLightPeak.AutoSize = true;
            this.lblLightPeak.Location = new System.Drawing.Point(92, 78);
            this.lblLightPeak.Name = "lblLightPeak";
            this.lblLightPeak.Size = new System.Drawing.Size(15, 16);
            this.lblLightPeak.TabIndex = 1;
            this.lblLightPeak.Text = "0";
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(192, 13);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 6;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblHumAve);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Controls.Add(this.lblHumMax);
            this.groupBox8.Controls.Add(this.lblHumMin);
            this.groupBox8.Controls.Add(this.label20);
            this.groupBox8.Location = new System.Drawing.Point(132, 181);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(120, 134);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Humidity";
            // 
            // lblHumAve
            // 
            this.lblHumAve.AutoSize = true;
            this.lblHumAve.Location = new System.Drawing.Point(67, 103);
            this.lblHumAve.Name = "lblHumAve";
            this.lblHumAve.Size = new System.Drawing.Size(15, 16);
            this.lblHumAve.TabIndex = 1;
            this.lblHumAve.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Minimum:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 103);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "Average:";
            // 
            // lblHumMax
            // 
            this.lblHumMax.AutoSize = true;
            this.lblHumMax.Location = new System.Drawing.Point(70, 69);
            this.lblHumMax.Name = "lblHumMax";
            this.lblHumMax.Size = new System.Drawing.Size(15, 16);
            this.lblHumMax.TabIndex = 1;
            this.lblHumMax.Text = "0";
            // 
            // lblHumMin
            // 
            this.lblHumMin.AutoSize = true;
            this.lblHumMin.Location = new System.Drawing.Point(70, 27);
            this.lblHumMin.Name = "lblHumMin";
            this.lblHumMin.Size = new System.Drawing.Size(15, 16);
            this.lblHumMin.TabIndex = 1;
            this.lblHumMin.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 69);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 16);
            this.label20.TabIndex = 0;
            this.label20.Text = "Maximum:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblNoiseAve);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.lblNoiseMax);
            this.groupBox5.Controls.Add(this.lblNoiseMin);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(6, 181);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(120, 134);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Noise";
            // 
            // lblNoiseAve
            // 
            this.lblNoiseAve.AutoSize = true;
            this.lblNoiseAve.Location = new System.Drawing.Point(67, 103);
            this.lblNoiseAve.Name = "lblNoiseAve";
            this.lblNoiseAve.Size = new System.Drawing.Size(15, 16);
            this.lblNoiseAve.TabIndex = 1;
            this.lblNoiseAve.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Minimum:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Average:";
            // 
            // lblNoiseMax
            // 
            this.lblNoiseMax.AutoSize = true;
            this.lblNoiseMax.Location = new System.Drawing.Point(70, 69);
            this.lblNoiseMax.Name = "lblNoiseMax";
            this.lblNoiseMax.Size = new System.Drawing.Size(15, 16);
            this.lblNoiseMax.TabIndex = 1;
            this.lblNoiseMax.Text = "0";
            // 
            // lblNoiseMin
            // 
            this.lblNoiseMin.AutoSize = true;
            this.lblNoiseMin.Location = new System.Drawing.Point(70, 27);
            this.lblNoiseMin.Name = "lblNoiseMin";
            this.lblNoiseMin.Size = new System.Drawing.Size(15, 16);
            this.lblNoiseMin.TabIndex = 1;
            this.lblNoiseMin.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Maximum:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblLightAve);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.lblLightMax);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lblLightMin);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(132, 41);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(120, 134);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Light";
            // 
            // lblLightAve
            // 
            this.lblLightAve.AutoSize = true;
            this.lblLightAve.Location = new System.Drawing.Point(67, 106);
            this.lblLightAve.Name = "lblLightAve";
            this.lblLightAve.Size = new System.Drawing.Size(15, 16);
            this.lblLightAve.TabIndex = 1;
            this.lblLightAve.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Minimum:";
            // 
            // lblLightMax
            // 
            this.lblLightMax.AutoSize = true;
            this.lblLightMax.Location = new System.Drawing.Point(70, 72);
            this.lblLightMax.Name = "lblLightMax";
            this.lblLightMax.Size = new System.Drawing.Size(15, 16);
            this.lblLightMax.TabIndex = 1;
            this.lblLightMax.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Maximum:";
            // 
            // lblLightMin
            // 
            this.lblLightMin.AutoSize = true;
            this.lblLightMin.Location = new System.Drawing.Point(70, 30);
            this.lblLightMin.Name = "lblLightMin";
            this.lblLightMin.Size = new System.Drawing.Size(15, 16);
            this.lblLightMin.TabIndex = 1;
            this.lblLightMin.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Average:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Date: ";
            // 
            // txtDateStats
            // 
            this.txtDateStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateStats.Location = new System.Drawing.Point(41, 15);
            this.txtDateStats.Name = "txtDateStats";
            this.txtDateStats.Size = new System.Drawing.Size(145, 20);
            this.txtDateStats.TabIndex = 3;
            this.txtDateStats.Text = "DD/MM/YYYY";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTempAve);
            this.groupBox3.Controls.Add(this.lblTempMax);
            this.groupBox3.Controls.Add(this.lblTempMin);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(6, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 134);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Temperature";
            // 
            // lblTempAve
            // 
            this.lblTempAve.AutoSize = true;
            this.lblTempAve.Location = new System.Drawing.Point(66, 106);
            this.lblTempAve.Name = "lblTempAve";
            this.lblTempAve.Size = new System.Drawing.Size(15, 16);
            this.lblTempAve.TabIndex = 1;
            this.lblTempAve.Text = "0";
            // 
            // lblTempMax
            // 
            this.lblTempMax.AutoSize = true;
            this.lblTempMax.Location = new System.Drawing.Point(69, 72);
            this.lblTempMax.Name = "lblTempMax";
            this.lblTempMax.Size = new System.Drawing.Size(15, 16);
            this.lblTempMax.TabIndex = 1;
            this.lblTempMax.Text = "0";
            // 
            // lblTempMin
            // 
            this.lblTempMin.AutoSize = true;
            this.lblTempMin.Location = new System.Drawing.Point(69, 30);
            this.lblTempMin.Name = "lblTempMin";
            this.lblTempMin.Size = new System.Drawing.Size(15, 16);
            this.lblTempMin.TabIndex = 1;
            this.lblTempMin.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Average:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Maximum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Minimum:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.nudDays);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.btnPointGraph);
            this.groupBox7.Controls.Add(this.btnBoxPlotGraph);
            this.groupBox7.Controls.Add(this.btnBarGraph);
            this.groupBox7.Controls.Add(this.chart1);
            this.groupBox7.Controls.Add(this.btnLineGraph);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.txtDateGraph);
            this.groupBox7.Controls.Add(this.btnPlot);
            this.groupBox7.Controls.Add(this.cbChoice);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(295, 25);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(546, 461);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Chart Options";
            // 
            // nudDays
            // 
            this.nudDays.Enabled = false;
            this.nudDays.Location = new System.Drawing.Point(224, 40);
            this.nudDays.Name = "nudDays";
            this.nudDays.Size = new System.Drawing.Size(41, 22);
            this.nudDays.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(271, 44);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Days";
            // 
            // btnPointGraph
            // 
            this.btnPointGraph.Location = new System.Drawing.Point(465, 41);
            this.btnPointGraph.Name = "btnPointGraph";
            this.btnPointGraph.Size = new System.Drawing.Size(75, 23);
            this.btnPointGraph.TabIndex = 11;
            this.btnPointGraph.Text = "Point";
            this.btnPointGraph.UseVisualStyleBackColor = true;
            this.btnPointGraph.Click += new System.EventHandler(this.btnPointGraph_Click);
            // 
            // btnBoxPlotGraph
            // 
            this.btnBoxPlotGraph.Location = new System.Drawing.Point(465, 12);
            this.btnBoxPlotGraph.Name = "btnBoxPlotGraph";
            this.btnBoxPlotGraph.Size = new System.Drawing.Size(75, 23);
            this.btnBoxPlotGraph.TabIndex = 10;
            this.btnBoxPlotGraph.Text = "Box Plot";
            this.btnBoxPlotGraph.UseVisualStyleBackColor = true;
            this.btnBoxPlotGraph.Click += new System.EventHandler(this.btnBoxPlotGraph_Click);
            // 
            // btnBarGraph
            // 
            this.btnBarGraph.Location = new System.Drawing.Point(384, 41);
            this.btnBarGraph.Name = "btnBarGraph";
            this.btnBarGraph.Size = new System.Drawing.Size(75, 23);
            this.btnBarGraph.TabIndex = 9;
            this.btnBarGraph.Text = "Bar";
            this.btnBarGraph.UseVisualStyleBackColor = true;
            this.btnBarGraph.Click += new System.EventHandler(this.btnBarGraph_Click);
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(9, 68);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(531, 387);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnLineGraph
            // 
            this.btnLineGraph.Location = new System.Drawing.Point(384, 12);
            this.btnLineGraph.Name = "btnLineGraph";
            this.btnLineGraph.Size = new System.Drawing.Size(75, 23);
            this.btnLineGraph.TabIndex = 9;
            this.btnLineGraph.Text = "Line";
            this.btnLineGraph.UseVisualStyleBackColor = true;
            this.btnLineGraph.Click += new System.EventHandler(this.btnLineGraph_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Date: ";
            // 
            // txtDateGraph
            // 
            this.txtDateGraph.Enabled = false;
            this.txtDateGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateGraph.Location = new System.Drawing.Point(82, 16);
            this.txtDateGraph.MaxLength = 10;
            this.txtDateGraph.Name = "txtDateGraph";
            this.txtDateGraph.Size = new System.Drawing.Size(145, 20);
            this.txtDateGraph.TabIndex = 7;
            this.txtDateGraph.Text = "DD/MM/YYYY";
            // 
            // btnPlot
            // 
            this.btnPlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlot.Location = new System.Drawing.Point(303, 21);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(75, 23);
            this.btnPlot.TabIndex = 6;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click_1);
            // 
            // cbChoice
            // 
            this.cbChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChoice.FormattingEnabled = true;
            this.cbChoice.Items.AddRange(new object[] {
            "Temperature Readings for Date",
            "Humidity Readings for Date",
            "Light Readings for Date",
            "Noise Readings for Date",
            "Average Temperature/Day for Last",
            "Average Humidity/Day for Last",
            "Average Light/Day for Last",
            "Average Noise/Day for Last"});
            this.cbChoice.Location = new System.Drawing.Point(13, 41);
            this.cbChoice.Name = "cbChoice";
            this.cbChoice.Size = new System.Drawing.Size(205, 21);
            this.cbChoice.TabIndex = 5;
            this.cbChoice.SelectionChangeCommitted += new System.EventHandler(this.cbChoice_SelectionChangeCommitted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(871, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // FormArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormArchive";
            this.Text = "Archive Version";
            this.Load += new System.EventHandler(this.FormArchive_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblNoisePeak;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTempPeak;
        private System.Windows.Forms.Label lblLightPeak;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblNoiseAve;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNoiseMax;
        private System.Windows.Forms.Label lblNoiseMin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblLightAve;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLightMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLightMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTempAve;
        private System.Windows.Forms.Label lblTempMax;
        private System.Windows.Forms.Label lblTempMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDateStats;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDateGraph;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.ComboBox cbChoice;
        private System.Windows.Forms.Button btnBarGraph;
        private System.Windows.Forms.Button btnLineGraph;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lblHumAve;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblHumMax;
        private System.Windows.Forms.Label lblHumMin;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblHumPeak;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnPointGraph;
        private System.Windows.Forms.Button btnBoxPlotGraph;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown nudDays;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

    }
}