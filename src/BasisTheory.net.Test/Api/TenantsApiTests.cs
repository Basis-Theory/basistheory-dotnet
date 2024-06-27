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
    ///  Class for testing TenantsApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class TenantsApiTests
    {
        private TenantsApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new TenantsApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of TenantsApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOf' TenantsApi
            //Assert.IsInstanceOf(typeof(TenantsApi), instance);
        }

        
        /// <summary>
        /// Test CreateConnection
        /// </summary>
        [Test]
        public void CreateConnectionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //CreateTenantConnectionRequest createTenantConnectionRequest = null;
            //var response = instance.CreateConnection(createTenantConnectionRequest);
            //Assert.IsInstanceOf(typeof(CreateTenantConnectionResponse), response, "response is CreateTenantConnectionResponse");
        }
        
        /// <summary>
        /// Test CreateInvitation
        /// </summary>
        [Test]
        public void CreateInvitationTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //CreateTenantInvitationRequest createTenantInvitationRequest = null;
            //var response = instance.CreateInvitation(createTenantInvitationRequest);
            //Assert.IsInstanceOf(typeof(TenantInvitationResponse), response, "response is TenantInvitationResponse");
        }
        
        /// <summary>
        /// Test Delete
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //instance.Delete();
            
        }
        
        /// <summary>
        /// Test DeleteConnection
        /// </summary>
        [Test]
        public void DeleteConnectionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.DeleteConnection();
            //Assert.IsInstanceOf(typeof(CreateTenantConnectionResponse), response, "response is CreateTenantConnectionResponse");
        }
        
        /// <summary>
        /// Test DeleteInvitation
        /// </summary>
        [Test]
        public void DeleteInvitationTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid invitationId = null;
            //instance.DeleteInvitation(invitationId);
            
        }
        
        /// <summary>
        /// Test DeleteMember
        /// </summary>
        [Test]
        public void DeleteMemberTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid memberId = null;
            //instance.DeleteMember(memberId);
            
        }
        
        /// <summary>
        /// Test Get
        /// </summary>
        [Test]
        public void GetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.Get();
            //Assert.IsInstanceOf(typeof(Tenant), response, "response is Tenant");
        }
        
        /// <summary>
        /// Test GetInvitations
        /// </summary>
        [Test]
        public void GetInvitationsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //TenantInvitationStatus? status = null;
            //int? page = null;
            //string start = null;
            //int? size = null;
            //var response = instance.GetInvitations(status, page, start, size);
            //Assert.IsInstanceOf(typeof(TenantInvitationResponsePaginatedList), response, "response is TenantInvitationResponsePaginatedList");
        }
        
        /// <summary>
        /// Test GetMembers
        /// </summary>
        [Test]
        public void GetMembersTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<Guid> userId = null;
            //int? page = null;
            //string start = null;
            //int? size = null;
            //var response = instance.GetMembers(userId, page, start, size);
            //Assert.IsInstanceOf(typeof(TenantMemberResponsePaginatedList), response, "response is TenantMemberResponsePaginatedList");
        }
        
        /// <summary>
        /// Test GetTenantUsageReport
        /// </summary>
        [Test]
        public void GetTenantUsageReportTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetTenantUsageReport();
            //Assert.IsInstanceOf(typeof(TenantUsageReport), response, "response is TenantUsageReport");
        }
        
        /// <summary>
        /// Test ResendInvitation
        /// </summary>
        [Test]
        public void ResendInvitationTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid invitationId = null;
            //var response = instance.ResendInvitation(invitationId);
            //Assert.IsInstanceOf(typeof(TenantInvitationResponse), response, "response is TenantInvitationResponse");
        }
        
        /// <summary>
        /// Test Update
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //UpdateTenantRequest updateTenantRequest = null;
            //var response = instance.Update(updateTenantRequest);
            //Assert.IsInstanceOf(typeof(Tenant), response, "response is Tenant");
        }
        
        /// <summary>
        /// Test UpdateMember
        /// </summary>
        [Test]
        public void UpdateMemberTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid memberId = null;
            //UpdateTenantMemberRequest updateTenantMemberRequest = null;
            //var response = instance.UpdateMember(memberId, updateTenantMemberRequest);
            //Assert.IsInstanceOf(typeof(TenantMemberResponse), response, "response is TenantMemberResponse");
        }
        
    }

}
