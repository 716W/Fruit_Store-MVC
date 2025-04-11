using System.ComponentModel.DataAnnotations.Schema;

namespace Fruit_Store_MVC.Models
{
    public class New
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public String ? Description { get; set; }
        [NotMapped]
        public IFormFile ? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
