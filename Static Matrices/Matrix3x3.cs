using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Matrices {
    public struct Matrix3x3 {
        private CoVector3[] cv;
        private Vector3[] v;

        private Vector3 v1;
        private Vector3 v2;
        private Vector3 v3;

        public Vector3[] Vectors {
            get {
                if (v == null) {
                    v = new Vector3[3] { v1, v2, v3 };
                }
                return v;
            }
        }

        private Matrix3x3(Vector3[] vectors) : this(vectors[0], vectors[1], vectors[2]) { }

        public Matrix3x3(Vector3 first, Vector3 second, Vector3 third) {
            cv = null;
            v = null;
            v1 = first;
            v2 = second;
            v3 = third;
        }

        public Matrix3x3(CoVector3 first, CoVector3 second, CoVector3 third) :
            this(new Vector3(first.X, second.X, third.X),
                 new Vector3(first.Y, second.Y, third.Y),
                 new Vector3(first.Z, second.Z, third.Z)) { }

        public Matrix3x3(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3) :
            this(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2), new Vector3(x3, y3, z3)) {}

        public CoVector3[] CoVectors {
            get {
                if (cv == null) {
                    cv = new CoVector3[3] {
                    new CoVector3(v1.X, v2.X, v3.X),
                    new CoVector3(v1.Y, v2.Y, v3.Y),
                    new CoVector3(v1.Z, v2.Z, v3.Z)
                    };
                }
                return cv;
            }
        }

        public double X1 => v1.X;
        public double Y1 => v1.Y;
        public double Z1 => v1.Z;
        public double X2 => v2.X;
        public double Y2 => v2.Y;
        public double Z2 => v2.Z;
        public double X3 => v3.X;
        public double Y3 => v3.Y;
        public double Z3 => v3.Z;

        public double this[int row, int column] => Vectors[row][column];
        public Vector3 this[int row] => Vectors[row];

        public double Det => CoVectors[0] * (CoVectors[1] ^ CoVectors[2]);
        public double Trace => v1.X + v2.Y + v3.Z;
        public double Norm => Math.Sqrt(Vectors.Select(v => v.X * v.X + v.Y * v.Y + v.Z * v.Z).Sum());
        public Matrix3x3 Transposed => new Matrix3x3(Array.ConvertAll(CoVectors, cv => (Vector3)cv));
        public Matrix3x3 Inversed => new Matrix3x3((Vector3)(CoVectors[1] ^ CoVectors[2]),
                                                   (Vector3)(CoVectors[2] ^ CoVectors[0]),
                                                   (Vector3)(CoVectors[0] ^ CoVectors[1])) / Det;
        public Matrix3x3 Symmetrized => (this + Transposed) / 2;
        public Matrix3x3 Asymmetrized => (this - Transposed) / 2;

        public override int GetHashCode() {
            return 163 * v1.GetHashCode()  + 181 * v2.GetHashCode() + 199 * v3.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (!(obj is Matrix3x3)) {
                return false;
            }

            return Equals((Matrix3x3)obj);
        }

        public bool Equals(Matrix3x3 m) {
            return v1 == m[0] && v2 == m[1] && v3 == m[2];
        }

        public static bool operator ==(Matrix3x3 first, Matrix3x3 second) {
            return first.Equals(second);
        }

        public static bool operator !=(Matrix3x3 first, Matrix3x3 second) {
            return !(first == second);
        }

        public static Matrix3x3 operator +(Matrix3x3 first, Matrix3x3 second) {
            return new Matrix3x3(first.Vectors.Zip(second.Vectors, (f, s) => f + s).ToArray());
        }

        public static Matrix3x3 operator -(Matrix3x3 first, Matrix3x3 second) {
            return new Matrix3x3(first.Vectors.Zip(second.Vectors, (f, s) => f - s).ToArray());
        }

        public static Matrix3x3 operator *(Matrix3x3 matrix, double scalar) {
            return new Matrix3x3(Array.ConvertAll(matrix.Vectors, v => v * scalar));
        }

        public static Matrix3x3 operator *(double scalar, Matrix3x3 matrix) {
            return matrix * scalar;
        }

        public static Matrix3x3 operator /(Matrix3x3 matrix, double scalar) {
            return new Matrix3x3(Array.ConvertAll(matrix.Vectors, v => v / scalar));
        }

        public static Vector3 operator *(Vector3 vector, Matrix3x3 matrix) {
            return Vector3.UnsafeConvert(Array.ConvertAll(matrix.CoVectors, cv => (Vector3)cv * vector));
        }

        public static CoVector3 operator *(Matrix3x3 matrix, CoVector3 covector) {
            return CoVector3.UnsafeConvert(Array.ConvertAll(matrix.Vectors, cv => covector * (CoVector3)cv));
        }

        public static Matrix3x3 operator *(Matrix3x3 first, Matrix3x3 second) {
            return new Matrix3x3(
                Vector3.UnsafeConvert(Array.ConvertAll(second.CoVectors, cv => (Vector3)cv * first.v1)),
                Vector3.UnsafeConvert(Array.ConvertAll(second.CoVectors, cv => (Vector3)cv * first.v2)),
                Vector3.UnsafeConvert(Array.ConvertAll(second.CoVectors, cv => (Vector3)cv * first.v3))
                );
        }
    }
}
