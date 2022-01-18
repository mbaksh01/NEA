using System.Drawing;
using System.Windows.Forms;

namespace GlobalWarmingModel
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GlobeImageBox = new System.Windows.Forms.PictureBox();
            this.TempGraph = new System.Windows.Forms.PictureBox();
            this.SeaLevelRiseGraph = new System.Windows.Forms.PictureBox();
            this.CO2Graph = new System.Windows.Forms.PictureBox();
            this.TimelineBar = new System.Windows.Forms.HScrollBar();
            this.TimelineLable = new System.Windows.Forms.Label();
            this.ColourScaleBox = new System.Windows.Forms.PictureBox();
            this.OptionsComboBox = new System.Windows.Forms.ComboBox();
            this.SelectionComboBox = new System.Windows.Forms.ComboBox();
            this.infolabel = new System.Windows.Forms.Label();
            this.TopLabel = new System.Windows.Forms.Label();
            this.BottomLabel = new System.Windows.Forms.Label();
            this.infolabel2 = new System.Windows.Forms.Label();
            this.infolabel3 = new System.Windows.Forms.Label();
            this.InformationBox = new System.Windows.Forms.PictureBox();
            this.MainGraph = new LiveCharts.WinForms.CartesianChart();
            this.AltimeterLabelText = new System.Windows.Forms.Label();
            this.AltimeterLabelAns = new System.Windows.Forms.Label();
            this.MeanLabelAns = new System.Windows.Forms.Label();
            this.MeanLabelText = new System.Windows.Forms.Label();
            this.StDevLabelAns = new System.Windows.Forms.Label();
            this.StDevLabelText = new System.Windows.Forms.Label();
            this.NumericLabelAns = new System.Windows.Forms.Label();
            this.NumericLabelText = new System.Windows.Forms.Label();
            this.YearLabelAns = new System.Windows.Forms.Label();
            this.YearLabelText = new System.Windows.Forms.Label();
            this.TimelineBarToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PointLabel = new System.Windows.Forms.Label();
            this.DrawBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GlobeImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeaLevelRiseGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CO2Graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColourScaleBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformationBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GlobeImageBox
            // 
            this.GlobeImageBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.GlobeImageBox.Location = new System.Drawing.Point(12, 12);
            this.GlobeImageBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GlobeImageBox.Name = "GlobeImageBox";
            this.GlobeImageBox.Size = new System.Drawing.Size(1019, 574);
            this.GlobeImageBox.TabIndex = 0;
            this.GlobeImageBox.TabStop = false;
            this.GlobeImageBox.Tag = "mytag";
            this.GlobeImageBox.Click += new System.EventHandler(this.GlobeImageBox_Click);
            // 
            // TempGraph
            // 
            this.TempGraph.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TempGraph.Location = new System.Drawing.Point(1292, 14);
            this.TempGraph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TempGraph.Name = "TempGraph";
            this.TempGraph.Size = new System.Drawing.Size(291, 235);
            this.TempGraph.TabIndex = 2;
            this.TempGraph.TabStop = false;
            // 
            // SeaLevelRiseGraph
            // 
            this.SeaLevelRiseGraph.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SeaLevelRiseGraph.Location = new System.Drawing.Point(1292, 498);
            this.SeaLevelRiseGraph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SeaLevelRiseGraph.Name = "SeaLevelRiseGraph";
            this.SeaLevelRiseGraph.Size = new System.Drawing.Size(291, 231);
            this.SeaLevelRiseGraph.TabIndex = 3;
            this.SeaLevelRiseGraph.TabStop = false;
            // 
            // CO2Graph
            // 
            this.CO2Graph.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CO2Graph.Location = new System.Drawing.Point(1292, 254);
            this.CO2Graph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CO2Graph.Name = "CO2Graph";
            this.CO2Graph.Size = new System.Drawing.Size(291, 240);
            this.CO2Graph.TabIndex = 4;
            this.CO2Graph.TabStop = false;
            // 
            // TimelineBar
            // 
            this.TimelineBar.Location = new System.Drawing.Point(83, 670);
            this.TimelineBar.Maximum = 2020;
            this.TimelineBar.Minimum = 1980;
            this.TimelineBar.Name = "TimelineBar";
            this.TimelineBar.Size = new System.Drawing.Size(871, 24);
            this.TimelineBar.TabIndex = 1;
            this.TimelineBar.Value = 1980;
            this.TimelineBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Timeline_Bar_Scroll);
            this.TimelineBar.MouseHover += new System.EventHandler(this.Timeline_Bar_MouseHover);
            // 
            // TimelineLable
            // 
            this.TimelineLable.AutoSize = true;
            this.TimelineLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimelineLable.Location = new System.Drawing.Point(460, 621);
            this.TimelineLable.Name = "TimelineLable";
            this.TimelineLable.Size = new System.Drawing.Size(116, 31);
            this.TimelineLable.TabIndex = 6;
            this.TimelineLable.Text = "Timeline";
            // 
            // ColourScaleBox
            // 
            this.ColourScaleBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ColourScaleBox.Location = new System.Drawing.Point(1060, 12);
            this.ColourScaleBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ColourScaleBox.Name = "ColourScaleBox";
            this.ColourScaleBox.Size = new System.Drawing.Size(27, 143);
            this.ColourScaleBox.TabIndex = 7;
            this.ColourScaleBox.TabStop = false;
            // 
            // OptionsComboBox
            // 
            this.OptionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OptionsComboBox.FormattingEnabled = true;
            this.OptionsComboBox.Items.AddRange(new object[] {
            "Sea Level",
            "Carbon Dioxide Levels",
            "Global Temperature",
            "Ice Sheets",
            "Arctic Sea Ice"});
            this.OptionsComboBox.Location = new System.Drawing.Point(1060, 160);
            this.OptionsComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OptionsComboBox.Name = "OptionsComboBox";
            this.OptionsComboBox.Size = new System.Drawing.Size(207, 24);
            this.OptionsComboBox.TabIndex = 8;
            this.OptionsComboBox.SelectedIndexChanged += new System.EventHandler(this.Options_comboBox_SelectedIndexChanged);
            // 
            // SelectionComboBox
            // 
            this.SelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectionComboBox.FormattingEnabled = true;
            this.SelectionComboBox.Items.AddRange(new object[] {
            "Graph",
            "World Map"});
            this.SelectionComboBox.Location = new System.Drawing.Point(1060, 191);
            this.SelectionComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectionComboBox.Name = "SelectionComboBox";
            this.SelectionComboBox.Size = new System.Drawing.Size(207, 24);
            this.SelectionComboBox.TabIndex = 9;
            this.SelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.Selection_comboBox_SelectedIndexChanged);
            // 
            // infolabel
            // 
            this.infolabel.AutoSize = true;
            this.infolabel.Location = new System.Drawing.Point(1192, 498);
            this.infolabel.Name = "infolabel";
            this.infolabel.Size = new System.Drawing.Size(61, 17);
            this.infolabel.TabIndex = 10;
            this.infolabel.Text = "infolabel";
            this.infolabel.Click += new System.EventHandler(this.infolabel_Click);
            // 
            // TopLabel
            // 
            this.TopLabel.AutoSize = true;
            this.TopLabel.Location = new System.Drawing.Point(1092, 11);
            this.TopLabel.Name = "TopLabel";
            this.TopLabel.Size = new System.Drawing.Size(33, 17);
            this.TopLabel.TabIndex = 11;
            this.TopLabel.Text = "Top";
            // 
            // BottomLabel
            // 
            this.BottomLabel.AutoSize = true;
            this.BottomLabel.Location = new System.Drawing.Point(1092, 139);
            this.BottomLabel.Name = "BottomLabel";
            this.BottomLabel.Size = new System.Drawing.Size(52, 17);
            this.BottomLabel.TabIndex = 12;
            this.BottomLabel.Text = "Bottom";
            // 
            // infolabel2
            // 
            this.infolabel2.AutoSize = true;
            this.infolabel2.Location = new System.Drawing.Point(1192, 522);
            this.infolabel2.Name = "infolabel2";
            this.infolabel2.Size = new System.Drawing.Size(61, 17);
            this.infolabel2.TabIndex = 13;
            this.infolabel2.Text = "infolabel";
            // 
            // infolabel3
            // 
            this.infolabel3.AutoSize = true;
            this.infolabel3.Location = new System.Drawing.Point(1192, 549);
            this.infolabel3.Name = "infolabel3";
            this.infolabel3.Size = new System.Drawing.Size(61, 17);
            this.infolabel3.TabIndex = 14;
            this.infolabel3.Text = "infolabel";
            // 
            // InformationBox
            // 
            this.InformationBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.InformationBox.Location = new System.Drawing.Point(1060, 223);
            this.InformationBox.Margin = new System.Windows.Forms.Padding(4);
            this.InformationBox.Name = "InformationBox";
            this.InformationBox.Size = new System.Drawing.Size(205, 362);
            this.InformationBox.TabIndex = 15;
            this.InformationBox.TabStop = false;
            // 
            // MainGraph
            // 
            this.MainGraph.BackColor = System.Drawing.SystemColors.Control;
            this.MainGraph.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainGraph.Location = new System.Drawing.Point(12, 12);
            this.MainGraph.Name = "MainGraph";
            this.MainGraph.Size = new System.Drawing.Size(1019, 574);
            this.MainGraph.TabIndex = 16;
            this.MainGraph.Text = "Graph";
            this.MainGraph.DataClick += new LiveCharts.Events.DataClickHandler(this.MainGraph_DataClick);
            // 
            // AltimeterLabelText
            // 
            this.AltimeterLabelText.AutoSize = true;
            this.AltimeterLabelText.Location = new System.Drawing.Point(1076, 277);
            this.AltimeterLabelText.Name = "AltimeterLabelText";
            this.AltimeterLabelText.Size = new System.Drawing.Size(103, 17);
            this.AltimeterLabelText.TabIndex = 17;
            this.AltimeterLabelText.Text = "Altimeter Type:";
            // 
            // AltimeterLabelAns
            // 
            this.AltimeterLabelAns.AutoSize = true;
            this.AltimeterLabelAns.Location = new System.Drawing.Point(1076, 294);
            this.AltimeterLabelAns.Name = "AltimeterLabelAns";
            this.AltimeterLabelAns.Size = new System.Drawing.Size(30, 17);
            this.AltimeterLabelAns.TabIndex = 18;
            this.AltimeterLabelAns.Text = "N/a";
            // 
            // MeanLabelAns
            // 
            this.MeanLabelAns.AutoSize = true;
            this.MeanLabelAns.Location = new System.Drawing.Point(1076, 381);
            this.MeanLabelAns.Name = "MeanLabelAns";
            this.MeanLabelAns.Size = new System.Drawing.Size(30, 17);
            this.MeanLabelAns.TabIndex = 20;
            this.MeanLabelAns.Text = "N/a";
            // 
            // MeanLabelText
            // 
            this.MeanLabelText.AutoSize = true;
            this.MeanLabelText.Location = new System.Drawing.Point(1076, 364);
            this.MeanLabelText.Name = "MeanLabelText";
            this.MeanLabelText.Size = new System.Drawing.Size(47, 17);
            this.MeanLabelText.TabIndex = 19;
            this.MeanLabelText.Text = "Mean:";
            // 
            // StDevLabelAns
            // 
            this.StDevLabelAns.AutoSize = true;
            this.StDevLabelAns.Location = new System.Drawing.Point(1076, 422);
            this.StDevLabelAns.Name = "StDevLabelAns";
            this.StDevLabelAns.Size = new System.Drawing.Size(30, 17);
            this.StDevLabelAns.TabIndex = 22;
            this.StDevLabelAns.Text = "N/a";
            // 
            // StDevLabelText
            // 
            this.StDevLabelText.AutoSize = true;
            this.StDevLabelText.Location = new System.Drawing.Point(1076, 405);
            this.StDevLabelText.Name = "StDevLabelText";
            this.StDevLabelText.Size = new System.Drawing.Size(133, 17);
            this.StDevLabelText.TabIndex = 21;
            this.StDevLabelText.Text = "Standard Deviation:";
            // 
            // NumericLabelAns
            // 
            this.NumericLabelAns.AutoSize = true;
            this.NumericLabelAns.Location = new System.Drawing.Point(1076, 338);
            this.NumericLabelAns.Name = "NumericLabelAns";
            this.NumericLabelAns.Size = new System.Drawing.Size(30, 17);
            this.NumericLabelAns.TabIndex = 24;
            this.NumericLabelAns.Text = "N/a";
            // 
            // NumericLabelText
            // 
            this.NumericLabelText.AutoSize = true;
            this.NumericLabelText.Location = new System.Drawing.Point(1076, 321);
            this.NumericLabelText.Name = "NumericLabelText";
            this.NumericLabelText.Size = new System.Drawing.Size(132, 17);
            this.NumericLabelText.TabIndex = 23;
            this.NumericLabelText.Text = "Total Observations:";
            // 
            // YearLabelAns
            // 
            this.YearLabelAns.AutoSize = true;
            this.YearLabelAns.Location = new System.Drawing.Point(1075, 249);
            this.YearLabelAns.Name = "YearLabelAns";
            this.YearLabelAns.Size = new System.Drawing.Size(30, 17);
            this.YearLabelAns.TabIndex = 26;
            this.YearLabelAns.Text = "N/a";
            // 
            // YearLabelText
            // 
            this.YearLabelText.AutoSize = true;
            this.YearLabelText.Location = new System.Drawing.Point(1075, 232);
            this.YearLabelText.Name = "YearLabelText";
            this.YearLabelText.Size = new System.Drawing.Size(42, 17);
            this.YearLabelText.TabIndex = 25;
            this.YearLabelText.Text = "Year:";
            // 
            // PointLabel
            // 
            this.PointLabel.AutoSize = true;
            this.PointLabel.Location = new System.Drawing.Point(1077, 547);
            this.PointLabel.Name = "PointLabel";
            this.PointLabel.Size = new System.Drawing.Size(40, 17);
            this.PointLabel.TabIndex = 27;
            this.PointLabel.Text = "Point";
            // 
            // DrawBtn
            // 
            this.DrawBtn.Location = new System.Drawing.Point(1078, 456);
            this.DrawBtn.Name = "DrawBtn";
            this.DrawBtn.Size = new System.Drawing.Size(100, 28);
            this.DrawBtn.TabIndex = 28;
            this.DrawBtn.Text = "Draw";
            this.DrawBtn.UseVisualStyleBackColor = true;
            this.DrawBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1808, 738);
            this.Controls.Add(this.DrawBtn);
            this.Controls.Add(this.PointLabel);
            this.Controls.Add(this.YearLabelAns);
            this.Controls.Add(this.YearLabelText);
            this.Controls.Add(this.NumericLabelAns);
            this.Controls.Add(this.NumericLabelText);
            this.Controls.Add(this.StDevLabelAns);
            this.Controls.Add(this.StDevLabelText);
            this.Controls.Add(this.MeanLabelAns);
            this.Controls.Add(this.MeanLabelText);
            this.Controls.Add(this.AltimeterLabelAns);
            this.Controls.Add(this.AltimeterLabelText);
            this.Controls.Add(this.infolabel3);
            this.Controls.Add(this.infolabel2);
            this.Controls.Add(this.BottomLabel);
            this.Controls.Add(this.TopLabel);
            this.Controls.Add(this.infolabel);
            this.Controls.Add(this.SelectionComboBox);
            this.Controls.Add(this.OptionsComboBox);
            this.Controls.Add(this.ColourScaleBox);
            this.Controls.Add(this.TimelineLable);
            this.Controls.Add(this.TimelineBar);
            this.Controls.Add(this.CO2Graph);
            this.Controls.Add(this.SeaLevelRiseGraph);
            this.Controls.Add(this.TempGraph);
            this.Controls.Add(this.GlobeImageBox);
            this.Controls.Add(this.InformationBox);
            this.Controls.Add(this.MainGraph);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "Form1";
            this.Text = "infolabel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GlobeImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeaLevelRiseGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CO2Graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColourScaleBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformationBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GlobeImageBox;
        private System.Windows.Forms.PictureBox TempGraph;
        private System.Windows.Forms.PictureBox SeaLevelRiseGraph;
        private System.Windows.Forms.PictureBox CO2Graph;
        private System.Windows.Forms.HScrollBar TimelineBar;
        private System.Windows.Forms.Label TimelineLable;
        private System.Windows.Forms.PictureBox ColourScaleBox;
        private System.Windows.Forms.ComboBox OptionsComboBox;
        private System.Windows.Forms.ComboBox SelectionComboBox;
        private Label infolabel;
        private Label TopLabel;
        private Label BottomLabel;
        private Label infolabel2;
        private Label infolabel3;
        private PictureBox InformationBox;
        private LiveCharts.WinForms.CartesianChart MainGraph;
        private Label AltimeterLabelText;
        private Label AltimeterLabelAns;
        private Label MeanLabelAns;
        private Label MeanLabelText;
        private Label StDevLabelAns;
        private Label StDevLabelText;
        private Label NumericLabelAns;
        private Label NumericLabelText;
        private Label YearLabelAns;
        private Label YearLabelText;
        private ToolTip TimelineBarToolTip;
        private Label PointLabel;
        private Button DrawBtn;
    }
}

