namespace JSONPlaceholderTest.Models
{
    public class UserDataModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }

        public class Address
        {
            public string street { get; set; }
            public string suite { get; set; }
            public string city { get; set; }
            public string zipcode { get; set; }
            public Geo geo { get; set; }

            public class Geo
            {
                public string lat { get; set; }
                public string lng { get; set; }
            }
        }

        public class Company
        {
            public string name { get; set; }
            public string catchPhrase { get; set; }
            public string bs { get; set; }
        }

        public bool IsEqual(UserDataModel other)
        {            
            if (this.id == other.id && this.name == other.name && this.username == other.username && this.email == other.email 
                && this.address.street == other.address.street && this.address.suite == other.address.suite
                && this.address.city == other.address.city && this.address.zipcode == other.address.zipcode
                && this.address.geo.lat == other.address.geo.lat && this.address.geo.lng == other.address.geo.lng
                && this.phone == other.phone && this.website == other.website && this.company.name == other.company.name
                && this.company.catchPhrase == other.company.catchPhrase && this.company.bs == other.company.bs)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }    
}
