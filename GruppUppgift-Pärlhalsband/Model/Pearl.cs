using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GruppUppgift_Pärlhalsband.InterfaceModel;

namespace GruppUppgift_Pärlhalsband.Model
{
    internal class Pearl : IPearl
    {
        public decimal Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Colors Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Shapes Shape { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Origins Origin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int CompareTo(IPearl? other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IPearl? other)
        {
            throw new NotImplementedException();
        }
    }
}
