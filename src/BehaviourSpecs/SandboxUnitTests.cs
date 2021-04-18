#nullable disable

//-----------------------------------------------------------------------
// <copyright file="SandboxUnitTests.cs"
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

using ChannelAdam.TestFramework.NUnit.Abstractions;
using Oprf.Net;
using Oprf.Net.Abstractions;
using Oprf.Net.Sodium;
using TechTalk.SpecFlow;

namespace BehaviourSpecs
{
    [Binding]
    [Scope(Feature = "Sandbox")]
    public class SandboxUnitTests : TestEasy
    {
        [When("initialisation is performed")]
        public void WhenInitialisationIsPerformed()
        {
            const CipherSuiteName cipherSuiteName = CipherSuiteName.Ristretto255_SHA512;
            PrimeOrderGroupFactory pogFactory = new();
            HashFunctionFactory hfFactory = new();
            CipherSuite cipherSuite = new CipherSuite(cipherSuiteName, ProtocolMode.Base, pogFactory, hfFactory);

            SodiumLibrary.InitialiseCryptography();
            LogAssert.AreEqual("Sodium library version", "1.0.18", SodiumLibrary.GetSodiumLibraryVersion());

            BaseModeClientContext clientContext = new(cipherSuite);
            BaseModeServerContext serverContext = new(cipherSuite);
        }

        [Then("no errors occurred")]
        public void ThenNoErrorsOccurred()
        {
            // Nothing to do
        }
    }
}
