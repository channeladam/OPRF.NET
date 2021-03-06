//-----------------------------------------------------------------------
// <copyright file="Ristretto255PrimeOrderGroup.cs"
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
using System.Security.Cryptography;
using Oprf.Net.Abstractions;
using Oprf.Net.Utilities;

namespace Oprf.Net.PrimeOrderGroups
{
    public class Ristretto255PrimeOrderGroup : IPrimeOrderGroup
    {
        private readonly Lazy<int> _elementBytesLength = new(() =>
            (int)Sodium.crypto_core_ristretto255.CryptoCoreRistretto255Bytes());

        private readonly Lazy<int> _scalarBytesLength = new(() =>
            (int)Sodium.crypto_core_ristretto255.CryptoCoreRistretto255Scalarbytes());

        private readonly Lazy<int> _hashBytesLength = new(() =>
            (int)Sodium.crypto_core_ristretto255.CryptoCoreRistretto255Hashbytes());
        private readonly ICipherSuite _cipherSuite;

        public Ristretto255PrimeOrderGroup(ICipherSuite cipherSuite)
        {
            _cipherSuite = cipherSuite ?? throw new ArgumentNullException(nameof(cipherSuite));
        }

        /// <inheritdoc />
        public int GroupElementBytesLength => _elementBytesLength.Value;

        /// <inheritdoc />
        public int ScalarBytesLength => _scalarBytesLength.Value;

        /// <inheritdoc />
        public int HashBytesLength => _hashBytesLength.Value;

        /// <inheritdoc />
        public unsafe byte[] GenerateRandomGroupElement()
        {
            byte[] result = new byte[GroupElementBytesLength];

            fixed (byte* resultPointer = &result[0])
            {
                Sodium.crypto_core_ristretto255.CryptoCoreRistretto255Random(resultPointer);
            }

            return result;
        }

        /// <inheritdoc />
        public unsafe byte[] GenerateRandomScalar()
        {
            byte[] result = new byte[ScalarBytesLength];

            fixed (byte* resultPointer = &result[0])
            {
                Sodium.crypto_core_ristretto255.CryptoCoreRistretto255ScalarRandom(resultPointer);
            }

            return result;
        }

        /// <summary>
        /// Inverts the given Scalar.
        /// </summary>
        /// <param name="scalarToInvert">The scalar value to be inverted.</param>
        /// <returns>The inverted Scalar value.</returns>
        public unsafe byte[] InvertScalar(byte[] scalarToInvert)
        {
            byte[] result = new byte[ScalarBytesLength];

            fixed (byte* resultPointer = &result[0],
                         scalarToInvertPointer = &scalarToInvert[0])
            {
                Sodium.crypto_core_ristretto255.CryptoCoreRistretto255ScalarInvert(resultPointer, scalarToInvertPointer);
            }

            return result;
        }

        /// <inheritdoc />
        public unsafe byte[] PerformScalarMultiplication(byte[] nScalar, byte[] pGroupElement)
        {
            nScalar.ValidateLength(ScalarBytesLength, "n");
            pGroupElement.ValidateLength(GroupElementBytesLength, "p");

            byte[] qGroupElementResult = new byte[GroupElementBytesLength];

            fixed (byte* qResultPointer = &qGroupElementResult[0],
                         nScalarPointer = &nScalar[0],
                         pGroupElementPointer = &pGroupElement[0])
            {
                // 0 on success, -1 on error
                int success = Sodium.crypto_scalarmult_ristretto255.CryptoScalarmultRistretto255(qResultPointer, nScalarPointer, pGroupElementPointer);
                if (success != 0)
                {
                    // -1 if q is the identity element
                    throw new CryptographicException("Sodium Library: crypto_scalarmult_ristretto255() has failed");
                }
            }

            return qGroupElementResult;
        }

