using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
//using System.Drawing;

namespace _1_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Cv2.GetVersionString());
            OpenCvSharp.Size cv_size = new OpenCvSharp.Size();
            //System.Drawing.Size draw_size = new System.Drawing.Size();

            //Mat color = new Mat(new Size(10, 10), MatType.CV_8U);
            //Mat gray = new Mat(10, 10, MatType.CV_8U);
            Mat src = Cv2.ImRead("Ref\\image.jpg");
            Mat gray = new Mat();
            Mat hist = new Mat();
            Mat result = Mat.Ones(new Size(256, src.Height), MatType.CV_8UC1);
            Mat dst = new Mat();

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.CalcHist(new Mat[] { gray }, new int[] { 0 }, null, hist, 1, new int[] { 256 }, new Rangef[] { new Rangef(0, 256) });
            Cv2.Normalize(hist, hist, 0, 255, NormTypes.MinMax);

            for (int i = 0; i < hist.Rows; i++)
            {
                Cv2.Line(result, new Point(i, src.Height), new Point(i, src.Height - hist.Get<float>(i)), Scalar.White);
            }
            Cv2.HConcat(new Mat[] { gray, result }, dst);
            //Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

            Scalar s1 = new Scalar(255, 127);
            Scalar s2 = Scalar.Yellow;
            Scalar s3 = Scalar.All(99);

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);

            Size size = new Size(640, 480);
            Mat img = new Mat(size, MatType.CV_8UC3);
            Mat img2 = new Mat(img.Size(), MatType.CV_8UC3);

            Console.WriteLine($"{size.Width}, {size.Height}");
            Console.WriteLine(img.Size());
            Console.WriteLine($"{img.Size().Width}, {img.Size().Height}");
            Console.WriteLine($"{img.Width}, {img.Height}");

            Range range = new Range(0, 100);
            Console.WriteLine($"{range.Start}, {range.End}");

            Rect rect1 = new Rect(new Point(0, 0), new Size(640, 480));
            Rect rect2 = new Rect(100, 100, 640, 480);
            Rect rect3 = rect1.Union(rect2);
            Rect rect4 = rect1.Intersect(rect2);
            Console.WriteLine(rect1);
            Console.WriteLine(rect2);
            Console.WriteLine(rect3);
            Console.WriteLine(rect4);

            Mat M = new Mat();
            M.Create(MatType.CV_8UC3, new int[] { 480, 640 });
            M.SetTo(new Scalar(255, 0, 0));

            //Cv2.ImShow("Blue screen", M);
            //Cv2.WaitKey();
            Mat m = Mat.Eye(new Size(3, 3), MatType.CV_64FC3);
            m.Set<Vec3d>(0, 0, new Vec3d(9, 99, 999));

            Console.WriteLine(m.At<double>(0, 0));

            Console.WriteLine(m.At<Vec3d>(0, 0));
            Console.WriteLine(m.At<Vec3d>(0, 0).Item0);
            Console.WriteLine(m.At<Vec3d>(0, 0).Item1);
            Console.WriteLine(m.At<Vec3d>(0, 0).Item2);
            Console.WriteLine(m.At<Point3d>(2, 2));
            Console.WriteLine(m.At<long>(2, 2));


            Mat m2 = Mat.Eye(new Size(3, 3), MatType.CV_8UC3);
            m2.Set<Vec3b>(0, 0, new Vec3b(3, 13, 23));
            m2.Set<Vec3b>(1, 1, new Vec3b(6, 16, 26));
            m2.Set<Vec3b>(2, 2, new Vec3b(9, 19, 29));


            for (int y = 0; y < m2.Rows; y++)
            {
                for(int x = 0; x < m2.Cols; x++)
                {
                    int offset = (int)m2.Step() * y + m2.ElemSize() * x;
                    byte i = Marshal.ReadByte(m2.Ptr(0) + offset + 0);
                    byte j = Marshal.ReadByte(m2.Ptr(0) + offset + 1);
                    byte k = Marshal.ReadByte(m2.Ptr(0) + offset + 2);

                    Console.WriteLine($"({x},{y},{offset}) - ({i},{j},{k})");
                }
            }

            Mat<Vec3b> mv3f = new Mat<Vec3b>(m2);
            MatIndexer<Vec3b> indexer = mv3f.GetIndexer();

            indexer[1] = new Vec3b(5, 15, 25);

            for (int y = 0; y < m2.Rows; y++)
            {
                for (int x = 0; x < m2.Cols; x++)
                {
                    int offset = (int)m2.Step() * y + m2.ElemSize() * x;

                    Console.WriteLine($"({x},{y} original) - ({m2.Get<Vec3b>(y,x).Item0},{m2.Get<Vec3b>(y, x).Item1},{m2.Get<Vec3b>(y, x).Item2})");
                    Console.WriteLine($"({x},{y} New) - ({indexer[y, x].Item0},{indexer[y, x].Item1},{indexer[y, x].Item2})");
                }
            }

            Mat m3 = new Mat();
            m3.Create(new Size(500, 500), MatType.CV_8UC3);
            m3.SetTo(new Vec3b(255, 0, 0));


            var row = m3.Row(0);
            var rowIndexer = row.GetGenericIndexer<Vec3b>();
            for(int i = 0; i < m3.Cols; i++)
            {
                rowIndexer[0, i] = new Vec3b(0, 0, 255);
            }

            var rows = m3.RowRange(1, 5);
            rows.SetTo(new Vec3b(0, 0, 0));

            Cv2.ImShow("First Screen", m3);
            Cv2.WaitKey();




        }
    }
}
