namespace VkListDownloader
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.IO;
	using System.Text;
	using System.Windows.Forms;

	public partial class FrmMain : Form
	{

		private Dictionary<string, string> _urlDictionary;
		private BackgroundWorker _worker;
		delegate void SetProgress(string id, int retry, int progress);

		public FrmMain() {
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

			int position = 0;
			while (position < fileData.Length) {
				var artist = GetBlock(fileData, ref position);
				var title = GetBlock(fileData, ref position);
				var url = GetBlock(fileData, ref position);
				result.Add(string.Concat(artist, " - ", title), url);
			}

			/*var urls = fileData.Split(';');
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
			}*/
			_urlDictionary = result;
		}

		private string GetBlock(string data, ref int position) {
			string charCount = string.Empty;
			for (int i = position; i <= data.Length; i++) {
				if (data[i] != '|') {
					charCount += data[i];
				} else {
					position = i + 1;
					break;
				}
			}
			var charCountInt = Int32.Parse(charCount);
			string result = data.Substring(position, charCountInt);
			position += charCountInt;
			return result;
		}

		void linkDownloader_Progress(string id, int retry, int progress) {
			BeginInvoke(new MethodInvoker(delegate {
				foreach (ListViewItem item in listView1.Items) {
					if ((string)item.Tag == id) {
						item.SubItems[1].Text = retry.ToString();
						var line = string.Concat(progress, "% [");
						int count = 0;
						for (int i = 0; i < (int)(progress / 10); i++) {
							line += "█";
							count++;
						}
						for (int i = 0; i < 10 - count; i++) {
							line += "░";
						}
						line += "]";
						if (item.SubItems[2].Text != line) {
							item.SubItems[2].Text = line;
						}
						//item.SubItems[2].Text = progress + @" %";
					}
				}
			}));
		}

		private void LoadToListView(Dictionary<string, string> dictionary) {
			foreach (var item in dictionary) {
				var ii = new ListViewItem {
					Text = item.Key,
					Tag = Tools.GetMD5Hash(string.Concat(item.Key, item.Value))
				};
				ii.SubItems.Add("0");
				ii.SubItems.Add("");
				listView1.Items.Add(ii);
			}
		}

		private void btnHelp_Click(object sender, EventArgs e) {
			var help = new FrmHelp();
			help.ShowDialog();
		}


	}
}
