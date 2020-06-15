using SophiaStore.Core.DomainObjects;

namespace SophiaStore.Catalog.Domain.Aggregate
{
    public class Dimensions : ValueObject<Dimensions>
    {
        public decimal Height { get; private set; }
        public decimal Width { get; private set; }
        public decimal Depth { get; private set; }

        public Dimensions(decimal height, decimal width, decimal depth)
        {
            AssertionConcern.IsLessOrEquals(height, 1, "Height field can't be less or equal then 1");
            AssertionConcern.IsLessOrEquals(width, 1, "Width field can't be less or equal then 1");
            AssertionConcern.IsLessOrEquals(depth, 1, "Depth field can't be less or equal then 1");

            Height = height;
            Width = width;
            Depth = depth;
        }

        public string Descripton()
        {
            return $"HxWxD {Height} X {Width} X {Depth}";
        }

        protected override bool EqualsCore(Dimensions dimensions)
        {
            if (dimensions is null) return false;

            if (ReferenceEquals(this, dimensions)) return true;

            return dimensions.Height.Equals(Height) && dimensions.Depth.Equals(Depth) && dimensions.Width.Equals(Width);
        }
    }
}

