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
    /// AConfig.xaml 的交互逻辑
    /// </summary>
    public partial class AConfig : Page
    {
        public AConfig()
        {
            InitializeComponent();

            ShowInit();

            InitUi();
        }


        private void InitUi()
        {
            MainWindow m = Application.Current.Properties["mainwindow"] as MainWindow;
            m.SetTitle(FindResource("StrUid_config") as string);
        }


        private void ShowInit()
        {
            init_radioButton.IsChecked = true;
            frame.Navigate(new Uri("BInit.xaml", UriKind.Relative));
        }


        private void init_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("BInit.xaml", UriKind.Relative));

        }

        private void password_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("BPass.xaml", UriKind.Relative));

        }

        private void export_radioButton_Checked(object sender, RoutedEventArgs e)
        {

            frame.Navigate(new Uri("BExport.xaml", UriKind.Relative));

        }

        private void lang_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("BLang.xaml", UriKind.Relative));

        }

        private void about_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("BAbout.xaml", UriKind.Relative));

        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("AHome.xaml", UriKind.Relative));
        }
    }
}
