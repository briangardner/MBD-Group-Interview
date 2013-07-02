using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace Interview
{
    [TestFixture]
    class TestReportRequest
    {
        private string path = "D:\\Users\\a27a7wt\\My Documents\\Visual Studio 2010\\Projects\\Interview\\Interview\\XML Folder";
        private string reportPath = "C:\\Temp";
        private bool noIncludeSubDir = false;
        private bool includeSubDir = true;
        private string targetElement = "customer";
        public TestReportRequest()
        {
        }

        [Test]
        public void TestCreatingReportRequestWithoutIncludingSubDirectories()
        {
            ReportRequest request = new ReportRequest(path, reportPath, noIncludeSubDir, targetElement);
            Assert.AreEqual(1, request.getFiles().Count);
        }
        [Test]
        public void TestCreatingReportRequestIncludingSubDirectories()
        {
            ReportRequest request = new ReportRequest(path, reportPath, includeSubDir, targetElement);
            Assert.AreEqual(2, request.getFiles().Count);
        }

        [Test]
        public void TestFindingTargetWithoutSubDirectories()
        {
            ReportRequest request = new ReportRequest(path, reportPath, noIncludeSubDir, targetElement);
            List<ReportResult> result = request.findTarget();
            Assert.AreEqual(1, result.Count);
        }
        [Test]
        public void TestResultDataOfFirstElementOfResultsWithoutSubDirectories()
        {
            ReportRequest request = new ReportRequest(path, reportPath, noIncludeSubDir, targetElement);
            List<ReportResult> result = request.findTarget();
            Assert.AreEqual(3, result[0].nodeCount);
        }

        [Test]
        public void TestFindingTargetIncludingSubDirectories()
        {
            ReportRequest request = new ReportRequest(path, reportPath, includeSubDir, targetElement);
            List<ReportResult> result = request.findTarget();
            Assert.AreEqual(2, result.Count);
        }
        [Test]
        public void TestResultDataOfFirstElementOfResultsIncludingSubDirectories()
        {
            ReportRequest request = new ReportRequest(path, reportPath, includeSubDir, targetElement);
            List<ReportResult> result = request.findTarget();
            Assert.AreEqual(2, result[1].nodeCount);
        }

        [Test]
        public void TestGettingCorrectRootElement()
        {
            ReportRequest request = new ReportRequest(path, reportPath, includeSubDir, targetElement);
            List<ReportResult> result = request.findTarget();
            Assert.AreEqual("customers", result[0].rootNodeName);
        }

        [Test]
        public void TestGettingCorrectPathName()
        {
            string correctPath = path + "\\TestXMLFile.xml";
            ReportRequest request = new ReportRequest(path, reportPath, includeSubDir, targetElement);
            List<ReportResult> result = request.findTarget();
            Assert.AreEqual(correctPath, result[0].filePath);
        }
        [Test]
        public void TestSearchingForNonExistantTarget()
        {
            string invalidTargetElement = "invalid";
            ReportRequest request = new ReportRequest(path, reportPath, includeSubDir, invalidTargetElement);
            List<ReportResult> result = request.findTarget();
            Assert.AreEqual(0, result.Count);
        }
        [Test]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void TestLookingInInvalidXMLPath()
        {
            string invalidPath = "C:\\invalidPath";
            ReportRequest request = new ReportRequest(invalidPath, reportPath, includeSubDir, targetElement);
            List<ReportResult> result = request.findTarget();
        }

        [Test]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void TestInvalidReportPath()
        {
            string invalidPath = "C:\\invalidPath";
            ReportRequest request = new ReportRequest(invalidPath, reportPath, includeSubDir, targetElement);
            request.GenerateReport();
        }

        [Test]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void TestInvalidReportPathAndInvalidXMLPath()
        {
            string invalidPath = "C:\\invalidPath";
            ReportRequest request = new ReportRequest(invalidPath, invalidPath, includeSubDir, targetElement);
            request.GenerateReport();
        }
    }
}
