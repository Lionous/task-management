using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using application.DTOs.Enums;

namespace application.Models
{
    public class Homework
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public StatusEnum status { get; set; }
        public DateTime create_at { get; set; }
        
        public Guid category_id { get; set; }
        public Category? Category { get; set; }
    }
}
