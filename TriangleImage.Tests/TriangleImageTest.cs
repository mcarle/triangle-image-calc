using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using TriangleImage; 

namespace TriangleImage.Tests
{
    [TestClass]
    public class TriangleImageTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCalcTriangleCoordsBadInputs1() 
        {
            TriangleCoords.CalcTriangleCoords(new TriangleCoords.TriangleLocation('A', 13), 10); 
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCalcTriangleCoordsBadInputs2() 
        {
            TriangleCoords.CalcTriangleCoords(new TriangleCoords.TriangleLocation('G', 0), 10); 
        }

        [TestMethod]
        public void TestCalcTriangleCoords1()
        {
            Triangle t = TriangleCoords.CalcTriangleCoords(new TriangleCoords.TriangleLocation('A', 2), 10);
            Assert.AreEqual(0, t.V1.Row); 
            Assert.AreEqual(0, t.V1.Col); 
            Assert.AreEqual(0, t.V2.Row); 
            Assert.AreEqual(10, t.V2.Col); 
            Assert.AreEqual(10, t.V3.Row); 
            Assert.AreEqual(10, t.V3.Col);  
        }

        [TestMethod]
        public void TestCalcTriangleCoords2()
        {
            Triangle t = TriangleCoords.CalcTriangleCoords(new TriangleCoords.TriangleLocation('D', 7), 10);
            Assert.AreEqual(30, t.V1.Row); 
            Assert.AreEqual(30, t.V1.Col); 
            Assert.AreEqual(40, t.V2.Row); 
            Assert.AreEqual(40, t.V2.Col); 
            Assert.AreEqual(40, t.V3.Row); 
            Assert.AreEqual(30, t.V3.Col);  
        }


       [TestMethod]
        public void TestCalcTriangleCoords3()
        {
            Triangle t = TriangleCoords.CalcTriangleCoords(new TriangleCoords.TriangleLocation('F', 12), 10);
            Assert.AreEqual(50, t.V1.Row); 
            Assert.AreEqual(50, t.V1.Col); 
            Assert.AreEqual(50, t.V2.Row); 
            Assert.AreEqual(60, t.V2.Col); 
            Assert.AreEqual(60, t.V3.Row); 
            Assert.AreEqual(60, t.V3.Col);  
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCalcRowColBadInputs() 
        {
            var r = TriangleCoords.CalcRowAndCol(null, 10); 
        }

        [TestMethod]
        public void TestCalcRowCol1() 
        {
            Triangle t = new Triangle() 
            {
                V1 = new Triangle.TriangleVertex()
                {
                    Row = 0, 
                    Col = 0
                }, 
                V2 = new Triangle.TriangleVertex()
                {
                    Row = 0, 
                    Col = 10
                }, 
                V3 = new Triangle.TriangleVertex()
                {
                    Row = 10, 
                    Col = 10
                }
            }; 

            TriangleCoords.TriangleLocation r = 
                                    TriangleCoords.CalcRowAndCol(t, 10); 

            Assert.AreEqual('A', r.Row); 
            Assert.AreEqual(2, r.Col); 
        }

        [TestMethod]
        public void TestCalcRowCol2() 
        {
            Triangle t = new Triangle() 
            {
                V1 = new Triangle.TriangleVertex() 
                {
                    Row = 40, 
                    Col = 30, 
                }, 
                V2 = new Triangle.TriangleVertex()
                {
                    Row = 40, 
                    Col = 40
                }, 
                V3 = new Triangle.TriangleVertex() 
                {
                    Row = 30, 
                    Col = 30
                }
            }; 

            TriangleCoords.TriangleLocation r = 
                            TriangleCoords.CalcRowAndCol(t, 10); 

            Assert.AreEqual('D', r.Row); 
            Assert.AreEqual(7, r.Col); 
        }

        [TestMethod]
        public void TestCalcRowCol3() 
        {
            Triangle t = new Triangle() 
            {
                V1 = new Triangle.TriangleVertex() 
                {
                    Row = 50, 
                    Col = 50, 
                }, 
                V2 = new Triangle.TriangleVertex()
                {
                    Row = 60, 
                    Col = 60
                }, 
                V3 = new Triangle.TriangleVertex() 
                {
                    Row = 50, 
                    Col = 60
                }
            }; 

            TriangleCoords.TriangleLocation r = 
                            TriangleCoords.CalcRowAndCol(t, 10); 

            Assert.AreEqual('F', r.Row); 
            Assert.AreEqual(12, r.Col); 
        }

        [TestMethod]
        public void TestCalcRow4() 
        {
            Triangle t = new Triangle() 
            {
                V1 = new Triangle.TriangleVertex()
                {
                    Row = 10, 
                    Col = 10
                }, 
                V2 = new Triangle.TriangleVertex() 
                {
                    Row = 0, 
                    Col = 0
                }, 
                V3 = new Triangle.TriangleVertex() 
                {
                    Row = 10, 
                    Col = 0
                }
            }; 

            TriangleCoords.TriangleLocation r = 
                TriangleCoords.CalcRowAndCol(t, 10); 

            Assert.AreEqual('A', r.Row); 
            Assert.AreEqual(1, r.Col); 
        }
    }
}
