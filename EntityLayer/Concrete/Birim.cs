using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Birim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Birim adı boş bırakılamaz")]
        [StringLength(100, ErrorMessage = "Birim adı en fazla 100 karakter olabilir")]
        public string Ad { get; set; }
        public bool IsActive { get; set; }
    }
}
