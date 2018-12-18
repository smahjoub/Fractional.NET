using System;
using Fractional.Extentions;


namespace Fractional
{
    /// <summary>
    /// The main Fractional struct that allows parsing and working with fractinal expressions.
    /// </summary>
    public struct Fractional
    {
        #region private consts
        private const decimal ACCURACY_FACTOR = 0.00005m;
        private const long MAX = 999999999999999999L;
        #endregion

        #region private fields
        private long numerator;

        private long denominator;

        private bool isNaN;
        #endregion

        #region ctors
        /// <summary>
        /// Build the fractional object from a human readable repesentation of fractional.
        /// </summary>
        /// <param name="fractional">The fractional repesentation</param>
        public Fractional(string fractional = "0")
        {
            numerator = 0;
            denominator = 1;
            isNaN = false;
            EvaluateFractionalExpression(fractional);
        }

        /// <summary>
        /// Build the fractional object from a decimal
        /// </summary>
        /// <param name="value">The decimal value</param>
        /// <param name="keepExcat">Boolean flag that indicates if given value will be converted into nearest fraction</param>
        public Fractional(decimal value, bool keepExcat)
        {
            numerator = 0;
            denominator = 1;
            isNaN = false;

            if (keepExcat == false)
                ConvertToApproximateFraction(value);
            else
                ConvertToExcateFraction(value);
        }


        /// <summary>
        /// Build the fractional from a given numerator and denominator.
        /// </summary>
        /// <param name="num">The numerator.</param>
        /// <param name="denom">The denominator should be different from zero</param>
        public Fractional(long num, long denom)
        {
            numerator = 0;
            denominator = 1;
            isNaN = false;

            Simplify(num, denom);
        }

        #endregion

        #region propeties
        /// <summary>
        /// Try to get the actual value of the fraction. Throw NotFiniteNumberException if IsNaN is true.
        /// </summary>
        public decimal Value
        {
            get
            {
                if (IsNaN)
                    throw new NotFiniteNumberException();

                return (decimal)Numerator / (decimal)Denominator;
            }
        }
        /// <summary>
        /// Get the Numerator value.
        /// </summary>
        public long Numerator
        {
            get { return numerator; }

            private set
            {
                numerator = value;
            }
        }

        /// <summary>
        /// Get the denominator.
        /// </summary>
        public long Denominator
        {
            get { return denominator; }

            private set
            {
                denominator = value;
            }
        }

        /// <summary>
        /// Retrun an indication wether the object is valid number or not.
        /// </summary>
        public bool IsNaN
        {
            get { return isNaN; }
            private set
            {
                isNaN = value;
            }
        }
        #endregion

        #region override arithmetic operators

        #region addition

        public static Fractional operator +(Fractional f1, string s1)
        {
            var f2 = new Fractional(s1);

            return f1 + f2;
        }

        public static Fractional operator +(Fractional f1, double d)
        {
            var d1 = Convert.ToDecimal(d);

            return f1 + d1;
        }

        public static Fractional operator +(Fractional f1, float f)
        {
            var d1 = Convert.ToDecimal(f);

            return f1 + d1;
        }

        public static Fractional operator +(Fractional f1, long i)
        {
            var f2 = new Fractional(i, 1);

            return Addition(f1, f2);
        }

        public static Fractional operator +(Fractional f1, int i)
        {
            var f2 = new Fractional(i, 1);

            return Addition(f1, f2);
        }

        public static Fractional operator +(Fractional f1, short s)
        {
            var f2 = new Fractional(s, 1);

            return Addition(f1, f2);
        }

        public static Fractional operator +(Fractional f1, decimal d1)
        {
            var f2 = new Fractional(d1, false);

            return Addition(f1, f2);
        }

        public static Fractional operator +(Fractional f1, Fractional f2)
        {
            return Addition(f1, f2);
        }

        private static Fractional Addition(Fractional f1, Fractional f2)
        {
            var commonDenominator = f1.Denominator * f2.Denominator;

            var f1Numerator = f1.Numerator * f2.Denominator;
            var f2Numerator = f2.Numerator * f1.Denominator;

            return new Fractional(f1Numerator + f2Numerator, commonDenominator);
        }
        #endregion

        #region subtraction

        public static Fractional operator -(Fractional f1, string s1)
        {
            var f2 = new Fractional(s1);

            return f1 - f2;
        }

