using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace IssueTracker.Models
{
    public class UserModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int userId { get; set; }
        public int dueDate { get; set; }
        [Required]
        public string? AssignTo { get; set; }
        [Required]
        public string? TaskRole { get; set; }
        [Required]
        public string? TaskName { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? Notes { get; set; }
        [Required]
        public string? Priority { get; set; }
        public bool isCompleted { get; set; }








    }
}
