using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Static_Matrices;

// HOP, GOVNOKOD
namespace StaticMatricesTest {
    [TestClass]
    public class Matrix3x3Test {
        private double x1 = 1.2;
        private double y1 = 2.3;
        private double z1 = 3.4;
        private double x2 = 4.5;
        private double y2 = 5.6;
        private double z2 = 6.7;
        private double x3 = 7.8;
        private double y3 = 8.9;
        private double z3 = 9.1;
        Matrix3x3 m;
        Vector3[] v;
        CoVector3[] cv;

        [TestInitialize()]
        public void Initialize() {
            m = new Matrix3x3(x1, y1, z1, x2, y2, z2, x3, y3, z3);
            v = new Vector3[3] {
                new Vector3(x1, y1, z1),
                new Vector3(x2, y2, z2),
                new Vector3(x3, y3, z3)
            };

            cv = new CoVector3[3] {
                new CoVector3(v[0][0], v[1][0], v[2][0]),
                new CoVector3(v[0][1], v[1][1], v[2][1]),
                new CoVector3(v[0][2], v[1][2], v[2][2])
            };
        }

        [TestCleanup()]
        public void Cleanup() {
            m = new Matrix3x3();
            v = null;
            cv = null;
        }

        [TestMethod]
        public void Creation_MapsCorrect() {
            Assert.AreEqual(x1, m.X1);
            Assert.AreEqual(y1, m.Y1);
            Assert.AreEqual(z1, m.Z1);
            Assert.AreEqual(x2, m.X2);
            Assert.AreEqual(y2, m.Y2);
            Assert.AreEqual(z2, m.Z2);
            Assert.AreEqual(x3, m.X3);
            Assert.AreEqual(y3, m.Y3);
            Assert.AreEqual(z3, m.Z3);

            Assert.AreEqual(x1, m[0, 0]);
            Assert.AreEqual(y1, m[0, 1]);
            Assert.AreEqual(z1, m[0, 2]);
            Assert.AreEqual(x2, m[1, 0]);
            Assert.AreEqual(y2, m[1, 1]);
            Assert.AreEqual(z2, m[1, 2]);
            Assert.AreEqual(x3, m[2, 0]);
            Assert.AreEqual(y3, m[2, 1]);
            Assert.AreEqual(z3, m[2, 2]);

            Assert.AreEqual(x1, m[0][0]);
            Assert.AreEqual(y1, m[0][1]);
            Assert.AreEqual(z1, m[0][2]);
            Assert.AreEqual(x2, m[1][0]);
            Assert.AreEqual(y2, m[1][1]);
            Assert.AreEqual(z2, m[1][2]);
            Assert.AreEqual(x3, m[2][0]);
            Assert.AreEqual(y3, m[2][1]);
            Assert.AreEqual(z3, m[2][2]);
        }

        [TestMethod]
        public void Constuctors_WorkCorrect() {
            Matrix3x3 m2 = new Matrix3x3(v[0], v[1], v[2]);
            Matrix3x3 m3 = new Matrix3x3(cv[0], cv[1], cv[2]);
            Assert.AreEqual(m.X1, m2.X1);
            Assert.AreEqual(m.Y1, m2.Y1);
            Assert.AreEqual(m.Z1, m2.Z1);
            Assert.AreEqual(m.X2, m2.X2);
            Assert.AreEqual(m.Y2, m2.Y2);
            Assert.AreEqual(m.Z2, m2.Z2);
            Assert.AreEqual(m.X3, m2.X3);
            Assert.AreEqual(m.Y3, m2.Y3);
            Assert.AreEqual(m.Z3, m2.Z3);

            Assert.AreEqual(m.X1, m3.X1);
            Assert.AreEqual(m.Y1, m3.Y1);
            Assert.AreEqual(m.Z1, m3.Z1);
            Assert.AreEqual(m.X2, m3.X2);
            Assert.AreEqual(m.Y2, m3.Y2);
            Assert.AreEqual(m.Z2, m3.Z2);
            Assert.AreEqual(m.X3, m3.X3);
            Assert.AreEqual(m.Y3, m3.Y3);
            Assert.AreEqual(m.Z3, m3.Z3);
        }

