
namespace InvestingIncubator
{
    partial class JobSimulator
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
            this.Title = new System.Windows.Forms.Label();
            this.collapseablePanel1 = new InvestingIncubator.JobItem(Job.RocketSurgeon);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.collapseablePanel2 = new InvestingIncubator.JobItem(Job.RubbishCollector);
            this.collapseablePanel3 = new InvestingIncubator.JobItem(Job.RocketSurgeon);
            this.collapseablePanel9 = new InvestingIncubator.JobItem(Job.Waiter);
            this.collapseablePanel8 = new InvestingIncubator.JobItem(Job.RocketSurgeon);
            this.collapseablePanel7 = new InvestingIncubator.JobItem(Job.RubbishCollector);
            this.collapseablePanel10 = new InvestingIncubator.JobItem(Job.RocketSurgeon);
            this.collapseablePanel11 = new InvestingIncubator.JobItem(Job.RocketSurgeon);
            this.collapseablePanel12 = new InvestingIncubator.JobItem(Job.RocketSurgeon);
            this.collapseablePanel13 = new InvestingIncubator.JobItem(Job.RocketSurgeon);
            this.collapseablePanel14 = new InvestingIncubator.JobItem(Job.RocketSurgeon);
            this.collapseablePanel15 = new InvestingIncubator.JobItem(Job.RocketSurgeon);
            this.collapseablePanel16 = new InvestingIncubator.JobItem(Job.RocketSurgeon);
            this.collapseablePanel17 = new InvestingIncubator.JobItem(Job.RocketSurgeon);
            this.collapseablePanel18 = new InvestingIncubator.JobItem(Job.RocketSurgeon);
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(12, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(158, 28);
            this.Title.TabIndex = 0;
            this.Title.Text = "Available jobs";
            // 
            // collapseablePanel1
            // 
            this.collapseablePanel1.Location = new System.Drawing.Point(3, 3);
            this.collapseablePanel1.Name = "collapseablePanel1";
            this.collapseablePanel1.Size = new System.Drawing.Size(200, 25);
            this.collapseablePanel1.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.collapseablePanel1);
            this.flowLayoutPanel1.Controls.Add(this.collapseablePanel2);
            this.flowLayoutPanel1.Controls.Add(this.collapseablePanel3);
            this.flowLayoutPanel1.Controls.Add(this.collapseablePanel10);
            this.flowLayoutPanel1.Controls.Add(this.collapseablePanel11);
            this.flowLayoutPanel1.Controls.Add(this.collapseablePanel12);
            this.flowLayoutPanel1.Controls.Add(this.collapseablePanel13);
            this.flowLayoutPanel1.Controls.Add(this.collapseablePanel14);
            this.flowLayoutPanel1.Controls.Add(this.collapseablePanel15);
            this.flowLayoutPanel1.Controls.Add(this.collapseablePanel16);
            this.flowLayoutPanel1.Controls.Add(this.collapseablePanel17);
            this.flowLayoutPanel1.Controls.Add(this.collapseablePanel18);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 56);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(650, 6000);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(650, 524);
            this.flowLayoutPanel1.TabIndex = 11;
    //        this.flowLayoutPanel1.ClientSizeChanged += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            // 
            // collapseablePanel2
            // 
            this.collapseablePanel2.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel2.Location = new System.Drawing.Point(3, 34);
            this.collapseablePanel2.Name = "collapseablePanel2";
            this.collapseablePanel2.Size = new System.Drawing.Size(200, 22);
            this.collapseablePanel2.TabIndex = 11;
            // 
            // collapseablePanel3
            // 
            this.collapseablePanel3.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel3.Location = new System.Drawing.Point(3, 62);
            this.collapseablePanel3.Name = "collapseablePanel3";
            this.collapseablePanel3.Size = new System.Drawing.Size(200, 22);
            this.collapseablePanel3.TabIndex = 12;
            // 
            // collapseablePanel9
            // 
            this.collapseablePanel9.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel9.Location = new System.Drawing.Point(3, 59);
            this.collapseablePanel9.Name = "collapseablePanel9";
            this.collapseablePanel9.Size = new System.Drawing.Size(200, 22);
            this.collapseablePanel9.TabIndex = 12;
            // 
            // collapseablePanel8
            // 
            this.collapseablePanel8.Location = new System.Drawing.Point(3, 31);
            this.collapseablePanel8.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel8.Name = "collapseablePanel8";
            this.collapseablePanel8.Size = new System.Drawing.Size(200, 22);
            this.collapseablePanel8.TabIndex = 11;
            // 
            // collapseablePanel7
            // 
            this.collapseablePanel7.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel7.Location = new System.Drawing.Point(3, 3);
            this.collapseablePanel7.Name = "collapseablePanel7";
            this.collapseablePanel7.Size = new System.Drawing.Size(200, 22);
            this.collapseablePanel7.TabIndex = 10;



            // 
            // collapseablePanel10
            // 
            this.collapseablePanel10.Location = new System.Drawing.Point(3, 90);
            this.collapseablePanel10.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel10.Name = "collapseablePanel10";
            this.collapseablePanel10.Size = new System.Drawing.Size(200, 25);
            this.collapseablePanel10.TabIndex = 13;
            // 
            // collapseablePanel11
            // 
            this.collapseablePanel11.Location = new System.Drawing.Point(3, 121);
            this.collapseablePanel11.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel11.Name = "collapseablePanel11";
            this.collapseablePanel11.Size = new System.Drawing.Size(200, 22);
            this.collapseablePanel11.TabIndex = 14;
            // 
            // collapseablePanel12
            // 
            this.collapseablePanel12.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel12.Location = new System.Drawing.Point(3, 149);
            this.collapseablePanel12.Name = "collapseablePanel12";
            this.collapseablePanel12.Size = new System.Drawing.Size(200, 22);
            this.collapseablePanel12.TabIndex = 15;
            // 
            // collapseablePanel13
            // 
            this.collapseablePanel13.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel13.Location = new System.Drawing.Point(3, 177);
            this.collapseablePanel13.Name = "collapseablePanel13";
            this.collapseablePanel13.Size = new System.Drawing.Size(200, 25);
            this.collapseablePanel13.TabIndex = 16;
            // 
            // collapseablePanel14
            // 
            this.collapseablePanel14.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel14.Location = new System.Drawing.Point(3, 208);
            this.collapseablePanel14.Name = "collapseablePanel14";
            this.collapseablePanel14.Size = new System.Drawing.Size(200, 22);
            this.collapseablePanel14.TabIndex = 17;
            // 
            // collapseablePanel15
            // 
            this.collapseablePanel15.Location = new System.Drawing.Point(3, 236);
            this.collapseablePanel15.Name = "collapseablePanel15";
            this.collapseablePanel15.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel15.Size = new System.Drawing.Size(200, 22);
            this.collapseablePanel15.TabIndex = 18;
            // 
            // collapseablePanel16
            // 
            this.collapseablePanel16.Location = new System.Drawing.Point(3, 264);
            this.collapseablePanel16.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel16.Name = "collapseablePanel16";
            this.collapseablePanel16.Size = new System.Drawing.Size(200, 25);
            this.collapseablePanel16.TabIndex = 19;
            // 
            // collapseablePanel17
            // 
            this.collapseablePanel17.Location = new System.Drawing.Point(3, 295);
            this.collapseablePanel17.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel17.Name = "collapseablePanel17";
            this.collapseablePanel17.Size = new System.Drawing.Size(200, 22);
            this.collapseablePanel17.TabIndex = 20;
            // 
            // collapseablePanel18
            // 
            this.collapseablePanel18.Location = new System.Drawing.Point(3, 323);
            this.collapseablePanel18.DropDown += new System.EventHandler(this.flowLayoutPanel1_ClientSizeChanged);
            this.collapseablePanel18.Name = "collapseablePanel18";
            this.collapseablePanel18.Size = new System.Drawing.Size(200, 22);
            this.collapseablePanel18.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // JobSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 592);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Title);
            this.Name = "JobSimulator";
            this.Text = "JobSimulator";
            this.Load += new System.EventHandler(this.JobSimulator_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private JobItem collapseablePanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private JobItem collapseablePanel2;
        private JobItem collapseablePanel3;
        private JobItem collapseablePanel9;
        private JobItem collapseablePanel8;
        private JobItem collapseablePanel7;
        private JobItem collapseablePanel10;
        private JobItem collapseablePanel11;
        private JobItem collapseablePanel12;
        private JobItem collapseablePanel13;
        private JobItem collapseablePanel14;
        private JobItem collapseablePanel15;
        private JobItem collapseablePanel16;
        private JobItem collapseablePanel17;
        private JobItem collapseablePanel18;
        private System.Windows.Forms.Label label1;
    }
}