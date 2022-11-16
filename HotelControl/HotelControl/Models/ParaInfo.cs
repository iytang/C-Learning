using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelControl.Models
{
    /// <summary>
    /// 参数信息类
    /// 用来描述风机的通信地址等信息
    /// </summary>
    public class ParaInfo
    {
        public string ParaName { get; set; }
        public byte SlaveId { get; set; }
        //寄存器地址
        public ushort Address { get; set; }
        // 参数类型
        public string DataType { get; set; }
        // 参数描述
        public string Note { get; set; }
    }
}
