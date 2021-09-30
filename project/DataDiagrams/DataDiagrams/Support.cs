using System;
using System.IO;

namespace DataDiagrams
{
    public class Support
    {

        private static readonly Config config = new Config();

        /// <summary>
        /// Given a filename and the number of bytes to read, returns a byte array
        /// containing the first n bytes from the file.
        /// </summary>
        /// <param name="filename">The file to read from</param>
        /// <param name="n">The number of bytes to read</param>
        /// <returns>An array of bytes</returns>
        public static byte[] ReadBytes(String filename, int n)
        {
            filename = config.GetTestDirectory() + filename;
            if (!File.Exists(filename))
            {
                throw new IOException($"The filespecified \"{filename}\" does not exists");
            }
            FileStream reader = new FileStream(filename, FileMode.Open);

            byte[] data = new byte[n];
            for (int ix = 0; ix < n; ix++)
            {
                int d = reader.ReadByte();
                if (d == -1)
                {
                    throw new EndOfStreamException($"The end of the file has been reached. Read {ix} bytes but expected {n}.");
                }
                data[ix] = (byte)d;
            }
            reader.Close();
            return data;
        }

        /// <summary>
        /// Copies a subset of bytes from the specified byte array, data,
        /// into a new byte array. The first byte copied is specefied by
        /// startIx and the number of bytes to copy is specified by length.
        /// <example> Example:
        /// <code>
        /// byte[] data = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 };
        /// byte[] subdata = Support.GetBytes(data, 2, 2);
        /// Console.WriteLine(Support.ToHex(subdata));
        /// </code>
        /// Writes: "0x0304"
        /// </example>
        /// </summary>
        /// <param name="data">The bytes to copy</param>
        /// <param name="startIx">The first byte to copy</param>
        /// <param name="length">The number of bytes to copy</param>
        /// <returns>A subset of the bytes from the specified byte array</returns>
        public static byte[] GetBytes(byte[] data, int startIx, int length)
        {
            byte[] subarray = new byte[length];
            for (int ix = 0; ix < length; ix++)
            {
                subarray[ix] = data[ix + startIx];
            }
            return subarray;
        }

        /// <summary>
        /// Given a byte, data, returns the highest order nibble (4-bits).
        /// </summary>
        /// <param name="data">The byte to examine</param>
        /// <returns>a 4-bit number</returns>
        public static byte GetTopNibble(byte data)
        {
            return (byte)(data >> 4);
        }

        /// <summary>
        /// Given a byte, data, returns the lowest order nibble (4-bits).
        /// </summary>
        /// <param name="data">The byte to examine</param>
        /// <returns>A 4-bit number</returns>
        public static byte GetBottomNibble(byte data)
        {
            return (byte)(data & 0x0F);
        }

        /// <summary>
        /// Given a byte, returns a hexadecimal string representing its value
        /// </summary>
        /// <param name="data">The byte to examine</param>
        /// <returns>A string containing a hexadecimal value</returns>
        public static String ToHex(byte data)
        {
            return "0x" + data.ToString("X2");
        }

        /// <summary>
        /// Given an array of bytes, returns a hexadecimal string representing its values
        /// </summary>
        /// <param name="data">The data to examine</param>
        /// <returns>A hexadecimal representation of the data</returns>
        public static String ToHex(byte[] data)
        {
            String hex = "";
            foreach(byte b in data) {
                hex += b.ToString("x2");
            }
            return "0x";
        }
    }
}
