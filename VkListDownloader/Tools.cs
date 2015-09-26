using System.Text;

namespace VkListDownloader
{
	using System.Linq;
	using System.Security.Cryptography;

	public static class Tools
	{
		public static string GetMD5Hash(string input) {
			MD5 md5 = MD5.Create();
			byte[] inputBytes = Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);
			var sb = new StringBuilder();
			for (int i = 0; i < hash.Length; i++) {
				sb.Append(hash[i].ToString("X2"));
			}
			return sb.ToString();
		}

		public static string FixFileName(string name) {
			const string correctChars = 
				"123456789qwertyuiopasdfghjklzxcvbnm,.'!~@#$%&*()-_=+`йцукенгшщзхъфывапролджэячсмитьбю ";
			var result = string.Empty;
			for (int i = 0; i < name.Length; i++) {
				if (correctChars.Any(x => x == name.ToLower()[i])) {
					result += name[i];
				} else {
					//result += ".";
				}
			}
			if (string.IsNullOrEmpty(result))
			{
				result = "Unknown";
			}
			return result.Length < 40 ? result : result.Substring(0,40);
		}

	}

}