        [TestMethod]
        public void Creation_Maps_Vector3_And_CoVector3_Correct() {
            Assert.AreEqual(m.Vectors[0], v[0]);
            Assert.AreEqual(m.Vectors[1], v[1]);
            Assert.AreEqual(m.Vectors[2], v[2]);

            Assert.AreEqual(m[0], v[0]);
            Assert.AreEqual(m[1], v[1]);
            Assert.AreEqual(m[2], v[2]);

            Assert.AreEqual(m.CoVectors[0], cv[0]);
            Assert.AreEqual(m.CoVectors[1], cv[1]);
            Assert.AreEqual(m.CoVectors[2], cv[2]);
        }

        [TestMethod]
        public void SameMatrix_IsEqual() {
            Assert.IsTrue(m.Equals(m));
            Assert.IsTrue(m == m);
            Assert.IsFalse(m != m);
            Assert.AreEqual(m.GetHashCode(), m.GetHashCode());
        }

        [TestMethod]
        public void DifferentMatrices_AreNotEqual() {
            Matrix3x3 m2 = new Matrix3x3(11.2, 12.3, 13.4,
                                         14.5, 15.6, 16.7,
                                         17.8, 18.9, 19.1);
            Assert.IsFalse(m2.Equals(m));
            Assert.IsFalse(m.Equals(m2));
            Assert.IsFalse(m == m2);
            Assert.IsFalse(m2 == m);
            Assert.IsTrue(m != m2);
            Assert.IsTrue(m2 != m);
        }

        [TestMethod]
        public void VectorWithSameValues_IsEqual() {
            Matrix3x3 m2 = new Matrix3x3(m.Vectors[0], m.Vectors[1], m.Vectors[2]);
            Assert.IsTrue(m.Equals(m2));
            Assert.IsTrue(m2.Equals(m));
            Assert.IsTrue(m == m2);
            Assert.IsTrue(m2 == m);
            Assert.IsFalse(m != m2);
            Assert.IsFalse(m2 != m);

            Assert.AreEqual(m.GetHashCode(), m2.GetHashCode());
            Assert.AreEqual(m[0, 0], m2[0, 0]);
            Assert.AreEqual(m[0, 1], m2[0, 1]);
            Assert.AreEqual(m[0, 2], m2[0, 2]);
            Assert.AreEqual(m[1, 0], m2[1, 0]);
            Assert.AreEqual(m[1, 1], m2[1, 1]);
            Assert.AreEqual(m[1, 2], m2[1, 2]);
            Assert.AreEqual(m[2, 0], m2[2, 0]);
            Assert.AreEqual(m[2, 1], m2[2, 1]);
            Assert.AreEqual(m[2, 2], m2[2, 2]);
        }

        [TestMethod]
        public void Det_IsCorrect() {
            double expected = m[0][0] * m[1][1] * m[2][2] + m[1][0] * m[2][1] * m[0][2] +
                m[2][0] * m[0][1] * m[1][2] - m[2][0] * m[1][1] * m[0][2] -
                m[2][1] * m[1][2] * m[0][0] - m[2][2] * m[1][0] * m[0][1];
            Assert.AreEqual(expected, m.Det, 0.00000001);
        }

        [TestMethod]
        public void Trace_IsCorrect() {
            double expected = m[0, 0] + m[1, 1] + m[2, 2];
            Assert.AreEqual(expected, m.Trace);
        }

        [TestMethod]
        public void Norm_IsCorrect() {
            double expected = Math.Sqrt(
                m[0, 0] * m[0, 0] + m[0, 1] * m[0, 1] + m[0, 2] * m[0, 2] +
                m[1, 0] * m[1, 0] + m[1, 1] * m[1, 1] + m[1, 2] * m[1, 2] +
                m[2, 0] * m[2, 0] + m[2, 1] * m[2, 1] + m[2, 2] * m[2, 2]);
            Assert.AreEqual(expected, m.Norm);
        }

