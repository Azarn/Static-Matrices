using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Matrices {
    public struct Vector3 {
        public Vector3(double x, double y, double z) {
            X = x;
            Y = y;
            Z = z;
        }

        public double this[int index] {
            get {
                switch(index) {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    case 2:
                        return Z;
                    default:
                        throw new IndexOutOfRangeException(String.Format("0 <= index < 3, but got {0}", index));
                }
            }
        }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public double V0 => Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector3 Normalized => this / V0;

        public override int GetHashCode() {
            return 73 * X.GetHashCode() + 101 * Y.GetHashCode() + 139 * Z.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (!(obj is Vector3)) {
                return false;
            }

            return Equals((Vector3)obj);
        }

        public bool Equals(Vector3 v) {
            return X == v.X && Y == v.Y && Z == v.Z;
        }

        public static bool operator ==(Vector3 first, Vector3 second) {
            return first.Equals(second);
        }

        public static bool operator !=(Vector3 first, Vector3 second) {
            return !(first == second);
        }

        public static Vector3 operator +(Vector3 first, Vector3 second) {
            return new Vector3(first.X + second.X, first.Y + second.Y, first.Z + second.Z);
        }

        public static Vector3 operator -(Vector3 first, Vector3 second) {
            return new Vector3(first.X - second.X, first.Y - second.Y, first.Z - second.Z);
        }

        public static Vector3 operator *(Vector3 vector, double scalar) {
            return new Vector3(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
        }

        public static Vector3 operator *(double scalar, Vector3 vector) {
            return vector * scalar;
        }

        public static Vector3 operator /(Vector3 vector, double scalar) {
            return new Vector3(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);
        }

        public static double operator *(Vector3 first, Vector3 second) {
            return first.X * second.X + first.Y * second.Y + first.Z * second.Z;
        }

        public static Vector3 operator ^(Vector3 first, Vector3 second) {
            return new Vector3(first.Y * second.Z - first.Z * second.Y,
                               first.Z * second.X - first.X * second.Z,
                               first.X * second.Y - first.Y * second.X);
        }

        public static double operator *(Vector3 first, CoVector3 second) {
            return first * (Vector3)second;
        }

        public static Matrix3x3 operator *(CoVector3 first, Vector3 second) {
            return new Matrix3x3(first.X * second, first.Y * second, first.Z * second);
        }

        public static explicit operator CoVector3(Vector3 v) {
            return new CoVector3(v.X, v.Y, v.Z);
        }

        public static Vector3 UnsafeConvert(double[] values) {
            return new Vector3(values[0], values[1], values[2]);
        }

        public override string ToString() {
            return string.Format("x: {0}, y: {1}, z: {2}", X, Y, Z);
        }
    }
}
