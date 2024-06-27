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
    ///  Class for testing ProxiesApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class ProxiesApiTests
    {
        private ProxiesApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new ProxiesApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of ProxiesApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOf' ProxiesApi
            //Assert.IsInstanceOf(typeof(ProxiesApi), instance);
        }

        
        /// <summary>
        /// Test Create
        /// </summary>
        [Test]
        public void CreateTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //CreateProxyRequest createProxyRequest = null;
            //var response = instance.Create(createProxyRequest);
            //Assert.IsInstanceOf(typeof(Proxy), response, "response is Proxy");
        }
        
        /// <summary>
        /// Test Delete
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid id = null;
            //instance.Delete(id);
            
        }
        
        /// <summary>
        /// Test Get
        /// </summary>
        [Test]
        public void GetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<Guid> id = null;
            //string name = null;
            //int? page = null;
            //string start = null;
            //int? size = null;
            //var response = instance.Get(id, name, page, start, size);
            //Assert.IsInstanceOf(typeof(ProxyPaginatedList), response, "response is ProxyPaginatedList");
        }
        
        /// <summary>
        /// Test GetById
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid id = null;
            //var response = instance.GetById(id);
            //Assert.IsInstanceOf(typeof(Proxy), response, "response is Proxy");
        }
        
        /// <summary>
        /// Test Patch
        /// </summary>
        [Test]
        public void PatchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid id = null;
            //PatchProxyRequest patchProxyRequest = null;
            //instance.Patch(id, patchProxyRequest);
            
        }
        
        /// <summary>
        /// Test Update
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid id = null;
            //UpdateProxyRequest updateProxyRequest = null;
            //var response = instance.Update(id, updateProxyRequest);
            //Assert.IsInstanceOf(typeof(Proxy), response, "response is Proxy");
        }
        
    }

}