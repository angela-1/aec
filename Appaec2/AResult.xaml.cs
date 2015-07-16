



using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// AResult.xaml 的交互逻辑
    /// </summary>
    public partial class AResult : Page
    {
        private string tag;

        public AResult(string tag)
        {
            this.tag = tag;
            InitializeComponent();
            ShowResult();

            InitUi();
        }


        private void InitUi()
        {
            MainWindow m = Application.Current.Properties["mainwindow"] as MainWindow;
            m.SetTitle(FindResource("StrUid_account") as string);
        }

        private void ShowResult()
        {

            TextBox[] tbl = new TextBox[9]
            {tag_textBox, cat_textBox, url_textBox, user_textBox,
               pwd_textBox, phone_textBox, mail_textBox,
               notes_textBox, lastmodified_textBox
            };






            string sql = "select * from accounts where tag='" + tag + "'";
            ADbInteractive db = new ADbInteractive(AStatic.DbPath);
            using (SQLiteDataReader reader = db.ExecReader(sql, null))
            {


                while (reader.Read())
                {

                    //result += "  " + reader.GetString(0) + "\n\n";
                    for (int i = 1; i < 10; i++)
                    {
                        tbl[i - 1].Text = reader.GetString(i);

                    }

                    //textBlock.Text = result;

                    //Console.WriteLine("ID:{0},TypeName{1}", reader.GetInt64(0), reader.GetString(1));
                }
                reader.Close();
            }



        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("AHome.xaml", UriKind.Relative));
        }

        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BAccount(tag));
        }

        private void del_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AConfirm(tag_textBox.Text));

        }
    }


}
