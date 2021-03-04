﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Protocols.TestManager.PTMService.Abstractions.Kernel;
using System;

namespace Microsoft.Protocols.TestManager.PTMService.PTMService.Controllers
{
    /// <summary>
    /// Test suite management controller.
    /// </summary>
    [Route("api/management/testsuite")]
    [ApiController]
    public class TestSuiteManagementController : PTMServiceControllerBase
    {
        /// <summary>
        /// Constructor of test suite management controller.
        /// </summary>
        /// <param name="ptmKernelService"></param>
        public TestSuiteManagementController(IPTMKernelService ptmKernelService)
            : base(ptmKernelService)
        {

        }

        /// <summary>
        /// Install request.
        /// </summary>
        public class InstallRequest
        {
            /// <summary>
            /// Test suite name.
            /// </summary>
            public string TestSuiteName { get; set; }

            /// <summary>
            /// Test suite package.
            /// </summary>
            public IFormFile Package { get; set; }

            /// <summary>
            /// Description.
            /// </summary>
            public string Description { get; set; }
        }

        /// <summary>
        /// Install a test suite by uploading its package.
        /// </summary>
        /// <param name="request">The install request.</param>
        /// <returns>The test suite Id.</returns>
        [HttpPost]
        public int Install([FromForm] InstallRequest request)
        {
            if (String.IsNullOrEmpty(request.TestSuiteName))
            {
                throw new ArgumentNullException(nameof(request.TestSuiteName));
            }

            if (request.Package == null)
            {
                throw new ArgumentNullException(nameof(request.Package));
            }

            string packageName = request.Package.FileName;

            var packageStream = request.Package.OpenReadStream();

            int id = PTMKernelService.InstallTestSuite(request.TestSuiteName, packageName, packageStream, request.Description);

            return id;
        }
    }
}
