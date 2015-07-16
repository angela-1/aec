



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appaec2
{
    class ALibModel
    {
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
            }
        }


        private string pyindex;
        public string Pyindex
        {
            get
            {
                return pyindex;
            }
            set
            {
                pyindex = value;
            }
        }

        private string pyfspell;
        public string Pyfspell
        {
            get
            {
                return pyfspell;
            }
            set
            {
                pyfspell = value;
            }
        }

        public ALibModel()
        {

        }


        public ALibModel(string t, string c, string py, string pyf)
        {
            tag = t;
            category = c;
            pyindex = py;
            pyfspell = pyf;
        }


    }
}
