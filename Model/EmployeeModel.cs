using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace SampleAngularAPI.Model
{
    public class EmployeeModel
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }

        private DateTime? createdDateTimeUtc;
        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? CreatedDateTimeUtc
        {
            get
            {
                if (createdDateTimeUtc != null)
                {
                    return DateTime.Parse(createdDateTimeUtc.Value.ToString("MM/dd/yyyy HH:mm:ss"));
                }
                return createdDateTimeUtc;
            }
            set
            {
                createdDateTimeUtc = value;
            }
        }
    }
}
