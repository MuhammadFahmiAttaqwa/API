using Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("AdvertistmentPage")]
    public class AdvertistmentPage : DomainEntity<string>
    {

        public string Name { get; set; }

        public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; } = new List<AdvertistmentPosition>();

    }
}