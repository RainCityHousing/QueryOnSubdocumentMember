// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Bson;


Console.WriteLine("Hello, World!");

var dbSecret = "Username:Password";
var connectionStr = string.Format("YourConnectionString", dbSecret);

var client = new MongoClient(connectionStr);

MyDbContext db = MyDbContext.Create(client.GetDatabase("efdemo"));

db.NestedDocumentTest.Add(new NestedDocumentTest()
{
    _id = ObjectId.GenerateNewId(),
    Name = "Nested Nancy",
    NestedItem = new NestedDocumentTest.Item(){
        item1 = 1,
        item2 = "2"
    }
});
db.SaveChanges();

//TODO check to see if we can work around issue by adding _id ObjectID to subdocument
Console.WriteLine(db.NestedDocumentTest.Where(x => x.NestedItem.item1 == 1).ToJson().ToString());
