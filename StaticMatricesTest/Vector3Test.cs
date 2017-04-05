using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Static_Matrices;

// WOW, SUCH TRASH, SO COPYPASTED
namespace StaticMatricesTest {
    [TestClass]
    public class Vector3Test {
        private double x = 1.1;
        private double y = 2.2;
        private double z = 3.3;
        Vector3 v;

        [TestInitialize()]
        public void Initialize() {
            v = new Vector3(x, y, z);
        }

        [TestCleanup()]
        public void Cleanup() {
            v = new Vector3();
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
            Vector3 v2 = new Vector3(5.5, 6.6, 7.7);
            Assert.IsFalse(v2.Equals(v));
            Assert.IsFalse(v.Equals(v2));
            Assert.IsFalse(v == v2);
            Assert.IsFalse(v2 == v);
            Assert.IsTrue(v != v2);
            Assert.IsTrue(v2 != v);
        }

        [TestMethod]
        public void VectorWithSameValues_IsEqual() {
            Vector3 v2 = new Vector3(x, y, z);
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
            Vector3 nv = v.Normalized;
            Assert.AreEqual(nv.X, x / norm);
            Assert.AreEqual(nv.Y, y / norm);
            Assert.AreEqual(nv.Z, z / norm);
        }

        [TestMethod]
        public void Normalized_IsNotEqualToStartVector() {
            Vector3 nv = v.Normalized;
            Assert.AreNotEqual(v.X, nv.X);
            Assert.AreNotEqual(v.Y, nv.Y);
            Assert.AreNotEqual(v.Z, nv.Z);
        }

        [TestMethod]
        public void Addition_ReallyAdds() {
            Vector3 v2 = new Vector3(5.5, 6.6, 7.7);

            Vector3 av = v + v2;
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
            Vector3 v2 = new Vector3(5.5, 6.6, 7.7);

            Vector3 av = v - v2;
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
            Vector3 v2 = v * s;
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
            Vector3 v2 = v / s;
            Assert.AreEqual(v2.X, x / s);
            Assert.AreEqual(v2.Y, y / s);
            Assert.AreEqual(v2.Z, z / s);

            Assert.AreNotEqual(v2.X, v.X);
            Assert.AreNotEqual(v2.Y, v.Y);
            Assert.AreNotEqual(v2.Z, v.Z);
        }

        [TestMethod]
        public void ScalarMultiplication_ReallyMuls() {
            Vector3 v2 = new Vector3(5.5, 6.6, 7.7);
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
            Vector3 v2 = new Vector3(5.5, 6.6, 7.7);

            Vector3 mv = v ^ v2;
            Assert.AreEqual(mv.X, (y * v2.Z - z * v2.Y));
            Assert.AreEqual(mv.Y, -(x * v2.Z - z * v2.X));
            Assert.AreEqual(mv.Z, (x * v2.Y - y * v2.X));

            mv = v2 ^ v;
            Assert.AreEqual(mv.X, -(y * v2.Z - z * v2.Y));
            Assert.AreEqual(mv.Y, (x * v2.Z - z * v2.X));
            Assert.AreEqual(mv.Z, -(x * v2.Y - y * v2.X));
        }

        [TestMethod]
        public void Vector3_Mul_CoVector3_Correct() {
            CoVector3 v2 = new CoVector3(5.5, 6.6, 7.7);
            double expected = v.X * v2.X + v.Y * v2.Y + v.Z * v2.Z;
            double value = v * v2;
            Assert.AreEqual(value, expected);
        }

        [TestMethod]
        public void CoVector3_Mul_Vector3_Correct() {
            CoVector3 v2 = new CoVector3(5.5, 6.6, 7.7);
            Matrix3x3 m = v2 * v;
            Assert.AreEqual(m[0, 0], v2.X * x);
            Assert.AreEqual(m[0, 1], v2.X * y);
            Assert.AreEqual(m[0, 2], v2.X * z);
            Assert.AreEqual(m[1, 0], v2.Y * x);
            Assert.AreEqual(m[1, 1], v2.Y * y);
            Assert.AreEqual(m[1, 2], v2.Y * z);
            Assert.AreEqual(m[2, 0], v2.Z * x);
            Assert.AreEqual(m[2, 1], v2.Z * y);
            Assert.AreEqual(m[2, 2], v2.Z * z);
        }

        [TestMethod]
        public void Cast_ToCoVector3_Correct() {
            CoVector3 cv = (CoVector3)v;

            Assert.AreEqual(x, v.X);
            Assert.AreEqual(y, v.Y);
            Assert.AreEqual(z, v.Z);

            Assert.AreEqual(x, cv.X);
            Assert.AreEqual(y, cv.Y);
            Assert.AreEqual(z, cv.Z);
        }

        [TestMethod]
        public void UnsafeConvert_Correct() {
            Vector3 v2 = Vector3.UnsafeConvert(new double[3] { x, y, z });
            Assert.AreEqual(x, v2.X);
            Assert.AreEqual(y, v2.Y);
            Assert.AreEqual(z, v2.Z);
        }
    }
}
