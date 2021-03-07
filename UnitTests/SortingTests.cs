using NUnit.Framework;
using SortingApp;
using System;

namespace UnitTests
{
    public class SortingTests
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
            Assert.AreEqual("aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy", new Sorting("Contrary to popular belief, the pink unicorn flies east.").GenerateOutput());
            Assert.AreEqual("deefijlmosssttu", new Sorting("@#!'lsdfjiu     some test").GenerateOutput());
            Assert.AreEqual("aaadddfjjjklopsss", new Sorting("ASD:LKJDF OPASD_)(AS )J J").GenerateOutput());
        }
        [Test]
        public void ExceptionTest()
        {
            Assert.DoesNotThrow(() => new Sorting("Contrary to popular belief, Lorem Ipsum is not simply random text.It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.Richard McClintock, a Latin professor at Hampden - Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of 'de Finibus Bonorum et Malorum'(The Extremes of Good and Evil) by Cicero, written in 45 BC.This book is a treatise on the theory of ethics, very popular during the Renaissance.The first line of Lorem Ipsum, 'Lorem ipsum dolor sit amet..', comes from a line in section 1.10.32.").GenerateOutput());
            Assert.Throws<ArgumentNullException>(() => new Sorting(null).GenerateOutput());
        }

        [Test]
        public void LimitTest()
        {
            Random rnd = new Random();
            string longText = "";
            for (int i = 0; i < 100000; i++)
            {
                longText += (char)rnd.Next('a', 'z');
            }
            Assert.DoesNotThrow(() => new Sorting(longText).GenerateOutput());
        }
    }
}