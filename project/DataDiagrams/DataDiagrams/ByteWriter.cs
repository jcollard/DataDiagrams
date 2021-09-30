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
                } else
                {
                    Console.WriteLine($"Deleting \"${filename}\".");
                    File.Delete(filename);
                }
            } 
            writer = new FileStream(filename, FileMode.Create);
            
        }

        public bool WriteByte(String byteString)
        {
            if(byteString.Length != 2)
            {
                throw new ArgumentException($"\"{byteString}\" is an invalid byte string.");
            }
            writer.WriteByte(7);
            writer.Flush();
            return true;
        }

    }
}
