using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Static_Matrices;

// DO NOT LOOK, IT IS SHIT
namespace StaticMatricesTest {
    [TestClass]
    public class CoVector3Test {
        private double x = 1.1;
        private double y = 2.2;
        private double z = 3.3;
        CoVector3 v;

        [TestInitialize()]
        public void Initialize() {
            v = new CoVector3(x, y, z);
        }

        [TestCleanup()]
        public void Cleanup() {
            v = new CoVector3();
        }


        [TestMethod]
        public void Creation_MapsCorrect_XYZ() {
            Assert.AreEqual(x, v.X);
            Assert.AreEqual(y, v.Y);
            Assert.AreEqual(z, v.Z);

            Assert.AreEqual(x, v[0]);
            Assert.AreEqual(y, v[1]);
            Assert.AreEqual(z, v[2]);
        }

        [TestMethod]
        public void SameVector_IsEqual() {
            Assert.IsTrue(v.Equals(v));
            Assert.IsTrue(v == v);
            Assert.IsFalse(v != v);
            Assert.AreEqual(v.GetHashCode(), v.GetHashCode());
        }

        [TestMethod]
        public void DifferentVectors_AreNotEqual() {
            CoVector3 v2 = new CoVector3(5.5, 6.6, 7.7);
            Assert.IsFalse(v2.Equals(v));
            Assert.IsFalse(v.Equals(v2));
            Assert.IsFalse(v == v2);
            Assert.IsFalse(v2 == v);
            Assert.IsTrue(v != v2);
            Assert.IsTrue(v2 != v);
        }

        [TestMethod]
        public void VectorWithSameValues_IsEqual() {
            CoVector3 v2 = new CoVector3(x, y, z);
            Assert.IsTrue(v.Equals(v2));
            Assert.IsTrue(v2.Equals(v));
            Assert.IsTrue(v == v2);
            Assert.IsTrue(v2 == v);
            Assert.IsFalse(v != v2);
            Assert.IsFalse(v2 != v);

            Assert.AreEqual(v.GetHashCode(), v2.GetHashCode());
            Assert.AreEqual(x, v2.X);
            Assert.AreEqual(y, v2.Y);
            Assert.AreEqual(z, v2.Z);
            Assert.AreEqual(x, v.X);
            Assert.AreEqual(y, v.Y);
            Assert.AreEqual(z, v.Z);
        }

        [TestMethod]
        public void Norm_IsCorrect() {
            Assert.AreEqual(v.V0, Math.Sqrt(x * x + y * y + z * z));
        }

        [TestMethod]
        public void Normalized_IsCorrect() {
            double norm = Math.Sqrt(x * x + y * y + z * z);
            CoVector3 nv = v.Normalized;
            Assert.AreEqual(nv.X, x / norm);
            Assert.AreEqual(nv.Y, y / norm);
            Assert.AreEqual(nv.Z, z / norm);
        }

        [TestMethod]
        public void Normalized_IsNotEqualToStartVector() {
            CoVector3 nv = v.Normalized;
            Assert.AreNotEqual(v.X, nv.X);
            Assert.AreNotEqual(v.Y, nv.Y);
            Assert.AreNotEqual(v.Z, nv.Z);
        }

        [TestMethod]
        public void Addition_ReallyAdds() {
            CoVector3 v2 = new CoVector3(5.5, 6.6, 7.7);

            CoVector3 av = v + v2;
            Assert.AreEqual(av.X, x + v2.X);
            Assert.AreEqual(av.Y, y + v2.Y);
            Assert.AreEqual(av.Z, z + v2.Z);

            Assert.AreNotEqual(av.X, v.X);
            Assert.AreNotEqual(av.Y, v.Y);
            Assert.AreNotEqual(av.Z, v.Z);

            av = v2 + v;
            Assert.AreEqual(av.X, x + v2.X);
            Assert.AreEqual(av.Y, y + v2.Y);
            Assert.AreEqual(av.Z, z + v2.Z);
        }

