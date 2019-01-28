﻿namespace Distributions
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
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.numberOfExperimentsTextBox = new System.Windows.Forms.TextBox();
            this.numberOfSequencesTextBox = new System.Windows.Forms.TextBox();
            this.lambdaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.goBernoulliButton = new System.Windows.Forms.Button();
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.meanLabel = new System.Windows.Forms.Label();
            this.varianceLabel = new System.Windows.Forms.Label();
            this.standardDeviationLabel = new System.Windows.Forms.Label();
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.exponentialButton = new System.Windows.Forms.Button();
            this.runsTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.plotView2 = new OxyPlot.WindowsForms.PlotView();
            this.SuspendLayout();
            // 
            // numberOfExperimentsTextBox
            // 
            this.numberOfExperimentsTextBox.Location = new System.Drawing.Point(12, 144);
            this.numberOfExperimentsTextBox.Name = "numberOfExperimentsTextBox";
            this.numberOfExperimentsTextBox.Size = new System.Drawing.Size(100, 20);
            this.numberOfExperimentsTextBox.TabIndex = 0;
            // 
            // numberOfSequencesTextBox
            // 
            this.numberOfSequencesTextBox.Location = new System.Drawing.Point(12, 171);
            this.numberOfSequencesTextBox.Name = "numberOfSequencesTextBox";
            this.numberOfSequencesTextBox.Size = new System.Drawing.Size(100, 20);
            this.numberOfSequencesTextBox.TabIndex = 1;
            // 
            // lambdaTextBox
            // 
            this.lambdaTextBox.Location = new System.Drawing.Point(12, 12);
            this.lambdaTextBox.Name = "lambdaTextBox";
            this.lambdaTextBox.Size = new System.Drawing.Size(100, 20);
            this.lambdaTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trials";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sequences";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lambda";
            // 
            // goBernoulliButton
            // 
            this.goBernoulliButton.Location = new System.Drawing.Point(13, 225);
            this.goBernoulliButton.Name = "goBernoulliButton";
            this.goBernoulliButton.Size = new System.Drawing.Size(75, 23);
            this.goBernoulliButton.TabIndex = 6;
            this.goBernoulliButton.Text = "Go!";
            this.goBernoulliButton.UseVisualStyleBackColor = true;
            this.goBernoulliButton.Click += new System.EventHandler(this.goBernoulliButton_Click);
            // 
            // plotView
            // 
            this.plotView.Location = new System.Drawing.Point(265, 12);
            this.plotView.Name = "plotView";
            this.plotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView.Size = new System.Drawing.Size(523, 426);
            this.plotView.TabIndex = 7;
            this.plotView.Text = "plotView1";
            this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // meanLabel
            // 
            this.meanLabel.AutoSize = true;
            this.meanLabel.Location = new System.Drawing.Point(9, 269);
            this.meanLabel.Name = "meanLabel";
            this.meanLabel.Size = new System.Drawing.Size(37, 13);
            this.meanLabel.TabIndex = 8;
            this.meanLabel.Text = "Mean:";
            // 
            // varianceLabel
            // 
            this.varianceLabel.AutoSize = true;
            this.varianceLabel.Location = new System.Drawing.Point(9, 296);
            this.varianceLabel.Name = "varianceLabel";
            this.varianceLabel.Size = new System.Drawing.Size(52, 13);
            this.varianceLabel.TabIndex = 9;
            this.varianceLabel.Text = "Variance:";
            // 
            // standardDeviationLabel
            // 
            this.standardDeviationLabel.AutoSize = true;
            this.standardDeviationLabel.Location = new System.Drawing.Point(9, 321);
            this.standardDeviationLabel.Name = "standardDeviationLabel";
            this.standardDeviationLabel.Size = new System.Drawing.Size(101, 13);
            this.standardDeviationLabel.TabIndex = 10;
            this.standardDeviationLabel.Text = "Standard Deviation:";
            // 
            // intervalTextBox
            // 
            this.intervalTextBox.Location = new System.Drawing.Point(12, 361);
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.Size = new System.Drawing.Size(100, 20);
            this.intervalTextBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Interval";
            // 
            // exponentialButton
            // 
            this.exponentialButton.Location = new System.Drawing.Point(12, 417);
            this.exponentialButton.Name = "exponentialButton";
            this.exponentialButton.Size = new System.Drawing.Size(75, 23);
            this.exponentialButton.TabIndex = 13;
            this.exponentialButton.Text = "Go 2!";
            this.exponentialButton.UseVisualStyleBackColor = true;
            this.exponentialButton.Click += new System.EventHandler(this.exponentialButton_Click);
            // 
            // runsTextBox
            // 
            this.runsTextBox.Location = new System.Drawing.Point(12, 388);
            this.runsTextBox.Name = "runsTextBox";
            this.runsTextBox.Size = new System.Drawing.Size(100, 20);
            this.runsTextBox.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Runs";
            // 
            // plotView2
            // 
            this.plotView2.Location = new System.Drawing.Point(849, 15);
            this.plotView2.Name = "plotView2";
            this.plotView2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView2.Size = new System.Drawing.Size(548, 423);
            this.plotView2.TabIndex = 16;
            this.plotView2.Text = "plotView1";
            this.plotView2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 522);
            this.Controls.Add(this.plotView2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.runsTextBox);
            this.Controls.Add(this.exponentialButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.intervalTextBox);
            this.Controls.Add(this.standardDeviationLabel);
            this.Controls.Add(this.varianceLabel);
            this.Controls.Add(this.meanLabel);
            this.Controls.Add(this.plotView);
            this.Controls.Add(this.goBernoulliButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lambdaTextBox);
            this.Controls.Add(this.numberOfSequencesTextBox);
            this.Controls.Add(this.numberOfExperimentsTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numberOfExperimentsTextBox;
        private System.Windows.Forms.TextBox numberOfSequencesTextBox;
        private System.Windows.Forms.TextBox lambdaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button goBernoulliButton;
        private OxyPlot.WindowsForms.PlotView plotView;
        private System.Windows.Forms.Label meanLabel;
        private System.Windows.Forms.Label varianceLabel;
        private System.Windows.Forms.Label standardDeviationLabel;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button exponentialButton;
        private System.Windows.Forms.TextBox runsTextBox;
        private System.Windows.Forms.Label label5;
        private OxyPlot.WindowsForms.PlotView plotView2;
    }
}

