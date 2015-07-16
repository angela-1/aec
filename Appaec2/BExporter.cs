

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Text.RegularExpressions;


namespace Appaec2
{
	class BExporter
	{

		private string[] title;



		private string head = "";
		private string body = "";
		private string tail = "</tbody>\n</table>\n</div>\n</body>\n</html>";

		public BExporter()
		{

			Window m = Application.Current.Properties["mainwindow"] as Window;
            title = new string[9] {
                m.FindResource("StrUid_tag") as string,
                m.FindResource("StrUid_category") as string,
                m.FindResource("StrUid_url") as string,
                m.FindResource("StrUid_user") as string,
                m.FindResource("StrUid_password") as string,
                m.FindResource("StrUid_phone") as string,
                m.FindResource("StrUid_mail") as string,
                m.FindResource("StrUid_notes") as string,
                m.FindResource("StrUid_lastmodified") as string
            };
		}


        public void Export(string type, string fname)
        {
           
            if (type == "HTML")
            {
                HtmlExport(fname);
            }
            else if (type == "TXT")
            {
                TxtExport(fname);
            }

        }


		public void HtmlExport(string fname)
		{

			using (StreamReader fs = new StreamReader("share\\head.html"))
			{
				head = fs.ReadToEnd();

			}

			head += "<h2>Accounts</h2>\n";
			DateTime dt = DateTime.Now;
			head += "<p>" + dt.ToString() + "</p>\n";

			body = "<table class=\"dataintable\">\n<tbody>\n";

			body += "<tr>";
			for (int i = 1; i < 10; i++)
			{
				body += "<th>"+title[i - 1] + "</th>\n";

			}
			body += "</tr>\n";


			string sql = "select * from accounts order by pyindex asc";

			ADbInteractive db = new ADbInteractive(AStatic.DbPath);

			using (SQLiteDataReader reader = db.ExecReader(sql, null))
			{
				while (reader.Read())
				{
					body += "<tr>\n";


					for (int i = 1; i < 10; i++)
					{
						body += "<td>" + reader.GetString(i) + "</td>\n";

					}
					body += "</tr>\n";
				}
				reader.Close();

			}


			using (StreamWriter fw = new StreamWriter(fname, false))
			{
				fw.Write(head + body + tail);
			}

		}


		public void TxtExport(string fname)
		{

			string sql = "select * from accounts order by pyindex asc";

			FileStream fs = new FileStream(fname, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);

			string result = "";
			for (int i = 1; i < 10; i++)
			{
				result += title[i - 1] + ",";

			}

			sw.Write(result + "\r\n");

			result = "";
			ADbInteractive db = new ADbInteractive(AStatic.DbPath);

			using (SQLiteDataReader reader = db.ExecReader(sql, null))
			{
				while (reader.Read())
				{
					for (int i = 1; i < 10; i++)
					{
						result += reader.GetString(i) + ",";

					}
					result += "\r\n";
				}
				reader.Close();

			}
			sw.Write(result);

			sw.Close();
			fs.Close();
		}


        public string GetSaveFilePath(string exporttype)
        {
            Dictionary<string, string> type = new Dictionary<string, string>()
            {
                {"HTML", "HTML|*.html"},
                {"TXT", "TXT|*.txt"}
            };

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            dlg.FileName = "accounts"; // Default file name
            dlg.DefaultExt = type[exporttype].Split('*')[1]; // Default file extension
            dlg.Filter = type[exporttype]; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();


            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                return dlg.FileName;

            }
            else
            {
                return null;
            }
        }


    }
}