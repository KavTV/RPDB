using System;
using System.Collections.Generic;
using System.Text;

namespace SKPDB_Library
{
    public class Comment
    {

        public int Commentid { get { return commentid; } }
        public string Username { get { return username; } }
        public string Msg { get { return msg; } }
        public DateTime Timestamp{ get { return timestamp; } }

        private int commentid;
        private string username;
        private string msg;
        private DateTime timestamp;

        public Comment(int commentid, string username, string msg, DateTime timestamp)
        {
            this.commentid = commentid;
            this.username = username;
            this.msg = msg;
            this.timestamp = timestamp;
        }

    }
}
