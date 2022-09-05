using System.ComponentModel.DataAnnotations;

namespace ProductApi.Data
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "State Title", Prompt = "Enter State Title")]
        [Required(ErrorMessage = "State Title is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title length between 3-50")]
        public string Title { get; set; }
    }
}