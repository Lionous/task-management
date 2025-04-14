using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace application.Models
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid id { get; set; }
        public string name { get; set; }
        
        public ICollection<Homework> ListTask { get; set; } = new List<Homework>();
    }
}
