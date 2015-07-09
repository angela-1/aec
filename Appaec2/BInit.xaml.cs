using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Appaec2
{
    /// <summary>
    /// BInit.xaml 的交互逻辑
    /// </summary>
    public partial class BInit : Page
    {
        public BInit()
        {
            InitializeComponent();
            CheckDb();
        }

        private void CheckDb()
        {
            if (AStatic.DbPath != null )
            {

                DisableInit();

            }
        }

        private void DisableInit()
        {
            db_textBox.Text = AStatic.DbPath;
            db_textBox.IsEnabled = false;
            key_textBox.IsEnabled = false;
            savefile_button.IsEnabled = false;
            start_button.IsEnabled = false;
        }

        private void Createdbtable()
        {
            
            ADbInteractive db = new ADbInteractive(AStatic.DbPath);

            db.CreateDb(AStatic.DbPath);

            string sql = "create table accounts(id integer primary key, tag text unique not null, category text, url text, user text, password text, phone text, mail text, notes text, lastmodified TimeStamp NOT NULL DEFAULT (datetime('now','localtime')), pyindex text, pyfspell text)";


            db.ExecQuery(sql, null);



        }

        private void start_button_Click(object sender, RoutedEventArgs e)
        {
            // save dbpath to config.ini
            if (db_textBox.Text != "" && key_textBox.Text != "")
            {
                AUtils tool = new AUtils();
                AEncrypter encrypter = new AEncrypter();
                // 1 weite to config.ini
                tool.WriteConfig(db_textBox.Text);
                tool.ReadDbpath();
                // 2 gen key file
                AStatic.StringKey = key_textBox.Text;
                encrypter.WriteKeyFile(key_textBox.Text);
                encrypter.ReadKeyFile();
                
                // 3 create db
                Createdbtable();
                DisableInit();

                // 4 envrypt db
                if (encrypter.EncryptFile(AStatic.DbPath))
                {
                    Window m = Application.Current.Properties["mainwindow"] as Window;
                    Frame main_frame = m.FindName("main_frame") as Frame;
                    main_frame.Navigate(new ASignin());

                }
                

               


            }
            else if (db_textBox.Text == "")
            {
                db_textBox.Foreground = Brushes.Red;
                db_textBox.Text = "DB path can NOT be null";
            }
            else if (key_textBox.Text == "")
            {
                key_textBox.Foreground = Brushes.Red;
                key_textBox.Text = "Key can NOT be null";
            }



        }

        private void signout_button_Click(object sender, RoutedEventArgs e)
        {
            // del key file
            // and erase dbpath
            if (File.Exists(AStatic.KeyPath))
            {
                File.Delete(AStatic.KeyPath);
                
            }
            //AUtils t = new AUtils();
            
            //string s = t.GetSpells("Facebook", false);
            //MessageBox.Show(s, "see");

            string dirpath = System.Environment.CurrentDirectory;
            AStatic.WritePrivateProfileString("aec", "dbpath", "", 
                dirpath + "\\" + AStatic.ConfigPath);

            Application.Current.Shutdown();

            
        }

        private void savefile_button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "accounts"; // Default file name
            dlg.DefaultExt = ".db3"; // Default file extension
            dlg.Filter = "AEC 数据库 (.db3)|*.db3"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            string filename = string.Empty;

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                filename = dlg.FileName;
                db_textBox.Text = filename;
            }
  
        }
    }
}
