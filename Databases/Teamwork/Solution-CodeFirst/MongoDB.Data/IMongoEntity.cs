using MongoDB.Driver;

namespace MongoDB.Data
{
    public interface IMongoEntity
    {
        string _id { get; set; }
        Oid GetOid();

        Document GetAsDocument();
        void UpdateFromDocument(Document document);
    }
}