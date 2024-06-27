/*
 * Basis Theory API
 *
 * ## Getting Started * Sign-in to [Basis Theory](https://basistheory.com) and go to [Applications](https://portal.basistheory.com/applications) * Create a Basis Theory Private Application * All permissions should be selected * Paste the API Key into the `BT-API-KEY` variable
 *
 * The version of the OpenAPI document: v1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Xunit;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using BasisTheory.net.Api;
using BasisTheory.net.Model;
using BasisTheory.net.Client;
using System.Reflection;
using Newtonsoft.Json;

namespace BasisTheory.net.Test.Model
{
    /// <summary>
    ///  Class for testing ThreeDSAuthentication
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class ThreeDSAuthenticationTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for ThreeDSAuthentication
        //private ThreeDSAuthentication instance;

        public ThreeDSAuthenticationTests()
        {
            // TODO uncomment below to create an instance of ThreeDSAuthentication
            //instance = new ThreeDSAuthentication();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of ThreeDSAuthentication
        /// </summary>
        [Fact]
        public void ThreeDSAuthenticationInstanceTest()
        {
            // TODO uncomment below to test "IsType" ThreeDSAuthentication
            //Assert.IsType<ThreeDSAuthentication>(instance);
        }


        /// <summary>
        /// Test the property 'PanTokenId'
        /// </summary>
        [Fact]
        public void PanTokenIdTest()
        {
            // TODO unit test for the property 'PanTokenId'
        }
        /// <summary>
        /// Test the property 'ThreedsVersion'
        /// </summary>
        [Fact]
        public void ThreedsVersionTest()
        {
            // TODO unit test for the property 'ThreedsVersion'
        }
        /// <summary>
        /// Test the property 'AcsTransactionId'
        /// </summary>
        [Fact]
        public void AcsTransactionIdTest()
        {
            // TODO unit test for the property 'AcsTransactionId'
        }
        /// <summary>
        /// Test the property 'DsTransactionId'
        /// </summary>
        [Fact]
        public void DsTransactionIdTest()
        {
            // TODO unit test for the property 'DsTransactionId'
        }
        /// <summary>
        /// Test the property 'SdkTransactionId'
        /// </summary>
        [Fact]
        public void SdkTransactionIdTest()
        {
            // TODO unit test for the property 'SdkTransactionId'
        }
        /// <summary>
        /// Test the property 'AcsReferenceNumber'
        /// </summary>
        [Fact]
        public void AcsReferenceNumberTest()
        {
            // TODO unit test for the property 'AcsReferenceNumber'
        }
        /// <summary>
        /// Test the property 'DsReferenceNumber'
        /// </summary>
        [Fact]
        public void DsReferenceNumberTest()
        {
            // TODO unit test for the property 'DsReferenceNumber'
        }
        /// <summary>
        /// Test the property 'AuthenticationValue'
        /// </summary>
        [Fact]
        public void AuthenticationValueTest()
        {
            // TODO unit test for the property 'AuthenticationValue'
        }
        /// <summary>
        /// Test the property 'AuthenticationStatus'
        /// </summary>
        [Fact]
        public void AuthenticationStatusTest()
        {
            // TODO unit test for the property 'AuthenticationStatus'
        }
        /// <summary>
        /// Test the property 'AuthenticationStatusCode'
        /// </summary>
        [Fact]
        public void AuthenticationStatusCodeTest()
        {
            // TODO unit test for the property 'AuthenticationStatusCode'
        }
        /// <summary>
        /// Test the property 'AuthenticationStatusReason'
        /// </summary>
        [Fact]
        public void AuthenticationStatusReasonTest()
        {
            // TODO unit test for the property 'AuthenticationStatusReason'
        }
        /// <summary>
        /// Test the property 'Eci'
        /// </summary>
        [Fact]
        public void EciTest()
        {
            // TODO unit test for the property 'Eci'
        }
        /// <summary>
        /// Test the property 'AcsChallengeMandated'
        /// </summary>
        [Fact]
        public void AcsChallengeMandatedTest()
        {
            // TODO unit test for the property 'AcsChallengeMandated'
        }
        /// <summary>
        /// Test the property 'AcsDecoupledAuthentication'
        /// </summary>
        [Fact]
        public void AcsDecoupledAuthenticationTest()
        {
            // TODO unit test for the property 'AcsDecoupledAuthentication'
        }
        /// <summary>
        /// Test the property 'AuthenticationChallengeType'
        /// </summary>
        [Fact]
        public void AuthenticationChallengeTypeTest()
        {
            // TODO unit test for the property 'AuthenticationChallengeType'
        }
        /// <summary>
        /// Test the property 'AcsRenderingType'
        /// </summary>
        [Fact]
        public void AcsRenderingTypeTest()
        {
            // TODO unit test for the property 'AcsRenderingType'
        }
        /// <summary>
        /// Test the property 'AcsSignedContent'
        /// </summary>
        [Fact]
        public void AcsSignedContentTest()
        {
            // TODO unit test for the property 'AcsSignedContent'
        }
        /// <summary>
        /// Test the property 'AcsChallengeUrl'
        /// </summary>
        [Fact]
        public void AcsChallengeUrlTest()
        {
            // TODO unit test for the property 'AcsChallengeUrl'
        }
        /// <summary>
        /// Test the property 'ChallengeAttempts'
        /// </summary>
        [Fact]
        public void ChallengeAttemptsTest()
        {
            // TODO unit test for the property 'ChallengeAttempts'
        }
        /// <summary>
        /// Test the property 'ChallengeCancelReason'
        /// </summary>
        [Fact]
        public void ChallengeCancelReasonTest()
        {
            // TODO unit test for the property 'ChallengeCancelReason'
        }
        /// <summary>
        /// Test the property 'CardholderInfo'
        /// </summary>
        [Fact]
        public void CardholderInfoTest()
        {
            // TODO unit test for the property 'CardholderInfo'
        }
        /// <summary>
        /// Test the property 'WhitelistStatus'
        /// </summary>
        [Fact]
        public void WhitelistStatusTest()
        {
            // TODO unit test for the property 'WhitelistStatus'
        }
        /// <summary>
        /// Test the property 'WhitelistStatusSource'
        /// </summary>
        [Fact]
        public void WhitelistStatusSourceTest()
        {
            // TODO unit test for the property 'WhitelistStatusSource'
        }
        /// <summary>
        /// Test the property 'MessageExtensions'
        /// </summary>
        [Fact]
        public void MessageExtensionsTest()
        {
            // TODO unit test for the property 'MessageExtensions'
        }

    }

}
