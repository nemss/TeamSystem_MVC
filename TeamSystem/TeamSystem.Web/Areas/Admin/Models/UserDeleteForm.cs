namespace TeamSystem.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserDeleteForm
    {
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
