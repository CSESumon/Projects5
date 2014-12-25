namespace StudentEntryDB_App
{
    partial class Menu
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
            this.menuEntrybutton = new System.Windows.Forms.Button();
            this.menuViewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // menuEntrybutton
            // 
            this.menuEntrybutton.Location = new System.Drawing.Point(74, 59);
            this.menuEntrybutton.Name = "menuEntrybutton";
            this.menuEntrybutton.Size = new System.Drawing.Size(136, 79);
            this.menuEntrybutton.TabIndex = 0;
            this.menuEntrybutton.Text = "Entry";
            this.menuEntrybutton.UseVisualStyleBackColor = true;
            this.menuEntrybutton.Click += new System.EventHandler(this.menuEntrybutton_Click);
            // 
            // menuViewButton
            // 
            this.menuViewButton.Location = new System.Drawing.Point(256, 59);
            this.menuViewButton.Name = "menuViewButton";
            this.menuViewButton.Size = new System.Drawing.Size(150, 79);
            this.menuViewButton.TabIndex = 1;
            this.menuViewButton.Text = "View";
            this.menuViewButton.UseVisualStyleBackColor = true;
            this.menuViewButton.Click += new System.EventHandler(this.menuViewButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.menuViewButton);
            this.Controls.Add(this.menuEntrybutton);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button menuEntrybutton;
        private System.Windows.Forms.Button menuViewButton;
    }
}