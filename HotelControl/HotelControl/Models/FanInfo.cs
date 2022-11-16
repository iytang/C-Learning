using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelControl.Models
{
    /// <summary>
    /// 风机配置信息
    /// </summary>
    public class FanInfo
    {
        public string FanName { get; set; }
        // 风机状态参数
        public string StateParaName { get; set; }
        // 风机温度参数
        public string TemperParaName { get; set; }
    }
}
