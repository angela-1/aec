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
    class AUtils
    {

        public AUtils()
        {

        }


        public void CreateConfigIni()
        {


            FileStream fs = new FileStream(AStatic.ConfigPath, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs);

            string ini = "[aec]\r\ndbpath=\r\nlanguage=zh-CN";
            sw.Write(ini);


            sw.Close();
            fs.Close();



        }

        public void ReadLang()
        {
            string dirpath = System.Environment.CurrentDirectory;

            StringBuilder str = new StringBuilder();
            long s = AStatic.GetPrivateProfileString("aec", "language", null,
                str, 10, dirpath + "\\" + AStatic.ConfigPath);
            if (s > 0)
            {
                AStatic.Lang = str.ToString();

            }
            else
            {
                AStatic.Lang = "zh-CN";
            }


        }

        public void WriteLang()
        {
            string dirpath = System.Environment.CurrentDirectory;
            long s = AStatic.WritePrivateProfileString("aec", "language",
                AStatic.Lang, dirpath + "\\" + AStatic.ConfigPath);

        }


        public void ChooseLang(string lang)
        {
            List<ResourceDictionary> dictionaryList = new List<ResourceDictionary>();
            foreach (ResourceDictionary dictionary in Application.Current.Resources.MergedDictionaries)
            {
                dictionaryList.Add(dictionary);
            }
            string requestedCulture = string.Format("LangDictionary.{0}.xaml", lang);
            ResourceDictionary resourceDictionary = dictionaryList.FirstOrDefault(d => d.Source.OriginalString.Equals(requestedCulture));
            if (resourceDictionary == null)
            {
                requestedCulture = "LangDictionary.xaml";
                resourceDictionary = dictionaryList.FirstOrDefault(d => d.Source.OriginalString.Equals(requestedCulture));
            }
            if (resourceDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);

            }
        }

        public void ReadDbpath()
        {
            string dirpath = System.Environment.CurrentDirectory;

            StringBuilder str = new StringBuilder();
            long s = AStatic.GetPrivateProfileString("aec", "dbpath", null,
                str, 255, dirpath + "\\" + AStatic.ConfigPath);
            if (s > 0)
            {
                AStatic.DbPath = str.ToString();

            }
            else
            {
                AStatic.DbPath = null;

            }


        }

        public long WriteConfig(string dbpath)
        {
            if (!File.Exists(AStatic.ConfigPath))
            {
                CreateConfigIni();
            }
            string dirpath = System.Environment.CurrentDirectory;
            long s = AStatic.WritePrivateProfileString("aec", "dbpath",
                dbpath, dirpath + "\\" + AStatic.ConfigPath);
            return s;
        }


        public void ReadCatalog()
        {
            AStatic.Catalog = new List<ALibModel>();
            string sql = "select tag, category, pyindex, pyfspell from accounts order by pyindex asc";


            ADbInteractive db = new ADbInteractive(AStatic.DbPath);
            using (SQLiteDataReader reader = db.ExecReader(sql, null))
            {
                while (reader.Read())
                {
                    AStatic.Catalog.Add(new ALibModel(reader.GetString(0),
                        reader.GetString(1), reader.GetString(2),
                        reader.GetString(3)));

                }
                reader.Close();

            }
        }

 

        public void WaitingEncrypt()
        {
            System.Threading.Thread.Sleep(2000);
            
            AEncrypter encrypter = new AEncrypter();
            if (File.Exists(AStatic.DbPath))
            {
                encrypter.EncryptFile(AStatic.DbPath);
            }
        }

 
    }
}
