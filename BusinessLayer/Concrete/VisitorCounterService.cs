using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class VisitorCounterService
    {
        private int visitorCount;

        public int GetVisitorCount()
        {
            return visitorCount;
        }

        public void IncrementVisitorCount()
        {
            visitorCount++;
        }
    }
}
