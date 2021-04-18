//-----------------------------------------------------------------------
// <copyright file="IClientContext.cs"
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

using System.Security;

namespace Oprf.Net.Abstractions
{
    public interface IClientContext
    {
        /// <summary>
        /// Blinding mechanism for the user input - randomising it with a Scalar and converting it into a Group Element.
        /// </summary>
        ClientContextBlindResult Blind(SecureString clientInput);

        /// <summary>
        /// Blinding mechanism for the user input - randomising it with a Scalar and converting it into a Group Element.
        /// </summary>
        ClientContextBlindResult Blind(byte[] clientInput);
    }
}
