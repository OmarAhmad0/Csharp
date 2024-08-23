namespace BookStoreApp.Users
{
    partial class frmPersonUser
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
            this.us_SelectePerson1 = new BookStoreApp.People.us_SelectePerson();
            this.SuspendLayout();
            // 
            // us_SelectePerson1
            // 
            this.us_SelectePerson1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.us_SelectePerson1.Location = new System.Drawing.Point(0, 0);
            this.us_SelectePerson1.Name = "us_SelectePerson1";
            this.us_SelectePerson1.Size = new System.Drawing.Size(514, 300);
            this.us_SelectePerson1.TabIndex = 0;
            this.us_SelectePerson1.OnPersonSelected += new System.EventHandler<BookStoreApp.People.us_SelectePerson.PeopleEventArgs>(this.us_SelectePerson1_OnPersonSelected);
            // 
            // frmPersonUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 300);
            this.Controls.Add(this.us_SelectePerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPersonUser";
            this.Text = "frmPersonUser";
            this.ResumeLayout(false);

        }

        #endregion

        private People.us_SelectePerson us_SelectePerson1;
    }
}