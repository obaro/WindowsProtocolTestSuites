// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1434
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Protocols.TestSuites.WspTS
{
    using Microsoft.Protocols.TestTools;
    using Microsoft.Protocols.TestTools.Messages.Runtime;
    using System;

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class TestCaseGetRowsOut_E_FailErrorWithInvalidBinding : WspModelTestBase
    {
        public TestCaseGetRowsOut_E_FailErrorWithInvalidBinding()
        {
            this.SetSwitch("generatedtestpath", "..\\\\TestSuite");
            this.SetSwitch("generatedtestnamespace", "Microsoft.Protocols.TestSuites.WspTS");
            this.SetSwitch("graphtimeout", "1000");
            this.SetSwitch("statebound", "-1");
            this.SetSwitch("stepbound", "6000");
            this.SetSwitch("pathbound", "32");
            this.SetSwitch("stepsperstatebound", "1024");
        }

        #region Expect Delegates
        public delegate void CPMConnectOutResponseDelegate1(uint errorCode);

        public delegate void CPMCreateQueryOutResponseDelegate1(uint errorCode);

        public delegate void CPMSetBindingsInResponseDelegate1(uint errorCode);

        public delegate void GetServerPlatformDelegate1(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.SkuOsVersion platform, bool @return);

        public delegate void CPMGetRowsOutResponseDelegate1(uint errorCode);

        public delegate void CPMFreeCursorOutResponseDelegate1(uint errorCode);

        public delegate void CPMGetQueryStatusOutResponseDelegate1(uint errorCode);

        public delegate void CPMGetQueryStatusExOutResponseDelegate1(uint errorCode);

        public delegate void CPMRatioFinishedOutResponseDelegate1(uint errorCode);

        public delegate void CPMFetchValueOutResponseDelegate1(uint errorCode);

        public delegate void CPMCiStateInOutResponseDelegate1(uint errorCode);

        public delegate void CPMSendNotifyOutResponseDelegate1(uint errorCode);

        public delegate void CPMFindIndicesOutResponseDelegate1(uint errorCode);

        public delegate void CPMGetRowsetNotifyOutResponseDelegate1(uint errorCode);

        public delegate void CPMGetScopeStatisticsOutResponseDelegate1(uint errorCode);

        public delegate void CPMSetScopePrioritizationOutResponseDelegate1(uint errorCode);

        public delegate void CPMUpdateDocumentsOutResponseDelegate1(uint errorCode);
        #endregion

        #region Event Metadata
        static System.Reflection.MethodBase CPMConnectInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMConnectIn");

        static System.Reflection.EventInfo CPMConnectOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMConnectOutResponse");

        static System.Reflection.MethodBase CPMCreateQueryInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMCreateQueryIn", typeof(bool));

        static System.Reflection.EventInfo CPMCreateQueryOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMCreateQueryOutResponse");

        static System.Reflection.MethodBase CPMSetBindingsInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMSetBindingsIn", typeof(bool), typeof(bool));

        static System.Reflection.EventInfo CPMSetBindingsInResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMSetBindingsInResponse");

        static System.Reflection.MethodBase GetServerPlatformInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "GetServerPlatform", typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.SkuOsVersion).MakeByRefType());

        static System.Reflection.MethodBase CPMGetRowsInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMGetRowsIn", typeof(bool));

        static System.Reflection.EventInfo CPMGetRowsOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMGetRowsOutResponse");

        static System.Reflection.MethodBase CPMFreeCursorInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMFreeCursorIn", typeof(bool));

        static System.Reflection.EventInfo CPMFreeCursorOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMFreeCursorOutResponse");

        static System.Reflection.MethodBase CPMDisconnectInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMDisconnect");

        static System.Reflection.MethodBase CPMGetQueryStatusInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMGetQueryStatusIn", typeof(bool));

        static System.Reflection.MethodBase CPMGetQueryStatusExInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMGetQueryStatusExIn", typeof(bool));

        static System.Reflection.MethodBase CPMRatioFinishedInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMRatioFinishedIn", typeof(bool));

        static System.Reflection.MethodBase CPMFetchValueInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMFetchValueIn", typeof(bool));

        static System.Reflection.MethodBase CPMCiStateInOutInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMCiStateInOut");

        static System.Reflection.MethodBase CPMGetNotifyInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMGetNotify", typeof(bool));

        static System.Reflection.MethodBase CPMFindIndicesInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMFindIndicesIn", typeof(bool));

        static System.Reflection.MethodBase CPMGetRowsetNotifyInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMGetRowsetNotifyIn", typeof(int), typeof(bool));

        static System.Reflection.MethodBase CPMSetScopePrioritizationInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMSetScopePrioritizationIn", typeof(uint));

        static System.Reflection.MethodBase CPMGetScopeStatisticsInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMGetScopeStatisticsIn");

        static System.Reflection.MethodBase CPMUpdateDocumentsInInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMUpdateDocumentsIn", typeof(uint), typeof(uint));

        static System.Reflection.EventInfo CPMGetQueryStatusOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMGetQueryStatusOutResponse");

        static System.Reflection.EventInfo CPMGetQueryStatusExOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMGetQueryStatusExOutResponse");

        static System.Reflection.EventInfo CPMRatioFinishedOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMRatioFinishedOutResponse");

        static System.Reflection.EventInfo CPMFetchValueOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMFetchValueOutResponse");

        static System.Reflection.EventInfo CPMCiStateInOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMCiStateInOutResponse");

        static System.Reflection.EventInfo CPMSendNotifyOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMSendNotifyOutResponse");

        static System.Reflection.EventInfo CPMFindIndicesOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMFindIndicesOutResponse");

        static System.Reflection.EventInfo CPMGetRowsetNotifyOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMGetRowsetNotifyOutResponse");

        static System.Reflection.EventInfo CPMGetScopeStatisticsOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMGetScopeStatisticsOutResponse");

        static System.Reflection.EventInfo CPMSetScopePrioritizationOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMSetScopePrioritizationOutResponse");

        static System.Reflection.EventInfo CPMUpdateDocumentsOutResponseInfo = TestManagerHelpers.GetEventInfo(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter), "CPMUpdateDocumentsOutResponse");
        #endregion

        #region Adapter Instances
        private Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter IWspAdapterInstance;
        #endregion

        #region Class Initialization and Cleanup
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void ClassInitialize(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context)
        {
            PtfTestClassBase.Initialize(context);
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void ClassCleanup()
        {
            PtfTestClassBase.Cleanup();
        }
        #endregion

        #region Test Initialization and Cleanup
        protected override void TestInitialize()
        {
            this.InitializeTestManager();
            this.IWspAdapterInstance = ((Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter)(this.GetAdapter(typeof(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.Adapter.IWspAdapter))));
            this.Subscribe(CPMConnectOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMCreateQueryOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMSetBindingsInResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMGetRowsOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMFreeCursorOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMGetQueryStatusOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMGetQueryStatusExOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMRatioFinishedOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMFetchValueOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMCiStateInOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMSendNotifyOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMFindIndicesOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMGetRowsetNotifyOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMGetScopeStatisticsOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMSetScopePrioritizationOutResponseInfo, this.IWspAdapterInstance);
            this.Subscribe(CPMUpdateDocumentsOutResponseInfo, this.IWspAdapterInstance);
        }

        protected override void TestCleanup()
        {
            base.TestCleanup();
            this.CleanupTestManager();
        }
        #endregion

        #region Test Starting in S0
        //[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("MS-WSP_R592, MS-WSP_R599, MS-WSP_R647, MS-WSP_R651, MS-WSP_R653, MS-WSP_R654, MS-" +
            "WSP_R655, MS-WSP_R657, MS-WSP_R708, MS-WSP_R747, MS-WSP_R791, MS-WSP_R793")]
        public virtual void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0()
        {
            this.Manager.BeginTest("TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0");
            this.Manager.Comment("reaching state \'S0\'");
            this.Manager.Comment("executing step \'call CPMConnectIn()\'");
            this.IWspAdapterInstance.CPMConnectIn();
            this.Manager.Comment("reaching state \'S1\'");
            this.Manager.Comment("checking step \'return CPMConnectIn\'");
            this.Manager.Comment("reaching state \'S2\'");
            this.Manager.ExpectEvent(this.QuiescenceTimeout, true, new ExpectedEvent(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.CPMConnectOutResponseInfo, null, new CPMConnectOutResponseDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMConnectOutResponseChecker)));
            this.Manager.Comment("reaching state \'S3\'");
            this.Manager.Comment("executing step \'call CPMCreateQueryIn(True)\'");
            this.IWspAdapterInstance.CPMCreateQueryIn(true);
            this.Manager.Comment("reaching state \'S4\'");
            this.Manager.Comment("checking step \'return CPMCreateQueryIn\'");
            this.Manager.Comment("reaching state \'S5\'");
            this.Manager.ExpectEvent(this.QuiescenceTimeout, true, new ExpectedEvent(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.CPMCreateQueryOutResponseInfo, null, new CPMCreateQueryOutResponseDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMCreateQueryOutResponseChecker)));
            this.Manager.Comment("reaching state \'S6\'");
            this.Manager.Comment("executing step \'call CPMSetBindingsIn(False,True)\'");
            this.IWspAdapterInstance.CPMSetBindingsIn(false, true);
            this.Manager.Comment("reaching state \'S7\'");
            this.Manager.Comment("checking step \'return CPMSetBindingsIn\'");
            this.Manager.Comment("reaching state \'S8\'");
            this.Manager.ExpectEvent(this.QuiescenceTimeout, true, new ExpectedEvent(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.CPMSetBindingsInResponseInfo, null, new CPMSetBindingsInResponseDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMSetBindingsInResponseChecker)));
            this.Manager.Comment("reaching state \'S9\'");
            Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.SkuOsVersion temp0;
            bool temp1;
            this.Manager.Comment("executing step \'call GetServerPlatform(out _)\'");
            temp1 = this.IWspAdapterInstance.GetServerPlatform(out temp0);
            this.Manager.AddReturn(GetServerPlatformInfo, null, temp0, temp1);
            this.Manager.Comment("reaching state \'S10\'");
            int temp2 = this.Manager.ExpectReturn(this.QuiescenceTimeout, true, new ExpectedReturn(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.GetServerPlatformInfo, null, new GetServerPlatformDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0GetServerPlatformChecker)), new ExpectedReturn(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.GetServerPlatformInfo, null, new GetServerPlatformDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0GetServerPlatformChecker1)), new ExpectedReturn(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.GetServerPlatformInfo, null, new GetServerPlatformDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0GetServerPlatformChecker2)), new ExpectedReturn(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.GetServerPlatformInfo, null, new GetServerPlatformDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0GetServerPlatformChecker3)));
            if ((temp2 == 0))
            {
                this.Manager.Comment("reaching state \'S11\'");
                this.Manager.Comment("executing step \'call CPMGetRowsIn(True)\'");
                this.IWspAdapterInstance.CPMGetRowsIn(true);
                this.Manager.Comment("reaching state \'S15\'");
                this.Manager.Comment("checking step \'return CPMGetRowsIn\'");
                this.Manager.Comment("reaching state \'S19\'");
                this.Manager.ExpectEvent(this.QuiescenceTimeout, true, new ExpectedEvent(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.CPMGetRowsOutResponseInfo, null, new CPMGetRowsOutResponseDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMGetRowsOutResponseChecker)));
                this.Manager.Comment("reaching state \'S23\'");
                this.Manager.Comment("executing step \'call CPMFreeCursorIn(True)\'");
                this.IWspAdapterInstance.CPMFreeCursorIn(true);
                this.Manager.Comment("reaching state \'S27\'");
                this.Manager.Comment("checking step \'return CPMFreeCursorIn\'");
                this.Manager.Comment("reaching state \'S31\'");
                this.Manager.ExpectEvent(this.QuiescenceTimeout, true, new ExpectedEvent(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.CPMFreeCursorOutResponseInfo, null, new CPMFreeCursorOutResponseDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMFreeCursorOutResponseChecker)));
                this.Manager.Comment("reaching state \'S35\'");
                this.Manager.Comment("executing step \'call CPMDisconnect()\'");
                this.IWspAdapterInstance.CPMDisconnect();
                this.Manager.Comment("reaching state \'S39\'");
                this.Manager.Comment("checking step \'return CPMDisconnect\'");
                this.Manager.Comment("reaching state \'S43\'");
                goto label0;
            }
            if ((temp2 == 1))
            {
                this.Manager.Comment("reaching state \'S12\'");
                this.Manager.Comment("executing step \'call CPMGetRowsIn(True)\'");
                this.IWspAdapterInstance.CPMGetRowsIn(true);
                this.Manager.Comment("reaching state \'S16\'");
                this.Manager.Comment("checking step \'return CPMGetRowsIn\'");
                this.Manager.Comment("reaching state \'S20\'");
                this.Manager.ExpectEvent(this.QuiescenceTimeout, true, new ExpectedEvent(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.CPMGetRowsOutResponseInfo, null, new CPMGetRowsOutResponseDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMGetRowsOutResponseChecker1)));
                this.Manager.Comment("reaching state \'S24\'");
                this.Manager.Comment("executing step \'call CPMFreeCursorIn(True)\'");
                this.IWspAdapterInstance.CPMFreeCursorIn(true);
                this.Manager.Comment("reaching state \'S28\'");
                this.Manager.Comment("checking step \'return CPMFreeCursorIn\'");
                this.Manager.Comment("reaching state \'S32\'");
                this.Manager.ExpectEvent(this.QuiescenceTimeout, true, new ExpectedEvent(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.CPMFreeCursorOutResponseInfo, null, new CPMFreeCursorOutResponseDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMFreeCursorOutResponseChecker1)));
                this.Manager.Comment("reaching state \'S36\'");
                this.Manager.Comment("executing step \'call CPMDisconnect()\'");
                this.IWspAdapterInstance.CPMDisconnect();
                this.Manager.Comment("reaching state \'S40\'");
                this.Manager.Comment("checking step \'return CPMDisconnect\'");
                this.Manager.Comment("reaching state \'S44\'");
                goto label0;
            }
            if ((temp2 == 2))
            {
                this.Manager.Comment("reaching state \'S13\'");
                this.Manager.Comment("executing step \'call CPMGetRowsIn(True)\'");
                this.IWspAdapterInstance.CPMGetRowsIn(true);
                this.Manager.Comment("reaching state \'S17\'");
                this.Manager.Comment("checking step \'return CPMGetRowsIn\'");
                this.Manager.Comment("reaching state \'S21\'");
                this.Manager.ExpectEvent(this.QuiescenceTimeout, true, new ExpectedEvent(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.CPMGetRowsOutResponseInfo, null, new CPMGetRowsOutResponseDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMGetRowsOutResponseChecker2)));
                this.Manager.Comment("reaching state \'S25\'");
                this.Manager.Comment("executing step \'call CPMFreeCursorIn(True)\'");
                this.IWspAdapterInstance.CPMFreeCursorIn(true);
                this.Manager.Comment("reaching state \'S29\'");
                this.Manager.Comment("checking step \'return CPMFreeCursorIn\'");
                this.Manager.Comment("reaching state \'S33\'");
                this.Manager.ExpectEvent(this.QuiescenceTimeout, true, new ExpectedEvent(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.CPMFreeCursorOutResponseInfo, null, new CPMFreeCursorOutResponseDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMFreeCursorOutResponseChecker2)));
                this.Manager.Comment("reaching state \'S37\'");
                this.Manager.Comment("executing step \'call CPMDisconnect()\'");
                this.IWspAdapterInstance.CPMDisconnect();
                this.Manager.Comment("reaching state \'S41\'");
                this.Manager.Comment("checking step \'return CPMDisconnect\'");
                this.Manager.Comment("reaching state \'S45\'");
                goto label0;
            }
            if ((temp2 == 3))
            {
                this.Manager.Comment("reaching state \'S14\'");
                this.Manager.Comment("executing step \'call CPMGetRowsIn(True)\'");
                this.IWspAdapterInstance.CPMGetRowsIn(true);
                this.Manager.Comment("reaching state \'S18\'");
                this.Manager.Comment("checking step \'return CPMGetRowsIn\'");
                this.Manager.Comment("reaching state \'S22\'");
                this.Manager.ExpectEvent(this.QuiescenceTimeout, true, new ExpectedEvent(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.CPMGetRowsOutResponseInfo, null, new CPMGetRowsOutResponseDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMGetRowsOutResponseChecker3)));
                this.Manager.Comment("reaching state \'S26\'");
                this.Manager.Comment("executing step \'call CPMFreeCursorIn(True)\'");
                this.IWspAdapterInstance.CPMFreeCursorIn(true);
                this.Manager.Comment("reaching state \'S30\'");
                this.Manager.Comment("checking step \'return CPMFreeCursorIn\'");
                this.Manager.Comment("reaching state \'S34\'");
                this.Manager.ExpectEvent(this.QuiescenceTimeout, true, new ExpectedEvent(TestCaseGetRowsOut_E_FailErrorWithInvalidBinding.CPMFreeCursorOutResponseInfo, null, new CPMFreeCursorOutResponseDelegate1(this.TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMFreeCursorOutResponseChecker3)));
                this.Manager.Comment("reaching state \'S38\'");
                this.Manager.Comment("executing step \'call CPMDisconnect()\'");
                this.IWspAdapterInstance.CPMDisconnect();
                this.Manager.Comment("reaching state \'S42\'");
                this.Manager.Comment("checking step \'return CPMDisconnect\'");
                this.Manager.Comment("reaching state \'S46\'");
                goto label0;
            }
            throw new InvalidOperationException("never reached");
        label0:
            ;
            this.Manager.EndTest();
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMConnectOutResponseChecker(uint errorCode)
        {
            this.Manager.Comment("checking step \'event CPMConnectOutResponse(0)\'");
            this.Manager.Assert((errorCode == 0), string.Format("expected \'0\', actual \'{0}\' (errorCode of CPMConnectOutResponse, state S2)", errorCode));
            this.Manager.Checkpoint("MS-WSP_R592");
            this.Manager.Checkpoint("MS-WSP_R647");
            this.Manager.Checkpoint("MS-WSP_R651");
            this.Manager.Checkpoint("MS-WSP_R653");
            this.Manager.Checkpoint("MS-WSP_R654");
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMCreateQueryOutResponseChecker(uint errorCode)
        {
            this.Manager.Comment("checking step \'event CPMCreateQueryOutResponse(0)\'");
            this.Manager.Assert((errorCode == 0), string.Format("expected \'0\', actual \'{0}\' (errorCode of CPMCreateQueryOutResponse, state S5)", errorCode));
            this.Manager.Checkpoint("MS-WSP_R592");
            this.Manager.Checkpoint("MS-WSP_R599");
            this.Manager.Checkpoint("MS-WSP_R655");
            this.Manager.Checkpoint("MS-WSP_R657");
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMSetBindingsInResponseChecker(uint errorCode)
        {
            this.Manager.Comment("checking step \'event CPMSetBindingsInResponse(2147749384)\'");
            this.Manager.Assert((errorCode == 2147749384), string.Format("expected \'2147749384\', actual \'{0}\' (errorCode of CPMSetBindingsInResponse, state" +
                        " S8)", errorCode));
            this.Manager.Checkpoint("MS-WSP_R747");
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0GetServerPlatformChecker(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.SkuOsVersion platform, bool @return)
        {
            this.Manager.Comment("checking step \'return GetServerPlatform/[out Win2K8R2]:True\'");
            this.Manager.Assert((platform == Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.SkuOsVersion.Win2K8R2), string.Format("expected \'Microsoft.Protocols.TestTools.StackSdk.FileAccessService.WSP.SkuOsVersion.Win2K8R2\', actual \'{0" +
                        "}\' (platform of GetServerPlatform, state S10)", platform));
            this.Manager.Assert((@return == true), string.Format("expected \'true\', actual \'{0}\' (return of GetServerPlatform, state S10)", @return));
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMGetRowsOutResponseChecker(uint errorCode)
        {
            this.Manager.Comment("checking step \'event CPMGetRowsOutResponse(3221225485)\'");
            this.Manager.Assert((errorCode == 3221225485), string.Format("expected \'3221225485\', actual \'{0}\' (errorCode of CPMGetRowsOutResponse, state S19)", errorCode));
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMFreeCursorOutResponseChecker(uint errorCode)
        {
            this.Manager.Comment("checking step \'event CPMFreeCursorOutResponse(0)\'");
            this.Manager.Assert((errorCode == 0), string.Format("expected \'0\', actual \'{0}\' (errorCode of CPMFreeCursorOutResponse, state S31)", errorCode));
            this.Manager.Checkpoint("MS-WSP_R592");
            this.Manager.Checkpoint("MS-WSP_R599");
            this.Manager.Checkpoint("MS-WSP_R791");
            this.Manager.Checkpoint("MS-WSP_R793");
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0GetServerPlatformChecker1(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.SkuOsVersion platform, bool @return)
        {
            this.Manager.Comment("checking step \'return GetServerPlatform/[out Win2K8]:True\'");
            this.Manager.Assert((platform == Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.SkuOsVersion.Win2K8), string.Format("expected \'Microsoft.Protocols.TestTools.StackSdk.FileAccessService.WSP.SkuOsVersion.Win2K8\', actual \'{0}\'" +
                        " (platform of GetServerPlatform, state S10)", platform));
            this.Manager.Assert((@return == true), string.Format("expected \'true\', actual \'{0}\' (return of GetServerPlatform, state S10)", @return));
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMGetRowsOutResponseChecker1(uint errorCode)
        {
            this.Manager.Comment("checking step \'event CPMGetRowsOutResponse(2147549183)\'");
            this.Manager.Assert((errorCode == 2147549183), string.Format("expected \'2147549183\', actual \'{0}\' (errorCode of CPMGetRowsOutResponse, state S20)", errorCode));
            this.Manager.Checkpoint("MS-WSP_R708");
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMFreeCursorOutResponseChecker1(uint errorCode)
        {
            this.Manager.Comment("checking step \'event CPMFreeCursorOutResponse(0)\'");
            this.Manager.Assert((errorCode == 0), string.Format("expected \'0\', actual \'{0}\' (errorCode of CPMFreeCursorOutResponse, state S32)", errorCode));
            this.Manager.Checkpoint("MS-WSP_R592");
            this.Manager.Checkpoint("MS-WSP_R599");
            this.Manager.Checkpoint("MS-WSP_R791");
            this.Manager.Checkpoint("MS-WSP_R793");
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0GetServerPlatformChecker2(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.SkuOsVersion platform, bool @return)
        {
            this.Manager.Comment("checking step \'return GetServerPlatform/[out Win2K3]:True\'");
            this.Manager.Assert((platform == Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.SkuOsVersion.Win2K3), string.Format("expected \'Microsoft.Protocols.TestTools.StackSdk.FileAccessService.WSP.SkuOsVersion.Win2K3\', actual \'{0}\'" +
                        " (platform of GetServerPlatform, state S10)", platform));
            this.Manager.Assert((@return == true), string.Format("expected \'true\', actual \'{0}\' (return of GetServerPlatform, state S10)", @return));
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMGetRowsOutResponseChecker2(uint errorCode)
        {
            this.Manager.Comment("checking step \'event CPMGetRowsOutResponse(2147549183)\'");
            this.Manager.Assert((errorCode == 2147549183), string.Format("expected \'2147549183\', actual \'{0}\' (errorCode of CPMGetRowsOutResponse, state S21)", errorCode));
            this.Manager.Checkpoint("MS-WSP_R708");
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMFreeCursorOutResponseChecker2(uint errorCode)
        {
            this.Manager.Comment("checking step \'event CPMFreeCursorOutResponse(0)\'");
            this.Manager.Assert((errorCode == 0), string.Format("expected \'0\', actual \'{0}\' (errorCode of CPMFreeCursorOutResponse, state S33)", errorCode));
            this.Manager.Checkpoint("MS-WSP_R592");
            this.Manager.Checkpoint("MS-WSP_R599");
            this.Manager.Checkpoint("MS-WSP_R791");
            this.Manager.Checkpoint("MS-WSP_R793");
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0GetServerPlatformChecker3(Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.SkuOsVersion platform, bool @return)
        {
            this.Manager.Comment("checking step \'return GetServerPlatform/[out NonWindows]:True\'");
            this.Manager.Assert((platform == Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Wsp.SkuOsVersion.NonWindows), string.Format("expected \'Microsoft.Protocols.TestTools.StackSdk.FileAccessService.WSP.SkuOsVersion.NonWindows\', actual \'" +
                        "{0}\' (platform of GetServerPlatform, state S10)", platform));
            this.Manager.Assert((@return == true), string.Format("expected \'true\', actual \'{0}\' (return of GetServerPlatform, state S10)", @return));
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMGetRowsOutResponseChecker3(uint errorCode)
        {
            this.Manager.Comment("checking step \'event CPMGetRowsOutResponse(2147549183)\'");
            this.Manager.Assert((errorCode == 2147549183), string.Format("expected \'2147549183\', actual \'{0}\' (errorCode of CPMGetRowsOutResponse, state S22)", errorCode));
            this.Manager.Checkpoint("MS-WSP_R708");
        }

        private void TestCaseGetRowsOut_E_FailErrorWithInvalidBindingS0CPMFreeCursorOutResponseChecker3(uint errorCode)
        {
            this.Manager.Comment("checking step \'event CPMFreeCursorOutResponse(0)\'");
            this.Manager.Assert((errorCode == 0), string.Format("expected \'0\', actual \'{0}\' (errorCode of CPMFreeCursorOutResponse, state S34)", errorCode));
            this.Manager.Checkpoint("MS-WSP_R592");
            this.Manager.Checkpoint("MS-WSP_R599");
            this.Manager.Checkpoint("MS-WSP_R791");
            this.Manager.Checkpoint("MS-WSP_R793");
        }
        #endregion
    }
}
