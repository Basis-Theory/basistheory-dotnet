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
    ///  Class for testing Condition
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class ConditionTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for Condition
        //private Condition instance;

        public ConditionTests()
        {
            // TODO uncomment below to create an instance of Condition
            //instance = new Condition();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of Condition
        /// </summary>
        [Fact]
        public void ConditionInstanceTest()
        {
            // TODO uncomment below to test "IsType" Condition
            //Assert.IsType<Condition>(instance);
        }


        /// <summary>
        /// Test the property 'Attribute'
        /// </summary>
        [Fact]
        public void AttributeTest()
        {
            // TODO unit test for the property 'Attribute'
        }
        /// <summary>
        /// Test the property 'Operator'
        /// </summary>
        [Fact]
        public void OperatorTest()
        {
            // TODO unit test for the property 'Operator'
        }
        /// <summary>
        /// Test the property 'Value'
        /// </summary>
        [Fact]
        public void ValueTest()
        {
            // TODO unit test for the property 'Value'
        }

    }

}
