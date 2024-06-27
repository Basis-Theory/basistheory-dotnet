/*
 * Basis Theory API
 *
 * ## Getting Started * Sign-in to [Basis Theory](https://basistheory.com) and go to [Applications](https://portal.basistheory.com/applications) * Create a Basis Theory Private Application * All permissions should be selected * Paste the API Key into the `BT-API-KEY` variable
 *
 * The version of the OpenAPI document: v1
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using BasisTheory.net.Client;
using BasisTheory.net.Api;
using BasisTheory.net.Model;

namespace BasisTheory.net.Test
{
    /// <summary>
    ///  Class for testing TokensApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class TokensApiTests
    {
        private TokensApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new TokensApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of TokensApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOf' TokensApi
            //Assert.IsInstanceOf(typeof(TokensApi), instance);
        }

        
        /// <summary>
        /// Test Create
        /// </summary>
        [Test]
        public void CreateTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //CreateTokenRequest createTokenRequest = null;
            //var response = instance.Create(createTokenRequest);
            //Assert.IsInstanceOf(typeof(Token), response, "response is Token");
        }
        
        /// <summary>
        /// Test Delete
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //instance.Delete(id);
            
        }
        
        /// <summary>
        /// Test Get
        /// </summary>
        [Test]
        public void GetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> id = null;
            //Dictionary<string, string> metadata = null;
            //int? page = null;
            //string start = null;
            //int? size = null;
            //var response = instance.Get(id, metadata, page, start, size);
            //Assert.IsInstanceOf(typeof(TokenPaginatedList), response, "response is TokenPaginatedList");
        }
        
        /// <summary>
        /// Test GetById
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //var response = instance.GetById(id);
            //Assert.IsInstanceOf(typeof(Token), response, "response is Token");
        }
        
        /// <summary>
        /// Test GetV2
        /// </summary>
        [Test]
        public void GetV2Test()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string start = null;
            //int? size = null;
            //var response = instance.GetV2(start, size);
            //Assert.IsInstanceOf(typeof(TokenCursorPaginatedList), response, "response is TokenCursorPaginatedList");
        }
        
        /// <summary>
        /// Test Search
        /// </summary>
        [Test]
        public void SearchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //SearchTokensRequest searchTokensRequest = null;
            //var response = instance.Search(searchTokensRequest);
            //Assert.IsInstanceOf(typeof(TokenPaginatedList), response, "response is TokenPaginatedList");
        }
        
        /// <summary>
        /// Test Update
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //UpdateTokenRequest updateTokenRequest = null;
            //var response = instance.Update(id, updateTokenRequest);
            //Assert.IsInstanceOf(typeof(Token), response, "response is Token");
        }
        
    }

}
