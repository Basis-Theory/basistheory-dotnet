using System;

namespace BasisTheory.net.Common.Entities
{
    public readonly struct DataImpactLevel : IEquatable<DataImpactLevel>
    {
        private readonly string _name;

        public DataImpactLevel(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public static DataImpactLevel LOW { get; } = new DataImpactLevel("low");
        public static DataImpactLevel MODERATE { get; } = new DataImpactLevel("moderate");
        public static DataImpactLevel HIGH { get; } = new DataImpactLevel("high");

        public override string ToString() => _name;

        public bool Equals(DataImpactLevel other)
        {
            return _name == other._name;
        }

        public override bool Equals(object obj)
        {
            return obj is DataImpactLevel other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }

        public static implicit operator string(DataImpactLevel value) => value._name;
    }

}
