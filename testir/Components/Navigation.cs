using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace testir.Components
{
    class Navigation
    {
        public static bool isAuth = false;//авторизовался ли пользователь
        public static MainWindow main;//доступ к элементам окна МаинВиндоу
        public static List<Nav> navs = new List<Nav>();//история страниц
        public static User AuthUser = null;


    }
    class Nav
    {
        public string Title { get; set; }
        public Page Page { get; set; }
        public Nav(string Title, Page Page)
        {
            this.Title = Title;
            this.Page = Page;
        }
    }
}
