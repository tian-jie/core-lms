using System.Collections.Generic;

namespace Kevin.T.Clockify.Data.Models
{
    public class LoginModel
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string token { get; set; }
        public string status { get; set; }
        public bool isNew { get; set; }
        public string refreshToken { get; set; }

        public List<MembershipModel> membership { get; set; }

        public bool New { get; set; }
    }
    public class GetMembershipModel
    {
        public string id { get; set; }
        public string activeWorkspace { get; set; }
        public string defaultWorkspace { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string profilePicture { get; set; }
        public string status { get; set; }
    }
}
