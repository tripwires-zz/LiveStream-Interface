namespace Tripwires.LiveStream.Interface
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblChannelName = new System.Windows.Forms.Label();
            this.txtChannelName = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lstVods = new System.Windows.Forms.ListBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblVodType = new System.Windows.Forms.Label();
            this.pcbThumbnail = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChannelName
            // 
            resources.ApplyResources(this.lblChannelName, "lblChannelName");
            this.lblChannelName.Name = "lblChannelName";
            // 
            // txtChannelName
            // 
            resources.ApplyResources(this.txtChannelName, "txtChannelName");
            this.txtChannelName.Name = "txtChannelName";
            // 
            // btnConnect
            // 
            resources.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lstVods
            // 
            this.lstVods.FormattingEnabled = true;
            resources.ApplyResources(this.lstVods, "lstVods");
            this.lstVods.Name = "lstVods";
            this.lstVods.SelectedValueChanged += new System.EventHandler(this.lstVods_SelectedValueChanged);
            // 
            // btnDownload
            // 
            resources.ApplyResources(this.btnDownload, "btnDownload");
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1")});
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            // 
            // lblVodType
            // 
            resources.ApplyResources(this.lblVodType, "lblVodType");
            this.lblVodType.Name = "lblVodType";
            // 
            // pcbThumbnail
            // 
            resources.ApplyResources(this.pcbThumbnail, "pcbThumbnail");
            this.pcbThumbnail.Name = "pcbThumbnail";
            this.pcbThumbnail.TabStop = false;
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.pcbThumbnail);
            this.Controls.Add(this.lblVodType);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lstVods);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtChannelName);
            this.Controls.Add(this.lblChannelName);
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbThumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChannelName;
        private System.Windows.Forms.TextBox txtChannelName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox lstVods;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblVodType;
        private System.Windows.Forms.PictureBox pcbThumbnail;
        private System.Windows.Forms.Button btnUpdate;
    }
}