        /// <inheritdoc />
        /// <remarks>
        /// Hash to Ristretto255
        ///  - https://datatracker.ietf.org/doc/html/draft-irtf-cfrg-hash-to-curve-10#appendix-B
        ///  - https://tools.ietf.org/html/draft-irtf-cfrg-hash-to-curve-10#appendix-B
        /// </p>
        /// <p>
        /// The ristretto255 API defines a one-way map
        /// (https://datatracker.ietf.org/doc/html/draft-irtf-cfrg-hash-to-curve-10#ref-I-D.irtf-cfrg-ristretto255-decaf448, Section 4.3.4);
        /// this section refers to that map as ristretto255_map.
        /// </p>
        /// <p>
        /// The hash_to_ristretto255 function MUST be instantiated with an
        /// expand_message function that conforms to the requirements given in Section 5.4.
        /// In addition, it MUST use a domain separation tag constructed as described in Section 3.1, and all domain separation
        /// recommendations given in Section 10.4 apply when implementing protocols that use hash_to_ristretto255.
        /// </p>
        /// <p>
        /// hash_to_ristretto255(msg)
        ///
        ///  Parameters:
        ///   - DST, a domain separation tag (see discussion above).
        ///   - expand_message, a function that expands a byte string and
        ///       domain separation tag into a uniformly random byte string
        ///       (see discussion above).
        ///   - ristretto255_map, the one-way map from the ristretto255 API.
        /// </p>
        /// <p>
        ///  Input: msg, an arbitrary-length byte string.
        ///  Output: P, an element of the ristretto255 group.
        /// </p>
        /// <p>
        ///  Steps:
        ///   1. uniform_bytes = expand_message(msg, DST, 64)
        ///   2. P = ristretto255_map(uniform_bytes)
        ///   3. return P
        /// </p>
        /// <p>
        ///  Since hash_to_ristretto255 is not a hash-to-curve suite, it does not
        ///  have a Suite ID.  If a similar identifier is needed, it MUST be
        ///  constructed following the guidelines in Section 8.10, with the
        ///  following parameters:
        ///   *  CURVE_ID: "ristretto255"
        ///   *  HASH_ID: as described in Section 8.10
        ///   *  MAP_ID: "R255MAP"
        ///   *  ENC_VAR: "RO"
        /// </p>
        /// <p>
        ///  For example, if expand_message is expand_message_xmd using SHA-512, the REQUIRED identifier is:
        ///   ristretto255_XMD:SHA-512_R255MAP_RO_
        /// </p>
        /// </remarks>
        public unsafe byte[] HashToGroup(byte[] messageToHash)
        {
            // DST, a domain separation tag
            // as per https://datatracker.ietf.org/doc/html/draft-irtf-cfrg-voprf-06.txt#section-5.1
            byte[] dst = _cipherSuite.CreateDomainSeparationTag("HashToGroup");

            //   1. uniform_bytes = expand_message(msg, DST, 64)
            //     - "expand_message" = "expand_message_xmd" using SHA-512.
            byte[] uniformBytesHashResult = HashToCurveUtils.ExpandMessageXmd(messageToHash, dst, _hashBytesLength.Value, _cipherSuite.HashFunction);

            //   2. P = ristretto255_map(uniform_bytes)
            //     - ristretto255_map, the one-way map from the ristretto255 API.
            // https://libsodium.gitbook.io/doc/advanced/point-arithmetic/ristretto#hash-to-group
            byte[] pGroupElementResult = new byte[GroupElementBytesLength];

            fixed (byte* pGroupElementResultPointer = &pGroupElementResult[0],
                         hashResultPointer = &uniformBytesHashResult[0])
            {
                // 0 on success, -1 on error
                int success = Sodium.crypto_core_ristretto255.CryptoCoreRistretto255FromHash(pGroupElementResultPointer, hashResultPointer);
                if (success != 0)
                {
                    throw new CryptographicException("Sodium Library: crypto_core_ristretto255_from_hash() has failed");
                }
            }

            ///   3. return P
            return pGroupElementResult;
        }

        /// <summary>
        /// Determines if the provided Group Element is a valid point in the Group.
        /// </summary>
        /// <param name="pGroupElement">A Group Element 'P'.</param>
        /// <returns><c>true</c> if the given point is valid.</returns>
        public unsafe bool IsValidPoint(byte[] pGroupElement)
        {
            fixed (byte* pGroupElementPointer = &pGroupElement[0])
            {
                int success = Sodium.crypto_core_ristretto255.CryptoCoreRistretto255IsValidPoint(pGroupElementPointer);
                return success == 1;
            }
        }
    }
}
