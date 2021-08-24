using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public int ColourId { get; set; }
        public string ColourName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public List<string> ImagePaths { get; set; }
    
    }
}
