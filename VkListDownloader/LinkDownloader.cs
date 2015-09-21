namespace VkListDownloader
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Threading;
	using System.Windows.Forms;

	public class LinkDownloader
	{
		private readonly int _threadCount;
		private readonly Dictionary<string, string> _linkDictionary;
		private readonly string _workDirectory;
		private readonly int _retryCount;

		public event Action<string, int, int> Progress;

		private delegate void TestProgress(string id, int retry, int progress);

		public LinkDownloader(int threadCount, int retryCount, 
				string workDirectory, Dictionary<string, string> linkDictionary) {
			_threadCount = threadCount;
			_linkDictionary = linkDictionary;
			_workDirectory = workDirectory;
			_retryCount = retryCount;
			var thread = new Thread(Work) {
				IsBackground = true
			};
			thread.Start();
		}

		private void Work() {
			var threads = new List<Thread>();

			foreach (var link in _linkDictionary) {

				var activeThread = threads.Count(x => x.IsAlive);
				while (activeThread >= _threadCount) {
					Thread.Sleep(100);
					activeThread = threads.Count(x => x.IsAlive);
				}

				threads.RemoveAll(x => !x.IsAlive);

				KeyValuePair<string, string> link1 = link;
				var thread = new Thread(() => Downloaded(link1.Key, link1.Value)) {
					IsBackground = true
				};
				thread.Start();
				threads.Add(thread);
			}
		}

		private void Downloaded(string name, string url) {
			var fileId = Tools.GetMD5Hash(string.Concat(name, url));
			var tempFileName = string.Concat(_workDirectory, "\\", fileId);
			var wc = new WebClient();
			for (int i = 0; i < _retryCount; i++) {
				int retry = i;
				RizeEvent(fileId, retry, 0);
				wc.DownloadProgressChanged += (sender, args) =>
					RizeEvent(fileId, retry, (int)(args.BytesReceived * 100 / args.TotalBytesToReceive));
				wc.DownloadFileCompleted += (sender, args) => RizeEvent(fileId, retry, 100);
				try {
					wc.DownloadFile(url, tempFileName);
					break;
				} catch(Exception) {
				}
			}
		}

		private void RizeEvent(string id, int retry, int persent) {
			if (Progress != null) {
				Progress(id, retry, persent);
			}
		}

	}

	

}
