using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework.Models
{
    public class Task
    {
        //[Key]
        public Guid TaskId { get; set; }
        [ForeignKey("CategoryId")]
        public Guid CategoryId{ get; set; }
       // [Required]
        //[MaxLength(200)]
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public Priority PriorityTask { get; set; }
        public DateTime TaskDate { get; set; }        
        public virtual Category Category { get; set; }
        
        //[NotMapped]
        public string resum {get;set;}



    }
    public enum Priority
    {    
        Low,
        Medium,
        High
    }
}