        [TestMethod]
        public void Subtraction_ReallySubs() {
            CoVector3 v2 = new CoVector3(5.5, 6.6, 7.7);

            CoVector3 av = v - v2;
            Assert.AreEqual(av.X, x - v2.X);
            Assert.AreEqual(av.Y, y - v2.Y);
            Assert.AreEqual(av.Z, z - v2.Z);

            Assert.AreNotEqual(av.X, v.X);
            Assert.AreNotEqual(av.Y, v.Y);
            Assert.AreNotEqual(av.Z, v.Z);

            av = v2 - v;
            Assert.AreEqual(av.X, v2.X - x);
            Assert.AreEqual(av.Y, v2.Y - y);
            Assert.AreEqual(av.Z, v2.Z - z);
        }

        [TestMethod]
        public void MultiplicationWithScalar_ReallyMuls() {
            double s = 3.1415926;
            CoVector3 v2 = v * s;
            Assert.AreEqual(v2.X, x * s);
            Assert.AreEqual(v2.Y, y * s);
            Assert.AreEqual(v2.Z, z * s);

            Assert.AreNotEqual(v2.X, v.X);
            Assert.AreNotEqual(v2.Y, v.Y);
            Assert.AreNotEqual(v2.Z, v.Z);

            v2 = s * v;
            Assert.AreEqual(v2.X, x * s);
            Assert.AreEqual(v2.Y, y * s);
            Assert.AreEqual(v2.Z, z * s);
        }

        [TestMethod]
        public void DivisionWithScalar_ReallyDivs() {
            double s = 3.1415926;
            CoVector3 v2 = v / s;
            Assert.AreEqual(v2.X, x / s);
            Assert.AreEqual(v2.Y, y / s);
            Assert.AreEqual(v2.Z, z / s);

            Assert.AreNotEqual(v2.X, v.X);
            Assert.AreNotEqual(v2.Y, v.Y);
            Assert.AreNotEqual(v2.Z, v.Z);
        }

        [TestMethod]
        public void ScalarMultiplication_ReallyMuls() {
            CoVector3 v2 = new CoVector3(5.5, 6.6, 7.7);
            double expected = v.X * v2.X + v.Y * v2.Y + v.Z * v2.Z;
            double value = v * v2;
            Assert.AreEqual(value, expected);

            value = v2 * v;
            Assert.AreEqual(value, expected);

            Assert.AreNotEqual(v2.X, v.X);
            Assert.AreNotEqual(v2.Y, v.Y);
            Assert.AreNotEqual(v2.Z, v.Z);
        }

        [TestMethod]
        public void VectorMultiplication_ReallyMuls() {
            CoVector3 v2 = new CoVector3(5.5, 6.6, 7.7);

            CoVector3 mv = v ^ v2;
            Assert.AreEqual(mv.X, (y * v2.Z - z * v2.Y));
            Assert.AreEqual(mv.Y, -(x * v2.Z - z * v2.X));
            Assert.AreEqual(mv.Z, (x * v2.Y - y * v2.X));

            mv = v2 ^ v;
            Assert.AreEqual(mv.X, -(y * v2.Z - z * v2.Y));
            Assert.AreEqual(mv.Y, (x * v2.Z - z * v2.X));
            Assert.AreEqual(mv.Z, -(x * v2.Y - y * v2.X));
        }

        [TestMethod]
        public void Cast_ToCoVector3_Correct() {
            Vector3 cv = (Vector3)v;
            Assert.AreEqual(x, v.X);
            Assert.AreEqual(y, v.Y);
            Assert.AreEqual(z, v.Z);
            Assert.AreEqual(x, cv.X);
            Assert.AreEqual(y, cv.Y);
            Assert.AreEqual(z, cv.Z);
        }

        [TestMethod]
        public void UnsafeConvert_Correct() {
            CoVector3 v2 = CoVector3.UnsafeConvert(new double[3] { x, y, z });
            Assert.AreEqual(x, v2.X);
            Assert.AreEqual(y, v2.Y);
            Assert.AreEqual(z, v2.Z);
        }
    }
}
