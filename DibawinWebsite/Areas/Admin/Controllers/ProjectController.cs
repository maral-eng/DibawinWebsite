using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.ClassLibraries;
using DibawinWebsite.ClassLibraries.MenuGenrator.Attributes;
using DibawinWebsite.ClassLibraries.NotificationHandler;
using DibawinWebsite.ClassLibraries.Pagination;
using DibawinWebsite.Models;
using DibawinWebsite.Models.AdminViewModels;
using DibawinWebsite.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DibawinWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperVisor")]
    [MenuItem(Title = "پروژه ها", CssIcon = "ion ion-cube", Order = 3)]
    public class ProjectController : Controller
    {
        #region Inject
        private readonly IHostingEnvironment _hostingEnvironment;
        readonly string contentRootPath;
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        DbRepository<MyDBContext, Category, int> _dbCategory;
        DbRepository<MyDBContext, Clients, int> _dbClient;
        DbRepository<MyDBContext, ClientAddress, int> _dbClientAddress;
        DbRepository<MyDBContext, Skills, int> _dbSkills;
        DbRepository<MyDBContext, Projects, int> _dbProject;
        MyDBContext _db;
        public ProjectController
            (
                IHostingEnvironment hostingEnvironment,
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager,
                DbRepository<MyDBContext, Category, int> dbCategory,
                DbRepository<MyDBContext, Clients, int> dbClient,
                DbRepository<MyDBContext, ClientAddress, int> dbClientAddress,
                DbRepository<MyDBContext, Skills, int> dbSkills,
                DbRepository<MyDBContext, Projects, int> dbProject,
                MyDBContext db
            )
        {
            _hostingEnvironment = hostingEnvironment;
            contentRootPath = _hostingEnvironment.ContentRootPath;//returns the root path of the website
            _userManager = userManager;
            _roleManager = roleManager;

            _dbCategory = dbCategory;
            _dbClient = dbClient;
            _dbClientAddress = dbClientAddress;
            _dbSkills = dbSkills;
            _dbProject = dbProject;
            _db = db;
        }
        #endregion

        #region Projects
        [MenuItem(Title = "ثبت پروژه")]
        public ViewResult AddProject(string notification)
        {
            ViewData["CatList"] = _dbCategory.GetInclude(x => x.Parent).Where(x => x.Status == true).ToList();
            ViewData["SkillsList"] = _dbSkills.GetAll().Where(x => x.Status == true).ToList();
            ViewData["Clients"] = _dbClient.GetAll().Where(x => x.Status == true).ToList();
            if (notification != null)
            {
                ViewData["nvm"] = NotificationHandler.DeserializeMessage(notification);
                return View();
            }
            return View();
        }//end AddProject

        public async Task<IActionResult> AddProjectConfirm(ProjectClientViewModel model)
        {
            string nvm;
            try
            {
                if (!ModelState.IsValid)
                {
                    nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Wrong_Values, contentRootPath);
                    return RedirectToAction("Add", new { notification = nvm });
                }
                if (model != null)
                {
                    var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                    if (currentUser != null)
                    {
                        Projects newProject = new Projects()
                        {
                            Title = model.Title,
                            LatinTitle = model.LatinTitle,
                            Status = model.Status,
                            CategoryId = model.CategoryId > 0 ? model.CategoryId : null,
                            ClientId = model.ClientId > 0 ? model.ClientId : null,
                            Collaborators = model.Collaborators,
                            ProjectManagerFullName = model.ProjectManagerFullName,
                            Description = model.Description,
                            DefinedByUser = currentUser,
                            Starts = model.Starts != null ? CustomizeCalendar.PersianToGregorian(model.Starts ?? DateTime.Now) : DateTime.Now,
                            Ends = model.Ends != null ? CustomizeCalendar.PersianToGregorian(model.Ends ?? DateTime.Now) : DateTime.Now.AddMonths(2),
                            Technologies = model.Technologies,
                            Price = model.Price > 0 ? model.Price : 0
                        };
                        _dbProject.Insert(newProject);
                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Success_Insert, contentRootPath);
                        return RedirectToAction("AddProject", new { notification = nvm });
                    }

                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Insert, contentRootPath);
                return RedirectToAction("AddProject", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("AddProject", new { notification = nvm });
            }
        }//end AddProjectConfirm

        [MenuItem(Title = "لیست پروژه ها")]
        public ViewResult ProjectList(string notification, int pageNumber = 1, int pageSize = 25, int filter = 0)
        {
            TempData["currentFilter"] = filter;
            var projects = _dbProject.GetInclude(x => x.Client, y => y.DefinedByUser).Where(x => x.Deleted == false).AsQueryable();
            switch (filter)
            {
                case 0:
                    projects = _dbProject.GetInclude(x => x.Client, y => y.DefinedByUser).Where(x => x.Deleted == false).AsQueryable();
                    break;
                case 1:
                    projects = _dbProject.GetInclude(x => x.Client, y => y.DefinedByUser).Where(x => x.Deleted == true).AsQueryable();
                    break;
                case 2:
                    projects = _dbProject.GetInclude(x => x.Client, y => y.DefinedByUser).AsQueryable();
                    break;
                default:
                    projects = _dbProject.GetInclude(x => x.Client, y => y.DefinedByUser).Where(x => x.Deleted == false).AsQueryable();
                    break;
            }

            var Result = PagedResult<Projects>.GetPaged(projects, pageNumber, pageSize);
            var finalResult = Result.Results.ToList();
            //Parameters
            ViewData["pagenumber"] = pageNumber;
            ViewData["pagesize"] = pageSize;
            ViewData["totalRecords"] = projects.Count();

            if (notification != null)
            {
                ViewData["nvm"] = NotificationHandler.DeserializeMessage(notification);
                return View(finalResult);
            }
            return View(finalResult);
        }//end ProjectList

        public IActionResult ShowProject(int id)
        {
            string nvm;
            try
            {
                if (id > 0)
                {
                    var selectedRecord = _dbProject.GetIncludeById(id, x => x.Client, y => y.DefinedByUser, z => z.Category);
                    if (selectedRecord != null)
                    {
                        return View(selectedRecord);
                    }
                    else
                    {
                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Record_Not_Exist, contentRootPath);
                        return RedirectToAction("ProjectList", new { notification = nvm });
                    }
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("ProjectList", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("ProjectList", new { notification = nvm });
            }
        }//end ShowProject

        public IActionResult EditProject(int id)
        {
            string nvm;
            try
            {
                if (id > 0)
                {
                    var selectedRecord = _dbProject.GetIncludeById(id, x => x.Client, y => y.DefinedByUser, z => z.Category);
                    if (selectedRecord != null)
                    {
                        ViewData["CatList"] = _dbCategory.GetInclude(x => x.Parent).Where(x => x.Status == true).ToList();
                        ViewData["SkillsList"] = _dbSkills.GetAll().Where(x => x.Status == true).ToList();
                        ViewData["Clients"] = _dbClient.GetAll().Where(x => x.Status == true).ToList();

                        ViewData["selectedRecord"] = selectedRecord;
                        return View();
                    }
                    else
                    {
                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Record_Not_Exist, contentRootPath);
                        return RedirectToAction("ProjectList", new { notification = nvm });
                    }
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("ProjectList", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("ProjectList", new { notification = nvm });
            }
        }

        public async Task<IActionResult> EditProjectConfirm(ProjectClientViewModel model)
        {
            string nvm;
            try
            {
                if (!ModelState.IsValid)
                {
                    nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Wrong_Values, contentRootPath);
                    return RedirectToAction("ProjectList", new { notification = nvm });
                }
                if (model != null)
                {
                    var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                    var doesExist = _dbProject.GetAll().Where(x => (x.Title == model.Title || x.LatinTitle.ToLower() == model.LatinTitle.ToLower()) && x.Id != model.Id).ToList();
                    if (doesExist.Count > 0)
                    {
                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.DuplicatedValue, contentRootPath);
                        return RedirectToAction("ProjectList", new { notification = nvm });
                    }
                    var modifyingRecord = _dbProject.FindById(model.Id);
                    if (modifyingRecord != null)
                    {
                        modifyingRecord.Title = model.Title;
                        modifyingRecord.LatinTitle = model.LatinTitle;
                        modifyingRecord.ProjectManagerFullName = model.ProjectManagerFullName;
                        modifyingRecord.CategoryId = model.CategoryId;
                        modifyingRecord.Price = model.Price > 0 ? model.Price : 0;
                        modifyingRecord.Collaborators = model.Collaborators != null ? model.Collaborators : modifyingRecord.Collaborators;
                        modifyingRecord.ClientId = model.ClientId;
                        modifyingRecord.Technologies = model.Technologies;
                        modifyingRecord.Starts = model.Starts != null ? CustomizeCalendar.PersianToGregorian(model.Starts ?? DateTime.Now) : DateTime.Now;
                        modifyingRecord.Ends = model.Ends != null ? CustomizeCalendar.PersianToGregorian(model.Ends ?? DateTime.Now) : DateTime.Now.AddMonths(2);
                        modifyingRecord.Description = model.Description;
                        modifyingRecord.Status = model.Status;

                        modifyingRecord.ModifiedByUsers = modifyingRecord.ModifiedByUsers + $" - ویرایش شده توسط: {currentUser.UserName} ، در مورخه: {CustomizeCalendar.GregorianToPersianDateTime(DateTime.Now)} \n ";
                        
                        _dbProject.Update(modifyingRecord);

                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Success_Update, contentRootPath);
                        return RedirectToAction("ProjectList", new { notification = nvm });
                    }
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Update, contentRootPath);
                return RedirectToAction("ProjectList", new { notification = nvm });
            }
            catch(Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("ProjectList", new { notification = nvm });
            }
        }

        public IActionResult RemoveProject(int id)
        {
            string nvm;
            try
            {
                if (id > 0)
                {
                    _dbProject.DeleteById(id);
                    nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Success_Remove, contentRootPath);
                    return RedirectToAction("ProjectList", new { notification = nvm });
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Remove, contentRootPath);
                return RedirectToAction("ProjectList", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("ProjectList", new { notification = nvm });
            }
        }//end RemoveCategory

        public IActionResult TemporaryRemoveProject(int id)
        {
            string nvm;
            try
            {
                if (id > 0)
                {
                    var selectedProject = _dbProject.FindById(id);
                    if (selectedProject != null)
                    {
                        selectedProject.Deleted = true;
                        _dbProject.Update(selectedProject);

                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Success_Remove, contentRootPath);
                        return RedirectToAction("ProjectList", new { notification = nvm });
                    }
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Remove, contentRootPath);
                return RedirectToAction("ProjectList", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("ProjectList", new { notification = nvm });
            }
        }//end TemporaryRemoveProject

        public IActionResult RestoreProject(int id)
        {
            string nvm;
            try
            {
                if (id > 0)
                {
                    var selectedProject = _dbProject.FindById(id);
                    if (selectedProject != null)
                    {
                        selectedProject.Deleted = false;
                        _dbProject.Update(selectedProject);

                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Success_Restore, contentRootPath);
                        return RedirectToAction("ProjectList", new { notification = nvm });
                    }
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Restore, contentRootPath);
                return RedirectToAction("ProjectList", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("ProjectList", new { notification = nvm });
            }
        }//end RestoreProject
        #endregion

        #region Category
        [MenuItem(Title = "افزودن دسته بندی")]
        public ViewResult AddCategory(string notification)
        {
            var catList = _dbCategory.GetInclude(x => x.Parent).Where(x => x.Status == true).ToList();
            ViewData["CatList"] = catList;
            if (notification != null)
            {
                ViewData["nvm"] = NotificationHandler.DeserializeMessage(notification);
                return View();
            }
            return View();
        }//end AddCategory

        public async Task<IActionResult> AddCategoryConfirm(CategoryViewModel model)
        {
            string nvm;
            try
            {
                if (!ModelState.IsValid)
                {
                    nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Wrong_Values, contentRootPath);
                    return RedirectToAction("AddCategory", new { notification = nvm });
                }
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                var doesExist = _dbCategory.GetAll().Where(x => x.Name == model.Name || x.LatinName.ToLower() == model.LatinName.ToLower()).ToList();
                if (doesExist.Count > 0)
                {
                    nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.DuplicatedValue, contentRootPath);
                    return RedirectToAction("AddCategory", new { notification = nvm });
                }
                Category newCategory = new Category()
                {
                    Name = model.Name,
                    LatinName = model.LatinName,
                    Description = model.Description,
                    UserId = currentUser.Id,
                    AliasName = model.AliasName,
                    TitleAltName = model.TitleAltName,
                    Status = model.Status,
                    ConnectedLink = model.ConnectedLink
                };
                if (_dbCategory.GetAll().Count > 0)
                {
                    newCategory.ParentId = model.ParentId;
                }
                _dbCategory.Insert(newCategory);

                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Success_Insert, contentRootPath);
                return RedirectToAction("AddCategory", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("AddCategory", new { notification = nvm });
            }
        }//end AddCategoryConfirm

        [MenuItem(Title = "لیست دسته بندی")]
        public ViewResult CategoryList(string notification, int pageNumber = 1, int pageSize = 25, int filter = 0)
        {
            TempData["currentFilter"] = filter;
            var catList = _dbCategory.GetInclude(x => x.Parent).Where(x => x.Status == true).AsQueryable();
            switch (filter)
            {
                case 0:
                    catList = _dbCategory.GetInclude(x => x.Parent).Where(x => x.Status == true).AsQueryable();
                    break;
                case 1:
                    catList = _dbCategory.GetInclude(x => x.Parent).Where(x => x.Status == false).AsQueryable();
                    break;
                case 2:
                    catList = _dbCategory.GetInclude(x => x.Parent).AsQueryable();
                    break;
                default:
                    catList = _dbCategory.GetInclude(x => x.Parent).Where(x => x.Status == true).AsQueryable();
                    break;
            }
            var Result = PagedResult<Category>.GetPaged(catList, pageNumber, pageSize);
            var finalResult = Result.Results.ToList();
            //Parameters
            ViewData["pagenumber"] = pageNumber;
            ViewData["pagesize"] = pageSize;
            ViewData["totalRecords"] = catList.Count();

            if (notification != null)
            {
                ViewData["nvm"] = NotificationHandler.DeserializeMessage(notification);
                return View(finalResult);
            }
            return View(finalResult);
        }//end CategoryList

        public IActionResult RemoveCategory(int id)
        {
            string nvm;
            try
            {
                if (id > 0)
                {
                    _dbCategory.DeleteById(id);
                    nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Success_Remove, contentRootPath);
                    return RedirectToAction("CategoryList", new { notification = nvm });
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Remove, contentRootPath);
                return RedirectToAction("CategoryList", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("CategoryList", new { notification = nvm });
            }
        }//end RemoveCategory

        public IActionResult ShowCategory(int id)
        {
            string nvm;
            try
            {
                if (id > 0)
                {
                    var selectedRecord = _dbCategory.GetIncludeById(id, x => x.Parent, y => y.InverseParent, z => z.User);
                    if (selectedRecord != null)
                    {
                        return View(selectedRecord);
                    }
                    else
                    {
                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Record_Not_Exist, contentRootPath);
                        return RedirectToAction("CategoryList", new { notification = nvm });
                    }
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("CategoryList", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("CategoryList", new { notification = nvm });
            }
        }//end ShowCategory

        public IActionResult EditCategory(int id)
        {
            string nvm;
            try
            {
                if (id > 0)
                {
                    var selectedRecord = _dbCategory.GetIncludeById(id, x => x.Parent, y => y.InverseParent, z => z.User);
                    if (selectedRecord != null)
                    {
                        var catList = _dbCategory.GetInclude(x => x.Parent).ToList();
                        ViewData["CatList"] = catList;
                        ViewData["selectedCategory"] = selectedRecord;
                        return View();
                    }
                    else
                    {
                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Record_Not_Exist, contentRootPath);
                        return RedirectToAction("CategoryList", new { notification = nvm });
                    }
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("CategoryList", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("CategoryList", new { notification = nvm });
            }
        }//end EditCategory

        public async Task<IActionResult> EditCategoryConfirm(CategoryViewModel model)
        {
            string nvm;
            try
            {
                if (!ModelState.IsValid)
                {
                    nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Wrong_Values, contentRootPath);
                    return RedirectToAction("CategoryList", new { notification = nvm });
                }
                if (model != null)
                {
                    var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                    var doesExist = _dbCategory.GetAll().Where(x => (x.Name == model.Name || x.LatinName.ToLower() == model.LatinName.ToLower()) && x.Id != model.Id).ToList();
                    if (doesExist.Count > 0)
                    {
                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.DuplicatedValue, contentRootPath);
                        return RedirectToAction("CategoryList", new { notification = nvm });
                    }
                    var modifyingCategory = _dbCategory.FindById(model.Id);
                    if (modifyingCategory != null)
                    {
                        modifyingCategory.Name = model.Name;
                        modifyingCategory.LatinName = model.LatinName;
                        modifyingCategory.Status = model.Status;
                        modifyingCategory.ModifiedBy = modifyingCategory.ModifiedBy + $" - ویرایش شده توسط: {currentUser.UserName} ، در مورخه: {CustomizeCalendar.GregorianToPersianDateTime(DateTime.Now)} \n ";
                        modifyingCategory.ParentId = model.ParentId;
                        modifyingCategory.AliasName = model.AliasName;
                        modifyingCategory.TitleAltName = model.TitleAltName;
                        modifyingCategory.Description = model.Description;
                        modifyingCategory.ConnectedLink = model.ConnectedLink;

                        _dbCategory.Update(modifyingCategory);

                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Success_Update, contentRootPath);
                        return RedirectToAction("CategoryList", new { notification = nvm });
                    }
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Update, contentRootPath);
                return RedirectToAction("CategoryList", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("CategoryList", new { notification = nvm });
            }
        }//end EditCategoryConfirm

        public IActionResult TemporaryRemoveCategory(int id)
        {
            string nvm;
            try
            {
                if (id > 0)
                {
                    var selectedRecord = _dbCategory.FindById(id);
                    if (selectedRecord != null)
                    {
                        selectedRecord.Status = false;
                        _dbCategory.Update(selectedRecord);

                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Success_Remove, contentRootPath);
                        return RedirectToAction("CategoryList", new { notification = nvm });
                    }
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Remove, contentRootPath);
                return RedirectToAction("CategoryList", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("CategoryList", new { notification = nvm });
            }
        }//end TemporaryRemoveCategory

        public IActionResult RestoreCategory(int id)
        {
            string nvm;
            try
            {
                if (id > 0)
                {
                    var selectedRecord = _dbCategory.FindById(id);
                    if (selectedRecord != null)
                    {
                        selectedRecord.Status = true;
                        _dbCategory.Update(selectedRecord);

                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Success_Restore, contentRootPath);
                        return RedirectToAction("CategoryList", new { notification = nvm });
                    }
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Restore, contentRootPath);
                return RedirectToAction("CategoryList", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("CategoryList", new { notification = nvm });
            }
        }//end RestoreCategory

        #endregion

        #region Clients
        [MenuItem(Title = "افزودن کارفرمای پروژه")]
        public ViewResult AddClient(string notification)
        {
            if (notification != null)
            {
                ViewData["nvm"] = NotificationHandler.DeserializeMessage(notification);
                return View();
            }
            return View();
        }

        public async Task<IActionResult> AddClientConfirm(ClientViewModel model)
        {
            string nvm;
            try
            {
                if (!ModelState.IsValid)
                {
                    nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Wrong_Values, contentRootPath);
                    return RedirectToAction("AddClient", new { notification = nvm });
                }
                if (model != null)
                {
                    var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                    if (currentUser != null)
                    {
                        var isAlreadyExistClient = _dbClient.GetAll().Where(x => x.Title == model.Title || x.ClientCode == model.ClientCode).ToList();
                        if (isAlreadyExistClient.Count > 0)
                        {
                            nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.DuplicatedValue, contentRootPath);
                            return RedirectToAction("AddClient", new { notification = nvm });
                        }

                        using (var transaction = _db.Database.BeginTransaction())
                        {
                            ApplicationUser newUser = null;
                            IdentityResult newuUser_status = new IdentityResult();
                            var isAlreadyUserFoundByMobile = await _userManager.FindByNameAsync(model.Mobile != null ? model.Mobile : "");
                            var isAlreadyUserFoundByEmail = await _userManager.FindByNameAsync(model.Email != null ? model.Email : "");

                            Clients newClient = new Clients()
                            {
                                Title = model.Title,
                                LatinTitle = model.LatinTitle,
                                Status = model.Status,
                                ManagerFullName = model.ManagerFullName,
                                IsRealPersonality = model.IsRealPersonality,
                                ClientCode = model.ClientCode,
                                DefinedByUser = currentUser
                            };

                            if (isAlreadyUserFoundByEmail == null && isAlreadyUserFoundByMobile == null)
                            {
                                newUser = new ApplicationUser();
                                if (isAlreadyUserFoundByMobile == null)
                                {
                                    newUser.UserName = model.Mobile;
                                    newUser.PhoneNumberConfirmed = true;
                                }
                                else if (isAlreadyUserFoundByEmail == null)
                                {
                                    newUser.UserName = model.Email;
                                    newUser.EmailConfirmed = true;
                                }

                                newUser.LastName = model.ManagerFullName != null ? model.ManagerFullName : null;
                                newUser.PhoneNumber = model.Mobile;
                                newUser.DefinedByUser = currentUser;

                                newuUser_status = await _userManager.CreateAsync(newUser, model.ClientCode);
                                if (newuUser_status.Succeeded)
                                {
                                    await _userManager.AddToRoleAsync(newUser, "Customer");

                                    newClient.User = newUser;
                                }
                            }
                            else if (isAlreadyUserFoundByMobile != null)
                            {
                                newClient.User = isAlreadyUserFoundByMobile;
                            }
                            else if (isAlreadyUserFoundByEmail != null)
                            {
                                newClient.User = isAlreadyUserFoundByEmail;
                            }

                            int newClientInsertResult = _dbClient.Insert(newClient);

                            if (newClientInsertResult >= 1)
                            {
                                ClientAddress clientAddress = new ClientAddress()
                                {
                                    Address = model.Address,
                                    Telephone = model.Telephone,
                                    Mobile = model.Mobile,
                                    Fax = model.Fax,
                                    Coordinates = model.Coordinates,
                                    Email = model.Email,
                                    Comment = model.Comment,
                                    DefinedByUser = currentUser,
                                    PostalCode = model.PostalCode,
                                    Client = newClient
                                };
                                int newClientAddressInsertResult = _dbClientAddress.Insert(clientAddress);

                                transaction.Commit();
                                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Success_Insert, contentRootPath);
                                return RedirectToAction("AddClient", new { notification = nvm });
                            }
                        }
                    }
                    else
                    {
                        nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Login, contentRootPath);
                        return RedirectToAction("AddClient", new { notification = nvm });
                    }
                }
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Insert, contentRootPath);
                return RedirectToAction("AddClient", new { notification = nvm });
            }
            catch (Exception ex)
            {
                nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Failed_Operation, contentRootPath);
                return RedirectToAction("AddClient", new { notification = nvm });
            }
        }
        #endregion
    }
}