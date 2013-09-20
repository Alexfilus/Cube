using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cube
{
    public class MyMatrix
    {
        private double[,] _A = new double[3, 3];
        public MyMatrix()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    _A[i, j] = i == j ? 1 : 0;
        }
        public double this[int index1, int index2]
        {
            get { return _A[index1, index2]; }
            set { _A[index1, index2] = value; }
        }
        public static MyMatrix Tx(int angle)
        {
            double Angle = Math.PI / 180 * angle;
            MyMatrix Res = new MyMatrix();
            Res[1, 1] = Math.Cos(Angle);
            Res[1, 2] = Math.Sin(Angle);
            Res[2, 1] = -Math.Sin(Angle);
            Res[2, 2] = Math.Cos(Angle);
            return Res;
        }
        public static MyMatrix Ty(int angle)
        {
            double Angle = Math.PI / 180 * angle;
            MyMatrix Res = new MyMatrix();
            Res[0, 0] = Math.Cos(Angle);
            Res[0, 2] = Math.Sin(Angle);
            Res[2, 0] = -Math.Sin(Angle);
            Res[2, 2] = Math.Cos(Angle);
            return Res;
        }
        public static MyMatrix Tz(int angle)
        {
            double Angle = Math.PI / 180 * angle;
            MyMatrix Res = new MyMatrix();
            Res[0, 0] = Math.Cos(Angle);
            Res[0, 1] = Math.Sin(Angle);
            Res[1, 0] = -Math.Sin(Angle);
            Res[1, 1] = Math.Cos(Angle);
            return Res;
        }

        public static MyMatrix Tw(int angle, Point3D Vect)
        {
            double Angle = Math.PI / 180 * angle;
            MyMatrix Res = new MyMatrix();
            Point3DF UVect = new Point3DF(Vect.X / Vect.Norm(), Vect.Y / Vect.Norm(), Vect.Z / Vect.Norm());

            Res[0, 0] = UVect.X * UVect.X + (1 - UVect.X * UVect.X) * Math.Cos(Angle);
            Res[0, 1] = UVect.X * UVect.Y * (1 - Math.Cos(Angle)) + UVect.Z * Math.Sin(Angle);
            Res[0, 2] = UVect.X * UVect.Z * (1 - Math.Cos(Angle)) - UVect.Y * Math.Sin(Angle);

            Res[1, 0] = UVect.X * UVect.Y * (1 - Math.Cos(Angle)) - UVect.Z * Math.Sin(Angle);
            Res[1, 1] = UVect.Y * UVect.Y + (1 - UVect.Y * UVect.Y) * Math.Cos(Angle);
            Res[1, 2] = UVect.Y * UVect.Z * (1 - Math.Cos(Angle)) + UVect.X * Math.Sin(Angle);

            Res[2, 0] = UVect.X * UVect.Z * (1 - Math.Cos(Angle)) + UVect.Y * Math.Sin(Angle);
            Res[2, 1] = UVect.Y * UVect.Z * (1 - Math.Cos(Angle)) - UVect.X * Math.Sin(Angle);
            Res[2, 2] = UVect.Z * UVect.Z + (1 - UVect.Z * UVect.Z) * Math.Cos(Angle);

            return Res;
        }
        public static MyMatrix Tw(int angle, Point3DF Vect)
        {
            double Angle = Math.PI / 180 * angle;
            MyMatrix Res = new MyMatrix();
            Point3DF UVect = new Point3DF(Vect.X / Vect.Norm(), Vect.Y / Vect.Norm(), Vect.Z / Vect.Norm());

            Res[0, 0] = UVect.X * UVect.X + (1 - UVect.X * UVect.X) * Math.Cos(Angle);
            Res[0, 1] = UVect.X * UVect.Y * (1 - Math.Cos(Angle)) + UVect.Z * Math.Sin(Angle);
            Res[0, 2] = UVect.X * UVect.Z * (1 - Math.Cos(Angle)) - UVect.Y * Math.Sin(Angle);

            Res[1, 0] = UVect.X * UVect.Y * (1 - Math.Cos(Angle)) - UVect.Z * Math.Sin(Angle);
            Res[1, 1] = UVect.Y * UVect.Y + (1 - UVect.Y * UVect.Y) * Math.Cos(Angle);
            Res[1, 2] = UVect.Y * UVect.Z * (1 - Math.Cos(Angle)) + UVect.X * Math.Sin(Angle);

            Res[2, 0] = UVect.X * UVect.Z * (1 - Math.Cos(Angle)) + UVect.Y * Math.Sin(Angle);
            Res[2, 1] = UVect.Y * UVect.Z * (1 - Math.Cos(Angle)) - UVect.X * Math.Sin(Angle);
            Res[2, 2] = UVect.Z * UVect.Z + (1 - UVect.Z * UVect.Z) * Math.Cos(Angle);

            return Res;
        }
    }
}
