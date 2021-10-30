using System.Collections.Generic;

namespace Predictive_Solutions
{
    class JsonInfo
    {
        public List<User> contacts { get; private set; }
        public int count { get; private set; }

        public JsonInfo(List<User> users)
        {
            contacts = users;
            this.count = users.Count;
        }
    }
}
