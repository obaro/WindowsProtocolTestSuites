﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter;
using Microsoft.Protocols.TestTools;
using Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Fscc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Protocols.TestSuites.FileSharing.Common.Adapter;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Smb2;
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
        [Description("Verify the Query Directory response with FileDirectoryInformation from the server for search patterns described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileDirectoryInformation_StarWildCard()
        {
            byte[] outputBuffer;
            List<string> fileNames;
            FileDirectoryInformation[] fileDirectoryInformation;
            int filesCount; // Count files returned from the query, that exist in the FileNames list
            int numberOfFiles = 10; //random file name count
            FileInfoClass fileInfoClass = FileInfoClass.FILE_DIRECTORY_INFORMATION;

            //[MS-FSA] 2.1.4.4 - Test case for wildcard "*"
            fileNames = CreateRandomFileNames(numberOfFiles);
            outputBuffer = QueryByWidldCardAndFileInfoClass("*", fileInfoClass, fileNames);

            fileDirectoryInformation = FsaUtility.UnmarshalFileInformationArray<FileDirectoryInformation>(outputBuffer);

            Site.Assert.AreEqual(12, fileDirectoryInformation.Length, "The returned Buffer should contain two entries of FileNamesInformation.");
            Site.Assert.AreEqual(".", Encoding.Unicode.GetString(fileDirectoryInformation[0].FileName), "FileName of the first entry should be \".\".");
            Site.Assert.AreEqual("..", Encoding.Unicode.GetString(fileDirectoryInformation[1].FileName), "FileName of the second entry should be \"..\".");

            filesCount = fileNames.Intersect(GetListFileInformation(fileDirectoryInformation)).ToList().Count();

            Site.Assert.AreEqual(numberOfFiles, filesCount, $"Number of files created should be equal to the number of files returned: {numberOfFiles}.");
        }

        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileDirectoryInformation from the server for search patterns described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileDirectoryInformation_SpecialCase_StarWildCard()
        {
            byte[] outputBuffer;
            List<string> fileNames;
            FileDirectoryInformation[] fileDirectoryInformation;
            int filesCount; // Count files returned from the query, that exist in the FileNames list
            int numberOfFiles = 10; //random file name count
            FileInfoClass fileInfoClass = FileInfoClass.FILE_DIRECTORY_INFORMATION;

            //[MS-FSA] 2.1.4.4 - Test case for wildcard "*.*"
            fileNames = CreateRandomFileNames(numberOfFiles);
            outputBuffer = QueryByWidldCardAndFileInfoClass("*.*", fileInfoClass, fileNames);

            fileDirectoryInformation = FsaUtility.UnmarshalFileInformationArray<FileDirectoryInformation>(outputBuffer);

            Site.Assert.AreEqual(12, fileDirectoryInformation.Length, "The returned Buffer should contain two entries of FileNamesInformation.");
            Site.Assert.AreEqual(".", Encoding.Unicode.GetString(fileDirectoryInformation[0].FileName), "FileName of the first entry should be \".\".");
            Site.Assert.AreEqual("..", Encoding.Unicode.GetString(fileDirectoryInformation[1].FileName), "FileName of the second entry should be \"..\".");
            filesCount = fileNames.Intersect(GetListFileInformation(fileDirectoryInformation)).ToList().Count();
            Site.Assert.AreEqual(numberOfFiles, filesCount, $"Number of files created should be equal to the number of files returned: {numberOfFiles}.");
        }

        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileDirectoryInformation from the server for search patterns described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileDirectoryInformation_WildCard_QuestionMark()
        {
            byte[] outputBuffer;
            List<string> fileNames;
            FileDirectoryInformation[] fileDirectoryInformation;
            int filesCount; // Count files returned from the query, that exist in the FileNames list
            int numberOfFiles = 2; //random file name count
            FileInfoClass fileInfoClass = FileInfoClass.FILE_DIRECTORY_INFORMATION;

            //[MS-FSA] 2.1.4.4 - Test case for wildcard "?" (DOS_QM) within string
            fileNames = new List<string> { "Fine", "File", "Bile", "Fille", "Nine" };
            outputBuffer = QueryByWidldCardAndFileInfoClass("Fi?e", fileInfoClass, fileNames);

            fileDirectoryInformation = FsaUtility.UnmarshalFileInformationArray<FileDirectoryInformation>(outputBuffer);

            Site.Assert.AreEqual(2, fileDirectoryInformation.Length, "The returned Buffer should contain entries that match the pattern.");
            filesCount = fileNames.Intersect(GetListFileInformation(fileDirectoryInformation)).ToList().Count();
            Site.Assert.AreEqual(2, filesCount, $"Number of files created should be equal to the number of files returned: {numberOfFiles}.");
        }

        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileDirectoryInformation from the server for search patterns described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileDirectoryInformation_KleeneStarWildCard()
        {
            byte[] outputBuffer;
            List<string> fileNames;
            FileDirectoryInformation[] fileDirectoryInformation;
            int filesCount; // Count files returned from the query, that exist in the FileNames list
            int numberOfFiles = 4; //random file name count
            FileInfoClass fileInfoClass = FileInfoClass.FILE_DIRECTORY_INFORMATION;

            //[MS-FSA] 2.1.4.4 - Test case for wildcard "*" within string
            fileNames = new List<string> { "File", "Pile", "While", "Tile", "Nine" };
            outputBuffer = QueryByWidldCardAndFileInfoClass("*ile", fileInfoClass, fileNames);

            fileDirectoryInformation = FsaUtility.UnmarshalFileInformationArray<FileDirectoryInformation>(outputBuffer);

            Site.Assert.AreEqual(4, fileDirectoryInformation.Length, "The returned Buffer should contain two entries of FileNamesInformation.");
            filesCount = fileNames.Intersect(GetListFileInformation(fileDirectoryInformation)).ToList().Count();
            Site.Assert.AreEqual(4, filesCount, $"Number of files created should be equal to the number of files returned: {numberOfFiles}.");
        }

        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileDirectoryInformation from the server for search patterns described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileDirectoryInformation_DOS_STAR_WildCard()
        {
            byte[] outputBuffer;
            List<string> fileNames;
            FileDirectoryInformation[] fileDirectoryInformation;
            int filesCount; // Count files returned from the query, that exist in the FileNames list
            FileInfoClass fileInfoClass = FileInfoClass.FILE_DIRECTORY_INFORMATION;

            //[MS-FSA] 2.1.4.4 - Test case for wildcard DOS_STAR
            fileNames = new List<string> { "Fine.txt", "FileGrip.txt", "Bile.txt", "Tile.txt", "Nine.jpg" };
            outputBuffer = QueryByWidldCardAndFileInfoClass($"{DOS_STAR}txt", fileInfoClass, fileNames);

            fileDirectoryInformation = FsaUtility.UnmarshalFileInformationArray<FileDirectoryInformation>(outputBuffer);

            Site.Assert.AreEqual(4, fileDirectoryInformation.Length, "The returned Buffer should contain two entries of FileNamesInformation.");
            filesCount = fileNames.Intersect(GetListFileInformation(fileDirectoryInformation)).ToList().Count();
            Site.Assert.AreEqual(4, filesCount, $"Number of files created should be equal to the number of files returned: {4}.");
        }

        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileDirectoryInformation from the server for search patterns described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileDirectoryInformation_DOS_DOT_WildCard()
        {
            byte[] outputBuffer;
            List<string> fileNames;
            FileDirectoryInformation[] fileDirectoryInformation;
            int filesCount; // Count files returned from the query, that exist in the FileNames list
            FileInfoClass fileInfoClass = FileInfoClass.FILE_DIRECTORY_INFORMATION;

            //[MS-FSA] 2.1.4.4 - Test case for wildcard DOS_DOT  ( .* )
            fileNames = new List<string> { "grc.BlankFile.1.txt", "grc.BlankFile.2.txt", "grc_BadFile_1.txt", "grc_BadFile_2.txt", "grc_BadFile_3.txt" };
            outputBuffer = QueryByWidldCardAndFileInfoClass($"grc{DOS_DOT_I}", fileInfoClass, fileNames);

            fileDirectoryInformation = FsaUtility.UnmarshalFileInformationArray<FileDirectoryInformation>(outputBuffer);

            Site.Assert.AreEqual(2, fileDirectoryInformation.Length, "The returned Buffer should contain two entries of FileNamesInformation.");
            filesCount = fileNames.Intersect(GetListFileInformation(fileDirectoryInformation)).ToList().Count();
            Site.Assert.AreEqual(2, filesCount, $"Number of files created should be equal to the number of files returned: {2}.");
        }

        [TestMethod()]
        [TestCategory(TestCategories.Bvt)]
        [TestCategory(TestCategories.Fsa)]
        [TestCategory(TestCategories.QueryDirectory)]
        [TestCategory(TestCategories.NonSmb)]
        [Description("Verify the Query Directory response with FileDirectoryInformation from the server for search patterns described in [MS-FSA] 2.1.4.")]
        public void BVT_QueryDirectoryBySearchPattern_FileDirectoryInformation_DOS_DOT_QuestionMark_WildCard()
        {
            byte[] outputBuffer;
            List<string> fileNames;
            FileDirectoryInformation[] fileDirectoryInformation;
            int filesCount; // Count files returned from the query, that exist in the FileNames list
            FileInfoClass fileInfoClass = FileInfoClass.FILE_DIRECTORY_INFORMATION;

            //[MS-FSA] 2.1.4.4 - Test case for wildcard DOS_DOT  ( .? )
            fileNames = new List<string> { "grc.BlankFile.1.txt", "grc.BlankFile.2.txt", "grc.BlankFile.3.txt", "grc.BadFile_1.txt", "grc.BadFile_2.txt" };
            outputBuffer = QueryByWidldCardAndFileInfoClass($"grc.BlankFile{ DOS_DOT_II}.txt", fileInfoClass, fileNames);

            fileDirectoryInformation = FsaUtility.UnmarshalFileInformationArray<FileDirectoryInformation>(outputBuffer);

            Site.Assert.AreEqual(3, fileDirectoryInformation.Length, "The returned Buffer should contain two entries of FileNamesInformation.");
            filesCount = fileNames.Intersect(GetListFileInformation(fileDirectoryInformation)).ToList().Count();
            Site.Assert.AreEqual(3, filesCount, $"Number of files created should be equal to the number of files returned: {3}.");
        }

        #endregion

    }
}
