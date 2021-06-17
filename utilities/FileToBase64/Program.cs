using System;
using System.IO;

namespace FileToBase64
{
    class Program
    {
        static void Main(string[] args)
        {


            try
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("Usage: FileToBase64.exe [sourcefle] [destionationfile]" +
                        "\n\n" +
                        "Example: FileToBase64.exe c:\\image.png c:\\imagebase64.txt");
                    return;
                }

                string source = args[0];
                string dest = args[1];
                string ret = FileToBase64(source);

                if (dest.Equals("s"))
                    Console.Write(ret);
                else
                    File.WriteAllText(dest, ret);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Fail: " + ex.Message);
            }

        }

        public static string FileToBase64(string path)
        {
            Byte[] bytes = File.ReadAllBytes(path);
            String file = Convert.ToBase64String(bytes);
            return file;

        }
    }

}

