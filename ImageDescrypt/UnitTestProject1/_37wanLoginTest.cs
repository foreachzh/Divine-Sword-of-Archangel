using ImageDescrypt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ImageDescrypt.Entity;

namespace UnitTestProject1
{
    
    
    /// <summary>
    ///这是 _37wanLoginTest 的测试类，旨在
    ///包含所有 _37wanLoginTest 单元测试
    ///</summary>
    [TestClass()]
    public class _37wanLoginTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
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

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///__rsa 的测试
        ///</summary>
        [TestMethod()]
        public void @__rsaTest()
        {
            /*
            string str = "LYifFXmP889Rdczc112PA"; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = _37wanLogin.@__rsa(str);
            Assert.AreEqual(expected, actual);
            */
            string errMsg = "";
            HISTORYGAMESERVER server = null;
            _37wanLogin obj = new _37wanLogin("burnblood2", "8891129zh");
            bool bret = obj.Login(ref server, ref errMsg);

            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
