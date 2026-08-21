namespace learningprojectserver.models
{
    public class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string passwordhash { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public DateTime createdon { get; set; } = DateTime.Now;
        public bool isactive { get; set; } = true;
    }


    public class UserGenerateJwtTokenReq
    {
        public long userid { get; set; }
        public string usermobile { get; set; }
        public string username { get; set; }
        public string useremail { get; set; }

    }

    public class LoginReq
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Signupreq
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

    }

    public class UsersContext
    {
        public long userid { get; set; }
        public string usermobile { get; set; }
        public string username { get; set; }
        public string useremail { get; set; }
        public long organisationid { get; set; }
        public string organisationname { get; set; }
        public long organisationimageid { get; set; }
        public long organisationlocationid { get; set; }
        public string organisationlocationname { get; set; }
        public string refreshtoken { get; set; }
        public string accesstoken { get; set; }
    }

}
