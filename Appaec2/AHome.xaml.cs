using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace Appaec2
{
    /// <summary>
    /// AHome.xaml 的交互逻辑
    /// </summary>
    public partial class AHome : Page
    {


        Button clearbutton;

        private Boolean isHit;
        private List<ALibModel> hitList;
        private int searchStrLen;


        private List<ALibModel> comList;
        private ACompleteViewModel comViewModel;

        ALib lib;

        public AHome()
        {
            InitializeComponent();

            search_textBox.Focus();

            InitClass();

        }

        /// <summary>
        /// 主启动界面，判断是否有数据库
        /// 若有，判断是否运行中，
        /// 运行中则准备搜索补全的控件
        /// 若不是运行中，则显示登录界面
        /// </summary>
        private void InitClass()
        {
            if (AStatic.DbPath != null)
            {
                
                if (AStatic.IsRunning == false)
                {

                    Window m = Application.Current.Properties["mainwindow"] as Window;
                    Frame main_frame = m.FindName("main_frame") as Frame;
                    main_frame.Navigate(new ASignin());
                }


            }
            else
            {
                add_button.IsEnabled = false;
            }

            PrepareCompleteBox();

            lib = new ALib();
            lib_frame.Navigate(lib);


            hitList = new List<ALibModel>();

            comList = new List<ALibModel>();
            searchStrLen = 0;

        }



        private void PrepareCompleteBox()
        {

            clearbutton = new Button();
            clearbutton.Style = FindResource("ClearButtonStyle") as Style;
            clearbutton.Content = "\xE10A";
            clearbutton.FontFamily = new FontFamily("Segoe UI Symbol");
            clearbutton.FontSize = 9;
            clearbutton.AddHandler(MouseDownEvent, new MouseButtonEventHandler(clearbutton_Click), true);
        }








        private void clearbutton_Click(object sender, RoutedEventArgs e)
        {
            search_textBox.Text = "";
            cleargrid.Children.Remove(clearbutton);
            search_textBox.Focus();
        }



        private void set_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AConfig.xaml", UriKind.Relative));

        }



        private string PyIndex(string strChn, ALibModel item)
        {
            int fullmatch = item.Pyindex.IndexOf(strChn);
            int firstmathch = item.Pyfspell.IndexOf(strChn);
            if (fullmatch != -1 || firstmathch != -1)
            {
                return item.Tag;
            }
            else
            {
                return null;
            }

        }

        private void search_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {



            List<ALibModel> searchList;
            isHit = search_textBox.Text.Length < searchStrLen ?
                false : isHit;

            if (!isHit)
            {
                hitList.Clear();
            }

            searchStrLen = search_textBox.Text.Length;

            comList.Clear();



            if (AStatic.Catalog != null && search_textBox.Text != "")
            {

                AUtils t = new AUtils();
                searchList = isHit ? hitList : AStatic.Catalog;


                foreach (ALibModel item in searchList)
                {
                    if (PyIndex(search_textBox.Text, item) == item.Tag)
                    {
                        comList.Add(item);

                        if (!isHit)
                        {
                            hitList.Add(item);
                        }

                    }


                }


                if (comList.Count > 0)
                {
                    isHit = true;
                    //complete_grid.Height = 100;
                    // complete_grid.MaxHeight = 300;
                    //complete_grid.Height = completeListBox.Items.Count * 40; //completeListBox.Height;
                    //complete_grid.Children.Add(completeBorder);

                    //ac.Focus();
                    AComplete com = new AComplete();
                    lib_frame.Navigate(com);

                    ListBox comlb = com.FindName("listBox") as ListBox;

                    comViewModel = comlb.DataContext as ACompleteViewModel;
                    foreach (ALibModel item in comList)
                    {
                        comViewModel.Accountlist.Add(item);
                    }
                    comViewModel.Selectedindex = 0;






                }
                else
                {
                    isHit = false;


                    // if no result in search, show a tip.
                    ALib a = new ALib();
                    lib_frame.Navigate(a);

                    TextBox b = new TextBox() { FontSize = 16 };
                    b.Text = FindResource("StrUid_noresult") as string;
                    b.Text += " \"" + search_textBox.Text + "\"";
                    Grid c = a.FindName("grid") as Grid;
                    c.Children.Add(b);

                }


            }
            else
            {
                isHit = false;

                lib_frame.Navigate(new Uri("ALib.xaml", UriKind.Relative));

            }



        }


        private void search_textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                int li = comViewModel.Selectedindex + 1;
                comViewModel.Selectedindex = li > comList.Count
                    ? comList.Count : li;

            }
            if (e.Key == Key.Up)
            {
                int li = comViewModel.Selectedindex - 1;
                comViewModel.Selectedindex = li < 0
                    ? 0 : li;

            }
            if (e.Key == Key.Enter)
            {
                if (comList.Count > 0 && comViewModel.Selectedindex != -1)
                {
                    search_textBox.Text = comList[comViewModel.Selectedindex].Tag;

                    comList.Clear();

                    AResult result = new AResult(search_textBox.Text);
                    NavigationService.Navigate(result);


                }


                search_textBox.Focus();
                search_textBox.SelectAll();




                //textBlock.Text = "search selected.";
            }
            if (e.Key == Key.Escape)
            {
                clearbutton_Click(null, null);

            }
        }


        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(search_textBox.Text, "test");
            search_textBox_TextChanged(null, null);

        }



  



        private void add_button_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new BAccount());

        }

 







        void search_textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            cleargrid.Children.Clear();

            search_textBox.PreviewMouseDown += new MouseButtonEventHandler(search_textBox_PreviewMouseDown);
        }

        void search_textBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            search_textBox.Focus();

            e.Handled = true;
        }

        void search_textBox_GotFocus(object sender, RoutedEventArgs e)
        {

            search_textBox.SelectAll();
            if (search_textBox.Text != "")
            {
                cleargrid.Children.Add(clearbutton);
            }

            search_textBox.PreviewMouseDown -= new MouseButtonEventHandler(search_textBox_PreviewMouseDown);
        }

        
    }
}
