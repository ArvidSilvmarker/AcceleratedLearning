using System;

namespace Modul6
{
    class BlogPost
    {
        public string Header { get; set; }
        public DateTime PostedDate { get; set; }

        public BlogPost(string header)
        {
            Header = header;
            PostedDate = DateTime.Now;
        }
        public BlogPost(string header, DateTime postedDate)
        {
            Header = header;
            PostedDate = postedDate;
        }

        public void WriteHeader()
        {
            Console.WriteLine($"Bloggpostens har rubrik {Header}, och postades {PostedDate}");
        }

        public string TillSträng()
        {
            return $"En bloggpost med rubrik {Header}";
        }

        public override string ToString()
        {
            return $"En bloggpost med rubrik {Header}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //var b1 = new BlogPost("Min rubrik", new DateTime(2018, 03, 19));
            //var b2 = new BlogPost("Min andra rubrik");
            //b1.WriteHeader();
            //b2.WriteHeader();

            //Console.WriteLine(b1.ToString());

            var modul = new ElevatorProgram();
            modul.Run();
        }
    }
}
