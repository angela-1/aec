//  Some functions.
//	Copyright(C) 2015 hez0rs <hez0rs@163.com>
//
//	This program is free software : you can redistribute it and / or modify
//	it under the terms of the GNU General Public License as published by
//	the Free Software Foundation, either version 3 of the License, or
//	(at your option) any later version.
//
//	This program is distributed in the hope that it will be useful,
//	but WITHOUT ANY WARRANTY; without even the implied warranty of
//	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//	GNU General Public License for more details.
//
//	You should have received a copy of the GNU General Public License
//	along with this program.If not, see < http://www.gnu.org/licenses/>.



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


        private Boolean IsFileInUse(string fname)
        {
            bool inUse = true;

            FileStream fs = null;
            try
            {
                fs = new FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.None);
                inUse = false;
            }
            catch
            {

            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return inUse;           //true表示正在使用,false没有使用





        }

        public void WaitingEncrypt()
        {
            System.Threading.Thread.Sleep(2000);

            


            if (File.Exists(AStatic.DbPath))
            {


                while (true)
                {
                    
                    if (!IsFileInUse(AStatic.DbPath))
                    {
                        AEncrypter encrypter = new AEncrypter();
                        encrypter.EncryptFile(AStatic.DbPath);
                        AStatic.IsRunning = false;
                        break;
                    }
                    
                }

            }
        }


    }
}
