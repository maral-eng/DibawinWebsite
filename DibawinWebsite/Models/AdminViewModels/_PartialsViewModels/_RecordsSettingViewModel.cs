using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.Models.AdminViewModels._PartialsViewModels
{
    public class _RecordsSettingViewModel
    {
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string RecordId { get; set; }
        public bool? Status { get; set; }
        public bool? Deleted { get; set; }

        public ActionsName ActionsName { get; set; }
    }
    public class ActionsName
    {
        public string Show { get; set; }
        public string Edit { get; set; }
        public string PermanentRemove { get; set; }
        public string TemporaryRemove { get; set; }
        public string Restore { get; set; }
        public string List { get; set; }
    }
}
