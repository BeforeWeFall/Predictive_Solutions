
namespace Predictive_Solutions
{
    class User
    {
        public int id { get; set; }

        public string lastname { get; set; }

        public string firstname { get; set; }

        public string middlename { get; set; }

        public string phone { get; set; }

        public User(int id, string lastname, string firstname, string middlename, string phone)
        {
            this.id = id;
            this.lastname = lastname;
            this.firstname = firstname;
            this.middlename = middlename;
            this.phone = phone;
        }
    }
}
