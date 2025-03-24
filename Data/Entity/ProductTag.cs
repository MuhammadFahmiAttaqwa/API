using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.SharedKernel;

namespace Data.Entity
{
    public class ProductTag :DomainEntity<int>
    {
        public int ProductId { get; set; }

        [StringLength(50)]
        public string TagId { set; get; }

        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }
}