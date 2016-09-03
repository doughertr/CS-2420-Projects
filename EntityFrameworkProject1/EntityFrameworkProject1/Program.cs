using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFrameworkProject1
{

    public class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    class MeContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }

    class MainClass
    {
        static void Main()
        {
            var video = new Video
            {
                Title = "Hello World",
                Description = "..."
            };
            var meContext = new MeContext();
            meContext.Videos.Add(video);
            meContext.SaveChanges();
            Video meVideo = meContext.Videos.First();
            Console.WriteLine(meVideo.ID);
            Console.WriteLine(meVideo.Title);
            Console.WriteLine(meVideo.Description);
        }
    }
}
