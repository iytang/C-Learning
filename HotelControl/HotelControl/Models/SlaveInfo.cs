using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelControl.Models
{
    /// <summary>
    /// 从站信息类
    /// </summary>
    public class SlaveInfo
    {
        // 从站地址
        public byte SlaveId { get; set; }
        // 功能码
        public byte FunctionCode { get; set; }
        // 寄存器起始地址
        public ushort StartAddress { get; set; }
        // 寄存器数量
        public ushort Count { get; set; }
    }
}
