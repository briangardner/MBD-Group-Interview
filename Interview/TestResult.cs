using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Interview
{
    [TestFixture]
    class TestResult
    {
        public string testFileName = "C:\blah\blah.xml";
        public string testRootNode = "TestRootNode";
        public int testInitialCount = 5;

        public TestResult()
        {
        }

        [Test]
        public void TestCreatingNewResultWithNoCount()
        {
            ReportResult r = new ReportResult(testFileName, testRootNode);
            Assert.AreEqual(testFileName, r.filePath);
            Assert.AreEqual(testRootNode, r.rootNodeName);
            Assert.AreEqual(0, r.nodeCount);
        }
        [Test]
        public void TestCreatingNewResultWithCount()
        {
            ReportResult r = new ReportResult(testFileName, testRootNode, testInitialCount);
            Assert.AreEqual(testFileName, r.filePath);
            Assert.AreEqual(testRootNode, r.rootNodeName);
            Assert.AreEqual(5, r.nodeCount);
        }
        [Test]
        public void TestIncrementingCountByOne()
        {
            ReportResult r = new ReportResult(testFileName, testRootNode, testInitialCount);
            r.incrementCount();
            Assert.AreEqual(testFileName, r.filePath);
            Assert.AreEqual(testRootNode, r.rootNodeName);
            Assert.AreEqual(6, r.nodeCount);
        }

        [Test]
        public void TestIncrementingCountByThree()
        {
            ReportResult r = new ReportResult(testFileName, testRootNode, testInitialCount);
            r.incrementCount(3);
            Assert.AreEqual(testFileName, r.filePath);
            Assert.AreEqual(testRootNode, r.rootNodeName);
            Assert.AreEqual(8, r.nodeCount);
        }

        [Test]
        public void TestDecrementingCountByOne()
        {
            ReportResult r = new ReportResult(testFileName, testRootNode, testInitialCount);
            r.decrementCount();
            Assert.AreEqual(testFileName, r.filePath);
            Assert.AreEqual(testRootNode, r.rootNodeName);
            Assert.AreEqual(4, r.nodeCount);
        }

        [Test]
        public void TestDecrementingCountByThree()
        {
            ReportResult r = new ReportResult(testFileName, testRootNode, testInitialCount);
            r.decrementCount(3);
            Assert.AreEqual(testFileName, r.filePath);
            Assert.AreEqual(testRootNode, r.rootNodeName);
            Assert.AreEqual(2, r.nodeCount);
        }
        [Test]
        public void TestIncrementingAndDecrementingCount()
        {
            ReportResult r = new ReportResult(testFileName, testRootNode, testInitialCount);
            r.decrementCount(3);
            r.incrementCount();
            Assert.AreEqual(testFileName, r.filePath);
            Assert.AreEqual(testRootNode, r.rootNodeName);
            Assert.AreEqual(3, r.nodeCount);
        }
    }
}
