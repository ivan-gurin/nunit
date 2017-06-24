﻿// ***********************************************************************
// Copyright (c) 2009 Charlie Poole, Rob Prouse
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;

namespace NUnit.Framework.Constraints.Comparers
{
    /// <summary>
    /// Comparator for two <see cref="DateTimeOffset"/>s.
    /// </summary>
    internal class DateTimeOffsetsComparer
    {
        private readonly NUnitEqualityComparer _equalityComparer;

        internal DateTimeOffsetsComparer(NUnitEqualityComparer equalityComparer)
        {
            _equalityComparer = equalityComparer;
        }

        internal bool Equal(DateTimeOffset x, DateTimeOffset y, ref Tolerance tolerance)
        {
            bool result;

            if (tolerance != null && tolerance.Amount is TimeSpan)
            {
                TimeSpan amount = (TimeSpan)tolerance.Amount;
                result = (x - y).Duration() <= amount;
            }
            else
            {
                result = x == y;
            }

            if (result && _equalityComparer.WithSameOffset)
            {
                result = x.Offset == y.Offset;
            }

            return result;
        }
    }
}