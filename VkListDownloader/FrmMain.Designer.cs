namespace VkListDownloader
{
	partial class FrmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.txbFile = new System.Windows.Forms.TextBox();
			this.SelectList = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.gbLoadProgress = new System.Windows.Forms.GroupBox();
			this.lblLoaded = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.btnHelp = new System.Windows.Forms.Button();
			this.gbLoadProgress.SuspendLayout();
			this.SuspendLayout();
			// 
			// txbFile
			// 
			this.txbFile.Location = new System.Drawing.Point(12, 12);
			this.txbFile.Name = "txbFile";
			this.txbFile.ReadOnly = true;
			this.txbFile.Size = new System.Drawing.Size(475, 20);
			this.txbFile.TabIndex = 0;
			// 
			// SelectList
			// 
			this.SelectList.Location = new System.Drawing.Point(493, 9);
			this.SelectList.Name = "SelectList";
			this.SelectList.Size = new System.Drawing.Size(75, 23);
			this.SelectList.TabIndex = 1;
			this.SelectList.Text = "Select list";
			this.SelectList.UseVisualStyleBackColor = true;
			this.SelectList.Click += new System.EventHandler(this.SelectList_Click);
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(12, 38);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(710, 616);
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "File name";
			this.columnHeader1.Width = 450;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Retry";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Progress";
			this.columnHeader2.Width = 140;
			// 
			// gbLoadProgress
			// 
			this.gbLoadProgress.Controls.Add(this.lblLoaded);
			this.gbLoadProgress.Controls.Add(this.label1);
			this.gbLoadProgress.Location = new System.Drawing.Point(259, 310);
			this.gbLoadProgress.Name = "gbLoadProgress";
			this.gbLoadProgress.Size = new System.Drawing.Size(200, 100);
			this.gbLoadProgress.TabIndex = 3;
			this.gbLoadProgress.TabStop = false;
			this.gbLoadProgress.Visible = false;
			// 
			// lblLoaded
			// 
			this.lblLoaded.AutoSize = true;
			this.lblLoaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblLoaded.Location = new System.Drawing.Point(109, 36);
			this.lblLoaded.Name = "lblLoaded";
			this.lblLoaded.Size = new System.Drawing.Size(26, 29);
			this.lblLoaded.TabIndex = 1;
			this.lblLoaded.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(19, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Loaded:";
			// 
			// btnHelp
			// 
			this.btnHelp.Location = new System.Drawing.Point(574, 9);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(148, 23);
			this.btnHelp.TabIndex = 4;
			this.btnHelp.Text = "How create list ?";
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(734, 666);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.gbLoadProgress);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.SelectList);
			this.Controls.Add(this.txbFile);
			this.Name = "FrmMain";
			this.Text = "Form1";
			this.gbLoadProgress.ResumeLayout(false);
			this.gbLoadProgress.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txbFile;
		private System.Windows.Forms.Button SelectList;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.GroupBox gbLoadProgress;
		private System.Windows.Forms.Label lblLoaded;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button btnHelp;
	}
}

