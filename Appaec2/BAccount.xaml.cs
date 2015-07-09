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
    /// BAccount.xaml 的交互逻辑
    /// </summary>
    public partial class BAccount : Page
    {

        private BAccountViewModel accountviewmodel;

        public BAccount()
        {
            InitializeComponent();

            BindingVar(null);

        }

        public BAccount(string t)
        {
            InitializeComponent();

            BindingVar(t);

            // can not modify tag
            tag_textBox.IsEnabled = false;
        }


        private void BindingVar(string t)
        {
            if (t == null)
            {
                accountviewmodel= new BAccountViewModel();
                tablegrid.DataContext = accountviewmodel;
            }
            else
            {
                accountviewmodel = new BAccountViewModel(t);
                tablegrid.DataContext = accountviewmodel;
            }
            

            tag_textBox.SetBinding(TextBox.TextProperty, new Binding("Tag"));
            cat_textBox.SetBinding(TextBox.TextProperty, new Binding("Category"));
            url_textBox.SetBinding(TextBox.TextProperty, new Binding("Url"));
            user_textBox.SetBinding(TextBox.TextProperty, new Binding("User"));
            pwd_textBox.SetBinding(TextBox.TextProperty, new Binding("Password"));
            phone_textBox.SetBinding(TextBox.TextProperty, new Binding("Phone"));
            mail_textBox.SetBinding(TextBox.TextProperty, new Binding("Mail"));
            notes_textBox.SetBinding(TextBox.TextProperty, new Binding("Notes"));

            
        }




        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 获取鼠标相对标题栏位置
            Point position = e.GetPosition(titlegrid);

            // 如果鼠标位置在标题栏内，允许拖动
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (position.X >= 0 && position.X < titlegrid.ActualWidth && position.Y >= 0 && position.Y < titlegrid.ActualHeight)
                {
                    Window m = Application.Current.Properties["mainwindow"] as Window;
                    m.DragMove();
                }
            }
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AClosing.xaml", UriKind.Relative));

            AUtils t = new AUtils();
            Thread ec = new Thread(t.WaitingEncrypt);
            ec.Start();


        }

        private void min_button_Click(object sender, RoutedEventArgs e)
        {
            Window m = Application.Current.Properties["mainwindow"] as Window;

            m.WindowState = WindowState.Minimized;

        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AHome.xaml", UriKind.Relative));

        }

        private void ok_button_Click(object sender, RoutedEventArgs e)
        {
            if (tag_textBox.Text != "")
            {
                if(accountviewmodel.WriteAccount() == 1)
                {
                    AUtils tool = new AUtils();
                    tool.ReadCatalog();

                    NavigationService.Navigate(new Uri("AHome.xaml", UriKind.Relative));

                }
               

            }
            else 
            {
                tag_textBox.Foreground = Brushes.Red;
                tag_textBox.Text = "Tag can NOT be null";

            }

        }
    }
}
