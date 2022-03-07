using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_Pärlhalsband.InterfaceModel
{
    internal interface INecklace
    {
        IPearl this [int index] { get; }

        decimal Price { get; }

    }
}
