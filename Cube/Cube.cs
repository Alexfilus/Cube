using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Cube
{
    /// <summary>
    ///  Класс выводит 3D куб
    /// </summary>
    class Cube:Object
    {
        private Point3DF[] Vertex = new Point3DF[8];
        private static int width, height;
        private static double maxX, maxY, minX, minY;

        private Cube()
        {
            /*Vertex[0] = new Point3DF(0, 0, 0);
            Vertex[1] = new Point3DF(1, 0, 0);
            Vertex[2] = new Point3DF(1, 1, 0);
            Vertex[3] = new Point3DF(0, 1, 0);
            Vertex[4] = new Point3DF(0, 0, 1);
            Vertex[5] = new Point3DF(1, 0, 1);
            Vertex[6] = new Point3DF(1, 1, 1);
            Vertex[7] = new Point3DF(0, 1, 1);*/
            for (int i = 0; i < Vertex.Length; i++)
                Vertex[i] = new Point3DF(i % 2, i / 2 % 2, i / 4 % 2);
            maxX = 1.8;
            maxY = 1.8;
            minY = -1.8;
            minX = -1.8;
        }

        private Point3DF this[int index]
        {
            get
            {
                return Vertex[index];
            }
            set
            {
                Vertex[index] = value;
            }
        }

        private static int transX(double x)
        {
            return (int)((x - minX) / (maxX - minX) * width);
        }
        private static int transY(double y)
        {
            return (int)((maxY - y) / (maxY - minY) * height);
        }

        /// <summary>
        /// Процедура для отрисовки
        /// </summary>
        /// <param name="G">Объект на котором будем рисовать преобразованный в <c>Graphics</c></param>
        /// <param name="alpha">Угол поворота вокруг оси Ox</param>
        /// <param name="beta">Угол поворота вокруг оси Oy</param>
        /// <param name="gamma">Угол поворота вокруг оси Oz</param>
        /// <param name="sigma">Угол поворота вокруг вектора заданного <c>Vect</c></param>
        /// <param name="axis1">Ось абсцисс</param>
        /// <param name="axis2">Ось ординат</param>
        /// <param name="Vect">Произвольный целоцисленный вектор вокруг которого куб вращается на угол <c>Sigma</c></param>
        /// <param name="line_width">Толщина линий</param>
        /// <param name="showVect">Показывать ли вектор Vect</param>
        public static void DrawCube(Graphics G, Point3D Vect, Size size, int alpha = 30, int beta = 45, int gamma = 0, int sigma = 0, int axis1 = 0, int axis2 = 2, bool showVect = false, float line_width = 3, int Width = -1, int Height = -1)
        {
            Cube temp = new Cube();
            if ((size.Width == -1) && (size.Height == -1))
            {
                width = (int)G.VisibleClipBounds.Size.Width;
                height = (int)G.VisibleClipBounds.Size.Height;
            }
            else
            {
                width = size.Width;
                height = size.Height;
            }
            for (int i = 0; i < temp.Vertex.Length; i++)
            {
                temp[i] = temp[i] * MyMatrix.Tx(alpha);
                temp[i] = temp[i] * MyMatrix.Ty(beta);
                temp[i] = temp[i] * MyMatrix.Tz(gamma);
                temp[i] = temp[i] * MyMatrix.Tw(sigma, Vect);
            }
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            if (showVect) g.DrawLine(new Pen(Color.Yellow, line_width), transX(0), transY(0), transX(Vect[axis1]), transY(Vect[axis2]));
            for (int i = 0; i < 4; i++)
            {
                int num = (i == 3) ? i : i - i % 2;
                g.DrawLine(new Pen(Color.Blue, line_width), transX(temp[num][axis1]), transY(temp[num][axis2]), transX(temp[(i == 3) ? 1 : i + 1][axis1]), transY(temp[(i == 3) ? 1 : i + 1][axis2]));
                g.DrawLine(new Pen(Color.Green, line_width), transX(temp[i][axis1]), transY(temp[i][axis2]), transX(temp[i + 4][axis1]), transY(temp[i + 4][axis2]));
                g.DrawLine(new Pen(Color.Red, line_width), transX(temp[num + 4][axis1]), transY(temp[num + 4][axis2]), transX(temp[(i == 3) ? 5 : i + 5][axis1]), transY(temp[(i == 3) ? 5 : i + 5][axis2]));
            }
            g.Dispose();
            G.DrawImage(bmp, new Point(0, 0));
            G.Dispose();
            bmp.Dispose();
        }
        public static void DrawCube(Graphics G, Point3D Vect, int alpha = 30, int beta = 45, int gamma = 0, int sigma = 0, int axis1 = 0, int axis2 = 2, bool showVect = false, float line_width = 3, int Width = -1, int Height = -1)
        {
            DrawCube(G,Vect,new Size(Width,Height),alpha,beta,gamma,sigma,axis1,axis2,showVect,line_width);
        }
    }
}
