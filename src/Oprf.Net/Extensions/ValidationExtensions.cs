//-----------------------------------------------------------------------
// <copyright file="ValidationExtensions.cs"
//     Copyright (c) 2021 Adam Craven. All rights reserved.
// </copyright>
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

using System.Globalization;
using System.Security.Cryptography;

namespace System // DO NOT CHANGE THIS FROM System!!
{
    public static class ValidationExtensions
    {
        public static void ValidateLength(this byte[] array, int expectedLength, string errorName)
            => ValidateLength(array.Length, expectedLength, errorName);

        public static void ValidateLength(this byte[] array, uint expectedLength, string errorName)
            => ValidateLength(array.Length, expectedLength, errorName);

        public static void ValidateLength(this ReadOnlySpan<byte> array, int expectedLength, string errorName)
            => ValidateLength(array.Length, expectedLength, errorName);

        public static void ValidateLength(this ReadOnlySpan<byte> array, uint expectedLength, string errorName)
            => ValidateLength(array.Length, expectedLength, errorName);

        private static void ValidateLength(int actualLength, int expectedLength, string errorName)
        {
            if (actualLength == expectedLength)
            {
                return;
            }

            throw new CryptographicException($"Array '{errorName}' has length '{actualLength.ToString(CultureInfo.InvariantCulture)}' but was expected to be length '{expectedLength.ToString(CultureInfo.InvariantCulture)}'");
        }

        private static void ValidateLength(int actualLength, uint expectedLength, string errorName)
        {
            if (actualLength == expectedLength)
            {
                return;
            }

            throw new CryptographicException($"Array '{errorName}' has length '{actualLength.ToString(CultureInfo.InvariantCulture)}' but was expected to be length '{expectedLength.ToString(CultureInfo.InvariantCulture)}'");
        }
    }
}
