namespace Super_Tailor
{
    partial class Home
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateBillingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ubbutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eixtSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomerToolStripMenuItem,
            this.addProductToolStripMenuItem,
            this.generateBillingToolStripMenuItem,
            this.ubbutToolStripMenuItem,
            this.eixtSystemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(930, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // addCustomerToolStripMenuItem
            // 
            this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            this.addCustomerToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.addCustomerToolStripMenuItem.Text = "  Add Customer";
            this.addCustomerToolStripMenuItem.Click += new System.EventHandler(this.addCustomerToolStripMenuItem_Click_1);
            // 
            // addProductToolStripMenuItem
            // 
            this.addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            this.addProductToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.addProductToolStripMenuItem.Text = "    Add Cloth";
            this.addProductToolStripMenuItem.Click += new System.EventHandler(this.addProductToolStripMenuItem_Click);
            // 
            // generateBillingToolStripMenuItem
            // 
            this.generateBillingToolStripMenuItem.Name = "generateBillingToolStripMenuItem";
            this.generateBillingToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.generateBillingToolStripMenuItem.Text = "    Generate Billing";
            this.generateBillingToolStripMenuItem.Click += new System.EventHandler(this.generateBillingToolStripMenuItem_Click);
            // 
            // ubbutToolStripMenuItem
            // 
            this.ubbutToolStripMenuItem.Name = "ubbutToolStripMenuItem";
            this.ubbutToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.ubbutToolStripMenuItem.Text = "About Us";
            this.ubbutToolStripMenuItem.Click += new System.EventHandler(this.ubbutToolStripMenuItem_Click);
            // 
            // eixtSystemToolStripMenuItem
            // 
            this.eixtSystemToolStripMenuItem.Name = "eixtSystemToolStripMenuItem";
            this.eixtSystemToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.eixtSystemToolStripMenuItem.Text = "Eixt System";
            this.eixtSystemToolStripMenuItem.Click += new System.EventHandler(this.eixtSystemToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Super_Tailor.Properties.Resources.bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(930, 440);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateBillingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ubbutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eixtSystemToolStripMenuItem;


    }
}