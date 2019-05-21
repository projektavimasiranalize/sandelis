namespace WorkerEnvironment.Forms
{
    partial class BaseForm
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
            this.timeLabel = new System.Windows.Forms.Label();
            this.finishButton = new System.Windows.Forms.Button();
            this.taskLabel = new System.Windows.Forms.Label();
            this.taskPlaceLabel = new System.Windows.Forms.Label();
            this.placeDescLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.timeDescLabel = new System.Windows.Forms.Label();
            this.noTasksLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Khaki;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(-6, -5);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(523, 113);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "00:00";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timeLabel.Click += new System.EventHandler(this.timeLabel_Click);
            // 
            // finishButton
            // 
            this.finishButton.BackColor = System.Drawing.Color.PaleGreen;
            this.finishButton.FlatAppearance.BorderSize = 0;
            this.finishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishButton.Location = new System.Drawing.Point(-18, 561);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(535, 187);
            this.finishButton.TabIndex = 1;
            this.finishButton.Text = "BAIGTI";
            this.finishButton.UseVisualStyleBackColor = false;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // taskLabel
            // 
            this.taskLabel.BackColor = System.Drawing.Color.Transparent;
            this.taskLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskLabel.Location = new System.Drawing.Point(32, 293);
            this.taskLabel.Name = "taskLabel";
            this.taskLabel.Size = new System.Drawing.Size(443, 65);
            this.taskLabel.TabIndex = 2;
            this.taskLabel.Text = "name";
            this.taskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // taskPlaceLabel
            // 
            this.taskPlaceLabel.BackColor = System.Drawing.Color.Transparent;
            this.taskPlaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskPlaceLabel.Location = new System.Drawing.Point(32, 177);
            this.taskPlaceLabel.Name = "taskPlaceLabel";
            this.taskPlaceLabel.Size = new System.Drawing.Size(443, 67);
            this.taskPlaceLabel.TabIndex = 2;
            this.taskPlaceLabel.Text = "Vieta";
            this.taskPlaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.taskPlaceLabel.Click += new System.EventHandler(this.taskPlaceLabel_Click);
            // 
            // placeDescLabel
            // 
            this.placeDescLabel.AutoSize = true;
            this.placeDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.placeDescLabel.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeDescLabel.Location = new System.Drawing.Point(197, 143);
            this.placeDescLabel.Name = "placeDescLabel";
            this.placeDescLabel.Size = new System.Drawing.Size(113, 34);
            this.placeDescLabel.TabIndex = 2;
            this.placeDescLabel.Text = "VIETA:";
            this.placeDescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.LightCoral;
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.Location = new System.Drawing.Point(-1, -5);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(118, 113);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "<";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // timeDescLabel
            // 
            this.timeDescLabel.AutoSize = true;
            this.timeDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeDescLabel.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeDescLabel.Location = new System.Drawing.Point(106, 259);
            this.timeDescLabel.Name = "timeDescLabel";
            this.timeDescLabel.Size = new System.Drawing.Size(295, 34);
            this.timeDescLabel.TabIndex = 2;
            this.timeDescLabel.Text = "VYKDYMO LAIKAS:";
            this.timeDescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // noTasksLabel
            // 
            this.noTasksLabel.BackColor = System.Drawing.Color.Transparent;
            this.noTasksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noTasksLabel.Location = new System.Drawing.Point(32, 111);
            this.noTasksLabel.Name = "noTasksLabel";
            this.noTasksLabel.Size = new System.Drawing.Size(433, 447);
            this.noTasksLabel.TabIndex = 4;
            this.noTasksLabel.Text = "Aprašymas";
            this.noTasksLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.noTasksLabel.Visible = false;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.BackgroundImage = global::WorkerEnvironment.Properties.Resources.asdas;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(504, 731);
            this.Controls.Add(this.noTasksLabel);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.timeDescLabel);
            this.Controls.Add(this.placeDescLabel);
            this.Controls.Add(this.taskPlaceLabel);
            this.Controls.Add(this.taskLabel);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.timeLabel);
            this.DoubleBuffered = true;
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Worker window";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Label taskLabel;
        private System.Windows.Forms.Label taskPlaceLabel;
        private System.Windows.Forms.Label placeDescLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label timeDescLabel;
        private System.Windows.Forms.Label noTasksLabel;
    }
}