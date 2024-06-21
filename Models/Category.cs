using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entity_Framework.Models
{
    public class Category
    {
        //[Key]
        public Guid CategoryId { get; set; }

       // [Required]
       // [MaxLength(150)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int CategoryImpact {get; set;}

        [JsonIgnore]
        public virtual ICollection<Task> Task { get;}

    }
}
