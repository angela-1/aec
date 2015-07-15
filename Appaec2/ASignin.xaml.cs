using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// ASignin.xaml 的交互逻辑
    /// </summary>
    public partial class ASignin : Page
    {
        public ASignin()
        {
            InitializeComponent();
            key_textBox.Focus();

            InitUi();
        }


        private void InitUi()
        {
            MainWindow m = Application.Current.Properties["mainwindow"] as MainWindow;
            m.SetTitle(FindResource("StrUid_signin") as string);
        }

        private void signin_button_Click(object sender, RoutedEventArgs e)
        {
            AUtils t = new AUtils();
            AEncrypter encrypter = new AEncrypter();
            encrypter.ReadKeyFile();
            
            AStatic.StringKey = key_textBox.Text;
            if (encrypter.ValidKey(AStatic.StringKey))
            {

                if (encrypter.DecryptFile(AStatic.DbPath))
                {
                    AStatic.IsRunning = true;
                    t.ReadCatalog();

                    NavigationService.Navigate(new Uri("AHome.xaml", UriKind.Relative));

                }
                 
              
            }
            else
            {
                signinlabel.Content = FindResource("StrUid_wrongkey").ToString();
            }

            

        }







        private void key_textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                signin_button_Click(null, null);
               

                //textBlock.Text = "search selected.";
            }
        }


    }
}
