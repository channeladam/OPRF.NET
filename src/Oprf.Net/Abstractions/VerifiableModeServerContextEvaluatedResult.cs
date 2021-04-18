//-----------------------------------------------------------------------
// <copyright file="VerifiableModeServerContextEvaluatedResult.cs"
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
    public class VerifiableModeServerContextEvaluatedResult
    {
        /// <summary>
        /// Used in the base mode with verification of the server key.
        /// </summary>
        /// <param name="evaluatedGroupElement"></param>
        public VerifiableModeServerContextEvaluatedResult(byte[] evaluatedGroupElement) : this(evaluatedGroupElement, null)
        {
        }

        /// <summary>
        /// Used in the Verifiable OPRF mode.
        /// </summary>
        /// <param name="evaluatedGroupElement"></param>
        /// <param name="proof"></param>
        public VerifiableModeServerContextEvaluatedResult(byte[] evaluatedGroupElement, byte[]? proof)
        {
            EvaluatedGroupElement = evaluatedGroupElement ?? throw new System.ArgumentNullException(nameof(evaluatedGroupElement));
            Proof = proof;
        }

        public byte[] EvaluatedGroupElement { get; }

        /// <summary>
        /// The proof, only used in the Verifiable Mode.
        /// </summary>
        public byte[]? Proof { get; }
    }
}
