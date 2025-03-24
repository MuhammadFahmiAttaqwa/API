using Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("Color")]
    public class Color : DomainEntity<int>
    {

        [StringLength(250)]
        public string Name { get; set;}

        [StringLength(250)]
        public string Code { get; set; }

    }
}