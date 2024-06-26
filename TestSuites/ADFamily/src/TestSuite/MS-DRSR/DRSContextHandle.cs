// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Protocols.TestTools;
using Microsoft.Protocols.TestTools.StackSdk.ActiveDirectory.Drsr;

namespace Microsoft.Protocols.TestSuites.ActiveDirectory.Drsr
{
    [TestClass]
    public class DRSContextHandle : DrsrTestClassBase
    {
        #region Class Initialization and Cleanup
        [ClassInitialize]
        public static new void ClassInitialize(TestContext context)
        {
            DrsrTestClassBase.BaseInitialize(context);
        }

        [ClassCleanup]
        public static new void ClassCleanup()
        {
            DrsrTestClassBase.BaseCleanup();
        }
        #endregion

        #region Test Initialization and Cleanup
        protected override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override void TestCleanup()
        {
            base.TestCleanup();
        }
        #endregion

        /// <summary>
        /// test DRS bind and unbind success
        /// </summary>
        [BVT]
        [TestCategory("Win2003")]
        [ServerType(DcServerTypes.Any)]
        [SupportedADType(ADInstanceType.Both)]
        [Priority(0)]
        [Description("Basic DRS test for IDL_DRSBind and IDL_DRSUnbind")]
        [TestCategory("PDC")]
        [TestCategory("DomainWin2008R2")]
        [TestCategory("ForestWin2008R2")]
        [TestCategory("MS-DRSR")]
        [TestMethod]
        public void DRSR_DRSBind_UnBind()
        {
            DrsrTestChecker.Check();
            uint ret = drsTestClient.DrsBind(EnvironmentConfig.Machine.WritableDC1, EnvironmentConfig.User.ParentDomainAdmin, DRS_EXTENSIONS_IN_FLAGS.DRS_EXT_BASE);

            BaseTestSite.Assert.AreEqual<uint>(0, ret, "IDL_DRSBind: Checking return value - got: {0}, expect: 0, return value should be 0 on success.", ret);

            ret = drsTestClient.DrsUnbind(EnvironmentConfig.Machine.WritableDC1);

            BaseTestSite.Assert.AreEqual<uint>(0, ret, "IDL_DRSUnbind: Checking return value - got: {0}, expect: 0, return value should be 0 on success.", ret);
        }
    }


}
