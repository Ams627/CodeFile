using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFile
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (!args.Any())
                {
                    throw new Exception("You must specify a file to encode");
                }

                var bytes = File.ReadAllBytes(args[0]);
                var newbytes = new byte[bytes.Length];
                for (int i = 0; i < bytes.Length; ++i)
                {
                    newbytes[i] = (byte)(bytes[i] ^ 0xA5);
                }

                var newFilename = args[0] + ".coded";
                File.WriteAllBytes(newFilename, newbytes);
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
