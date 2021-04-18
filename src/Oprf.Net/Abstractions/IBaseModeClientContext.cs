//-----------------------------------------------------------------------
// <copyright file="IBaseModeClientContext.cs"
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
    public interface IBaseModeClientContext : IClientContext
    {
        /// <summary>
        /// Unblinds the server's evaluated result, verifies the server's proof if verifiability is required,
        /// and produces a byte array corresponding to the output of the OPRF protocol from the server's evaluated result.
        /// </summary>
        byte[] Finalise(byte[] clientInput, byte[] blindScalar, byte[] serverEvaluatedGroupElement);
    }
}
