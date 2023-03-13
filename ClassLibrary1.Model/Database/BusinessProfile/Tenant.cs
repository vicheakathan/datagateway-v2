using ClassLibrary1.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class Tenant : BaseEntity<Tenant>
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string? Name { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool? IsActive { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompnayId { get; set; }

        public Company? Company { get; set; }

        public Tenant()
        {
            CreateDate = DateTime.Now;
        }
    }
}
