using System.Windows;

namespace SimpleUIPong
{
    public class Utils
    {
        public static double DotProduct(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
    }
}