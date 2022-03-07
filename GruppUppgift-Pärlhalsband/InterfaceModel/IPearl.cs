using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_Pärlhalsband.InterfaceModel
{
    public enum Colors { Black, White, Pink }
    public enum Shapes { Round, Dropp }
    public enum Origins { SaltWater, SweetWater }
    internal interface IPearl : IEquatable<IPearl>, IComparable<IPearl>
    {
        decimal Price { get; }
        int Size { get; }
        Colors Color { get; }
        Shapes Shape { get; }
        Origins Origin { get; }
    }
}
