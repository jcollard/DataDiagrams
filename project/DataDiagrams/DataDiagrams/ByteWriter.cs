using System;
using System.IO;

namespace DataDiagrams
{
    public class ByteWriter
    {
        private FileStream writer;

        public ByteWriter(String filename, bool overwrite = false)
        {
            if (File.Exists(filename) && overwrite == false)
            {
                if (overwrite == false)
                {
                    throw new IOException($"The filespecified \"{filename}\" already exists.");
                }
                else
                {
                    Console.WriteLine($"Deleting \"${filename}\".");
                    File.Delete(filename);
                }
            }
            writer = new FileStream(filename, FileMode.Create);

        }

        public void WriteByte(byte toWrite)
        {
            writer.WriteByte(toWrite);
            writer.Flush();
        }
    }

}
