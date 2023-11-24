// See https://aka.ms/new-console-template for more information
using MongoDB.Bson;

public class NestedDocumentTest
{
    public ObjectId _id { get; set; }
    public string Name { get; set; }
    public Item NestedItem { get; set; }
    public class Item
    {
        public int item1 { get; set; }
        public string item2 { get; set; }
    }
}

