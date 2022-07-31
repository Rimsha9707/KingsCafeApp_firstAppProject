using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    class tblWorkerDetail
    {
        [PrimaryKey, AutoIncrement]
        public int WORKER_DETAIL_ID { get; set; }

        public DateTime WORKER_DETAIL_INT_IME { get; set; }

        public DateTime WORKER_DETAIL_OUT_TIME { get; set; }
        public string WORKER_DETAIL_LEAVE_REASON { get; set; }

        public int WORKER_FID { get; set; }

        public int RIDER_FID { get; set; }

    }
}
