using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dtos
{
    public class StokDto
    {
        public int Id { get; set; }
        public string DepoName { get; set; }
        public int StokMiktar { get; set; }
    }
}
