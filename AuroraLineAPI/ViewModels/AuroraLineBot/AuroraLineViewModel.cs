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
        Done =2,
        EnrollBook = 3
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

        public int SNO { get; set; }

        public string LineID { get; set; }

        public string Name { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "您的電話號碼格式有問題唷，請您在輸入一次\n (範例格式：0912345678／0223458088)")]
        public string Mobile { get; set; }

        [EmailAddress(ErrorMessage = "您的EMail格式有問題唷，請您在輸入一次\n(範例格式: a12345@hotmail.com)")]
        public string EMail { get; set; }

        public string Status { get; set; }

        public string ServiceDPT { get; set; }

        public string Address { get; set; }

    }
}