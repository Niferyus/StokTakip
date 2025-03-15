using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public abstract class EntityBase
    {
        public int InsUserId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        public bool Approved { get; set; }
        public bool Active { get; set; }
    }
}
