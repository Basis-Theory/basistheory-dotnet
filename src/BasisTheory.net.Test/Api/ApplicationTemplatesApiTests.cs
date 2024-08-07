/*
 * Basis Theory API
 *
 * ## Getting Started * Sign-in to [Basis Theory](https://basistheory.com) and go to [Applications](https://portal.basistheory.com/applications) * Create a Basis Theory Private Application * All permissions should be selected * Paste the API Key into the `BT-API-KEY` variable
 *
 * The version of the OpenAPI document: v1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using BasisTheory.net.Client;
using BasisTheory.net.Api;
// uncomment below to import models
//using BasisTheory.net.Model;

namespace BasisTheory.net.Test.Api
{
    /// <summary>
    ///  Class for testing ApplicationTemplatesApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class ApplicationTemplatesApiTests : IDisposable
    {
        private ApplicationTemplatesApi instance;

        public ApplicationTemplatesApiTests()
        {
            instance = new ApplicationTemplatesApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of ApplicationTemplatesApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' ApplicationTemplatesApi
            //Assert.IsType<ApplicationTemplatesApi>(instance);
        }

        /// <summary>
        /// Test Get
        /// </summary>
        [Fact]
        public void GetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.Get();
            //Assert.IsType<List<ApplicationTemplate>>(response);
        }

        /// <summary>
        /// Test GetById
        /// </summary>
        [Fact]
        public void GetByIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid id = null;
            //var response = instance.GetById(id);
            //Assert.IsType<ApplicationTemplate>(response);
        }
    }
}
