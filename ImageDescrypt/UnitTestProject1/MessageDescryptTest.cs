﻿using ImageDescrypt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    
    
    /// <summary>
    ///这是 MessageDescryptTest 的测试类，旨在
    ///包含所有 MessageDescryptTest 单元测试
    ///</summary>
    [TestClass()]
    public class MessageDescryptTest
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
        ///DecodeMsg 的测试
        ///</summary>
        [TestMethod()]
        public void DecodeMsgTest()
        {
            byte[] barr = // new byte[]{ 0x00, 0x00, 0x00, 0x07,  0x00, 0x01,  0x87, 0x6E, 0xCA, 0xA9, 0x07 }; // TODO: 初始化为适当的值
                //new byte[] { 0x00, 0x00, 0x00, 0x17, 0x00, 0x01, 0x8B, 0x51, 0x0A, 0x34, 
                //    0x0D, 0xB8, 0x00, 0x0D, 0x26, 0x26, 0x22, 0x43, 0x21, 0x21, 0x44, 0x21, 0x21, 0x45, 0x46, 0x46, 0x41};
                // new byte[] { 0x00, 0x00, 0x00, 0x12, 0x00, 0x01, 0x8F, 0x39, 0xCC, 0x9C, 0x01, 0x0A, 0xA2, 0x93, 0xDA, 0x96, 0x82, 0x80, 0xAD, 0xD0, 0x8E, 0x01 };
                //new byte[] { 0x0, 0x0, 0x0, 0xd, 0x0, 0x1, 0x8b, 0x51, 0x20, 0x91, 0x9, 0x21, 0x0, 0x3, 0xa4, 0x82, 0x82 };
                // new byte[] { 0x0, 0x0, 0x0, 0x47, 0x0, 0x1, 0xbd, 0xbd, 0xc6, 0xca, 0xbb, 0xa9, 0xa1, 0x86, 0xad, 0xc8, 0x8f, 0x1, 0xc6, 0xda, 0x89, 0x69, 0x0, 0xf, 0xe4, 0xb8, 0x9b, 0xe6, 0x9e, 0x97, 0xe6, 0x9a, 0x97, 0xe6, 0x9d, 0x80, 0xe8, 0x80, 0x85, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0xb0, 0x4, 0xe4, 0x9a, 0xc, 0x20, 0x5f, 0x8, 0xa4, 0x82, 0xdd, 0x3, 0x82, 0xdd, 0x3, 0xc8, 0x1, 0xc8, 0x1, 0x0, 0x0, 0x90, 0x3, 0x0, 0x5, 0x0, 0x0, 0x0, 0x0 };
                // new byte[] { 0x0, 0x0, 0x0, 0x5, 0x0, 0x9, 0x27, 0xd6, 0x2, 0x0, 0x0, 0x0, 0x26, 0x0, 0x1, 0xaa, 0x2e, 0x0, 0x1, 0x31, 0x0, 0x18, 0xe5, 0xae, 0x89, 0xe5, 0x85, 0xa8, 0xe9, 0x94, 0x81, 0xe8, 0xa7, 0xa3, 0xe9, 0x94, 0x81, 0xe6, 0x88, 0x90, 0xe5, 0x8a, 0x9f, 0xef, 0xbc, 0x81, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x48, 0x0, 0x1, 0xbd, 0xbd, 0x82, 0xc6, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0xcc, 0x8d, 0xff, 0x7b, 0x0, 0xf, 0xe4, 0xb8, 0x9b, 0xe6, 0x9e, 0x97, 0xe6, 0x9a, 0x97, 0xe6, 0x9d, 0x80, 0xe8, 0x80, 0x85, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0xc4, 0x4, 0x94, 0xa5, 0xc5, 0x9, 0xc, 0xf0, 0x9, 0x21, 0x80, 0xd9, 0x2, 0x80, 0xd9, 0x2, 0xc8, 0x1, 0xc8, 0x1, 0x0, 0x0, 0x90, 0x3, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x12, 0x0, 0x1, 0x8a, 0xfb, 0xde, 0xc5, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0xc, 0xa5, 0x8, 0xd6, 0x0, 0x0, 0x0, 0x1c, 0x0, 0x1, 0x8e, 0xd5, 0xea, 0xc5, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0x5, 0xf4, 0x9c, 0x1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x0, 0x0, 0x0, 0x1c, 0x0, 0x1, 0x8e, 0xd5, 0xc2, 0xc7, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0x2, 0xf4, 0x9c, 0x1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x0, 0x0, 0x0, 0x12, 0x0, 0x1, 0x8a, 0xfb, 0xa6, 0xc6, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0xb, 0xc4, 0x7, 0x14, 0x0, 0x0, 0x0, 0x1c, 0x0, 0x1, 0x8e, 0xd5, 0xda, 0xc7, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0x1, 0xf4, 0x9c, 0x1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x0, 0x0, 0x0, 0x1c, 0x0, 0x1, 0x8e, 0xd5, 0xa2, 0xc8, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0x6, 0xf4, 0x9c, 0x1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x0, 0x0, 0x0, 0xa, 0x0, 0x1, 0x92, 0xcf, 0x6, 0x0, 0x0, 0x1, 0x7c, 0x5a, 0x0, 0x0, 0x0, 0x11, 0x0, 0x1, 0x92, 0xbd, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0xe2, 0x98, 0x1, 0x0, 0x0, 0x0, 0x35, 0x0, 0x1, 0x92, 0xda, 0xb2, 0xdb, 0x6, 0x2, 0x0, 0x2b, 0x7b, 0x22, 0x65, 0x78, 0x70, 0x22, 0x3a, 0x32, 0x33, 0x39, 0x38, 0x39, 0x33, 0x36, 0x30, 0x2c, 0x22, 0x7a, 0x6f, 0x6e, 0x65, 0x6d, 0x6f, 0x64, 0x65, 0x6c, 0x69, 0x64, 0x22, 0x3a, 0x36, 0x2c, 0x22, 0x6b, 0x69, 0x6c, 0x6c, 0x22, 0x3a, 0x32, 0x37, 0x31, 0x7d, 0x0, 0x0, 0x0, 0x12, 0x0, 0x1, 0x8a, 0xfb, 0xde, 0xc5, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0xc, 0xa5, 0x8, 0xd6, 0x0, 0x0, 0x0, 0x1c, 0x0, 0x1, 0x8e, 0xd5, 0xea, 0xc5, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0x5, 0xf4, 0x9c, 0x1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x0, 0x0, 0x0, 0x1c, 0x0, 0x1, 0x8e, 0xd5, 0xc2, 0xc7, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0x2, 0xf4, 0x9c, 0x1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x0, 0x0, 0x0, 0x12, 0x0, 0x1, 0x8a, 0xfb, 0xa6, 0xc6, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0xb, 0xc4, 0x7, 0x14, 0x0, 0x0, 0x0, 0x1c, 0x0, 0x1, 0x8e, 0xd5, 0xda, 0xc7, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0x1, 0xf4, 0x9c, 0x1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x0, 0x0, 0x0, 0x1c, 0x0, 0x1, 0x8e, 0xd5, 0xa2, 0xc8, 0x9d, 0xcf, 0xbe, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0x6, 0xf4, 0x9c, 0x1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x0, 0x0, 0x0, 0xa, 0x0, 0x1, 0x92, 0xcf, 0x6, 0x0, 0x0, 0x1, 0x7c, 0x5a, 0x0, 0x0, 0x0, 0x11, 0x0, 0x1, 0x92, 0xbd, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0xe2, 0x98, 0x1, 0x0, 0x0, 0x0, 0x35, 0x0, 0x1, 0x92, 0xda, 0xb2, 0xdb, 0x6, 0x2, 0x0, 0x2b, 0x7b, 0x22, 0x65, 0x78, 0x70, 0x22, 0x3a, 0x32, 0x33, 0x39, 0x38, 0x39, 0x33, 0x36, 0x30, 0x2c, 0x22, 0x7a, 0x6f, 0x6e, 0x65, 0x6d, 0x6f, 0x64, 0x65, 0x6c, 0x69, 0x64, 0x22, 0x3a, 0x36, 0x2c, 0x22, 0x6b, 0x69, 0x6c, 0x6c, 0x22, 0x3a, 0x32, 0x37, 0x31, 0x7d };
                // new byte[] { 0x0, 0x0, 0x0, 0x5, 0x0, 0x3, 0xd, 0xa5, 0x0, 0x0, 0x0, 0x0, 0x37, 0x0, 0x1, 0x87, 0x5, 0x0, 0x1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x0, 0x19, 0xe5, 0xad, 0x90, 0xe9, 0xbc, 0xa0, 0x32, 0x38, 0x32, 0x2e, 0xe5, 0x8d, 0xa1, 0xe7, 0x89, 0xb9, 0xe5, 0xaf, 0x8c, 0xe5, 0xae, 0xbe, 0xe6, 0x81, 0xa9, 0xd6, 0x4, 0x0, 0xde, 0xcc, 0xef, 0xa1, 0xb, 0xa, 0x0, 0x0, 0x0 };
                // new byte[] { 0x0, 0x0, 0x0, 0x10, 0x0, 0x1, 0x92, 0xc1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0xbc, 0x1d, 0x0, 0x0, 0x0, 0x22, 0x0, 0x7, 0xa9, 0x55, 0xd8, 0xd5, 0xaf, 0xb7, 0xc4, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0xc, 0xc0, 0x9c, 0x1, 0x0, 0x0, 0x1c, 0xf4, 0x3, 0xc2, 0x0, 0x0, 0x0, 0x76, 0x0, 0x1, 0xaa, 0x2e, 0x0, 0x2, 0x31, 0x31, 0x0, 0x67, 0x7b, 0x22, 0x70, 0x73, 0x22, 0x3a, 0x5b, 0x7b, 0x22, 0x69, 0x64, 0x78, 0x22, 0x3a, 0x31, 0x2c, 0x22, 0x74, 0x79, 0x70, 0x65, 0x22, 0x3a, 0x33, 0x2c, 0x22, 0x76, 0x69, 0x70, 0x6c, 0x76, 0x22, 0x3a, 0x30, 0x7d, 0x5d, 0x2c, 0x22, 0x74, 0x22, 0x3a, 0x22, 0xe7, 0xbb, 0x8f, 0xe9, 0xaa, 0x8c, 0x3c, 0x66, 0x6f, 0x6e, 0x74, 0x20, 0x63, 0x6f, 0x6c, 0x6f, 0x72, 0x3d, 0x5c, 0x22, 0x23, 0x66, 0x66, 0x65, 0x61, 0x62, 0x37, 0x5c, 0x22, 0x3e, 0x33, 0x39, 0x31, 0x35, 0x30, 0x3c, 0x2f, 0x66, 0x6f, 0x6e, 0x74, 0x3e, 0xef, 0xbc, 0x88, 0x7b, 0x40, 0x7d, 0x2b, 0xe7, 0xbb, 0x8f, 0xe9, 0xaa, 0x8c, 0x30, 0xef, 0xbc, 0x89, 0x22, 0x7d, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x8, 0x0, 0x1, 0x92, 0xbf, 0xf8, 0xef, 0x92, 0x13, 0x0, 0x0, 0x0, 0xa, 0x0, 0x2, 0x27, 0x2d, 0x1, 0xc0, 0xbb, 0x1, 0x0, 0xc, 0x0, 0x0, 0x0, 0xa, 0x0, 0x1, 0x92, 0xcf, 0x6, 0x0, 0x0, 0x1, 0x7c, 0xe, 0x0, 0x0, 0x0, 0xa, 0x0, 0x1, 0x92, 0xcf, 0x6, 0x0, 0x0, 0x1, 0x7c, 0xe, 0x0, 0x0, 0x0, 0x22, 0x0, 0x1, 0x8e, 0xd6, 0xa2, 0xcd, 0xbb, 0xa9, 0xa1, 0x86, 0xad, 0xc8, 0x8f, 0x1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0xc0, 0x9c, 0x1, 0x0, 0xcc, 0x8c, 0x1, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x76, 0x0, 0x1, 0xaa, 0x2e, 0x0, 0x2, 0x31, 0x31, 0x0, 0x67, 0x7b, 0x22, 0x70, 0x73, 0x22, 0x3a, 0x5b, 0x7b, 0x22, 0x69, 0x64, 0x78, 0x22, 0x3a, 0x31, 0x2c, 0x22, 0x74, 0x79, 0x70, 0x65, 0x22, 0x3a, 0x33, 0x2c, 0x22, 0x76, 0x69, 0x70, 0x6c, 0x76, 0x22, 0x3a, 0x30, 0x7d, 0x5d, 0x2c, 0x22, 0x74, 0x22, 0x3a, 0x22, 0xe7, 0xbb, 0x8f, 0xe9, 0xaa, 0x8c, 0x3c, 0x66, 0x6f, 0x6e, 0x74, 0x20, 0x63, 0x6f, 0x6c, 0x6f, 0x72, 0x3d, 0x5c, 0x22, 0x23, 0x66, 0x66, 0x65, 0x61, 0x62, 0x37, 0x5c, 0x22, 0x3e, 0x33, 0x39, 0x31, 0x35, 0x30, 0x3c, 0x2f, 0x66, 0x6f, 0x6e, 0x74, 0x3e, 0xef, 0xbc, 0x88, 0x7b, 0x40, 0x7d, 0x2b, 0xe7, 0xbb, 0x8f, 0xe9, 0xaa, 0x8c, 0x30, 0xef, 0xbc, 0x89, 0x22, 0x7d, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x8, 0x0, 0x1, 0x92, 0xbf, 0xf8, 0xef, 0x92, 0x13, 0x0, 0x0, 0x0, 0xa, 0x0, 0x2, 0x27, 0x2d, 0x1, 0xc0, 0xbb, 0x1, 0x0, 0xc, 0x0, 0x0, 0x0, 0xa, 0x0, 0x1, 0x92, 0xcf, 0x6, 0x0, 0x0, 0x1, 0x7c, 0xe, 0x0, 0x0, 0x0, 0xa, 0x0, 0x1, 0x92, 0xcf, 0x6, 0x0, 0x0, 0x1, 0x7c, 0xe, 0x0, 0x0, 0x0, 0x22, 0x0, 0x1, 0x8e, 0xd6, 0xa2, 0xcd, 0xbb, 0xa9, 0xa1, 0x86, 0xad, 0xc8, 0x8f, 0x1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0xc0, 0x9c, 0x1, 0x0, 0xcc, 0x8c, 0x1, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0xa, 0x0, 0x1, 0x92, 0xcf, 0x6, 0x0, 0x0, 0x1, 0x7c, 0xe, 0x0, 0x0, 0x0, 0x11, 0x0, 0x1, 0x92, 0xbd, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0xcc, 0x8d, 0x1, 0x0, 0x0, 0x0, 0xa, 0x0, 0x1, 0x92, 0xcf, 0x6, 0x0, 0x0, 0x1, 0x7c, 0xe, 0x0, 0x0, 0x0, 0x11, 0x0, 0x1, 0x92, 0xbd, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x94, 0x8e, 0x1, 0x0, 0x0, 0x0, 0x10, 0x0, 0x1, 0x92, 0xc1, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x98, 0x20, 0x0, 0x0, 0x0, 0xa, 0x0, 0x1, 0x92, 0xcf, 0x6, 0x0, 0x0, 0x1, 0x7c, 0xe, 0x0, 0x0, 0x0, 0x11, 0x0, 0x1, 0x92, 0xbd, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x94, 0x8e, 0x1, 0x0, 0x0, 0x0, 0xa, 0x0, 0x1, 0x92, 0xcf, 0x6, 0x0, 0x0, 0x1, 0x7c, 0xe, 0x0, 0x0, 0x0, 0x11, 0x0, 0x1, 0x92, 0xbd, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x94, 0x8e, 0x1, 0x0, 0x0, 0x0, 0x15, 0x0, 0x1, 0x8a, 0xf7, 0xba, 0xcd, 0xbb, 0xa9, 0xa1, 0x86, 0xad, 0xc8, 0x8f, 0x1, 0x18, 0x8f, 0x1, 0xe7, 0x0, 0x1, 0x85, 0x0, 0x0, 0x0, 0xa, 0x0, 0x1, 0x92, 0xcf, 0x6, 0x0, 0x0, 0x1, 0x7c, 0xe, 0x0, 0x0, 0x0, 0x11, 0x0, 0x1, 0x92, 0xbd, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x94, 0x8e, 0x1, 0x0, 0x0, 0x0, 0x47, 0x0, 0x1, 0xbd, 0xbd, 0x8a, 0xcd, 0xbb, 0xa9, 0xa1, 0x86, 0xad, 0xc8, 0x8f, 0x1, 0xc8, 0xda, 0x89, 0x69, 0x0, 0xf, 0xe4, 0xb8, 0x9b, 0xe6, 0x9e, 0x97, 0xe7, 0x94, 0x9f, 0xe5, 0x91, 0xbd, 0xe4, 0xbd, 0x93, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0xc4, 0x4, 0xe4, 0x9a, 0xc, 0x1c, 0x5e, 0x4, 0x8a, 0xfa, 0xf3, 0x3, 0xfa, 0xf3, 0x3, 0xc8, 0x1, 0xc8, 0x1, 0x0, 0x0, 0x90, 0x3, 0x0, 0x1, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x10, 0x0, 0x1, 0x8a, 0xf3, 0x0, 0x1, 0xd4, 0xf4, 0xdc, 0xb3, 0xc4, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0x0, 0x0, 0x0, 0xa, 0x0, 0x1, 0x92, 0xcf, 0x6, 0x0, 0x0, 0x1, 0x7c, 0xe, 0x0, 0x0, 0x0, 0x11, 0x0, 0x1, 0x92, 0xbd, 0xb0, 0xb9, 0x9e, 0xcd, 0xad, 0x85, 0xad, 0xc8, 0x8f, 0x1, 0x94, 0x8e, 0x1, 0x0, 0x0, 0x1, 0xd, 0x0, 0x1, 0xaa, 0x2e, 0x0, 0x1, 0x36, 0x0, 0x90, 0x7b, 0x22, 0x70, 0x73, 0x22, 0x3a, 0x5b, 0x7b, 0x22, 0x6e, 0x61, 0x6d, 0x65, 0x22, 0x3a, 0x22, 0xe5, 0xad, 0x90, 0xe9, 0xbc, 0xa0, 0x32, 0x38, 0x32, 0x2e, 0xe7, 0x9a, 0x87, 0xe5, 0xb8, 0x9d, 0xe4, 0xb8, 0x80, 0xe6, 0x97, 0x8f, 0x22, 0x2c, 0x22, 0x70, 0x69, 0x64, 0x22, 0x3a, 0x22, 0x35, 0x31, 0x37, 0x32, 0x34, 0x38, 0x33, 0x31, 0x34, 0x35, 0x36, 0x32, 0x37, 0x31, 0x32, 0x30, 0x37, 0x34, 0x32, 0x22, 0x2c, 0x22, 0x74, 0x79, 0x70, 0x65, 0x22, 0x3a, 0x31, 0x7d, 0x5d, 0x2c, 0x22, 0x74, 0x22, 0x3a, 0x22, 0x7b, 0x40, 0x7d, 0xe5, 0x9c, 0xa8, 0x5b, 0xe5, 0xbc, 0x82, 0x5d, 0xe6, 0xad, 0xbb, 0xe4, 0xba, 0xa1, 0xe6, 0xb2, 0x99, 0xe6, 0xbc, 0xa0, 0xe5, 0x87, 0xbb, 0xe6, 0x9d, 0x80, 0xe4, 0xb8, 0x8d, 0xe6, 0x9c, 0xbd, 0xc2, 0xb7, 0xe9, 0x93, 0x81, 0xe8, 0xbd, 0xae, 0xe6, 0x88, 0x98, 0xe5, 0xa3, 0xab, 0xe6, 0x8e, 0x89, 0xe8, 0x90, 0xbd, 0x7b, 0x24, 0x7d, 0x22, 0x7d, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x0, 0xbc, 0xca, 0xd0, 0xb7, 0xc4, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0x9a, 0xed, 0xac, 0x1, 0x2, 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x30, 0xa0, 0x6, 0x62, 0xe8, 0x7, 0x2, 0x0, 0x0, 0x0, 0x4, 0x0, 0x0, 0x2, 0x1, 0x4, 0x1, 0x6, 0x1, 0x0, 0x0, 0x0, 0x5, 0x2, 0x0, 0x4, 0x0, 0x6, 0x0, 0x8, 0x0, 0xa, 0x0, 0x0, 0x0, 0x0, 0xf4, 0x44, 0xc4, 0x8, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x7, 0x30, 0x5f, 0x30, 0x5f, 0x30, 0x5f, 0x30, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x6, 0x31, 0x32, 0x5f, 0x30, 0x5f, 0x30, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1, 0xd, 0x0, 0x1, 0xaa, 0x2e, 0x0, 0x1, 0x36, 0x0, 0x90, 0x7b, 0x22, 0x70, 0x73, 0x22, 0x3a, 0x5b, 0x7b, 0x22, 0x6e, 0x61, 0x6d, 0x65, 0x22, 0x3a, 0x22, 0xe5, 0xad, 0x90, 0xe9, 0xbc, 0xa0, 0x32, 0x38, 0x32, 0x2e, 0xe7, 0x9a, 0x87, 0xe5, 0xb8, 0x9d, 0xe4, 0xb8, 0x80, 0xe6, 0x97, 0x8f, 0x22, 0x2c, 0x22, 0x70, 0x69, 0x64, 0x22, 0x3a, 0x22, 0x35, 0x31, 0x37, 0x32, 0x34, 0x38, 0x33, 0x31, 0x34, 0x35, 0x36, 0x32, 0x37, 0x31, 0x32, 0x30, 0x37, 0x34, 0x32, 0x22, 0x2c, 0x22, 0x74, 0x79, 0x70, 0x65, 0x22, 0x3a, 0x31, 0x7d, 0x5d, 0x2c, 0x22, 0x74, 0x22, 0x3a, 0x22, 0x7b, 0x40, 0x7d, 0xe5, 0x9c, 0xa8, 0x5b, 0xe5, 0xbc, 0x82, 0x5d, 0xe6, 0xad, 0xbb, 0xe4, 0xba, 0xa1, 0xe6, 0xb2, 0x99, 0xe6, 0xbc, 0xa0, 0xe5, 0x87, 0xbb, 0xe6, 0x9d, 0x80, 0xe4, 0xb8, 0x8d, 0xe6, 0x9c, 0xbd, 0xc2, 0xb7, 0xe9, 0x93, 0x81, 0xe8, 0xbd, 0xae, 0xe6, 0x88, 0x98, 0xe5, 0xa3, 0xab, 0xe6, 0x8e, 0x89, 0xe8, 0x90, 0xbd, 0x7b, 0x24, 0x7d, 0x22, 0x7d, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x0, 0xbc, 0xca, 0xd0, 0xb7, 0xc4, 0x87, 0xad, 0xc8, 0x8f, 0x1, 0x9a, 0xed, 0xac, 0x1, 0x2, 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x30, 0xa0, 0x6, 0x62, 0xe8, 0x7, 0x2, 0x0, 0x0, 0x0, 0x4, 0x0, 0x0, 0x2, 0x1, 0x4, 0x1, 0x6, 0x1, 0x0, 0x0, 0x0, 0x5, 0x2, 0x0, 0x4, 0x0, 0x6, 0x0, 0x8, 0x0, 0xa, 0x0, 0x0, 0x0, 0x0, 0xf4, 0x44, 0xc4, 0x8, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x7, 0x30, 0x5f, 0x30, 0x5f, 0x30, 0x5f, 0x30, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x6, 0x31, 0x32, 0x5f, 0x30, 0x5f, 0x30, 0x0, 0x0, 0x0, 0x0, 0x0 };
                //new byte[] { 0x0, 0x0, 0x0, 0x9, 0x0, 0x1, 0x95, 0xd2, 0x0, 0x0, 0x18, 0x42, 0x0 };
                //new byte[]{0x0,0x0,0x0,0x7,0x0,0x8,0x35,0xc0,0x0,0x0,0x0,0x0,0x0,0x0,0xa6,0x0,0x7,0xcc,0x1a,0xba,0x3,0x80,0xda,0xe1,0xa1,0xb,0xfe,0xab,0x81,0xa2,0xb,0x0,0x0,0x0,0x3,0x0,0x3,0x31,0x30,0x30,0x0,0x28,0x21,0x32,0x30,0x30,0x32,0x36,0x36,0x5f,0x31,0x2c,0x21,0x37,0x32,0x30,0x30,0x30,0x36,0x5f,0x34,0x2c,0x21,0x37,0x33,0x32,0x36,0x37,0x38,0x5f,0x32,0x30,0x2c,0x21,0x37,0x33,0x36,0x36,0x34,0x34,0x5f,0x31,0x0,0x0,0x3,0x35,0x30,0x30,0x0,0x27,0x21,0x32,0x30,0x30,0x32,0x36,0x37,0x5f,0x31,0x2c,0x21,0x37,0x33,0x32,0x34,0x38,0x38,0x5f,0x31,0x2c,0x21,0x37,0x33,0x36,0x36,0x34,0x35,0x5f,0x31,0x2c,0x21,0x37,0x33,0x36,0x38,0x35,0x36,0x5f,0x31,0x0,0x0,0x4,0x31,0x30,0x30,0x30,0x0,0x26,0x21,0x37,0x34,0x30,0x36,0x38,0x39,0x5f,0x31,0x2c,0x21,0x37,0x33,0x32,0x34,0x38,0x39,0x5f,0x31,0x2c,0x21,0x37,0x33,0x32,0x36,0x37,0x39,0x5f,0x34,0x2c,0x37,0x33,0x36,0x36,0x34,0x37,0x5f,0x31,0x0,0x0,0x1,0x30,0x0,0x0,0x0,0x0,0xa6,0x0,0x7,0xcc,0x1a,0xba,0x3,0x80,0xda,0xe1,0xa1,0xb,0xfe,0xab,0x81,0xa2,0xb,0x0,0x0,0x0,0x3,0x0,0x3,0x31,0x30,0x30,0x0,0x28,0x21,0x32,0x30,0x30,0x32,0x36,0x36,0x5f,0x31,0x2c,0x21,0x37,0x32,0x30,0x30,0x30,0x36,0x5f,0x34,0x2c,0x21,0x37,0x33,0x32,0x36,0x37,0x38,0x5f,0x32,0x30,0x2c,0x21,0x37,0x33,0x36,0x36,0x34,0x34,0x5f,0x31,0x0,0x0,0x3,0x35,0x30,0x30,0x0,0x27,0x21,0x32,0x30,0x30,0x32,0x36,0x37,0x5f,0x31,0x2c,0x21,0x37,0x33,0x32,0x34,0x38,0x38,0x5f,0x31,0x2c,0x21,0x37,0x33,0x36,0x36,0x34,0x35,0x5f,0x31,0x2c,0x21,0x37,0x33,0x36,0x38,0x35,0x36,0x5f,0x31,0x0,0x0,0x4,0x31,0x30,0x30,0x30,0x0,0x26,0x21,0x37,0x34,0x30,0x36,0x38,0x39,0x5f,0x31,0x2c,0x21,0x37,0x33,0x32,0x34,0x38,0x39,0x5f,0x31,0x2c,0x21,0x37,0x33,0x32,0x36,0x37,0x39,0x5f,0x34,0x2c,0x37,0x33,0x36,0x36,0x34,0x37,0x5f,0x31,0x0,0x0,0x1,0x30,0x0};
            new byte[] { 0x2, 0x1, 0x0, 0x9, 0x0, 0x1, 0x95, 0xd2, 0x0, 0x0, 0xc, 0x2a, 0x0 };
            int nvalue = MessageDescrypt.ReadInt(barr, 0);
                // MessageDescrypt.DecodeMsg(barr);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }
    }
}