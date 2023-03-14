using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core
{
    public class ClientSaleItems
    {
        public long QueueNo { get; set; }

        public DateTime OrderDateTime { get; set; }

        public string? Name { get; set; }

        public string? NameEnglish { get; set; }

        public string? NameKhmer { get; set; }

        public string? ItemCd { get; set; }

        public string? ItemSku { get; set; }

        public string? Type { get; set; }

        public string? GroupCd { get; set; }

        public string? GroupName { get; set; }

        public string? GroupEnglishName { get; set; }

        public string? GroupKhmerName { get; set; }

        public string? GroupAbv { get; set; }

        public string? CategoryCd { get; set; }

        public string? CategoryName { get; set; }

        public string? CategoryEnglishName { get; set; }

        public string? CategoryKhmerName { get; set; }

        public string? CategoryAbv { get; set; }

        public string? SizeCd { get; set; }

        public string? SizeName { get; set; }

        public string? SizeEnglishName { get; set; }

        public string? SizeKhmerName { get; set; }

        public string? SizeAbv { get; set; }

        public string? ImageUrl { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal qty { get; set; }

        public decimal SubAmount { get; set; }

        public decimal Discount { get; set; }

        public string? DiscountType { get; set; }

        public string? DiscountName { get; set; }

        public string? DiscountCode { get; set; }

        public string? ReasonCode { get; set; }

        public string? ReasonCodeName { get; set; }

        public decimal GrandAmount { get; set; }

        public decimal Vat { get; set; }

        public decimal VatPercentage { get; set; }

        public decimal Plt { get; set; }

        public string? Note { get; set; }

        public string? Status { get; set; }

        public string? SeatNumber { get; set; }

        public string? OrderById { get; set; }

        public string? OrderByName { get; set; }

        public Guid OrderByTerminalId { get; set; }

        public string? OrderByTerminalName { get; set; }

        public Guid SaleTransactionId { get; set; }

        public ClientSaleItems()
        {
        }
    }
}
