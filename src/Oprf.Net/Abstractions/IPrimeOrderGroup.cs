//-----------------------------------------------------------------------
// <copyright file="IPrimeOrderGroup.cs"
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

namespace Oprf.Net.Abstractions
{
    public interface IPrimeOrderGroup
    {
        /// <summary>
        /// The length of a byte array for a Group Element.
        /// </summary>
        int GroupElementBytesLength { get; }

        /// <summary>
        /// The length of a byte array for a Scalar value.
        /// </summary>
        int ScalarBytesLength { get; }

        /// <summary>
        /// The length of a byte array for a Hash.
        /// </summary>
        int HashBytesLength { get; }

        /// <summary>
        /// Generates a random Group Element.
        /// </summary>
        byte[] GenerateRandomGroupElement();

        /// <summary>
        /// Generates a random Scalar value.
        /// </summary>
        byte[] GenerateRandomScalar();

        /// <summary>
        /// Inverts the given Scalar.
        /// </summary>
        /// <param name="scalarToInvert">The scalar value to be inverted.</param>
        /// <returns>The inverted Scalar value.</returns>
        byte[] InvertScalar(byte[] scalarToInvert);

        /// <summary>
        /// Perform scalar multiplication of a Group Element with a scalar value.
        /// </summary>
        /// <param name="nScalar">The Scalar that 'p' is multiplied by.</param>
        /// <param name="pGroupElement">The Group Element that is multiplied by 'n'.</param>
        /// <returns>A group element 'q'. NOTE: this should NOT be used as a shared key prior to hashing.</returns>
        byte[] PerformScalarMultiplication(byte[] nScalar, byte[] pGroupElement);

        /// <summary>
        /// Hash the given message to a Group Element.
        /// </summary>
        /// <returns>A Group Element 'P'.</returns>
        /// <remarks>
        /// hash_to_curve(msg) - https://datatracker.ietf.org/doc/html/draft-irtf-cfrg-hash-to-curve-10
        ///  Input: msg, an arbitrary-length byte string.
        ///  Output: P, a point in G.
        ///  Steps:
        ///    1. u = hash_to_field(msg, 2)
        ///    2. Q0 = map_to_curve(u[0])
        ///    3. Q1 = map_to_curve(u[1])
        ///    4. R = Q0 + Q1              # Point addition
        ///    5. P = clear_cofactor(R)
        ///    6. return P
        ///  Each hash-to-curve suite in Section 8 instantiates one of these encoding functions for a specific elliptic curve.
        /// </remarks>
        byte[] HashToGroup(byte[] messageToHash);

        /// <summary>
        /// Determines if the provided Group Element is a valid point in the Group.
        /// </summary>
        /// <param name="pGroupElement">A Group Element 'P'.</param>
        /// <returns><c>true</c> if the given point is valid.</returns>
        bool IsValidPoint(byte[] pGroupElement);
    }
}
