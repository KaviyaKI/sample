using learningprojectserver.models;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace learningprojectserver.Services
{
    public class Userservice
    {
        private readonly string _connectionString;
        private Applicationsettings applicationsettings;

        public Userservice(Applicationsettings applicationsettings)
        {
            this.applicationsettings = applicationsettings;
        }

        public async Task<List<Users>> selectuser(Users req)
        {
            List<Users> userlist = new List<Users>();

            using var conn = new NpgsqlConnection(this.applicationsettings.postgresqlconnection);
            await conn.OpenAsync();

            string query = "SELECT * FROM testtable";

            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var user = new Users
                {
                   id = reader.GetInt32(0),
                    username = reader.GetString(1)
                };
                userlist.Add(user);


            }

            return userlist;
        }


        public async Task<bool> Signup(Users req)
        {
            using var conn = new NpgsqlConnection(this.applicationsettings.postgresqlconnection);
            await conn.OpenAsync();

          
            string hashedPassword = BC.HashPassword(req.passwordhash);

            string query = @"
            INSERT INTO users (username, password_hash, email, mobile)
            VALUES (@username, @password_hash, @email, @mobile);
        ";

            using var cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@username", req.username);
            cmd.Parameters.AddWithValue("@password_hash", hashedPassword);
            cmd.Parameters.AddWithValue("@email", req.email);
            cmd.Parameters.AddWithValue("@mobile", req.mobile ?? "");

            int result = await cmd.ExecuteNonQueryAsync();

            return result > 0;  
        }


        public async Task<UsersContext> LoginTransaction(LoginReq req)
        {
            var result = new UsersContext();

            var user = (await selectuser(new Users
            {
                username = req.Username
            })).First();
            
            if (!string.IsNullOrEmpty(req.Password))
            {
                var passwordWithSalt = req.Password;

                bool isPasswordValid = BC.Verify(passwordWithSalt, user.passwordhash);
                if (!isPasswordValid)
                {
                    throw new Exception("Invalid password");
                }

            }
          



            //var usersession = new UserSessions
            //{
            //    userid = user.id,
            //    code = Guid.NewGuid().ToString(),
            //    starttime = DateTime.UtcNow,
            //    endtime = DateTime.UtcNow.AddYears(1),
            //};

            //await usersessionservice.InsertTransaction(usersession);

            result.userid = user.id;
            result.usermobile = user.mobile;
            result.username = user.username;
            result.useremail = user.email;
            //result.userpermission = user.attributes.permission;
            //result.organisationid = organisation.id;
            //result.organisationname = organisation.name;
            //result.organisationtype = organisation.type;
            //result.organisationlocationid = organisationlocation.id;
            //result.organisationlocationname = organisationlocation.name;
            //result.refreshtoken = usersession.code;
            //result.accesstoken = GenerateJwtToken(new UserGenerateJwtTokenReq
            //{
            //    userid = user.id,
            //    usermobile = user.mobile,
            //    useremail = user.email,
            //    username = user.name,
            //    permissionhex = PermissionToHex(user.attributes.permission),
            //    organisationid = organisation.id,
            //    organisationname = organisation.name,
            //    organisationtype = organisation.type,
            //    organisationlocationid = organisationlocation.id,
            //    organisationlocationname = organisationlocation.name
            //});

            return result;
        }


        public string GenerateJwtToken(UserGenerateJwtTokenReq req)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.applicationsettings.jwtsecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                 new Claim("userid", req.userid.ToString()),
                 new Claim("usermobile", req.usermobile.ToString()),
                 new Claim("username", req.username.ToString()),
                 new Claim("useremail", req.useremail.ToString()),
              
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddYears(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }




}
