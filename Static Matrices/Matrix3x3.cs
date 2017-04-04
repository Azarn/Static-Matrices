using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Matrices {
    public struct Matrix3x3 {
        private CoVector3[] cv;

        public Vector3[] Vectors { get; private set; }

        private Matrix3x3(Vector3[] vectors) {
            cv = null;
            Vectors = vectors;
            foreach(var x in vectors) {
                Console.WriteLine(x);
            }
        }

        public Matrix3x3(Vector3 first, Vector3 second, Vector3 third) : this(new Vector3[3] { first, second, third }) { }

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
                    new CoVector3(Vectors[0].X, Vectors[1].X, Vectors[2].X),
                    new CoVector3(Vectors[0].Y, Vectors[1].Y, Vectors[2].Y),
                    new CoVector3(Vectors[0].Z, Vectors[1].Z, Vectors[2].Z)
                    };
                }
                return cv;
            }
        }

        public double X1 => Vectors[0].X;
        public double Y1 => Vectors[0].Y;
        public double Z1 => Vectors[0].Z;
        public double X2 => Vectors[1].X;
        public double Y2 => Vectors[1].Y;
        public double Z2 => Vectors[1].Z;
        public double X3 => Vectors[2].X;
        public double Y3 => Vectors[2].Y;
        public double Z3 => Vectors[2].Z;

        public double this[int row, int column] => Vectors[row][column];

        public double Det => CoVectors[0] * (CoVectors[1] ^ CoVectors[2]);

        public double Trace => Vectors[0].X + Vectors[1].Y + Vectors[2].Z;
        public double Norm => Math.Sqrt(Vectors.Select(v => v.X * v.X + v.Y * v.Y + v.Z * v.Z).Sum());
        public Matrix3x3 Transposed => new Matrix3x3(Array.ConvertAll(CoVectors, cv => (Vector3)cv));
        public Matrix3x3 Inversed => new Matrix3x3((Vector3)(CoVectors[1] ^ CoVectors[2]),
                                                   (Vector3)(CoVectors[2] ^ CoVectors[0]),
                                                   (Vector3)(CoVectors[0] ^ CoVectors[1])) / Det;
        public Matrix3x3 Symmetrized => (this + Transposed) / 2;
        public Matrix3x3 Asymmetrized => (this - Transposed) / 2;

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

        public static Matrix3x3 operator /(double scalar, Matrix3x3 matrix) {
            return matrix * scalar;
        }

        public static Vector3 operator *(Vector3 vector, Matrix3x3 matrix) {
            return Vector3.UnsafeConvert(Array.ConvertAll(matrix.CoVectors, cv => (Vector3)cv * vector));
        }

        public static CoVector3 operator *(Matrix3x3 matrix, CoVector3 covector) {
            return CoVector3.UnsafeConvert(Array.ConvertAll(matrix.Vectors, cv => covector * (CoVector3)cv));
        }

        public static Matrix3x3 operator *(Matrix3x3 first, Matrix3x3 second) {
            return new Matrix3x3(
                Vector3.UnsafeConvert(Array.ConvertAll(second.CoVectors, cv => (Vector3)cv * first.Vectors[0])),
                Vector3.UnsafeConvert(Array.ConvertAll(second.CoVectors, cv => (Vector3)cv * first.Vectors[1])),
                Vector3.UnsafeConvert(Array.ConvertAll(second.CoVectors, cv => (Vector3)cv * first.Vectors[2]))
                );
        }
    }
}
