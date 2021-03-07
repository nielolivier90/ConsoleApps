using ConwayGame;
using NUnit.Framework;
using SortingApp;
using System;
using System.Security.Cryptography;
using System.Threading;

namespace UnitTests
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
            BasicTest();
            ExceptionTest();
            LimitTest();
        }
        [Test]
        public void BasicTest()
        {
            //Running
            Assert.DoesNotThrow(() => new Game(20, 20, 20, 1).Start());
        }
        [Test]
        public void ExceptionTest()
        {
            //Spawnning
            Assert.Throws<NullReferenceException>(() => new Game(10,10,1,1).SpawnNew(null));

            //Running
            Assert.Throws<ArgumentOutOfRangeException>(() => new Game(20, 20, 20, -1).Start());
            Assert.Throws<ArgumentOutOfRangeException>(() => new Game(20, 20, -1, 500).Start());
            Assert.Throws<ArgumentOutOfRangeException>(() => new Game(20, 0, 20, 500).Start());
            Assert.Throws<ArgumentOutOfRangeException>(() => new Game(0, 20, 20, 500).Start());
        }
        [Test]
        public void LimitTest()
        {
            //Spawnning
            Assert.DoesNotThrow(() => new Game(10, 10, 1, 1).SpawnNew(new Game.SpawnType[100, 100]));

            //Running
            Assert.DoesNotThrow(() => new Game(1, 1, 1, 0).Start());
            Assert.DoesNotThrow(() => new Game(100, 100, 1000, 1).Start());
            //Assert.DoesNotThrow(() => Game.Start(100, 100, 1000, 10000));
        }
        [Test]
        public void ThreadTest()
        {
            // Check if we can run multiple
            Assert.DoesNotThrow(() =>
            new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    new Thread(() =>
                        new Game(10, 10, 10, 1).Start()
                    )
                    { IsBackground = true }.Start();
                }
            }).Start());
        }
    }
}