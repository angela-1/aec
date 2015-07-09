using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appaec2
{
    class BAccountViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChange(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private Boolean isnew;

        private string tag;
        public string Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
                NotifyChange("Tag");
            }
        }

        private string category;
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                NotifyChange("Category");
            }
        }

        private string url;
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
                NotifyChange("Url");
            }
        }

        private string user;
        public string User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                NotifyChange("User");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyChange("Password");
            }
        }

        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                NotifyChange("Phone");
            }
        }

        private string mail;
        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
                NotifyChange("Mail");
            }
        }

        private string notes;
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
                NotifyChange("Notes");
            }
        }

        public BAccountViewModel()
        {
            tag = "";
            category = "";
            url = "";
            user = "";
            password = "";
            phone = "";
            mail = "";
            notes = "";

            isnew = true;
        }

        public BAccountViewModel(string t)
        {
            ReadAccount(t);
            isnew = false;
        }

        public void ReadAccount(string t)
        {

            string sql = "select * from accounts where tag='" + t + "'";
            ADbInteractive db = new ADbInteractive(AStatic.DbPath);
            using (SQLiteDataReader reader = db.ExecReader(sql, null))
            {
                while (reader.Read())
                {

                    tag = reader.GetString(1);
                    category = reader.GetString(2);
                    url = reader.GetString(3);
                    user = reader.GetString(4);
                    password = reader.GetString(5);
                    phone = reader.GetString(6);
                    mail = reader.GetString(7);
                    notes = reader.GetString(8);
                }
                reader.Close();
            }
        }

        public int WriteAccount()
        {

            if (isnew)
            {
                return InsertInto();
            }
            else
            {
                return Update();
            }

        }


        private Boolean ExistsInDb(string t)
        {
            Boolean exists = false;
            foreach (var item in AStatic.Catalog)
            {
                if (t == item.Tag)
                {
                    exists = true;
                }
            }
            return exists;
        }


        private int InsertInto()
        {
            if (!ExistsInDb(tag))
            {
                APinYin pyer = new APinYin();
                
                string sql = "insert into accounts (tag, category, url, user, password, phone, mail, notes, pyindex, pyfspell) "
                    + "values('"
                + tag + "', '"
                + category + "', '"
                + url + "', '"
                + user + "', '"
                + password + "', '"
                + phone + "', '"
                + mail + "', '"
                + notes + "', '"
                + pyer.GetPyStr(tag, false).ToLower() + "', '"
                + pyer.GetPyStr(tag, true).ToLower() + "')";

                ADbInteractive db = new ADbInteractive(AStatic.DbPath);
                
                return db.ExecQuery(sql, null);
            }
            else
            {
                return -1;
            }


        }

        private int Update()
        {
            string sql = "update accounts set "
            //+ "tag='" + tag + "', "
            + "category='" + category + "',"
            + "url='" + url + "', "
            + "user='" + user + "', "
            + "password='" + password + "', "
            + "phone='" + phone + "', "
            + "mail='" + mail + "', "
            + "notes='" + notes + "', "
            + "lastmodified=datetime('now','localtime') "
            + "where tag='" + tag + "'";
            ADbInteractive db = new ADbInteractive(AStatic.DbPath);
            return db.ExecQuery(sql, null);
        }




    }
}
