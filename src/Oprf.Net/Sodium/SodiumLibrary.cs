//-----------------------------------------------------------------------
// <copyright file="SodiumLibrary.cs"
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

namespace Oprf.Net.Sodium
{
    public static class SodiumLibrary
    {
        public static void InitialiseCryptography()
        {
            // sodium_init() returns 0 on success, -1 on failure, and 1 if the library had already been initialized.
            if (core.SodiumInit() != -1)
            {
                return;
            }

            throw new CryptographicException("Unable to initialise the 'libsodium' cryptographic library");
        }

        public static string GetSodiumLibraryVersion()
            => version.SodiumVersionString();
    }
}
