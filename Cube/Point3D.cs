using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cube
{
    public class MyPoint3D<T>
    {
        public T X, Y, Z;
    }
    public class Point3D:MyPoint3D<int>
    {
        public Point3D(int x = 0, int y = 0, int z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public static Point3D operator +(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }
        public static Point3D operator *(Point3D p, MyMatrix M)
        {
            Point3D Res = new Point3D();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Res[i] += (int)(M[i, j] * p[j]);
           /* Res.X = (int)(M[0, 0] * p.X + M[0, 1] * p.Y + M[0, 2] * p.Z);
            Res.Y = (int)(M[1, 0] * p.X + M[1, 1] * p.Y + M[1, 2] * p.Z);
            Res.Z = (int)(M[2, 0] * p.X + M[2, 1] * p.Y + M[2, 2] * p.Z);*/
            
            return Res;
        }
        public double Norm()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return X;
                    case 1: return Y;
                    case 2: return Z;
                    default: return 0;
                }
            }
            set
            {
                switch (index)
                {
                    case 0: X = value; break; 
                    case 1: Y = value; break; 
                    case 2: Z = value; break; 
                    default: break;
                }
            }
        }
    }
    public class Point3DF: MyPoint3D<double>
    {
        public Point3DF(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public static Point3DF operator +(Point3DF p1, Point3DF p2)
        {
            return new Point3DF(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }
       public static Point3DF operator *(Point3DF p, MyMatrix M)
        {
            Point3DF Res = new Point3DF();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Res[i] += M[i, j] * p[j];
            /*Res.X = M[0, 0] * p.X + M[0, 1] * p.Y + M[0, 2] * p.Z;
            Res.Y = M[1, 0] * p.X + M[1, 1] * p.Y + M[1, 2] * p.Z;
            Res.Z = M[2, 0] * p.X + M[2, 1] * p.Y + M[2, 2] * p.Z;*/
            return Res;
        }
       
        public double Norm()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }
        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return X;
                    case 1: return Y;
                    case 2: return Z;
                    default: return 0;
                }
            }

            set
            {
                switch (index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    case 2: Z = value; break;
                    default: break;
                }
            }
        }
    }

}
