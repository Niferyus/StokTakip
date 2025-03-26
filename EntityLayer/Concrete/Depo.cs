using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Depo:EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Ad { get; set; }
        [Required]
        public int SehirId { get; set; }
        [ForeignKey("SehirId")]
        public Yerlesim Sehirr { get; set; }
        [Required]
        public int IlceId { get; set; }
        [ForeignKey("IlceId")]
        public Yerlesim Ilcee { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Adres { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string Mail { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string Yetkili { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Aciklama { get; set; }
        public ICollection<Urunler> Urunler { get; set; }
        public ICollection<Stok> Stoklar { get; set; }

    }
}
