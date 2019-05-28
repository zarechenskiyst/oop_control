using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_control
{
    class Program
    {
        class File
        {
            protected string Name;
            protected string Size;
            protected virtual string Extention { get; set; }
            public File()
            {
                Name = "";
                Size = "";
            }

            public File(string[] str)
            {
                Name = str[1];
                Size = str[2];
            }

            public override string ToString()
            {
                return $" Name: {Name}, size: {Size}";
            }

        }

        class TextFile : File
        {
            string Contents;

            public TextFile()
            {
                Contents = "";
                Extention = "txt";
            }

            public TextFile(string[] parseString) : base(parseString)
            {
                Contents = parseString[3];
                Extention = "txt";
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(base.ToString()).Append($" , Extention: {Extention}, Contents: {Contents}");
                return sb.ToString();
            }

        }

        class Movie : Image
        {
            string Length;

            public Movie(string[] parseString) : base(parseString)
            {
                Length = parseString[4];
                Extention = "mkv";
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(base.ToString()).Append($" , Length: {Length}");
                return sb.ToString();
            }

        }

        class Image : File
        {
            protected string Resolution;

            public Image(string[] parseString) : base(parseString)
            {
                Resolution = parseString[3];
                Extention = "img";
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(base.ToString()).Append($" , Extention: {Extention}, Resolution: {Resolution}");
                return sb.ToString();
            }

        }


        public static string[] ParseToArr(string line)
        {
            return line.Split(new char[] { '(', ')', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

        }
        static void Main(string[] args)
        {
            String text = @"Text: file.txt(6B); Some string content
Image: img.bmp(19MB); 1920х1080
  Text:data.txt(12B); Another string
   Text:data1.txt(7B); Yet another string
    Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";

            string[] arr = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            List<object> list = new List<object>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Contains("Text"))
                {
                    list.Add(new TextFile(ParseToArr(arr[i])));
                }
                else if (arr[i].Contains("Image"))
                {
                    list.Add(new Image(ParseToArr(arr[i])));
                }
                else if (arr[i].Contains("Movie"))
                {
                    list.Add(new Movie(ParseToArr(arr[i])));
                }

            }

            foreach (var e in list)
                Console.WriteLine(e.ToString());
        }
    }
}
