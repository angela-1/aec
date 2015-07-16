


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
            InitUi("StrUid_newaccount");
        }

        public BAccount(string t)
        {
            InitializeComponent();

            BindingVar(t);
            InitUi("StrUid_updateaccount");
            // can not modify tag
            tag_textBox.IsEnabled = false;
        }


        private void InitUi(string title)
        {
            MainWindow m = Application.Current.Properties["mainwindow"] as MainWindow;
            m.SetTitle(FindResource(title) as string);
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
