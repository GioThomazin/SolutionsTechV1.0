using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.Business.Entity
{
    public class TypeProcedure
    {
        [Key]
        public long IdTypeProcedure { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
    }
}
