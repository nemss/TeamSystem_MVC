namespace TeamSystem.Web.Areas.Admin.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;

    public class PlayerFormModel
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Ucn { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsReserved { get; set; }

        public IEnumerable<SelectListItem> ModelRoles { get; set; }

        public IEnumerable<SelectListItem> Teams { get; set; }
    }
}
