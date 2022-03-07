using GruppUppgift_Pärlhalsband.InterfaceModel;

namespace GruppUppgift_Pärlhalsband.Model
{
    internal class Pearl : IPearl
    {
        #region Class Fields and propertis
        public decimal Price
        {
            get
            {
                if (this.Origin == Origins.SweetWater)
                {
                    return this.Size * 50;
                }
                else
                    return (this.Size * 50) * 2;

            }
        }
        private int _size;
        public int Size
        {
            get => _size; private set
            {
                if (value < 5)
                {
                    _size = 5;
                }
                else if (value > 25)
                {
                    _size = 25;
                }
                else { _size = value; }
            }
        }
        public Colors Color { get; private set; }
        public Shapes Shape { get; private set; }
        public Origins Origin { get; private set; }
        #endregion

        #region Implementetion off IEquatable, IComparable, GetHashCode and ToString
        public int CompareTo(IPearl other)
        {
            if (this.Size != other.Size)
                return this.Size.CompareTo(other.Size);
            else if (this.Color != other.Color)
                return this.Color.CompareTo(other.Color);
            else
                return this.Shape.CompareTo(other.Shape);
        }
        public bool Equals(IPearl other) => (this.Size, this.Origin, this.Color, this.Shape) == (other.Size, other.Origin, other.Color, other.Shape);
        public override string ToString()
        {
            return $"\nPrice:{this.Price}\nSize:{this.Size}mm\nColor:{this.Color}\nShape:{this.Shape}\nOrigins:{this.Origin}\n";
        }
        public override int GetHashCode() => (this.Size, this.Origin, this.Color, this.Shape).GetHashCode();
        public override bool Equals(object? obj) => Equals(obj as IPearl);
        #endregion

        #region Methods aand Constructers
        public Pearl SetColor(Colors color) => new Pearl(this) { Color = color };
        public Pearl SetShape(Shapes shape) => new Pearl(this) { Shape = shape };
        public Pearl SetOrigins(Origins origin) => new Pearl(this) { Origin = origin };
        public Pearl SetSize(int size) => new Pearl(this) { Size = size };
        public Pearl(int size, Colors color, Shapes shape, Origins origin)
        {
            Size = size;
            Origin = origin;
            Color = color;
            Shape = shape;
        }
        public Pearl()
        {
            Random rng = new Random();
            Size = rng.Next(5, 26);
            Color = (Colors)rng.Next((int)Colors.Black, (int)Colors.Pink);
            Shape = (Shapes)rng.Next((int)Shapes.Round, (int)Shapes.Dropp);
            Origin = (Origins)rng.Next((int)Origins.SaltWater, (int)Origins.SweetWater);
        }
        public Pearl(Pearl aPearl)
        {
            this.Color = aPearl.Color;
            this.Shape = aPearl.Shape;
            this.Origin = aPearl.Origin;
            this.Size = aPearl.Size;
        }
        #endregion
    }
}
