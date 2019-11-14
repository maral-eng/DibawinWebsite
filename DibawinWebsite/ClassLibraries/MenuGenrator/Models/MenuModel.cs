using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.ClassLibraries.MenuGenrator.Models
{
    public class MenuModel
    {
        public MenuModel()
        {
            SubMenus = new List<SubMenu>();
        }
        public string Name { get; set; }
        public string CssIcon { get; set; }
        public string Url { get; set; }
        public List<SubMenu> SubMenus { get; set; }
        public string ParentControllerFullName { get; set; }
        public string ControllerFullName { get; set; }
        public int Order { get; set; }
    }
}
