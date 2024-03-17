namespace Omegahash.Attributes
{
    [AttributeUsage(AttributeTargets.Struct, Inherited = false)]
    public class BsonCollectionAttribute(string collectionName) : Attribute
    {
        private readonly string _collectionName = collectionName;

        public string CollectionName => _collectionName;
    }
}
