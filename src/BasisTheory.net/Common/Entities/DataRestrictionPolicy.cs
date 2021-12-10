using System;

namespace BasisTheory.net.Common.Entities
{
    public readonly struct DataRestrictionPolicy : IEquatable<DataRestrictionPolicy>
    {
        private readonly string _name;

        public DataRestrictionPolicy(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public static DataRestrictionPolicy MASK { get; } = new DataRestrictionPolicy("mask");
        public static DataRestrictionPolicy REDACT { get; } = new DataRestrictionPolicy("redact");

        public override string ToString() => _name;

        public bool Equals(DataRestrictionPolicy other)
        {
            return _name == other._name;
        }

        public override bool Equals(object obj)
        {
            return obj is DataRestrictionPolicy other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }

        public static implicit operator string(DataRestrictionPolicy value) => value._name;
    }

}
