//-----------------------------------------------------------------------
// <copyright file="HashFunctionFactory.cs"
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
using Oprf.Net.Abstractions;
using Oprf.Net.HashFunctions;

namespace Oprf.Net
{
    public class HashFunctionFactory : IHashFunctionFactory
    {
        public IHashFunction Create(CipherSuiteName cipherSuiteName, ICipherSuite cipherSuite)
            => cipherSuiteName switch
            {
                CipherSuiteName.Ristretto255_SHA512 => new Sha512HashFunction(),
                // case ObliviousPseudoRandomFunctionCipherSuite.P256_SHA256:
                // case ObliviousPseudoRandomFunctionCipherSuite.P384_SHA256:
                // case ObliviousPseudoRandomFunctionCipherSuite.P521_SHA256:
                // case ObliviousPseudoRandomFunctionCipherSuite.Decaf448_SHA512:
                // case ObliviousPseudoRandomFunctionCipherSuite.None:
                _ => throw new NotSupportedException("Hash function for Cipher Suite " + cipherSuiteName.ToString()),
            };
    }
}
