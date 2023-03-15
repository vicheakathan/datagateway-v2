using ClassLibrary1.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class SaleItems : BaseEntity<SaleItems>
    {
        public Guid Id { get; set; }

        [StringLength(128)]
        public long QueueNo { get; set; }

        public DateTime OrderDateTime { get; set; }

        [StringLength(128)]
        public string? Name { get; set; }

        [StringLength(128)]
        public string? NameEnglish { get; set; }

        [StringLength(128)]
        public string? NameKhmer { get; set; }

        [StringLength(128)]
        public string? ItemCd { get; set; }

        [StringLength(128)]
        public string? ItemSku { get; set; }

        [StringLength(128)]
        public string? Type { get; set; }

        [StringLength(128)]
        public string? GroupCd { get; set; }

        [StringLength(128)]
        public string? GroupName { get; set; }

        [StringLength(128)]
        public string? GroupEnglishName { get; set; }

        [StringLength(128)]
        public string? GroupKhmerName { get; set; }

        [StringLength(128)]
        public string? GroupAbv { get; set; }

        [StringLength(128)]
        public string? CategoryCd { get; set; }

        [StringLength(128)]
        public string? CategoryName { get; set; }

        [StringLength(128)]
        public string? CategoryEnglishName { get; set; }

        [StringLength(128)]
        public string? CategoryKhmerName { get; set; }

        [StringLength(128)]
        public string? CategoryAbv { get; set; }

        [StringLength(128)]
        public string? SizeCd { get; set; }

        [StringLength(128)]
        public string? SizeName { get; set; }

        [StringLength(128)]
        public string? SizeEnglishName { get; set; }

        [StringLength(128)]
        public string? SizeKhmerName { get; set; }

        [StringLength(128)]
        public string? SizeAbv { get; set; }

        [StringLength(128)]
        public string? ImageUrl { get; set; }

        [Column(TypeName = "Money")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "Money")]
        public decimal qty { get; set; }

        [Column(TypeName = "Money")]
        public decimal SubAmount { get; set; }

        [Column(TypeName = "Money")]
        public decimal Discount { get; set; }

        [StringLength(128)]
        public string? DiscountType { get; set; }

        [StringLength(128)]
        public string? DiscountName { get; set; }

        [StringLength(128)]
        public string? DiscountCode { get; set; }

        [StringLength(128)]
        public string? ReasonCode { get; set; }

        [StringLength(128)]
        public string? ReasonCodeName { get; set; }

        [Column(TypeName = "Money")]
        public decimal GrandAmount { get; set; }

        [Column(TypeName = "Money")]
        public decimal Vat { get; set; }

        [Column(TypeName = "Money")]
        public decimal VatPercentage { get; set; }

        [Column(TypeName = "Money")]
        public decimal Plt { get; set; }

        [StringLength(128)]
        public string? Note { get; set; }

        [StringLength(128)]
        public string? Status { get; set; }

        [StringLength(128)]
        public string? SeatNumber { get; set; }

        [StringLength(128)]
        public string? OrderById { get; set; }

        [StringLength(128)]
        public string? OrderByName { get; set; }

        public Guid OrderByTerminalId { get; set; }
        [StringLength(128)]
        public string? OrderByTerminalName { get; set; }

        [ForeignKey(nameof(SaleTransaction))]
        public Guid SaleTransactionId {get;set;}

        public SaleTransaction? SaleTransaction { get; set;}

        public SaleItems()
        {
        }
    }
}
