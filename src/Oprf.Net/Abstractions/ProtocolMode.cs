//-----------------------------------------------------------------------
// <copyright file="ProtocolMode.cs"
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
    /// <summary>
    /// Oblivious Pseudo-Random Function protocol variant modes of operation.
    /// </summary>
    /// <remarks>
    /// https://datatracker.ietf.org/doc/html/draft-irtf-cfrg-voprf-06.txt#section-3
    /// </remarks>
    public enum ProtocolMode
    {
        Base = 0x00,
        Verifiable = 0x01 // Not supported or needed for Opaque
    }
}
