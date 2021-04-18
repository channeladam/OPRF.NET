//-----------------------------------------------------------------------
// <copyright file="ByteArrayUtils.cs"
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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Oprf.Net.Utilities
{
    public static class ByteArrayUtils
    {
        public static byte[] Concatenate(IList<byte[]> byteArrays)
        {
            if (byteArrays is null)
            {
                throw new ArgumentNullException(nameof(byteArrays));
            }

            if (byteArrays.Count == 0)
            {
                return Array.Empty<byte>();
            }

            int totalLength;
            try
            {
                totalLength = byteArrays.Sum(byteArray => byteArray.Length);
            }
            catch (ArithmeticException)
            {
                throw new ArgumentException("The total length of the byte arrays to be concatenated is too long");
            }

            byte[] result = new byte[totalLength];

            int targetIndex = 0;
            for (int index = 0; index < byteArrays.Count; index++)
            {
                byte[] currentArray = byteArrays[index];
                currentArray.CopyTo(result, targetIndex);
                targetIndex += currentArray.Length;
            }

            return result;
        }

        public static byte[] Xor(byte[] byteArray1, byte[] byteArray2)
        {
            if (byteArray1 is null)
            {
                throw new ArgumentNullException(nameof(byteArray1));
            }

            if (byteArray2 is null)
            {
                throw new ArgumentNullException(nameof(byteArray2));
            }

            if (byteArray1.Length != byteArray2.Length)
            {
                throw new ArgumentException("The byte array inputs must be of the same length");
            }

            int resultLength = byteArray1.Length;
            byte[] result = new byte[resultLength];

            for (int index = 0; index < resultLength; index++)
            {
                result[index] = (byte)(byteArray1[index] ^ byteArray2[index]);
            }

            return result;
        }
    }
}
