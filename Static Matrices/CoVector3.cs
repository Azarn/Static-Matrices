using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Matrices {
    public struct CoVector3 {
        private double[] v;

        public CoVector3(double x, double y, double z) {
            v = new double[3] { x, y, z };
        }

        public double this[int index] => v[index];
        public double X => v[0];
        public double Y => v[1];
        public double Z => v[2];

        public double V0 => Math.Sqrt(X * X + Y * Y + Z * Z);

        public CoVector3 Normalized => this / V0;

        public override int GetHashCode() {
            return 67 * X.GetHashCode() + 107 * Y.GetHashCode() + 149 * Z.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (!(obj is CoVector3)) {
                return false;
            }

            return Equals((CoVector3)obj);
        }

        public bool Equals(CoVector3 v) {
            return X == v.X && Y == v.Y && Z == v.Z;
        }

        public static bool operator ==(CoVector3 first, CoVector3 second) {
            return first.Equals(second);
        }

        public static bool operator !=(CoVector3 first, CoVector3 second) {
            return !(first == second);
        }

        public static CoVector3 operator +(CoVector3 first, CoVector3 second) {
            return new CoVector3(first.X + second.X, first.Y + second.Y, first.Z + second.Z);
        }

        public static CoVector3 operator -(CoVector3 first, CoVector3 second) {
            return new CoVector3(first.X - second.X, first.Y - second.Y, first.Z - second.Z);
        }

        public static CoVector3 operator *(CoVector3 covector, double scalar) {
            return new CoVector3(covector.X * scalar, covector.Y * scalar, covector.Z * scalar);
        }

        public static CoVector3 operator *(double scalar, CoVector3 covector) {
            return covector * scalar;
        }

        public static CoVector3 operator /(CoVector3 covector, double scalar) {
            return new CoVector3(covector.X / scalar, covector.Y / scalar, covector.Z / scalar);
        }

        public static double operator *(CoVector3 first, CoVector3 second) {
            return first.X * second.X + first.Y * second.Y + first.Z * second.Z;
        }

        public static CoVector3 operator ^(CoVector3 first, CoVector3 second) {
            return new CoVector3(first.Y * second.Z - first.Z * second.Y,
                                 first.Z * second.X - first.X * second.Z,
                                 first.X * second.Y - first.Y * second.X);
        }

        public static explicit operator Vector3(CoVector3 v) {
            return new Vector3(v.X, v.Y, v.Z);
        }

        public static CoVector3 UnsafeConvert(double[] values) {
            return new CoVector3(values[0], values[1], values[2]);
        }

        public override string ToString() {
            return string.Format("x: {0}, y: {1}, z: {2}", X, Y, Z);
        }
    }
}
