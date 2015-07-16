//  DataContext of complete page.
//	Copyright(C) 2015 hez0rs <hez0rs@163.com>
//
//	This program is free software : you can redistribute it and / or modify
//	it under the terms of the GNU General Public License as published by
//	the Free Software Foundation, either version 3 of the License, or
//	(at your option) any later version.
//
//	This program is distributed in the hope that it will be useful,
//	but WITHOUT ANY WARRANTY; without even the implied warranty of
//	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//	GNU General Public License for more details.
//
//	You should have received a copy of the GNU General Public License
//	along with this program.If not, see < http://www.gnu.org/licenses/>.
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
