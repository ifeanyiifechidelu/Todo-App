using System;
using System.ComponentModel.DataAnnotations;

namespace Webform.Models
{
    public class FormModel
    {
        [Key]
        public int TaskId { get; set; }

        [Required (ErrorMessage ="Enter the Task")]
        [Display(Name = "Task")]
        public string Task { get; set; }
        public DateTime DueDate { get; set; }
    }
}
