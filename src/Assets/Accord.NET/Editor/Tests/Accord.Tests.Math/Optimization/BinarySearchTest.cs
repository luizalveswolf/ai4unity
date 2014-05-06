﻿// The Accord.NET Framework
// http://accord-framework.net
//
// Copyright © César Souza, 2009-2014
// cesarsouza at gmail.com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//

namespace Accord.Tests.Math
{
    using Accord.Math.Optimization;
    using NUnit.Framework;
    using System;
    using Accord.Math;


    [TestFixture]
    public class BinarySearchTest
    {
        double[] elements;
        int[] idx;

        public BinarySearchTest()
        {
            elements = new double[] { 5.2, 2.7, 8, 6.1, 21, 9, -1, 2, 0 };
            idx = Matrix.Indices(0, elements.Length);

            Array.Sort(elements, idx);
        }

        private TestContext testContextInstance;

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


        [Test]
        public void ConstructorTest()
        {
            Func<int, double> function = x => x * x * x + 2 * x * x - 10 * x + 1;
            BinarySearch search = new BinarySearch(function, -4, 3);
            double root = search.FindRoot();

            Assert.AreEqual(0, root);
        }

        [Test]
        public void ConstructorTest4()
        {
            // (x+5)^3 + 2(x+5)^2 - 10(x+5)
            Func<int, double> function = x =>
            {
                int y = (x + 5);
                return y * y * y + 2 * y * y - 10 * y;
            };

            BinarySearch search = new BinarySearch(function, -6, -4);
            double root = search.FindRoot();
            Assert.AreEqual(-5, root);
        }

        [Test]
        public void ConstructorTest1()
        {
            Func<int, double> function = x => elements[x];
            BinarySearch search = new BinarySearch(function, 0, elements.Length);

            int a1 = search.FindRoot();
            Assert.AreEqual(1, a1);

            for (int i = 0; i < elements.Length; i++)
            {
                int a2 = search.Find(elements[i]);
                Assert.AreEqual(i, a2);
            }
        }

        [Test]
        public void ConstructorTest2()
        {
            Func<int, double> function = x => elements[x];
            BinarySearch search = new BinarySearch(function, 0, elements.Length - 1);

            int a1 = search.Find(5);
            int a2 = search.Find(6);

            int a3 = search.Find(elements.Max() + 1);
            int a4 = search.Find(elements.Max() - 1);
            int a5 = search.Find(elements.Max());

            int a6 = search.Find(elements.Min() + 1);
            int a7 = search.Find(elements.Min() - 1);
            int a8 = search.Find(elements.Min());

            Assert.AreEqual(a1, 4);
            Assert.AreEqual(a2, 5);

            Assert.AreEqual(a3, 8);
            Assert.AreEqual(a4, 8);
            Assert.AreEqual(a5, 8);

            Assert.AreEqual(a6, 1);
            Assert.AreEqual(a7, 0);
            Assert.AreEqual(a8, 0);
        }

    }
}
