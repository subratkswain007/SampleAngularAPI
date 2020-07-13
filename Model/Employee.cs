using System;
using System.Runtime.Serialization;

namespace SampleAngularAPI.Model
{
    public class Employee
    {
        [IgnoreDataMember]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }

        private DateTime? createdDateTimeUtc;
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
