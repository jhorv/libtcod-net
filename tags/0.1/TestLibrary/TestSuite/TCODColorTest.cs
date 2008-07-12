﻿using System;
using NUnit.Framework;
using libtcodWrapper;

namespace libtcodWrapperTests
{
    [TestFixture]
    public class TCODColorTest
    {
        private TCODColor emptyConstructor;
        private TCODColor copyConstructor;
        private TCODColor normalConstructor;
        private TCODColor sameConstructor;
        private TCODColor diffConstructor;
        private TCODColor HSVConstructor;

        [SetUp]
        public void Init()
        {
            emptyConstructor = new TCODColor();
            copyConstructor = new TCODColor(TCODColor.TCOD_silver);
            normalConstructor = new TCODColor(2, 4, 6);
            sameConstructor = new TCODColor(2, 4, 6);
            diffConstructor = new TCODColor(4, 8, 12);
            HSVConstructor = new TCODColor(1.0f, .5f, .3f);
        }

        [TearDown]
        public void Cleanup()
        {
        }

        [Test]
        public void TestCopyConstructor()
        {
            Assert.IsTrue(copyConstructor.Equals(TCODColor.TCOD_silver));
        }

        [Test]
        public void TestEqualityOperators()
        {
            Assert.IsTrue(normalConstructor == sameConstructor);
            Assert.IsTrue(!(normalConstructor == diffConstructor));
            Assert.IsTrue(normalConstructor != diffConstructor);
        }

        [Test]
        public void TestHashCode()
        {
            emptyConstructor.GetHashCode();
            Assert.IsTrue(normalConstructor.GetHashCode() == sameConstructor.GetHashCode());
        }

        [Test]
        public void TestOperators()
        {
            TCODColor mult = sameConstructor * diffConstructor;
            mult = mult * 1.5f;
            mult = mult * 1.5;
            Assert.IsTrue((normalConstructor + sameConstructor) == diffConstructor);

            TCODColor.Interpolate(mult, normalConstructor, .4f);
        }

        [Test]
        public void TestHSV()
        {
            float h, s, v;
            HSVConstructor.GetHSV(out h, out s, out v);
            normalConstructor.GetHSV(out h, out s, out v);
        }
    }
}