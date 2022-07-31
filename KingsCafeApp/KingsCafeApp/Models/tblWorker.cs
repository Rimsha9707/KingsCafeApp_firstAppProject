using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    class tblWorker
    {
        [PrimaryKey, AutoIncrement]
        public int WORKER_ID { get; set; }

        public string WORKER_NAME { get; set; }

        public string WORKER_EMAIL { get; set; }

        public string WORKES_PASSWORD { get; set; }

        public string WORKER_CONTACT { get; set; }

        public string WORKER_ADDRESS { get; set; }

        public string WORKER_PICTURE { get; set; }

    }
}
