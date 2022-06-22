using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Models
{
    public class Inspection
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Status { get; set; }
        [StringLength(200)]
        public string Comments { get; set; }
        public int InspectionTypeId { get; set; }
        [ForeignKey("InspectionTypeId")]
        public virtual InspectionType InspectionType { get; set; }
    }
}
