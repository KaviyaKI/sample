using learningprojectserver.models;
using System.Data.Common;
using System.Data;
using learningprojectserver.Utils;

namespace learningprojectserver.Services
{
    public class Usersessionservice
    {
        public async Task InsertTransaction(UserSessions usersession)
        {
            String query = @"
                INSERT INTO UserSession (
                    code,userid,starttime,endtime,version,createdby,createdon,modifiedby,modifiedon,attributes,isactive,issuspended,parentid,isfactory,notes
                )
                VALUES (
                   @code,@userid,@starttime,@endtime,@version,@createdby,@createdon,@modifiedby,@modifiedon,@attributes,@isactive,@issuspended,@parentid,@isfactory,@notes
                )
                RETURNING id;
                ";
            usersession.isactive = true;
            //usersession.version = 1;
            //usersession.createdon = DateTime.UtcNow;
            //usersession.createdby = requeststate.usercontext.userid;
            //usersession.modifiedon = DateTime.UtcNow;
          
        }
    }
}
