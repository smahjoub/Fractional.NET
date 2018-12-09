﻿using System;
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
        /// <param name="value"></param>
        public Fractional(decimal value)
        {
            numerator = 0;
            denominator = 1;
            isNaN = false;

            EvaluateDecimalValue(value);
        }

        /// <summary>
        /// Build the fractional from a given numerator and denominator.
        /// </summary>
        /// <param name="num">The numerator.</param>
        /// <param name="denom">The denominator should be different from zero</param>
        public Fractional(long num, long denom)
        {
            numerator = num;
            denominator = denom;
            isNaN = denom == 0;
        }
        #endregion

        #region propeties

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

        #region private methods

        private void EvaluateDecimalValue(decimal input)
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
                Denominator = 999999999999999999;
                return;
            }

            if (decimal.Compare(input, 1.0E+19m) > 0)
            {
                Numerator = 999999999999999999 * sign;
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
                this.isNaN = true;
            }
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