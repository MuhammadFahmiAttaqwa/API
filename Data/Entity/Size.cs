using Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("Size")]
    public class Size : DomainEntity<int>
    {
        [StringLength(250)]
        public string Name { get; set;}
    }
}