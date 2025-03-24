using Data.Enums;
using Data.Interface;
using Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("ProductCategory")]
    public class ProductCategory : DomainEntity<int>, IHasSeoMetaData, ISwitchable, ISortable, IDateTracking
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public string? Image { get; set; }

        public bool? HomeFlag { get; set; }

        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public string? SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string? SeoKeywords { set; get; }
        public string? SeoDescription { set; get; }

        public virtual ICollection<Product> Products { set; get; } = new List<Product>();
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}