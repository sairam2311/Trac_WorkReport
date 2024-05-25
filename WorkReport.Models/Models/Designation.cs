using System.ComponentModel.DataAnnotations;

namespace Trac_WorkReport.Models
{
    public class Designation
    {
        [Key]
        public int DesId { get; set; }
        public string DesShort { get; set; }  // Assuming this represents the title of the designation

        public string DesFull { get; set; }

        // Other properties related to designation, if any
    }
}
