using RCFixer.o;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
namespace RCFixer
{
    internal class UpdateService
    {
        public static string version = "1.0.0";

        private static string currentTag = "v" + version;
        private static string remoteTag = "v";
        public static async Task<bool> checkForUpdate()
        {
            string endpoint = "https://api.github.com/repos/Osderda/RCFixer/releases/latest";

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            string tagNameKey = "\"tag_name\":";
            using (var wc = new TimedWebClient())
            {

                try
                {
                    wc.Headers.Set("User-Agent", "RCFixer");
                    string json = wc.DownloadString(endpoint);
                    int tagNameIndex = json.IndexOf(tagNameKey);
                    int versionStart = tagNameIndex + tagNameKey.Length + 1;
                    int versionEnd = json.IndexOf("\"", versionStart);
                    remoteTag = json.Substring(versionStart, versionEnd - versionStart);
                    return string.CompareOrdinal(remoteTag, currentTag) > 0;
                }
                catch
                {
                    return false;
                }

            }
        }

        public static void showUpdateNotice()
        {
            if (!lang.TR)
            {
                DialogResult confirmResult = MessageBox.Show($"A New version of RCFixer is available ({remoteTag}). Would you like to update now?", "RCFixer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    downloadAndInstallUpdate();
                }
            }
            else
            {
                DialogResult confirmResult = MessageBox.Show($"RCFixer'in Yeni bir sürümü mevcut ({remoteTag}). Şimdi güncellemek ister misiniz?", "RCFixer", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
                if (confirmResult == DialogResult.Yes)
                {
                    downloadAndInstallUpdate();
                }
            }

        }

        public static void downloadAndInstallUpdate()
        {
            //$"https://github.com/Osderda/RCFixer/releases/download/{remoteTag}/RCFixer.zip"
            new WebClient().DownloadFile($"https://github.com/Osderda/RCFixer/releases/download/{remoteTag}/RCFixer.zip", Application.StartupPath + "\\latest.zip");
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo sf = new System.Diagnostics.ProcessStartInfo();
            sf.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            sf.FileName = "cmd.exe";
            sf.Arguments = $"/C taskkill /F /PID {Process.GetCurrentProcess().Id} | tar -xf latest.zip | del \"latest.zip\" | start RCFixer.exe ";
            proc.StartInfo = sf;
            proc.Start();
            Environment.Exit(0);
        }
        public class TimedWebClient : WebClient
        {
            public WebHeaderCollection DefaultHeaders = new WebHeaderCollection { ["User-Agent"] = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.64 Safari/537.11" };
            public TimedWebClient()
            {
                Headers = DefaultHeaders;
            }
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                w.Timeout = 5 * 60 * 1000;
                return w;
            }
        }
    }
}
