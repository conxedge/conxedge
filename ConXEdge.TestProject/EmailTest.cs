using ConXEdge.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConXEdge.TestProject
{
    
    
    /// <summary>
    ///这是 EmailTest 的测试类，旨在
    ///包含所有 EmailTest 单元测试
    ///</summary>
    [TestClass()]
    public class EmailTest
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
        ///SendSMTPEMail 的测试
        ///</summary>
        [DataSource("System.Data.SqlClient", "Data Source=QQ-PC;Initial Catalog=SikaQC;Integrated Security=True", "aspnet_Users", DataAccessMethod.Sequential), TestMethod()]
        public void SendSMTPEMailTest()
        {
            Email target = new Email(); // TODO: 初始化为适当的值
            string strSmtpServer = string.Empty; // TODO: 初始化为适当的值
            string strFrom = string.Empty; // TODO: 初始化为适当的值
            string strFromPass = string.Empty; // TODO: 初始化为适当的值
            string strto = string.Empty; // TODO: 初始化为适当的值
            string strSubject = string.Empty; // TODO: 初始化为适当的值
            string strBody = string.Empty; // TODO: 初始化为适当的值
            
            target.SendSMTPEMail(strSmtpServer, strFrom, strFromPass, strto, strSubject, strBody);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }
    }
}
