using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Colour:ICar
    {
        public int CarId { get; set; }
        public string ColorName { get; set; }
    }
}
