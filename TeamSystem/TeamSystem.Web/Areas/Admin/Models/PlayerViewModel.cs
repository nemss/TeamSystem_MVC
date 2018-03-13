namespace TeamSystem.Web.Areas.Admin.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class PlayerViewModel
    {
        public IEnumerable<SelectListItem> ModelRoles { get; set; }

        public IEnumerable<SelectListItem> Teams { get; set; }
    }
}
