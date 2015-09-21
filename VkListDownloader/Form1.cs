﻿using System;
using System.Windows.Forms;

namespace VkListDownloader
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.IO;
	using System.Text;
	using System.Windows.Forms.VisualStyles;

	public partial class Form1 : Form
	{

		private Dictionary<string, string> _urlDictionary;
		private BackgroundWorker _worker;
		delegate void SetProgress(string id, int retry, int progress);

		public Form1() {
			InitializeComponent();
		}

		private void SelectList_Click(object sender, EventArgs e) {
			var dialog = new OpenFileDialog {
				Multiselect = false
			};
			var result = dialog.ShowDialog();
			if (result == DialogResult.OK) {
				txbFile.Text = dialog.FileName;
				listView1.Enabled = false;
				gbLoadProgress.Visible = true;
				Application.DoEvents();
				_worker = new BackgroundWorker() {
					WorkerReportsProgress = true
				};
				_worker.DoWork += worker_DoWork;
				_worker.ProgressChanged += (o, args) => {
					lblLoaded.Text = args.ProgressPercentage.ToString();
				};
				_worker.RunWorkerCompleted += (o, args) => {
					listView1.Enabled = true;
					gbLoadProgress.Visible = false;
					Application.DoEvents();
					LoadToListView(_urlDictionary);
					Application.DoEvents();
					var linkDownloader = new LinkDownloader(2, 10, "c:\\tmp\\", _urlDictionary);
					linkDownloader.Progress += linkDownloader_Progress;
					

				};
				_worker.RunWorkerAsync();
				
			}
		}

		void worker_DoWork(object sender, DoWorkEventArgs e) {
			var file = txbFile.Text;
			var result = new Dictionary<string, string>();
			string fileData = string.Empty;
			using (TextReader reader = new StreamReader(file, Encoding.UTF8)) {
				fileData = reader.ReadToEnd();
			}
			var urls = fileData.Split(';');
			int count = 0;
			foreach (var url in urls) {
				_worker.ReportProgress(count++);
				if (url.Length < 3) {
					continue;
				}
				var data = url.Split('|');
				if (data.Length != 3) {
					throw new Exception("ERROR BLYA");
				}
				var artist = Tools.FixFileName(data[0]);
				var title = Tools.FixFileName(data[1]);
				var fileUrl = data[2].Replace("h=","http://");
				result.Add(string.Concat(artist, " - ", title), fileUrl);
			}
			_urlDictionary = result;
		}

		void linkDownloader_Progress(string id, int retry, int progress) {

			BeginInvoke(new MethodInvoker(delegate {

				foreach (ListViewItem item in listView1.Items) {
					if ((string)item.Tag == id) {
						item.SubItems[1].Text = retry.ToString();
						item.SubItems[2].Text = progress + @" %";
					}
				}

			}));


			
		}

		private void SetInfo(string id, int retry, int progress) {
			if (this.listView1.InvokeRequired) {
				var d = new SetProgress(SetInfo);
				this.Invoke(d, new object[] { id, retry, progress });
			} 
		}

		private void LoadToListView(Dictionary<string, string> dictionary) {
			foreach (var item in dictionary) {
				var ii = new ListViewItem {
					Text = item.Key,
					Tag = Tools.GetMD5Hash(string.Concat(item.Key, item.Value))
				};
				ii.SubItems.Add("0");
				ii.SubItems.Add("0%");
				listView1.Items.Add(ii);
			}
		}


	}
}