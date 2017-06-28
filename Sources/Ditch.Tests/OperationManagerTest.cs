﻿using System;
using Ditch.Responses;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class OperationManagerTest : BaseTest, IDisposable
    {
        private OperationManager OperationManager;

        public OperationManagerTest()
        {
            OperationManager = new OperationManager();
            OperationManager.Init(ChainManager.KnownChains.Steem);
        }

        public void Dispose()
        {
            if (OperationManager != null)
                OperationManager.Close();
        }

        [Test]
        public void GetDynamicGlobalPropertiesTest()
        {
            var prop = OperationManager.GetDynamicGlobalProperties();
            prop.Start();
            Assert.IsTrue(prop != null);
            Assert.IsTrue(prop.Result != null);
            Assert.IsFalse(prop.Result.IsError);
        }

        [Test]
        public void GetContentTest()
        {
            var prop = OperationManager.GetContent("steepshot", "c-lib-ditch-1-0-for-graphene-from-steepshot-team-under-the-mit-license");
            prop.Start();
            Assert.IsTrue(prop != null);
            Assert.IsTrue(prop.Result != null);
            Assert.IsFalse(prop.Result.IsError);
            Assert.IsTrue(prop.Result.Result.TotalPayoutValue.Value > 0);
        }

        [Test]
        [TestCase("277.126 SBD")]
        public void ParseTestTest(string test)
        {
            var money = new Money(test);
            Assert.IsTrue(money.Value == 277.126);
            Assert.IsTrue(money.Currency == "SBD");
        }
    }
}