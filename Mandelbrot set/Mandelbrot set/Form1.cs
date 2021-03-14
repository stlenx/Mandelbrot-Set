using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Mandelbrot_set
{
    public partial class Form1 : Form
    {
        private Bitmap Image;
        private int iterations = 1000;
        public Form1()
        {
            InitializeComponent();
            Image = new Bitmap(1000,1000);
        }

        private int GetPixelInSet(double x, double y)
        {
            var Z = new Complex(0d,0d);
            var C = new Complex(x,y);
            
            var n = 0;
            while (Z.Modulus() <= 2 && n < iterations)
            {
                Z = (Z * Z) + C;
                n++;
            }
            return Z.Modulus() > 2 ? 0 : 1;
        }
        
        private Point2d coordFromPixelLocation (int pixelX,int pixelY,double minCoordX, double maxCoordX,double minCoordY,double maxCoordY)
        {
            var xPercent = (float) pixelX / Image.Width;
            var yPercent = (float) pixelY / Image.Height;

            var newX = minCoordX + (maxCoordX - minCoordX) * xPercent;
            var newY = minCoordY + (maxCoordY - minCoordY) * yPercent;

            return new Point2d (newX, newY);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            var g = Graphics.FromImage(Image);
            
            for (int y = 0; y < Image.Width; y++)
            {
                for (int x = 0; x < Image.Height; x++)
                {
                    var point = coordFromPixelLocation(x,y,-0,0.5,-0.5,0);
                    var test = GetPixelInSet(point.x, point.y);
                    if (test == 0)
                    {
                        g.DrawRectangle(Pens.White, new Rectangle(x,y,1,1));
                    }
                    else
                    {
                        g.DrawRectangle(Pens.Black, new Rectangle(x,y,1,1));
                    }
                }
            }
            e.Graphics.DrawImage(Image, 0,0);
        }
    }

    public struct Point2d
    {
        public double x;
        public double y;

        public Point2d(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public struct Complex {
        public double real;
        public double imaginary;
        public Complex(double real, double imaginary) 
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        
        public static Complex operator +(Complex one, Complex two) => new Complex(one.real + two.real, one.imaginary + two.imaginary);

        public static Complex operator *(Complex one, Complex two)
        {
            Complex output = new Complex();
            output.real = (two.real * one.real) + ((two.imaginary * one.imaginary) * - 1);
            output.imaginary = (two.real * one.imaginary) + (two.imaginary * one.real);
            return output;
        }

        public double Modulus() => Math.Sqrt((real * real)+(imaginary * imaginary));
    }
}