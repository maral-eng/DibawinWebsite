using DibawinWebsite.ClassLibraries.MenuGenrator.Attributes;
using DibawinWebsite.ClassLibraries.MenuGenrator.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DibawinWebsite.ClassLibraries.MenuGenrator
{
    public class MenuGenerator
    {
        public static List<MenuModel> CreateMenu()
        {
            List<MenuModel> menus = new List<MenuModel>();

            var currentAssembly = Assembly.GetAssembly(typeof(MenuGenerator));
            var allControllers = currentAssembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Controller))).ToList();
            var menuControllers = allControllers.Where(x => x.GetCustomAttribute<MenuItemAttribute>() != null ||
                                                        x.GetMethods().Any(m => m.GetCustomAttribute<MenuItemAttribute>() != null))
                                                        .ToList();

            List<MenuModel> subMenuControllers = new List<MenuModel>();

            menuControllers.ForEach(controller =>
            {
                var navigation = controller.GetCustomAttribute<MenuItemAttribute>();
                if (navigation == null)
                {
                    controller.GetMethods().ToList().ForEach(method =>
                    {
                        navigation = method.GetCustomAttribute<MenuItemAttribute>();
                        if (navigation == null)
                        {
                            return;
                        }
                        if (!UserHasAccess(method.GetCustomAttribute<AuthorizedRoleAttribute>()))
                        {
                            return;
                        }
                        MenuModel actionMenu = CreateAreaMenuItemFromAction(controller, method, navigation);
                        menus.Add(actionMenu);
                    });
                    return;
                }//navigation

                if (!UserHasAccess(controller.GetCustomAttribute<AuthorizedRoleAttribute>())) return;
                MenuModel menu = CreateAreaMenuItemFromController(controller, navigation);
                if (navigation.ParentController != null)
                {
                    if (navigation.ParentController.IsSubclassOf(typeof(Controller)))
                    {
                        menu.ParentControllerFullName = navigation.ParentController.FullName;
                        subMenuControllers.Add(menu);
                    }
                }
                menus.Add(menu);
            });
            menus = menus.Except(subMenuControllers).ToList();
            subMenuControllers.ForEach(sm =>
            {
                var parentMenu = menus.FirstOrDefault(m => m.ControllerFullName == sm.ParentControllerFullName);
                parentMenu?.SubMenus.Add(new SubMenu() { Name = sm.Name, Url = sm.Url });
            });
            return menus.OrderBy(m => m.Order).ToList();
        }

        private static MenuModel CreateAreaMenuItemFromController(Type controller, MenuItemAttribute menuItemAttribute)
        {
            string area = GetAreaNameForController(controller);
            var controllerName = controller.Name.Replace("Controller", "");
            var menu = new MenuModel()
            {
                Name = menuItemAttribute.Title ?? controllerName,
                ControllerFullName = controller.FullName,
                Order = menuItemAttribute.Order,
                CssIcon = menuItemAttribute.CssIcon
            };

            if (menuItemAttribute.IsClickable)
            {
                menu.Url = CreateActionPath(area, controllerName, menuItemAttribute.Action ?? "Index");
            }
            var submenus = new List<SubMenu>(); //The actions under the controller becomes submenu
            controller.GetMethods().ToList().ForEach(method =>
            {
                menuItemAttribute = method.GetCustomAttribute<MenuItemAttribute>();
                if (menuItemAttribute == null) return;
                if (!UserHasAccess(method.GetCustomAttribute<AuthorizedRoleAttribute>())) return;
                var submenu = new SubMenu()
                {

                    Name = menuItemAttribute.Title ?? method.Name,
                    Order = menuItemAttribute.Order,
                    CssIcon = menuItemAttribute.CssIcon

                };
                if (menuItemAttribute.IsClickable)
                {
                    submenu.Url = CreateActionPath(area, controllerName, method.Name);
                }
                submenus.Add(submenu);
            });
            menu.SubMenus = submenus.OrderBy(m => m.Order).ToList();
            return menu;
        }

        private static MenuModel CreateAreaMenuItemFromAction(Type controller, MethodInfo method, MenuItemAttribute menuItemAttribute)
        {
            string area = GetAreaNameForController(controller);

            var menu = new MenuModel()
            {
                Name = menuItemAttribute.Title ?? method.Name,
                ControllerFullName = controller.FullName,
                Order = menuItemAttribute.Order,
                CssIcon = menuItemAttribute.CssIcon
            };
            if (menuItemAttribute.IsClickable)
            {
                menu.Url = CreateActionPath(area, controller.Name.Replace("Controller", ""), method.Name);
            }
            return menu;
        }

        private static string CreateActionPath(string area, string controller, string action)
        {
            if (string.IsNullOrWhiteSpace(area))
                return $"~/{controller}/{action}";
            return $"~/{area}/{controller}/{action}";
        }

        private static string GetAreaNameForController(Type controller)
        {
            var area = "";
            if (string.IsNullOrWhiteSpace(controller.Namespace))
            {
                return area;
            }
            if (controller.Namespace.Contains("Areas"))
            {
                var parts = controller.Namespace.Split('.').ToList();
                area = parts[parts.FindLastIndex(n => n.Equals("Areas")) + 1];
            }
            return area;
        }

        public static string GetTitleOfController(string controllerName)
        {
            string controllerTitle = null;
            try
            {
                var currentAssembly = Assembly.GetAssembly(typeof(MenuGenerator));
                var allControllers = currentAssembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Controller))).ToList();
                var allActions = currentAssembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Action))).ToList();
                var menuControllers = allControllers.Where(x => x.GetCustomAttribute<MenuItemAttribute>() != null ||
                                                            x.GetMethods().Any(m => m.GetCustomAttribute<MenuItemAttribute>() != null))
                                                            .ToList();
                
                
                var currentController = menuControllers.Where(x => x.Name == $"{controllerName}Controller").FirstOrDefault();
                var controllerAttr = currentController.GetCustomAttribute<MenuItemAttribute>();
                controllerTitle = controllerAttr.Title;
                return controllerTitle;
            }
            catch(Exception ex)
            {
                return controllerTitle;
            }
            
        }
        public static string GetTitleOfAction(string actionName)
        {
            string actionTitle = null;
            var currentAssembly = Assembly.GetAssembly(typeof(MenuGenerator));
            var allControllers = currentAssembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Controller))).ToList();
            var allActions = currentAssembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Action))).ToList();
            var menuControllers = allControllers.Where(x => x.GetCustomAttribute<MenuItemAttribute>() != null ||
                                                        x.GetMethods().Any(m => m.GetCustomAttribute<MenuItemAttribute>() != null))
                                                        .ToList();


            return actionTitle;
        }
        private static bool UserHasAccess(AuthorizedRoleAttribute authorizedRoleAttribute)
        {
            if (authorizedRoleAttribute == null) return true;
            //write the right logic here. you may call a backend service to verify
            return authorizedRoleAttribute.Role == "Admin";
        }
    }
}