        [TestMethod]
        public void Transposed_IsCorrect() {
            Matrix3x3 m2 = new Matrix3x3((Vector3)cv[0], (Vector3)cv[1], (Vector3)cv[2]);
            Matrix3x3 mt = m.Transposed;
            Assert.AreEqual(m2[0, 0], mt[0, 0]);
            Assert.AreEqual(m2[0, 1], mt[0, 1]);
            Assert.AreEqual(m2[0, 2], mt[0, 2]);
            Assert.AreEqual(m2[1, 0], mt[1, 0]);
            Assert.AreEqual(m2[1, 1], mt[1, 1]);
            Assert.AreEqual(m2[1, 2], mt[1, 2]);
            Assert.AreEqual(m2[2, 0], mt[2, 0]);
            Assert.AreEqual(m2[2, 1], mt[2, 1]);
            Assert.AreEqual(m2[2, 2], mt[2, 2]);

            Assert.AreEqual(m[0, 0], mt[0, 0]);
            Assert.AreEqual(m[0, 1], mt[1, 0]);
            Assert.AreEqual(m[0, 2], mt[2, 0]);
            Assert.AreEqual(m[1, 0], mt[0, 1]);
            Assert.AreEqual(m[1, 1], mt[1, 1]);
            Assert.AreEqual(m[1, 2], mt[2, 1]);
            Assert.AreEqual(m[2, 0], mt[0, 2]);
            Assert.AreEqual(m[2, 1], mt[1, 2]);
            Assert.AreEqual(m[2, 2], mt[2, 2]);
        }

        [TestMethod]
        public void Inversed_IsCorrect() {

        }

        [TestMethod]
        public void Symmetrized_IsCorrect() {
            Matrix3x3 sm = m.Symmetrized;
            Assert.AreEqual(sm[0, 0], m[0, 0]);
            Assert.AreEqual(sm[0, 1], (m[0, 1] + m[1, 0]) / 2);
            Assert.AreEqual(sm[0, 2], (m[0, 2] + m[2, 0]) / 2);
            Assert.AreEqual(sm[1, 0], (m[1, 0] + m[0, 1]) / 2);
            Assert.AreEqual(sm[1, 1], m[1, 1]);
            Assert.AreEqual(sm[1, 2], (m[1, 2] + m[2, 1]) / 2);
            Assert.AreEqual(sm[2, 0], (m[2, 0] + m[0, 2]) / 2);
            Assert.AreEqual(sm[2, 1], (m[2, 1] + m[1, 2]) / 2);
            Assert.AreEqual(sm[2, 2], m[2, 2]);
        }

        [TestMethod]
        public void Asymmetrized_IsCorrect() {
            Matrix3x3 sm = m.Asymmetrized;
            Assert.AreEqual(sm[0, 0], 0);
            Assert.AreEqual(sm[0, 1], (m[0, 1] - m[1, 0]) / 2);
            Assert.AreEqual(sm[0, 2], (m[0, 2] - m[2, 0]) / 2);
            Assert.AreEqual(sm[1, 0], (m[1, 0] - m[0, 1]) / 2);
            Assert.AreEqual(sm[1, 1], 0);
            Assert.AreEqual(sm[1, 2], (m[1, 2] - m[2, 1]) / 2);
            Assert.AreEqual(sm[2, 0], (m[2, 0] - m[0, 2]) / 2);
            Assert.AreEqual(sm[2, 1], (m[2, 1] - m[1, 2]) / 2);
            Assert.AreEqual(sm[2, 2], 0);
        }

