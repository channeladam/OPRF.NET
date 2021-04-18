//-----------------------------------------------------------------------
// <copyright file="CipherSuite.cs"
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
using System.Collections.Generic;
using Oprf.Net.Abstractions;
using Oprf.Net.Utilities;
using Oprf.Net.Sodium;

namespace Oprf.Net
{
    public class CipherSuite : ICipherSuite
    {
        /// <remarks>
        /// DST Prefix - https://datatracker.ietf.org/doc/html/draft-irtf-cfrg-voprf-06.txt#section-5.1
        /// </remarks>
        private const string DomainSeparationTagPrefix = "VOPRF06";

        private static readonly byte[] _hyphenBytes = "-".ConvertStringAsUtf8ToByteArray();
        private static readonly byte[] _domainSeparationTagPrefixBytes = DomainSeparationTagPrefix.ConvertStringAsUtf8ToByteArray();

        private readonly Lazy<bool> _lazyCryptoInitialisation = new(() =>
        {
            SodiumLibrary.InitialiseCryptography();
            return true;
        });

        private readonly IPrimeOrderGroupFactory _primeOrderGroupFactory;
        private readonly Lazy<IPrimeOrderGroup> _lazyPrimeOrderGroup;
        private readonly IHashFunctionFactory _hashFunctionFactory;
        private readonly Lazy<IHashFunction> _lazyHashFunction;

        public CipherSuite(
            CipherSuiteName cipherSuiteName,
            IPrimeOrderGroupFactory primeOrderGroupFactory,
            IHashFunctionFactory hashFunctionFactory)
                : this(cipherSuiteName, ProtocolMode.Base, primeOrderGroupFactory, hashFunctionFactory)
        {
        }

        public CipherSuite(
            CipherSuiteName cipherSuiteName,
            ProtocolMode protocolMode,
            IPrimeOrderGroupFactory primeOrderGroupFactory,
            IHashFunctionFactory hashFunctionFactory)
        {
            CipherSuiteName = cipherSuiteName;
            ProtocolMode = protocolMode;

            _primeOrderGroupFactory = primeOrderGroupFactory ?? throw new ArgumentNullException(nameof(primeOrderGroupFactory));
            _lazyPrimeOrderGroup = new(() => _primeOrderGroupFactory.Create(cipherSuiteName, this));

            _hashFunctionFactory = hashFunctionFactory ?? throw new ArgumentNullException(nameof(hashFunctionFactory));
            _lazyHashFunction = new(() => _hashFunctionFactory.Create(cipherSuiteName, this));

            EnsureCryptoIsInitialised();
        }

        public CipherSuiteName CipherSuiteName { get; }
        public ProtocolMode ProtocolMode { get; }
        public IPrimeOrderGroup PrimeOrderGroup => _lazyPrimeOrderGroup.Value;
        public IHashFunction HashFunction => _lazyHashFunction.Value;

        public byte[] ProtocolContextString
        {
            get
            {
                byte[] result = new byte[3];
                BigEndianUtils.ConvertIntegerToOrdinalStringPrimitive((int)ProtocolMode, 1, ref result, 0);
                BigEndianUtils.ConvertIntegerToOrdinalStringPrimitive((int)CipherSuiteName, 2, ref result, 1);
                return result;
            }
        }

        public byte[] CreateDomainSeparationTag(string functionName)
            => ByteArrayUtils.Concatenate(new List<byte[]>
            {
                _domainSeparationTagPrefixBytes,
                _hyphenBytes,
                functionName.ConvertStringAsUtf8ToByteArray(),
                _hyphenBytes,
                ProtocolContextString
            });

        #region Private Methods

        private void EnsureCryptoIsInitialised()
        {
            bool _ = _lazyCryptoInitialisation.Value;
        }

        #endregion Private Methods
    }
}
