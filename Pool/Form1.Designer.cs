namespace _8Pool
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
            this.poolTable4 = new _8Pool.PoolTable();
            this.poolTable3 = new _8Pool.PoolTable();
            this.poolTable2 = new _8Pool.PoolTable();
            this.poolTable1 = new _8Pool.PoolTable();
            this.SuspendLayout();
            // 
            // poolTable4
            // 
            this.poolTable4.BackColor = System.Drawing.Color.Black;
            this.poolTable4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.poolTable4.HourlyRate = 10F;
            this.poolTable4.Location = new System.Drawing.Point(415, 319);
            this.poolTable4.Name = "poolTable4";
            this.poolTable4.Size = new System.Drawing.Size(389, 275);
            this.poolTable4.TabIndex = 3;
            this.poolTable4.TablePlayer = "Player3";
            this.poolTable4.TableTitle = "Table";
            this.poolTable4.OnTableComplete += new System.EventHandler<_8Pool.PoolTable.TableCompletedEventArgs>(this.poolTable_OnTableComplete);
            this.poolTable4.Load += new System.EventHandler(this.poolTable4_Load);
            // 
            // poolTable3
            // 
            this.poolTable3.BackColor = System.Drawing.Color.Black;
            this.poolTable3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.poolTable3.HourlyRate = 10F;
            this.poolTable3.Location = new System.Drawing.Point(415, 29);
            this.poolTable3.Name = "poolTable3";
            this.poolTable3.Size = new System.Drawing.Size(389, 275);
            this.poolTable3.TabIndex = 2;
            this.poolTable3.TablePlayer = "Player2";
            this.poolTable3.TableTitle = "Table";
            this.poolTable3.OnTableComplete += new System.EventHandler<_8Pool.PoolTable.TableCompletedEventArgs>(this.poolTable_OnTableComplete);
            // 
            // poolTable2
            // 
            this.poolTable2.BackColor = System.Drawing.Color.Black;
            this.poolTable2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.poolTable2.HourlyRate = 10F;
            this.poolTable2.Location = new System.Drawing.Point(22, 319);
            this.poolTable2.Name = "poolTable2";
            this.poolTable2.Size = new System.Drawing.Size(389, 275);
            this.poolTable2.TabIndex = 1;
            this.poolTable2.TablePlayer = "Player4";
            this.poolTable2.TableTitle = "Table";
            this.poolTable2.OnTableComplete += new System.EventHandler<_8Pool.PoolTable.TableCompletedEventArgs>(this.poolTable_OnTableComplete);
            // 
            // poolTable1
            // 
            this.poolTable1.BackColor = System.Drawing.Color.Black;
            this.poolTable1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.poolTable1.HourlyRate = 10F;
            this.poolTable1.Location = new System.Drawing.Point(22, 29);
            this.poolTable1.Name = "poolTable1";
            this.poolTable1.Size = new System.Drawing.Size(389, 275);
            this.poolTable1.TabIndex = 0;
            this.poolTable1.TablePlayer = "Player1";
            this.poolTable1.TableTitle = "Table1";
            this.poolTable1.OnTableComplete += new System.EventHandler<_8Pool.PoolTable.TableCompletedEventArgs>(this.poolTable_OnTableComplete);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(837, 605);
            this.Controls.Add(this.poolTable4);
            this.Controls.Add(this.poolTable3);
            this.Controls.Add(this.poolTable2);
            this.Controls.Add(this.poolTable1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private PoolTable poolTable1;
        private PoolTable poolTable3;
        private PoolTable poolTable4;
        private PoolTable poolTable2;
    }
}

