using System.ComponentModel.DataAnnotations;

namespace MMDb.Web.ViewModels.Lists
{
    public class CreateMovieListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "\"{0}\" is reqired.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "\"{0}\" should be min {2} and max {1}.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