        [TestMethod]
        public void Addition_ReallyAdds() {
            Matrix3x3 m2 = new Matrix3x3(11.2, 12.3, 13.4,
                                         14.5, 15.6, 16.7,
                                         17.8, 18.9, 19.1);

            Matrix3x3 am = m + m2;
            Assert.AreEqual(am[0, 0], x1 + m2[0, 0]);
            Assert.AreEqual(am[0, 1], y1 + m2[0, 1]);
            Assert.AreEqual(am[0, 2], z1 + m2[0, 2]);
            Assert.AreEqual(am[1, 0], x2 + m2[1, 0]);
            Assert.AreEqual(am[1, 1], y2 + m2[1, 1]);
            Assert.AreEqual(am[1, 2], z2 + m2[1, 2]);
            Assert.AreEqual(am[2, 0], x3 + m2[2, 0]);
            Assert.AreEqual(am[2, 1], y3 + m2[2, 1]);
            Assert.AreEqual(am[2, 2], z3 + m2[2, 2]);


            Assert.AreNotEqual(m[0, 0], am[0, 0]);
            Assert.AreNotEqual(m[0, 1], am[0, 1]);
            Assert.AreNotEqual(m[0, 2], am[0, 2]);
            Assert.AreNotEqual(m[1, 0], am[1, 0]);
            Assert.AreNotEqual(m[1, 1], am[1, 1]);
            Assert.AreNotEqual(m[1, 2], am[1, 2]);
            Assert.AreNotEqual(m[2, 0], am[2, 0]);
            Assert.AreNotEqual(m[2, 1], am[2, 1]);
            Assert.AreNotEqual(m[2, 2], am[2, 2]);

            am = m2 + m;
            Assert.AreEqual(am[0, 0], x1 + m2[0, 0]);
            Assert.AreEqual(am[0, 1], y1 + m2[0, 1]);
            Assert.AreEqual(am[0, 2], z1 + m2[0, 2]);
            Assert.AreEqual(am[1, 0], x2 + m2[1, 0]);
            Assert.AreEqual(am[1, 1], y2 + m2[1, 1]);
            Assert.AreEqual(am[1, 2], z2 + m2[1, 2]);
            Assert.AreEqual(am[2, 0], x3 + m2[2, 0]);
            Assert.AreEqual(am[2, 1], y3 + m2[2, 1]);
            Assert.AreEqual(am[2, 2], z3 + m2[2, 2]);
        }

        [TestMethod]
        public void Subtraction_ReallySubs() {
            Matrix3x3 m2 = new Matrix3x3(11.2, 12.3, 13.4,
                                         14.5, 15.6, 16.7,
                                         17.8, 18.9, 19.1);

            Matrix3x3 am = m - m2;
            Assert.AreEqual(am[0, 0], x1 - m2[0, 0]);
            Assert.AreEqual(am[0, 1], y1 - m2[0, 1]);
            Assert.AreEqual(am[0, 2], z1 - m2[0, 2]);
            Assert.AreEqual(am[1, 0], x2 - m2[1, 0]);
            Assert.AreEqual(am[1, 1], y2 - m2[1, 1]);
            Assert.AreEqual(am[1, 2], z2 - m2[1, 2]);
            Assert.AreEqual(am[2, 0], x3 - m2[2, 0]);
            Assert.AreEqual(am[2, 1], y3 - m2[2, 1]);
            Assert.AreEqual(am[2, 2], z3 - m2[2, 2]);


            Assert.AreNotEqual(m[0, 0], am[0, 0]);
            Assert.AreNotEqual(m[0, 1], am[0, 1]);
            Assert.AreNotEqual(m[0, 2], am[0, 2]);
            Assert.AreNotEqual(m[1, 0], am[1, 0]);
            Assert.AreNotEqual(m[1, 1], am[1, 1]);
            Assert.AreNotEqual(m[1, 2], am[1, 2]);
            Assert.AreNotEqual(m[2, 0], am[2, 0]);
            Assert.AreNotEqual(m[2, 1], am[2, 1]);
            Assert.AreNotEqual(m[2, 2], am[2, 2]);

            am = m2 - m;
            Assert.AreEqual(am[0, 0], m2[0, 0] - x1);
            Assert.AreEqual(am[0, 1], m2[0, 1] - y1);
            Assert.AreEqual(am[0, 2], m2[0, 2] - z1);
            Assert.AreEqual(am[1, 0], m2[1, 0] - x2);
            Assert.AreEqual(am[1, 1], m2[1, 1] - y2);
            Assert.AreEqual(am[1, 2], m2[1, 2] - z2);
            Assert.AreEqual(am[2, 0], m2[2, 0] - x3);
            Assert.AreEqual(am[2, 1], m2[2, 1] - y3);
            Assert.AreEqual(am[2, 2], m2[2, 2] - z3);
        }

