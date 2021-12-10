using System;

namespace BasisTheory.net.Common.Entities
{
    public readonly struct DataClassification : IEquatable<DataClassification>
    {
        private readonly string _name;

        public DataClassification(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public static DataClassification GENERAL { get; } = new DataClassification("general");
        public static DataClassification BANK { get; } = new DataClassification("bank");
        public static DataClassification PCI { get; } = new DataClassification("pci");
        public static DataClassification PII { get; } = new DataClassification("pii");

        public override string ToString() => _name;

        public bool Equals(DataClassification other)
        {
            return _name == other._name;
        }

        public override bool Equals(object obj)
        {
            return obj is DataClassification other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }

        public static implicit operator string(DataClassification value) => value._name;
    }

}
