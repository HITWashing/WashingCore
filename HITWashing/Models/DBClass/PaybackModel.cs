﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HITWashing.Models.DBClass
{
    public class PaybackModel
    {
        [Key]
        [DisplayName("POID")]
        public int PaybackOrderID { get; set; }

        public int UserID { get; set; }
        //[ForeignKey("UserID")]
        //public virtual AccountModel UAccount { get; set; }

        //public int TransportID { get; set; }
        //[ForeignKey("TransportID")]
        //public virtual AccountModel TAccount { get; set; }

        public int AccountID { get; set; }
        public virtual AccountModel Account { get; set; }//运送ID

        [DisplayName("是否取消")]
        public bool IsCanceled { get; set; }

        [DisplayName("是否完成")]
        public bool IsCompleted { get; set; }

    }
}
