using System;

namespace Task_4_2
{
    public sealed class RationalNumber : IComparable<RationalNumber>
    {
        private readonly int _denominator;

        public int Numerator { get; }
        public int Denominator
        {
            get => _denominator;
            init
            {
                if (value == 0)
                {
                    throw new DivideByZeroException();
                }

                _denominator = value;
            }
        }

        public static int Gcd(int p, int q)
        {
            if (q == 0)
            {
                return p;
            }

            var r = p % q;

            return Gcd(q, r);
        }

        public RationalNumber(int numerator = 0, int denominator = 1) 
        {
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            var gcd = Gcd(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        public int CompareTo(RationalNumber other)
        {
            return Numerator * other.Denominator - other.Numerator * Denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj is not RationalNumber rational)
            {
                return false;
            }

            return (Numerator == rational.Numerator && Denominator == rational.Denominator);
        }

        public override string ToString()
        {
            return Denominator == 1 ? $"Ration number: {Numerator}" : $"Ration number: {Numerator}/{Denominator}";
        }

        public override int GetHashCode()
        {
            return Numerator;
        }

        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) =>
            new(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);

        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) =>
            new(r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);

        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) =>
            new(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);

        public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) =>
            new(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);

        public static explicit operator double(RationalNumber r) => r.Numerator  / (double)r.Denominator;

        public static implicit operator RationalNumber(int a) => new(a, 1);
    }
}