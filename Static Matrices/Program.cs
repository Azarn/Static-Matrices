using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Matrices {
    class Program {
        static void Main(string[] args) {
            Vector3 v = new Vector3(1, 2, 3);
            Console.WriteLine(v);

            Matrix3x3 m = new Matrix3x3(1, 2, 3, 13, 17, 19, 8, 16, 32);
            Console.WriteLine("Det: {0}", m.Det);
            Console.WriteLine("Norm: {0}", m.Norm);
            Console.WriteLine("Transposed det: {0}", m.Transposed.Det);
            Console.WriteLine("Inversed det: {0}", m.Inversed.Det);
            Console.WriteLine("Trace: {0}", m.Trace);
            Console.WriteLine("Symmetrized det: {0}", m.Symmetrized.Det);
            Console.WriteLine("Asymmetrized det: {0}", m.Asymmetrized.Det);

            Console.WriteLine("Squared det: {0}", (m * m).Det);
        }
    }
}
