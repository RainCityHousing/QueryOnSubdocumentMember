// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

public class MyDbContext : DbContext
{
    public DbSet<NestedDocumentTest> NestedDocumentTest { get; init; }


    public static MyDbContext Create(IMongoDatabase database) =>
        new(new DbContextOptionsBuilder<MyDbContext>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            .Options);
    public MyDbContext(DbContextOptions options)
        : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<NestedDocumentTest>(x=>{
            x.ToCollection("NestedDocumentTest");
            x.OwnsOne<NestedDocumentTest.Item>("NestedItem");
        });

    }
}