        public static Fractional operator -(Fractional f1, double d)
        {
            var d1 = Convert.ToDecimal(d);

            return f1 - d1;
        }

        public static Fractional operator -(Fractional f1, float f)
        {
            var d1 = Convert.ToDecimal(f);

            return f1 - d1;
        }

        public static Fractional operator -(Fractional f1, long i)
        {
            var f2 = new Fractional(i, 1);

            return Subtraction(f1, f2);
        }

        public static Fractional operator -(Fractional f1, int i)
        {
            var f2 = new Fractional(i, 1);

            return Subtraction(f1, f2);
        }

        public static Fractional operator -(Fractional f1, short s)
        {
            var f2 = new Fractional(s, 1);

            return Subtraction(f1, f2);
        }

        public static Fractional operator -(Fractional f1, decimal d1)
        {
            var f2 = new Fractional(d1, false);

            return Subtraction(f1, f2);
        }

        public static Fractional operator -(Fractional f1, Fractional f2)
        {
            return Subtraction(f1, f2);
        }


        private static Fractional Subtraction(Fractional f1, Fractional f2)
        {
            var commonDenominator = f1.Denominator * f2.Denominator;

            var f1Numerator = f1.Numerator * f2.Denominator;
            var f2Numerator = f2.Numerator * f1.Denominator;

            return new Fractional(f1Numerator - f2Numerator, commonDenominator);
        }
        #endregion

        #region multiplication

        public static Fractional operator *(Fractional f1, string s1)
        {
            var f2 = new Fractional(s1);

            return f1 * f2;
        }

        public static Fractional operator *(Fractional f1, double d)
        {
            var d1 = Convert.ToDecimal(d);

            return f1 * d1;
        }

        public static Fractional operator *(Fractional f1, float f)
        {
            var d1 = Convert.ToDecimal(f);

            return f1 * d1;
        }

        public static Fractional operator *(Fractional f1, long i)
        {
            var f2 = new Fractional(i, 1);

            return Multiplication(f1, f2);
        }

        public static Fractional operator *(Fractional f1, int i)
        {
            var f2 = new Fractional(i, 1);

            return Multiplication(f1, f2);
        }

        public static Fractional operator *(Fractional f1, short s)
        {
            var f2 = new Fractional(s, 1);

            return Multiplication(f1, f2);
        }

        public static Fractional operator *(Fractional f1, decimal d1)
        {
            var f2 = new Fractional(d1, false);

            return Multiplication(f1, f2);
        }

        public static Fractional operator *(Fractional f1, Fractional f2)
        {
            return Multiplication(f1, f2);
        }

