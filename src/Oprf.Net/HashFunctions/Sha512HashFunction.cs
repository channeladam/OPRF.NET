//-----------------------------------------------------------------------
// <copyright file="Sha512HashFunction.cs"
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

using System.Security.Cryptography;
using Oprf.Net.Abstractions;

namespace Oprf.Net.HashFunctions
{
    public class Sha512HashFunction : IHashFunction
    {
        private static readonly SHA512Managed _hashFunction = new();

        public ushort InputBlockSizeInBytes => 128;
        public ushort OutputSizeInBits => 512;
        public ushort OutputSizeInBytes => 64;

        public byte[] HashData(byte[] source) => _hashFunction.ComputeHash(source);
    }
}
