using System.Data.SqlTypes;

namespace learningprojectserver.models
{
    public class UserSessions
    {
        public long id { get; set; }
        public long userid { get; set; }
        public string accesstoken { get; set; }
        public DateTime accesstokenvalidtill { get; set; } = (DateTime)SqlDateTime.MinValue;
        public DateTimeOffset accesstokenvaliduntiloffset { get; set; } = new DateTimeOffset((DateTime)SqlDateTime.MinValue, TimeSpan.Zero);
        public string refreshtoken { get; set; }
      
        public bool isexpired { get; set; }
        public int killedby { get; set; }
        public long createdby { get; set; }
        public long modifiedby { get; set; }
        public DateTime createdon { get; set; } = (DateTime)SqlDateTime.MinValue;
        public DateTimeOffset createdonoffset { get; set; } = new DateTimeOffset((DateTime)SqlDateTime.MinValue, TimeSpan.Zero);
        public DateTime modifiedon { get; set; } = (DateTime)SqlDateTime.MinValue;
        public DateTimeOffset modifiedonoffset { get; set; } = new DateTimeOffset((DateTime)SqlDateTime.MinValue, TimeSpan.Zero);
        public bool isactive { get; set; }
        public bool issuspended { get; set; }
        public int parentid { get; set; }
  

    }
}
