using System.ComponentModel.DataAnnotations;

namespace Trac_WorkReport.Models
{
    public class Projects
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string? Description { get; set; }

    }
}
