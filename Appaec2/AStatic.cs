using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Appaec2
{
    class AStatic
    {
        //[DllImport("Win32Project3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int GetPy( string ch, StringBuilder py);

        [DllImport("Appaec.Openssl.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int digest_md5(string buf, byte[] md);

        [DllImport("Appaec.Openssl.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int encrypt(byte[] src, byte[] dst, int len, byte[] key);

        [DllImport("Appaec.Openssl.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int decrypt(byte[] src, byte[] dst, int len, byte[] key);


        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        //参数说明：section：INI文件中的段落；
        //key：INI文件中的关键字；
        //val：INI文件中关键字的数值；
        //filePath：INI文件的完整的路径和名称。
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        //参数说明：section：INI文件中的段落名称；
        //key：INI文件中的关键字；
        //def：无法读取时候时候的缺省数值；
        //retVal：读取数值；size：数值的大小；
        //filePath：INI文件的完整路径和名称。



        private static string[] pydic;
        public static string[] Pydic
        {
            get
            {
                return pydic;
            }
            set
            {
                pydic = value;
            }
        }

        public static byte[] tmd()
        {
            byte[] n = new byte[16];
            digest_md5("fuck", n);

            return n;
        }

        private static string stringkey;
        public static string StringKey
        {
            get
            {
                return stringkey;
            }
            set
            {
                stringkey = value;
            }
        }

        private static Byte[] encryptkey;
        public static Byte[] EncryptKey
        {
            get
            {
                return encryptkey;
            }
            set
            {
                encryptkey = value;
            }
        }

        private static string keypath;
        public static string KeyPath
        {
            get
            {
                return keypath;
            }
            set
            {
                keypath = value;
            }
        }


        private static string configpath;
        public static string ConfigPath
        {
            get
            {
                return configpath;
            }
            set
            {
                configpath = value;
            }
        }

        private static Boolean isrunning;
        public static Boolean IsRunning
        {
            get
            {
                return isrunning;
            }
            set
            {
                isrunning = value;
            }
        }

        private static string dbpath;
        public static string DbPath
        {
            get
            {
                return dbpath;

            }
            set
            {
                dbpath = value;
            }
        }

        private static List<ALibModel> catalog;
        public static List<ALibModel> Catalog
        {
            get
            {
                return catalog;
            }
            set
            {
                catalog = value;
            }

        }


        private static string lang;
        public static string Lang
        {
            get
            {
                return lang;
            }
            set
            {
                lang = value;
            }
        }

        static AStatic()
        {

            //ReadConfig();
            //ReadKey();
            //if (ValidKey())
            //{
            //    DecryptDb();
            //    // modify dbpath string, then verify exists
            //    ReadCatalog();
            //    isrunning = true;
            //}


            //DecryptKey();

            configpath = "config.ini";
            keypath = ".aec-key";
            
            isrunning = false;
        }


        //private static Boolean DecryptDb()
        //{
        //    string dc = dbpath + ".secret";
        //    // decrypt it to .db3

        //    return File.Exists(dbpath);


        //}

        //public static void ReadCatalog()
        //{
        //    catalog = new List<ALibModel>();
        //    string sql = "select tag,category from accounts order by tag asc";
        //    ADbInteractive db = new ADbInteractive(dbpath);
        //    using (SQLiteDataReader reader = db.ExecReader(sql, null))
        //    {
        //        while (reader.Read())
        //        {
        //            catalog.Add(new ALibModel(reader.GetString(0), reader.GetString(1)));

        //        }
        //        reader.Close();
        //    }
        //}





  


    }
}
