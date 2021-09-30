using System;
using System.IO;

namespace DataDiagrams
{
    public class ByteReader
    {

        private FileStream reader;

        public ByteReader(String filename)
        {
            if (!File.Exists(filename))
            {
                    throw new IOException($"The filespecified \"{filename}\" does not exists");
            }
            reader = new FileStream(filename, FileMode.Open);

        }

        public byte[] ReadBytes(int length)
        {
            byte[] data = new byte[length];
            for(int ix = 0; ix < length; ix++)
            {
                int d = reader.ReadByte();
                if(d == -1)
                {
                    throw new EndOfStreamException($"The end of the file has been reached. Read {ix} bytes but expected {length}.");
                }
                data[ix] = (byte)d;
            }
            return data;
        }

    }

}
