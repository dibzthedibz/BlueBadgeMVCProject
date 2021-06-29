using System.ComponentModel.DataAnnotations;

namespace WOTMVC.Models.BookMods
{
    public class BookCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int PageCount { get; set; }
    }
}
