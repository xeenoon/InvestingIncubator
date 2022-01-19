
using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace InvestingIncubator
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.slider1Val = new System.Windows.Forms.Label();
            this.slider2Val = new System.Windows.Forms.Label();
            this.percentagediff1 = new System.Windows.Forms.Label();
            this.sliderLine1 = new System.Windows.Forms.Panel();
            this.sliderLine2 = new System.Windows.Forms.Panel();
            this.sliderHandle1 = new System.Windows.Forms.PictureBox();
            this.sliderHandle2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sliderLine4 = new System.Windows.Forms.Panel();
            this.sliderLine3 = new System.Windows.Forms.Panel();
            this.percentageDiff2 = new System.Windows.Forms.Label();
            this.slider4Val = new System.Windows.Forms.Label();
            this.slider3Val = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sharename1 = new System.Windows.Forms.Label();
            this.sharename2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sliderHandle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderHandle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(601, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // slider1Val
            // 
            this.slider1Val.AutoSize = true;
            this.slider1Val.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slider1Val.Location = new System.Drawing.Point(48, 348);
            this.slider1Val.Name = "slider1Val";
            this.slider1Val.Size = new System.Drawing.Size(0, 21);
            this.slider1Val.TabIndex = 3;
            // 
            // slider2Val
            // 
            this.slider2Val.AutoSize = true;
            this.slider2Val.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slider2Val.Location = new System.Drawing.Point(294, 348);
            this.slider2Val.Name = "slider2Val";
            this.slider2Val.Size = new System.Drawing.Size(0, 21);
            this.slider2Val.TabIndex = 4;
            // 
            // percentagediff1
            // 
            this.percentagediff1.AutoSize = true;
            this.percentagediff1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentagediff1.Location = new System.Drawing.Point(134, 387);
            this.percentagediff1.Name = "percentagediff1";
            this.percentagediff1.Size = new System.Drawing.Size(0, 26);
            this.percentagediff1.TabIndex = 5;
            // 
            // sliderLine1
            // 
            this.sliderLine1.BackColor = System.Drawing.Color.Red;
            this.sliderLine1.ForeColor = System.Drawing.Color.Red;
            this.sliderLine1.Location = new System.Drawing.Point(165, 28);
            this.sliderLine1.Name = "sliderLine1";
            this.sliderLine1.Size = new System.Drawing.Size(2, 244);
            this.sliderLine1.TabIndex = 6;
            // 
            // sliderLine2
            // 
            this.sliderLine2.BackColor = System.Drawing.Color.Red;
            this.sliderLine2.ForeColor = System.Drawing.Color.Red;
            this.sliderLine2.Location = new System.Drawing.Point(205, 28);
            this.sliderLine2.Name = "sliderLine2";
            this.sliderLine2.Size = new System.Drawing.Size(2, 244);
            this.sliderLine2.TabIndex = 7;
            // 
            // sliderHandle1
            // 
            this.sliderHandle1.Image = ((System.Drawing.Image)(resources.GetObject("sliderHandle1.Image")));
            this.sliderHandle1.InitialImage = null;
            this.sliderHandle1.Location = new System.Drawing.Point(157, 19);
            this.sliderHandle1.Name = "sliderHandle1";
            this.sliderHandle1.Size = new System.Drawing.Size(10, 10);
            this.sliderHandle1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sliderHandle1.TabIndex = 8;
            this.sliderHandle1.TabStop = false;
            this.sliderHandle1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sliderHandle1_MouseDown);
            this.sliderHandle1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sliderHandle1_MouseMove);
            this.sliderHandle1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sliderHandle1_MouseUp);
            // 
            // sliderHandle2
            // 
            this.sliderHandle2.Image = ((System.Drawing.Image)(resources.GetObject("sliderHandle2.Image")));
            this.sliderHandle2.InitialImage = null;
            this.sliderHandle2.Location = new System.Drawing.Point(205, 19);
            this.sliderHandle2.Name = "sliderHandle2";
            this.sliderHandle2.Size = new System.Drawing.Size(10, 10);
            this.sliderHandle2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sliderHandle2.TabIndex = 9;
            this.sliderHandle2.TabStop = false;
            this.sliderHandle2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sliderHandle2_MouseDown);
            this.sliderHandle2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sliderHandle2_MouseMove);
            this.sliderHandle2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sliderHandle2_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(186, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Days";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(9, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Price";
            // 
            // chart1
            // 
            this.chart1.CausesValidation = false;
            chartArea1.AxisX2.Title = "Days";
            chartArea1.AxisY2.Title = "Price";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(8, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(402, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(601, 185);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Visible = false;
            // 
            // chart2
            // 
            this.chart2.CausesValidation = false;
            chartArea2.AxisX2.Title = "Days";
            chartArea2.AxisY2.Title = "Price";
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(472, 12);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(402, 300);
            this.chart2.TabIndex = 13;
            this.chart2.Text = "magicChart1";
            this.chart2.Visible = false;
            // 
            // sliderLine4
            // 
            this.sliderLine4.BackColor = System.Drawing.Color.Red;
            this.sliderLine4.ForeColor = System.Drawing.Color.Red;
            this.sliderLine4.Location = new System.Drawing.Point(676, 28);
            this.sliderLine4.Name = "sliderLine4";
            this.sliderLine4.Size = new System.Drawing.Size(2, 244);
            this.sliderLine4.TabIndex = 15;
            this.sliderLine4.Visible = false;
            // 
            // sliderLine3
            // 
            this.sliderLine3.BackColor = System.Drawing.Color.Red;
            this.sliderLine3.ForeColor = System.Drawing.Color.Red;
            this.sliderLine3.Location = new System.Drawing.Point(636, 28);
            this.sliderLine3.Name = "sliderLine3";
            this.sliderLine3.Size = new System.Drawing.Size(2, 244);
            this.sliderLine3.TabIndex = 14;
            this.sliderLine3.Visible = false;
            // 
            // percentageDiff2
            // 
            this.percentageDiff2.AutoSize = true;
            this.percentageDiff2.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentageDiff2.Location = new System.Drawing.Point(600, 378);
            this.percentageDiff2.Name = "percentageDiff2";
            this.percentageDiff2.Size = new System.Drawing.Size(0, 26);
            this.percentageDiff2.TabIndex = 18;
            // 
            // slider4Val
            // 
            this.slider4Val.AutoSize = true;
            this.slider4Val.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slider4Val.Location = new System.Drawing.Point(760, 339);
            this.slider4Val.Name = "slider4Val";
            this.slider4Val.Size = new System.Drawing.Size(0, 21);
            this.slider4Val.TabIndex = 17;
            // 
            // slider3Val
            // 
            this.slider3Val.AutoSize = true;
            this.slider3Val.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slider3Val.Location = new System.Drawing.Point(514, 339);
            this.slider3Val.Name = "slider3Val";
            this.slider3Val.Size = new System.Drawing.Size(0, 21);
            this.slider3Val.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(650, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Days";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(473, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Price";
            this.label2.Visible = false;
            // 
            // sharename1
            // 
            this.sharename1.AutoSize = true;
            this.sharename1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sharename1.Location = new System.Drawing.Point(12, 315);
            this.sharename1.Name = "sharename1";
            this.sharename1.Size = new System.Drawing.Size(0, 16);
            this.sharename1.TabIndex = 21;
            this.sharename1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // sharename2
            // 
            this.sharename2.AutoSize = true;
            this.sharename2.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sharename2.Location = new System.Drawing.Point(473, 315);
            this.sharename2.Name = "sharename2";
            this.sharename2.Size = new System.Drawing.Size(0, 16);
            this.sharename2.TabIndex = 22;
            this.sharename2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(877, 450);
            this.Controls.Add(this.sharename2);
            this.Controls.Add(this.sharename1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.percentageDiff2);
            this.Controls.Add(this.slider4Val);
            this.Controls.Add(this.slider3Val);
            this.Controls.Add(this.sliderLine4);
            this.Controls.Add(this.sliderLine3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sliderHandle2);
            this.Controls.Add(this.sliderHandle1);
            this.Controls.Add(this.sliderLine2);
            this.Controls.Add(this.sliderLine1);
            this.Controls.Add(this.percentagediff1);
            this.Controls.Add(this.slider2Val);
            this.Controls.Add(this.slider1Val);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(893, 489);
            this.MinimumSize = new System.Drawing.Size(893, 489);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Share history";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sliderHandle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderHandle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label slider1Val;
        private System.Windows.Forms.Label slider2Val;
        private System.Windows.Forms.Label percentagediff1;
        private System.Windows.Forms.Panel sliderLine1;
        private System.Windows.Forms.Panel sliderLine2;
        private System.Windows.Forms.PictureBox sliderHandle1;
        private System.Windows.Forms.PictureBox sliderHandle2;
        private Chart chart1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private Chart chart2;
        private System.Windows.Forms.Panel sliderLine4;
        private System.Windows.Forms.Panel sliderLine3;
        private System.Windows.Forms.Label percentageDiff2;
        private System.Windows.Forms.Label slider4Val;
        private System.Windows.Forms.Label slider3Val;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sharename1;
        private System.Windows.Forms.Label sharename2;
    }
}