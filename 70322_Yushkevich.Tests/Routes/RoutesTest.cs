using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace _70322_Yushkevich.Tests.Routes
{
    /// <summary>
    /// Summary description for RoutesTest
    /// </summary>
    [TestClass]
    public class RoutesTest
    {
        public RoutesTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }


        //*7
        [TestMethod]
        public void DefaultRouteTest()
        {
            // Arrange
            // Макет Http - контекста
            var mockContext = new Mock<HttpContextBase>();
            mockContext
            .Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
            .Returns("~/");
            // Создание коллекции маршрутов и регистрация маршрутов
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            //Act
            //Получение данных маршрута
            var result = routes.GetRouteData(mockContext.Object);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", result.Values["controller"]);
            Assert.AreEqual("Index", result.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, result.Values["id"]);
        }


    }
}
