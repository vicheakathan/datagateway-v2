using ClassLibrary1.Core;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class TaskSaleTransaction : BaseEntity<TaskSaleTransaction>
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(SaleTransaction))]
        public Guid SaleTransactionId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? CompleteDate { get; set; }

        public DateTime? FailDate { get; set; }

        public bool IsSuccess { get; set; }

        public bool IsFail { get; set; }

        public string? Tenant { get; set; }

        public SaleTransaction? SaleTransaction { get; set; }

        public TaskSaleTransaction()
        {
        }
    }
}
