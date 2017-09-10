using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraLineAPI.AuroraLine.ViewModels
{
    /// <summary>
    /// 對話狀態
    /// </summary>
    public enum UserInfoStatus
    {
        Name = 0,
        Mobile = 1,
        ServiceDPT =2 ,
        EMAIL = 3, 
        GetGift = 5
    }

    public enum UserState
    {
        Normal=0,
        Engage=1
    }

    public enum AgentState
    {
        Idle=0,
        Busy=1,
        Disable=2
    }

    public class AuroraLineViewModel
    {
        public string LineID { get; set; }

        public string Name { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "您的電話號碼格式有問題唷，請您在輸入一次")]
        public string mobile { get; set; }

        [EmailAddress(ErrorMessage = "您的EMail格式有問題唷，請您在輸入一次")]
        public string EMail { get; set; }

        public UserInfoStatus Status { get; set; }

        public string ServiceDPT { get; set; }

    }
}