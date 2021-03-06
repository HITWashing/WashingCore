﻿using BSXWashing.Models.EnumClass;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSXWashing.Models.DBClass
{
    public class AccountModel
    {
        [Key]
        [StringLength(32, ErrorMessage = "用户名必须为2~32", MinimumLength = 2)]
        [DisplayName("用户名")]
        public string AccountName { get; set; }

        [DisplayName("手机号")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, ErrorMessage = "电话号码长度必须为11位", MinimumLength = 11)]
        public string MobileNumber { get; set; }

        [StringLength(64, ErrorMessage = "商家地址必须为2~64", MinimumLength = 2)]
        [DisplayName("商家地址")]
        public string Address { get; set; }

        [Required]
        [DisplayName("用户类别")]
        public EnumAccountType Type { get; set; }

        [Required]
        [DisplayName("用户级别")]
        public EnumAccountLevel Level { get; set; }

        [Required]
        [DisplayName("商家种类")]
        public EnumAccountCategory Category { get; set; }

        [DisplayName("用户密码")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "密码长度必须在8到32之间", MinimumLength = 8)]
        [Required]
        public string Password { get; set; }

        [DisplayName("密码确认")]
        [NotMapped]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "密码长度必须在8到32之间", MinimumLength = 8)]
        public string ConfirmPassword { get; set; }

        [DisplayName("混淆盐")]
        public string Salt { get; set; }

        [DisplayName("商户名")]
        [StringLength(32, ErrorMessage = "商户名必须为2~32", MinimumLength = 2)]
        [Required]
        public string StoreName { get; set; }

        [DisplayName("余额")]
        public double Balance { get; set; }

        //-----------外键替换更改----------------------------------

        [DisplayName("房间数")]
        [Range(0, 2147483647, ErrorMessage = "非法数字")]
        public int RoomNumber { get; set; }

        [DisplayName("备注")]
        public string Note { get; set; }

        [DisplayName("1.2米 床数")]
        [Range(0, 2147483647, ErrorMessage = "非法数字")]
        public int TwoBedNumber { get; set; }

        [DisplayName("1.5米 床数")]
        [Range(0, 2147483647, ErrorMessage = "非法数字")]
        public int FiveBedNumber { get; set; }

        [DisplayName("1.8米 床数")]
        [Range(0, 2147483647, ErrorMessage = "非法数字")]
        public int EightBedNumber { get; set; }

        [DisplayName("用户区域")]
        public EnumAreaCategory Area { get; set; }

        //----------------------------------------------------------

        [DisplayName("库存信息")]
        public virtual ICollection<WarehouseModel> Warehouses { get; set; }

        [DisplayName("充值信息")]
        public virtual ICollection<TopupModel> Topups { get; set; }

        [DisplayName("借订单运送信息")]
        public virtual ICollection<BorrowModel> BorrowTransport { get; set; }

        [DisplayName("还订单运送信息")]
        public virtual ICollection<PaybackModel> PaybackTransport { get; set; }

        [DisplayName("折扣信息")]
        public virtual ICollection<DiscountModel> Discounts { get; set; }
    }
}