        [TestMethod]
        public void ScalarMultiplication_ReallyMuls() {
            double scalar = 3.1415926;

            Matrix3x3 am = m * scalar;
            Assert.AreEqual(am[0, 0], m[0, 0] * scalar);
            Assert.AreEqual(am[0, 1], m[0, 1] * scalar);
            Assert.AreEqual(am[0, 2], m[0, 2] * scalar);
            Assert.AreEqual(am[1, 0], m[1, 0] * scalar);
            Assert.AreEqual(am[1, 1], m[1, 1] * scalar);
            Assert.AreEqual(am[1, 2], m[1, 2] * scalar);
            Assert.AreEqual(am[2, 0], m[2, 0] * scalar);
            Assert.AreEqual(am[2, 1], m[2, 1] * scalar);
            Assert.AreEqual(am[2, 2], m[2, 2] * scalar);

            Assert.AreNotEqual(m[0, 0], am[0, 0]);
            Assert.AreNotEqual(m[0, 1], am[0, 1]);
            Assert.AreNotEqual(m[0, 2], am[0, 2]);
            Assert.AreNotEqual(m[1, 0], am[1, 0]);
            Assert.AreNotEqual(m[1, 1], am[1, 1]);
            Assert.AreNotEqual(m[1, 2], am[1, 2]);
            Assert.AreNotEqual(m[2, 0], am[2, 0]);
            Assert.AreNotEqual(m[2, 1], am[2, 1]);
            Assert.AreNotEqual(m[2, 2], am[2, 2]);

            am = scalar * m;
            Assert.AreEqual(am[0, 0], m[0, 0] * scalar);
            Assert.AreEqual(am[0, 1], m[0, 1] * scalar);
            Assert.AreEqual(am[0, 2], m[0, 2] * scalar);
            Assert.AreEqual(am[1, 0], m[1, 0] * scalar);
            Assert.AreEqual(am[1, 1], m[1, 1] * scalar);
            Assert.AreEqual(am[1, 2], m[1, 2] * scalar);
            Assert.AreEqual(am[2, 0], m[2, 0] * scalar);
            Assert.AreEqual(am[2, 1], m[2, 1] * scalar);
            Assert.AreEqual(am[2, 2], m[2, 2] * scalar);
        }

        [TestMethod]
        public void ScalarDivision_ReallyDivs() {
            double scalar = 3.1415926;

            Matrix3x3 am = m / scalar;
            Assert.AreEqual(am[0, 0], m[0, 0] / scalar);
            Assert.AreEqual(am[0, 1], m[0, 1] / scalar);
            Assert.AreEqual(am[0, 2], m[0, 2] / scalar);
            Assert.AreEqual(am[1, 0], m[1, 0] / scalar);
            Assert.AreEqual(am[1, 1], m[1, 1] / scalar);
            Assert.AreEqual(am[1, 2], m[1, 2] / scalar);
            Assert.AreEqual(am[2, 0], m[2, 0] / scalar);
            Assert.AreEqual(am[2, 1], m[2, 1] / scalar);
            Assert.AreEqual(am[2, 2], m[2, 2] / scalar);

            Assert.AreNotEqual(m[0, 0], am[0, 0]);
            Assert.AreNotEqual(m[0, 1], am[0, 1]);
            Assert.AreNotEqual(m[0, 2], am[0, 2]);
            Assert.AreNotEqual(m[1, 0], am[1, 0]);
            Assert.AreNotEqual(m[1, 1], am[1, 1]);
            Assert.AreNotEqual(m[1, 2], am[1, 2]);
            Assert.AreNotEqual(m[2, 0], am[2, 0]);
            Assert.AreNotEqual(m[2, 1], am[2, 1]);
            Assert.AreNotEqual(m[2, 2], am[2, 2]);
        }

