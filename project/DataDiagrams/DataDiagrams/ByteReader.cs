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

        public byte ReadByte()
        {
            int data = reader.ReadByte();
            if(data == -1)
            {
                throw new EndOfStreamException("The end of the file has been reached.");
            }
            return (byte)data;
        }

    }

}
