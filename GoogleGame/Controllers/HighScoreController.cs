using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoogleGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighScoreController : ControllerBase
    {
    //    private string MyConnectionString { get;}
    //    public DbSet<Blog> Blog { get; set; }
    //    public DbSet<Post> Post { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlServer(ConectionString);
    //    }
    //    public void HighScoreRequest()
    //    {
    //        try
    //        {
    //            Queries().Wait();
    //        }
    //        catch (Exception e)
    //        {
    //            System.Console.WriteLine(e);
    //            throw;
    //        }
    //    }

    //    static async Task Queries()
    //    {
    //        var connStr = MyConnectionString;
    //        var conn = new SqlConnection(connStr);

    //        var readMany = @"SELECT *
    //                        FROM Db.PhotoGame";
    //    }
    }
}