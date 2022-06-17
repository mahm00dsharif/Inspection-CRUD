using System.ComponentModel.DataAnnotations;

namespace Inspection.Models
{
    public class InspectionType
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string InspectionName { get; set; }

        public List<Inspection> Inspections { get; set; }
    }
}