        private static Fractional Multiplication(Fractional f1, Fractional f2)
        {
            return new Fractional(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
        }
        #endregion

        #region division

        public static Fractional operator /(Fractional f1, string s1)
        {
            var f2 = new Fractional(s1);

            return f1 / f2;
        }

        public static Fractional operator /(Fractional f1, double d)
        {
            var d1 = Convert.ToDecimal(d);

            return f1 / d1;
        }

        public static Fractional operator /(Fractional f1, float f)
        {
            var d1 = Convert.ToDecimal(f);

            return f1 / d1;
        }

        public static Fractional operator /(Fractional f1, long i)
        {
            var f2 = new Fractional(i, 1);

            return Division(f1, f2);
        }

        public static Fractional operator /(Fractional f1, int i)
        {
            var f2 = new Fractional(i, 1);

            return Division(f1, f2);
        }

        public static Fractional operator /(Fractional f1, short s)
        {
            var f2 = new Fractional(s, 1);

            return Division(f1, f2);
        }

        public static Fractional operator /(Fractional f1, decimal d1)
        {
            var f2 = new Fractional(d1, false);

            return Division(f1, f2);
        }


        public static Fractional operator /(Fractional f1, Fractional f2)
        {
            return Division(f1, f2);
        }

        private static Fractional Division(Fractional f1, Fractional f2)
        {
            return new Fractional(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
        }
        #endregion

        #endregion

        #region override comparison operators
        public static bool operator <(Fractional f1, Fractional f2)
        {
            return !f1.IsNaN && !f2.IsNaN && decimal.Compare(f1.Value, f2.Value) < 0;
        }

        public static bool operator >(Fractional f1, Fractional f2)
        {
            return !f1.IsNaN && !f2.IsNaN && decimal.Compare(f1.Value, f2.Value) > 0;
        }

        public static bool operator ==(Fractional f1, Fractional f2)
        {
            return !f1.IsNaN && !f2.IsNaN && f1.Numerator == f2.Numerator && f1.Denominator == f2.Denominator;
        }

        public static bool operator !=(Fractional f1, Fractional f2)
        {
            return f1.IsNaN || f2.IsNaN || f1.Numerator != f2.Numerator || f1.Denominator != f2.Denominator;
        }
        #endregion

        #region private methods

        private void Simplify(long num, long denom)
        {
            if (denom != 0)
            {
                var gcd = GCD(Math.Abs(num), Math.Abs(denom));
                if(gcd <= denom)
                {
                    Numerator = num / gcd;
                    Denominator = denom / gcd;
                }
                else
                {
                    Numerator = num;
                    Denominator = denom;
                }
            }
            else
            {
                Numerator = num;
                Denominator = denom;
            }
        }

        private long GCD(long a, long b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        private void ConvertToExcateFraction(decimal input)
        {
            var sign = (decimal.Compare(input, decimal.Zero) >= 0) ? 1 : -1;
            var decimalPlaces = input.GetDecimalPlaces();
            input = Math.Abs(input);

            Denominator = decimal.ToInt64((decimal)Math.Pow(10, decimalPlaces));
            Numerator = decimal.ToInt64((sign * Math.Truncate(input * Denominator)));
        }


        private void ConvertToApproximateFraction(decimal input)
        {
            var sign = (decimal.Compare(input, decimal.Zero) >= 0) ? 1 : -1;

            input = Math.Abs(input);

            if (input.IsAnInteger())
            {
                Numerator   = decimal.ToInt64(input * sign);
                Denominator = 1;
                return;
            }

            if(decimal.Compare(input, 1.0E-19m) < 0)
            {
                Numerator = decimal.ToInt64(sign);
                Denominator = MAX;
                return;
            }

            if (decimal.Compare(input, 1.0E+19m) > 0)
            {
                Numerator = MAX * sign;
                Denominator = 1;
                return;
            }

            decimal fractNumerator = 0.0m, fractDenominator = 1.0m, Z = input, scratchValue = 0.0m, pevDenominator = 0.0m;

            do
            {

                Z = 1.0m / (Z - decimal.ToInt64(Z));
                scratchValue = fractDenominator;
                fractDenominator = fractDenominator * decimal.ToInt64(Z) + pevDenominator;
                pevDenominator = scratchValue;

                fractNumerator = decimal.ToInt64(input * fractDenominator + 0.5m);

            } while (Math.Abs(input - (fractNumerator / fractDenominator)) > ACCURACY_FACTOR && !Z.IsAnInteger());

            Numerator = decimal.ToInt64(fractNumerator) * sign;
            Denominator = decimal.ToInt64(fractDenominator);
            IsNaN = Denominator == 0;

        }

        private void EvaluateFractionalExpression(string fractionalExpr)
        {
            if (fractionalExpr.IsMixedFractional())
            {
                var parts     = fractionalExpr.Split(' ');
                var wholePart = long.Parse(parts[0]);
                var sign = (wholePart >= 0) ? 1 : -1;
                var fractionalPart = parts[1];

                wholePart = Math.Abs(wholePart);

                EvaluateSimpleFractionalExpression(fractionalPart, out long nume, out long denom);

                Numerator = (wholePart * denom + nume) * sign;
                Denominator = denom;

                IsNaN = Denominator == 0;

            }
            else if (fractionalExpr.IsSimpleFractional())
            {
                EvaluateSimpleFractionalExpression(fractionalExpr, out long nume, out long denom);

                Numerator = nume;
                Denominator = denom;

                IsNaN = Denominator == 0;
            }
            else
            {
                IsNaN = true;
            }

            Simplify(Numerator, Denominator);
        }

        private void EvaluateSimpleFractionalExpression(string expression, out long numerator, out long denominator)
        {
            var parts = expression.Split('/');
            numerator = long.Parse(parts[0]);
            denominator = (parts.Length == 2) ? long.Parse(parts[1]) : 1L;
        }
        #endregion

    }
}