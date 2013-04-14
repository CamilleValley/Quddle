using FreeQ_WS.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using FreeQ_WS.Classes;
using System.Collections.Generic;

namespace FreeQ_WS.Tests
{
    
    
    /// <summary>
    ///This is a test class for QueueServiceTest and is intended
    ///to contain all QueueServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class QueueServiceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CreateQueue
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\FreeQ\\FreeQ_WS\\FreeQ_WS", "/")]
        [UrlToTest("http://localhost:19871/")]
        public void CreateQueueTest()
        {
            QueueService target = new QueueService();
            string queueName = "Test_ShouldWork";
            long firstTicketNumber = 1;
            string physicalAddress = string.Empty;
            bool isActive = true;
            Guid userID = new Guid("24f7bf2e-56ee-44f0-a70f-7e7fbb321c38");
            Classes.Queue result;

            try
            {
                result = target.CreateQueue(queueName, firstTicketNumber, physicalAddress, isActive, userID);
            }
            catch
            {
                Assert.Fail();
            }

            try
            {
                queueName = "Test_ShouldNotWork_WrongUser";
                userID = System.Guid.NewGuid();

                result = target.CreateQueue(queueName, firstTicketNumber, physicalAddress, isActive, userID);

                userID = new Guid("24f7bf2e-56ee-44f0-a70f-7e7fbb321c38");

                Assert.Fail();
            }
            catch {}

            try
            {
                queueName = "";

                result = target.CreateQueue(queueName, firstTicketNumber, physicalAddress, isActive, userID);

                Assert.Fail();
            }
            catch { }
        }

        /// <summary>
        ///A test for GetQueue
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\FreeQ\\FreeQ_WS\\FreeQ_WS", "/")]
        [UrlToTest("http://localhost:19871/")]
        public void GetQueueTest()
        {
            QueueService target = new QueueService();
            Guid queueID = new Guid("93b5c72f-1541-4909-83f0-87c295082127");
            Classes.Queue actual;
            actual = target.GetQueue(queueID);
            Assert.AreNotEqual(null, actual);

            queueID = System.Guid.NewGuid();
            actual = target.GetQueue(queueID);
            Assert.AreEqual(null, actual);
        }

        /// <summary>
        ///A test for UpdateQueue
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\FreeQ\\FreeQ_WS\\FreeQ_WS", "/")]
        [UrlToTest("http://localhost:19871/")]
        public void UpdateQueueTest()
        {
            QueueService target = new QueueService();

            Guid queueID = new Guid("93b5c72f-1541-4909-83f0-87c295082127");
            string queueName = "Test_ShouldWork";
            long nextTicketNumber = 41;
            string physicalAddress = string.Empty;
            bool isActive = false;
            
            bool actual;
            actual = target.UpdateQueue(queueID, queueName, nextTicketNumber, physicalAddress, isActive);
            Assert.AreEqual(true, actual);

            queueID = System.Guid.NewGuid();
            queueName = "Test_ShouldNotWork_WrongID";
            actual = target.UpdateQueue(queueID, queueName, nextTicketNumber, physicalAddress, isActive);
            Assert.AreEqual(false, actual);

            try
            {
                queueID = new Guid("93b5c72f-1541-4909-83f0-87c295082127");
                nextTicketNumber = -1;
                queueName = "Test_ShouldNotWork_WrongInvalidNextTicketNumber";
                actual = target.UpdateQueue(queueID, queueName, nextTicketNumber, physicalAddress, isActive);

                Assert.Fail();
            }
            catch { }
        }

        /// <summary>
        ///A test for GetQueues
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\FreeQ\\FreeQ_WS\\FreeQ_WS", "/")]
        [UrlToTest("http://localhost:19871/")]
        public void GetQueuesTest()
        {
            QueueService target = new QueueService();
            Guid userID = new Guid("24f7bf2e-56ee-44f0-a70f-7e7fbb321c39");
            List<Classes.Queue> actual;
            actual = target.GetQueues(userID);
            Assert.AreEqual(1, actual.Count);

            userID = System.Guid.NewGuid();
            actual = target.GetQueues(userID);
            Assert.AreEqual(0, actual.Count);
        }
    }
}
