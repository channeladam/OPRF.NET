//-----------------------------------------------------------------------
// <copyright file="ConversionExtensions.cs"
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

using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace System // DO NOT CHANGE THIS FROM System!!!
{
    public static class ConversionExtensions
    {
        public static unsafe byte[] ConvertHexStringToByteArray(this string hex)
        {
            int byteLength = hex.Length >> 1;
            byte[] result = new byte[byteLength];
            ulong resultByteLength = 0;

            fixed (byte* resultPointer = &result[0])
            {
                Oprf.Net.Sodium.utils.SodiumHex2bin(resultPointer, (ulong)byteLength, hex, (ulong)hex.Length, null, ref resultByteLength, null);
            }

            return result;
        }

        public static byte[] ConvertStringAsUtf8ToByteArray(this string stringToConvert)
            => Encoding.UTF8.GetBytes(stringToConvert);

        public static string? ConvertToString(this SecureString secureString)
        {
            IntPtr stringPointer = IntPtr.Zero;

            try
            {
                stringPointer = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(stringPointer);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(stringPointer);
            }
        }

        public static byte[] ConvertToByteArray(this SecureString secureString)
        {
            IntPtr stringPointer = IntPtr.Zero;

            try
            {
                stringPointer = Marshal.SecureStringToGlobalAllocUnicode(secureString);

                byte[] unicodeBytes = new byte[secureString.Length >> 1];
                for (int index = 0; index < unicodeBytes.Length; index++)
                {
                    unicodeBytes[index] = Marshal.ReadByte(stringPointer, index);
                }

                return unicodeBytes;
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(stringPointer);
            }
        }
    }
}
