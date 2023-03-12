using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Dtos
{
    public class UpdateUserModelsDto
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int dueDate { get; set; }
        public string? AssignTo { get; set; }
        public string? TaskRole { get; set; }
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public string? Priority { get; set; }
        public bool isCompleted { get; set; }

    }
}
