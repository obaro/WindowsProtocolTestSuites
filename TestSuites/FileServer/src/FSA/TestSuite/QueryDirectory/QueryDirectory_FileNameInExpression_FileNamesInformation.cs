﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter;
using Microsoft.Protocols.TestTools;
using Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Fscc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Protocols.TestSuites.FileSharing.Common.Adapter;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Protocols.TestSuites.FileSharing.FSA.TestSuite.TraditionalTestCases.QueryDirectory
{
    public partial class QueryDirectoryTestCases : PtfTestClassBase
    {
        #region Test cases
        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileNamesInformation from the server for search pattern * described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileNamesInformation_AsteriskWildCard()
        {
            var fileInformation = new List<FileNamesInformation>();
            int filesInDirectoryCount = 10;
            int expectedFilesReturnedLength = 12;
            var wildCard = "*";

            BVT_QueryDirectoryBySearchPattern<FileNamesInformation>(
                fileInformation.ToArray(),
                FileInfoClass.FILE_NAMES_INFORMATION,
                wildCard, 
                filesInDirectoryCount, 
                expectedFilesReturnedLength);
        }

        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileNamesInformation from the server for search pattern *.* described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileNamesInformation_SpecialCase_AsteriskWildCard()
        {
            var fileInformation = new List<FileNamesInformation>();
            int filesInDirectoryCount = 10;
            int expectedFilesReturnedLength = 12;
            var wildCard = "*.*";

            BVT_QueryDirectoryBySearchPattern<FileNamesInformation>(
                fileInformation.ToArray(),
                FileInfoClass.FILE_NAMES_INFORMATION,
                wildCard,
                filesInDirectoryCount,
                expectedFilesReturnedLength);
        }

        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileNamesInformation from the server for search pattern ? described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileNamesInformation_WildCard_QuestionMark()
        {
            var fileInformation = new List<FileNamesInformation>();
            int expectedFilesReturnedLength = 2;
            var fileNames = new List<string> { "Fine", "File", "Bile", "Fille", "Nine" };
            var wildCard = "Fi?e";

            BVT_QueryDirectoryBySearchPattern<FileNamesInformation>(
                fileInformation.ToArray(),
                FileInfoClass.FILE_NAMES_INFORMATION,
                fileNames,
                wildCard,
                expectedFilesReturnedLength);
        }

        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileNamesInformation from the server for search pattern * described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileNamesInformation_AsteriskInStringWildCard()
        {
            var fileInformation = new List<FileNamesInformation>();
            int expectedFilesReturnedLength = 2;
            var fileNames = new List<string> { "Fine", "File", "Bile", "Fille", "Nine" };
            var wildCard = "*ile";

            BVT_QueryDirectoryBySearchPattern<FileNamesInformation>(
                fileInformation.ToArray(),
                FileInfoClass.FILE_NAMES_INFORMATION,
                fileNames,
                wildCard,
                expectedFilesReturnedLength);
        }

        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileNamesInformation from the server for search pattern DOS_STAR described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileNamesInformation_DOS_STAR_WildCard()
        {
            var fileInformation = new List<FileNamesInformation>();
            int expectedFilesReturnedLength = 4;
            var fileNames = new List<string> { "Fine.txt", "FileGrip.txt", "Bile.txt", "Tile.txt", "Nine.jpg" };
            var wildCard = $"{DOS_STAR}txt";

            BVT_QueryDirectoryBySearchPattern<FileNamesInformation>(
                fileInformation.ToArray(),
                FileInfoClass.FILE_NAMES_INFORMATION,
                fileNames,
                wildCard,
                expectedFilesReturnedLength);
        }

        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileNamesInformation from the server for search pattern DOS_QM described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileNamesInformation_DOS_QM_WildCard()
        {
            var fileInformation = new List<FileNamesInformation>();
            int expectedFilesReturnedLength = 2;
            var fileNames = new List<string> { "Fine", "File", "Bile", "Fille", "Nine" };
            var wildCard = $"Fi{DOS_QM}e";

            BVT_QueryDirectoryBySearchPattern<FileNamesInformation>(
                fileInformation.ToArray(),
                FileInfoClass.FILE_NAMES_INFORMATION,
                fileNames,
                wildCard,
                expectedFilesReturnedLength);
        }


        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileNamesInformation from the server for search pattern DOS_DOT described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileNamesInformation_DOS_DOT_WildCard()
        {
            var fileInformation = new List<FileNamesInformation>();
            int expectedFilesReturnedLength = 3;
            var fileNames = new List<string> { "grcBlankFile1.", "grcBlankFile2.", "grcBlankFile3.", "grc.BadFile_1.txt", "grc.BadFile_2.txt" };
            var wildCard = $"grcBlankFile?{DOS_DOT}";

            BVT_QueryDirectoryBySearchPattern<FileNamesInformation>(
                fileInformation.ToArray(),
                FileInfoClass.FILE_NAMES_INFORMATION,
                fileNames,
                wildCard,
                expectedFilesReturnedLength);
        }

        #endregion

    }
}
