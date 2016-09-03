using System;
using System.Data.Entity;

public class Video
{
    public int ID { get; set; }
	public string Title { get; set; }
    public string Description { get; set; }
}

class MeContext : DbContext
{
    public MeContext() : base(@"Data Source =(local)\MYINSTANCE;Initial Catalog=MyTestDb;Integrated Security=True")
    {
           
    }
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
    }
}
