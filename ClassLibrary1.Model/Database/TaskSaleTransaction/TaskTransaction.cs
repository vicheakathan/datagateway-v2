using ClassLibrary1.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class TaskTransaction : BaseEntity<TaskTransaction>
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public ICollection<TaskSaleTransaction>? TaskSaleTransaction { get; set; }

        public TaskTransaction()
        {
            TaskSaleTransaction = new Collection<TaskSaleTransaction>();
        }
    }
}
