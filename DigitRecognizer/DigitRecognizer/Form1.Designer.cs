namespace DigitRecognizer
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numberToPredict = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.predictedNumber = new System.Windows.Forms.Label();
            this.predict = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clear = new System.Windows.Forms.Button();
            this.Train = new System.Windows.Forms.Button();
            this.octaveOutput = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(24, 58);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 162);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // numberToPredict
            // 
            this.numberToPredict.AutoSize = true;
            this.numberToPredict.Location = new System.Drawing.Point(59, 28);
            this.numberToPredict.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numberToPredict.Name = "numberToPredict";
            this.numberToPredict.Size = new System.Drawing.Size(90, 15);
            this.numberToPredict.TabIndex = 1;
            this.numberToPredict.Text = "Draw digit here";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 349);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(150, 19);
            this.progressBar1.TabIndex = 3;
            // 
            // predictedNumber
            // 
            this.predictedNumber.AutoSize = true;
            this.predictedNumber.Location = new System.Drawing.Point(272, 295);
            this.predictedNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.predictedNumber.Name = "predictedNumber";
            this.predictedNumber.Size = new System.Drawing.Size(26, 15);
            this.predictedNumber.TabIndex = 4;
            this.predictedNumber.Text = "N/A";
            // 
            // predict
            // 
            this.predict.Location = new System.Drawing.Point(114, 242);
            this.predict.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.predict.Name = "predict";
            this.predict.Size = new System.Drawing.Size(60, 24);
            this.predict.TabIndex = 5;
            this.predict.Text = "Predict";
            this.predict.UseVisualStyleBackColor = true;
            this.predict.Click += new System.EventHandler(this.predict_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(24, 242);
            this.clear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(60, 24);
            this.clear.TabIndex = 6;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Train
            // 
            this.Train.CausesValidation = false;
            this.Train.Location = new System.Drawing.Point(24, 279);
            this.Train.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Train.Name = "Train";
            this.Train.Size = new System.Drawing.Size(150, 31);
            this.Train.TabIndex = 7;
            this.Train.Text = "Train";
            this.Train.UseVisualStyleBackColor = true;
            this.Train.Click += new System.EventHandler(this.Train_Click);
            // 
            // octaveOutput
            // 
            this.octaveOutput.AutoSize = true;
            this.octaveOutput.Location = new System.Drawing.Point(22, 322);
            this.octaveOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.octaveOutput.Name = "octaveOutput";
            this.octaveOutput.Size = new System.Drawing.Size(87, 15);
            this.octaveOutput.TabIndex = 8;
            this.octaveOutput.Text = "Octave output: ";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(198, 58);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(171, 56);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 378);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.octaveOutput);
            this.Controls.Add(this.Train);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.predict);
            this.Controls.Add(this.predictedNumber);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.numberToPredict);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Digit Recognizer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label numberToPredict;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label predictedNumber;
        private System.Windows.Forms.Button predict;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button Train;
        private System.Windows.Forms.Label octaveOutput;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

