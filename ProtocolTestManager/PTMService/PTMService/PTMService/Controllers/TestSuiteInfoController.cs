﻿using Microsoft.AspNetCore.Mvc;

namespace PTMService.Controllers
{
    /// <summary>
    /// Test suite info controller.
    /// </summary>
    [Route("api/testsuite")]
    [ApiController]
    public class TestSuiteInfoController : ControllerBase
    {
        /// <summary>
        /// Get test suites.
        /// </summary>
        /// <returns>An array containing test suites.</returns>
        [HttpGet]
        public TestSuite[] GetTestSuites()
        {
            return new TestSuite[]
            {
                new TestSuite
                {
                    Name = "FileServer",
                },
            };
        }

        /// <summary>
        /// Get detail of a specific test suite.
        /// </summary>
        /// <param name="id">The test suite Id.</param>
        /// <returns>The detail of test suite.</returns>
        [Route("{id}")]
        [HttpGet]
        public TestSuite GetTestSuiteDetail(int id)
        {
            return new TestSuite
            {
                Name = "FileServer",
                TestCases = new TestCase[]
                {
                    new TestCase
                    {
                        Name= "Test",
                        Categories = new string[]
                        {
                            "BVT",
                        },
                    },
                },
            };
        }
    }
}
