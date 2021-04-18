#nullable disable

//-----------------------------------------------------------------------
// <copyright file="ProtocolUnitTests.cs"
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

using System.Linq;
using ChannelAdam.TestFramework.NUnit.Abstractions;
using Oprf.Net;
using Oprf.Net.Abstractions;
// using Oprf.Net.Internal;
using TechTalk.SpecFlow;

namespace BehaviourSpecs
{
    [Binding]
    [Scope(Feature = "Protocol")]
    public class ProtocolUnitTests : TestEasy
    {
        // private KeyPair _keyPair1;
        // private int _expectedKeyLength;
        private ICipherSuite _cipherSuite;
        private byte[] _actualContextString;
        private byte[] _expectedContextString;

        // #region Before/After

        // [BeforeScenario]
        // public void BeforeScenario()
        // {
        // }

        // #endregion

        // #region Given

        // [Given("")]
        // public void Given()
        // {
        // }

        // #endregion

        #region When

        // [When("a public-private key pair is generated")]
        // public void WhenAPublicPrivateKeyPairIsGenerated()
        // {
        //     _keyPair1 = CryptoUtils.GenerateKeyPair(ObliviousPseudoRandomFunctionCipherSuite.P384_SHA256);
        //     _expectedKeyLength = 384 / 8;
        // }

        [When("the Context String for a protocol context is generated")]
        public void WhenTheContextStringForAProtocolContextIsGenerated()
        {
            const CipherSuiteName cipherSuiteName = CipherSuiteName.Ristretto255_SHA512;
            PrimeOrderGroupFactory pogFactory = new();
            HashFunctionFactory hfFactory = new();
            _cipherSuite = new CipherSuite(cipherSuiteName, pogFactory, hfFactory);

            _actualContextString = _cipherSuite.ProtocolContextString.ToArray();
            _expectedContextString = new byte[] { 0, 0, (byte)cipherSuiteName }; // Mode 0, Cipher 0x0004
        }

        // [When("")]
        // public void When()
        // {
        // }

        #endregion

        #region Then

        // [Then("the public and private keys are available")]
        // public void ThenThePublicAndPrivateKeysAreAvailable()
        // {
        //     byte[] allZeroes = Enumerable.Repeat<byte>(0, _expectedLength).ToArray();
        //     byte[] all255s = Enumerable.Repeat<byte>(255, _expectedLength).ToArray();

        //     // TODO: change the assertions below to use !SequenceEqual instead of All
        //     LogAssert.AreEqual("Private key is populated with expected length", _expectedKeyLength, _keyPair1.PrivateKey.Length);
        //     LogAssert.IsTrue("Private key is not all byte 255", _keyPair1.PrivateKey.ToArray().All(b => b != 255));

        //     LogAssert.AreEqual("Public key X coordinate is populated with expected length", _expectedKeyLength, _keyPair1.PublicKeyX.Length);
        //     LogAssert.IsTrue("Public key X coordinate is not all byte 255", _keyPair1.PublicKeyX.ToArray().All(b => b != 255));

        //     LogAssert.AreEqual("Public key Y coordinate is populated with expected length", _expectedKeyLength, _keyPair1.PublicKeyY.Length);
        //     LogAssert.IsTrue("Public key Y coordinate is not all byte 255", _keyPair1.PublicKeyY.ToArray().All(b => b != 255));
        // }

        [Then("the Context String is as expected")]
        public void ThenTheContextStringIsAsExpected()
            => LogAssert.IsTrue("Context String is as expected", _expectedContextString.SequenceEqual(_actualContextString));

        // [Then("")]
        // public void Then()
        // {
        // }

        #endregion
    }
}
