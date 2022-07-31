using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    class tblFeedback
    {
        [PrimaryKey, AutoIncrement]
        public int FEEDBACK_ID { get; set; }
        public string FEEDBACK_DESCRIPTION { get; set; }
        public string FEEDBACK_NAME { get; set; }
        public int WHATSAPP_NO { get; set; }
        public int PHONE_NO { get; set; }
        public string ADDRESS { get; set; }
    }
}
