using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Numerics;
using System.Runtime.CompilerServices;
using ColorHelper;
using ColorConverter = ColorHelper.ColorConverter;

namespace Mandelbrot_set
{
    public partial class Form1 : Form
    {
        private Bitmap Image;
        private Bitmap SecondImage;
        private int height;
        private int width;
        private int iterations;
        private Color[,] imagePixels;
        public Form1()
        {
            InitializeComponent();
            Image = new Bitmap(1000,1000);
            height = Image.Height;
            width = Image.Width;
            imagePixels = new Color[width,height];
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Image, 0,0);
        }
        private void AnimationJulia()
        {
            for (int pos = -width/8; pos < width/2; pos+=1)
            {
                CalculateJulia(pos,pos);
            }
        }
        private void CalculateSet()
        {
            var zoom = (double) ScaleFactor.Value;
            var Xscale = XScale.Value;
            var threads = 24;
            Parallel.For(0, threads, (i, state) =>
            {
                var yStart = width / threads * i;
                var yEnd = width / threads * (i + 1);
                for (int y = yStart; y < yEnd; y++)
                {
                    for (int x = 0; x < height; x++)
                    {
                        var moveLeft =(int) (Xscale * (decimal) zoom) * 100;
                        var scale = 2 / zoom;
                        
                        var point = coordFromPixelLocation(
                            x-(moveLeft),y,-scale,scale,-scale,scale);
                        var result = GetPixelInSet(new Complex(0,0), new Complex(point.x,point.y));
                        
                        if (result == -1)
                        {
                            imagePixels[x, y] = Color.Black;
                        }
                        else
                        {
                            var hueValue = (int) ((100 * result) / NumberOfIterations.Value);
                            RGB rgb = ColorConverter.HslToRgb(new HSL(hueValue, 255,50));
                            imagePixels[x, y] = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                        }
                    }
                }
            });
            DrawSet();
            Refresh(); 
        }
        private void CalculateJulia(int X, int Y)
        {
            var zoom = (double) ScaleFactor.Value;
            var Xscale = XScale.Value;
            Parallel.For(0, 24, (i, state) =>
            {
                var yStart = width / 24 * i;
                var yEnd = width / 24 * (i + 1);
                for (int y = yStart; y < yEnd; y++)
                {
                    for (int x = 0; x < height; x++)
                    {
                        var moveLeft =(int) (Xscale * (decimal) zoom) * 100;
                        var scale = 2 / zoom;

                        var point = coordFromPixelLocation(x-(moveLeft),y,-scale,scale,-scale,scale);
                        var pointC = coordFromPixelLocation(X-(moveLeft),Y,-scale,scale,-scale,scale);
                        
                        var result = GetPixelInSet(new Complex(point.x,point.y), new Complex(pointC.x,pointC.y));
                        
                        if (result == -1)
                        {
                            imagePixels[x, y] = Color.Black;
                        }
                        else
                        {
                            var hueValue = (int) ((100 * result) / NumberOfIterations.Value);
                            RGB rgb = ColorConverter.HslToRgb(new HSL(hueValue, 255,50));
                            imagePixels[x, y] = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                        }
                    }
                }
            });
            DrawSet();
            Refresh(); 
        }
        private void DrawSet()
        {
            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    Image.SetPixel(x,y,imagePixels[x,y]);
                }
            }
        }
        private int GetPixelInSet(Complex Z, Complex C)
        {
            var n = 0;
            while (Z.Modulus() <= 2 && n < iterations)
            {
                Z = Pow(Z, 2) + C;
                n++;
            }
            return Z.Modulus() > 2 ? n : -1;
        }
        private Point2d coordFromPixelLocation (decimal pixelX,int pixelY,double minCoordX, double maxCoordX,double minCoordY,double maxCoordY)
        {
            var xPercent = (float) pixelX / width;
            var yPercent = (float) pixelY / height;

            var newX = minCoordX + (maxCoordX - minCoordX) * xPercent;
            var newY = minCoordY + (maxCoordY - minCoordY) * yPercent;

            return new Point2d (newX, newY);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            iterations = (int) NumberOfIterations.Value;
            CalculateSet();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            CalculateJulia(e.X,e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "X=" + e.X + " | Y=" + e.Y;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnimationJulia();
        }
        
        private Complex Pow(Complex a, float n)
        {
            var originalA = a;
            for (int i = 0; i < n - 1; i++)
            {
                a = a * originalA;
            }
            return a;
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
            output.real = (two.real * one.real) + ((two.imaginary * one.imaginary) * -1);
            output.imaginary = (two.real * one.imaginary) + (two.imaginary * one.real);
            return output;
        }
        public double Modulus() => Math.Sqrt((real * real)+(imaginary * imaginary));
    }
}