        [TestMethod]
        public void Vector3_And_Matrix3x3_Multiplication_ReallyMuls() {
            Vector3 v2 = new Vector3(11.2, 12.3, 13.4);
            Vector3 expected = new Vector3(v2[0] * m[0, 0] + v2[1] * m[1, 0] + v2[2] * m[2, 0],
                                           v2[0] * m[0, 1] + v2[1] * m[1, 1] + v2[2] * m[2, 1],
                                           v2[0] * m[0, 2] + v2[1] * m[1, 2] + v2[2] * m[2, 2]);
            Assert.AreEqual(expected, v2 * m);
        }

        [TestMethod]
        public void Matrix3x3_And_CoVector3_Multiplication_ReallyMuls() {
            CoVector3 cv2 = new CoVector3(11.2, 12.3, 13.4);
            CoVector3 expected = new CoVector3(m[0, 0] * cv2[0] + m[0, 1] * cv2[1] + m[0, 2] * cv2[2],
                                               m[1, 0] * cv2[0] + m[1, 1] * cv2[1] + m[1, 2] * cv2[2],
                                               m[2, 0] * cv2[0] + m[2, 1] * cv2[1] + m[2, 2] * cv2[2]);
            Assert.AreEqual(expected, m * cv2);
        }

        [TestMethod]
        public void Matrix3x3_And_Matrix3x3_Multiplication_ReallyMuls() {
            Matrix3x3 m2 = new Matrix3x3(11.2, 12.3, 13.4,
                                         14.5, 15.6, 16.7,
                                         17.8, 18.9, 19.1);
            Matrix3x3 mv = m * m2;
            Matrix3x3 expected = new Matrix3x3(
                m[0, 0] * m2[0, 0] + m[0, 1] * m2[1, 0] + m[0, 2] * m2[2, 0],
                m[0, 0] * m2[0, 1] + m[0, 1] * m2[1, 1] + m[0, 2] * m2[2, 1],
                m[0, 0] * m2[0, 2] + m[0, 1] * m2[1, 2] + m[0, 2] * m2[2, 2],
                m[1, 0] * m2[0, 0] + m[1, 1] * m2[1, 0] + m[1, 2] * m2[2, 0],
                m[1, 0] * m2[0, 1] + m[1, 1] * m2[1, 1] + m[1, 2] * m2[2, 1],
                m[1, 0] * m2[0, 2] + m[1, 1] * m2[1, 2] + m[1, 2] * m2[2, 2],
                m[2, 0] * m2[0, 0] + m[2, 1] * m2[1, 0] + m[2, 2] * m2[2, 0],
                m[2, 0] * m2[0, 1] + m[2, 1] * m2[1, 1] + m[2, 2] * m2[2, 1],
                m[2, 0] * m2[0, 2] + m[2, 1] * m2[1, 2] + m[2, 2] * m2[2, 2]
                );

            Assert.AreEqual(mv[0, 0], expected[0, 0]);
            Assert.AreEqual(mv[0, 1], expected[0, 1]);
            Assert.AreEqual(mv[0, 2], expected[0, 2]);
            Assert.AreEqual(mv[1, 0], expected[1, 0]);
            Assert.AreEqual(mv[1, 1], expected[1, 1]);
            Assert.AreEqual(mv[1, 2], expected[1, 2]);
            Assert.AreEqual(mv[2, 0], expected[2, 0]);
            Assert.AreEqual(mv[2, 1], expected[2, 1]);
            Assert.AreEqual(mv[2, 2], expected[2, 2]);
        }
    }
}
