using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Appaec2
{
    class ACompleteViewModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChange(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }


        private int selectedindex;
        public int Selectedindex
        {
            get
            {
                return selectedindex;
            }
            set
            {
                selectedindex = value;
                NotifyChange("Selectedindex");
            }
        }


        private ObservableCollection<ALibModel> accountlist;
        public ObservableCollection<ALibModel> Accountlist
        {
            get
            {
                return accountlist;
            }
            set
            {
                accountlist = value;
                NotifyChange("Accountlist");
            }
        }

        

        public ACompleteViewModel()
        {

            accountlist = new ObservableCollection<ALibModel>();



        }




    }
}
