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
            this.cmbVodType = new System.Windows.Forms.ComboBox();
            this.lblVodType = new System.Windows.Forms.Label();
            this.pcbThumbnail = new System.Windows.Forms.PictureBox();
            this.cmbResolutions = new System.Windows.Forms.ComboBox();
            this.lblResolution = new System.Windows.Forms.Label();
            this.lblLoad = new System.Windows.Forms.Label();
            this.nmrNumberOfVideos = new System.Windows.Forms.NumericUpDown();
            this.btnAddToQueue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pcbThumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrNumberOfVideos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // cmbVodType
            // 
            this.cmbVodType.FormattingEnabled = true;
            this.cmbVodType.Items.AddRange(new object[] {
            resources.GetString("cmbVodType.Items"),
            resources.GetString("cmbVodType.Items1")});
            resources.ApplyResources(this.cmbVodType, "cmbVodType");
            this.cmbVodType.Name = "cmbVodType";
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
            // cmbResolutions
            // 
            this.cmbResolutions.FormattingEnabled = true;
            resources.ApplyResources(this.cmbResolutions, "cmbResolutions");
            this.cmbResolutions.Name = "cmbResolutions";
            this.cmbResolutions.SelectedIndexChanged += new System.EventHandler(this.cmbResolutions_SelectedIndexChanged);
            // 
            // lblResolution
            // 
            resources.ApplyResources(this.lblResolution, "lblResolution");
            this.lblResolution.Name = "lblResolution";
            // 
            // lblLoad
            // 
            resources.ApplyResources(this.lblLoad, "lblLoad");
            this.lblLoad.Name = "lblLoad";
            // 
            // nmrNumberOfVideos
            // 
            this.nmrNumberOfVideos.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            resources.ApplyResources(this.nmrNumberOfVideos, "nmrNumberOfVideos");
            this.nmrNumberOfVideos.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmrNumberOfVideos.Name = "nmrNumberOfVideos";
            this.nmrNumberOfVideos.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnAddToQueue
            // 
            resources.ApplyResources(this.btnAddToQueue, "btnAddToQueue");
            this.btnAddToQueue.Name = "btnAddToQueue";
            this.btnAddToQueue.UseVisualStyleBackColor = true;
            this.btnAddToQueue.Click += new System.EventHandler(this.btnAddToQueue_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddToQueue);
            this.Controls.Add(this.nmrNumberOfVideos);
            this.Controls.Add(this.lblLoad);
            this.Controls.Add(this.lblResolution);
            this.Controls.Add(this.cmbResolutions);
            this.Controls.Add(this.pcbThumbnail);
            this.Controls.Add(this.lblVodType);
            this.Controls.Add(this.cmbVodType);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lstVods);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtChannelName);
            this.Controls.Add(this.lblChannelName);
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbThumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrNumberOfVideos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChannelName;
        private System.Windows.Forms.TextBox txtChannelName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox lstVods;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ComboBox cmbVodType;
        private System.Windows.Forms.Label lblVodType;
        private System.Windows.Forms.PictureBox pcbThumbnail;
        private System.Windows.Forms.ComboBox cmbResolutions;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.NumericUpDown nmrNumberOfVideos;
        private System.Windows.Forms.Button btnAddToQueue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

