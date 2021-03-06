//-----------------------------------------------------------------------
// <copyright file="BaseModeServerContext.cs"
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

namespace Oprf.Net
{
    /// <summary>
    /// An implementation of the Server Context when operating in the OPRF Base Mode.
    /// </summary>
    public class BaseModeServerContext : ProtocolContext, IBaseModeServerContext
    {
        public BaseModeServerContext(CipherSuite cipherSuite) : base(cipherSuite)
        {
            if (CipherSuite.ProtocolMode == ProtocolMode.Base)
            {
                return;
            }

            throw new InvalidOperationException("The Cipher Suite Protocol Mode must be 'Base'");
        }

        /// <summary>
        /// Evaluates the client's blinded result.
        /// </summary>
        /// <param name="skSServerPrivateKeyScalar">The secret key of the server (skS) - i.e. the server's private key as a scalar value.</param>
        /// <param name="clientBlindedGroupElement">The serialised blinded element from the client - i.e. the blinded user's password.</param>
        /// <returns>A serialised Group Element - to be an input to an Unblind function.</returns>
        /// <remarks>
        /// Base Mode Specification: see https://datatracker.ietf.org/doc/html/draft-irtf-cfrg-voprf-06.txt#section-3.4.1.1.
        ///   Input:
        ///     PrivateKey skS
        ///     SerializedElement blindedElement
        ///   Output:
        ///     SerializedElement evaluatedElement
        ///   def Evaluate(skS, blindedElement):
        ///     R = GG.DeserializeElement(blindedElement)
        ///     Z = skS * R
        ///     evaluatedElement = GG.SerializeElement(Z)
        ///     return evaluatedElement
        /// </remarks>
        public byte[] Evaluate(byte[] skSServerPrivateKeyScalar, byte[] clientBlindedGroupElement)
            => CipherSuite.PrimeOrderGroup.PerformScalarMultiplication(skSServerPrivateKeyScalar, clientBlindedGroupElement);
    }
}
