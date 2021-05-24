using System;
using System.Text;

namespace BasisTheory.net.Common.Extensions
{
    public static class ByteExtensions
    {
        public static string ToUTF8String(this byte[] bytes) => Encoding.UTF8.GetString(bytes);
        public static string ToBase64String(this byte[] bytes) => Convert.ToBase64String(bytes);

        public static byte[] ToBytes(this string value) => Encoding.UTF8.GetBytes(value);

        public static byte[] FromBase64String(this string value) => Convert.FromBase64String(value);
    }
}
