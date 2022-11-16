using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 实体配置类
    /// </summary>
    public class Config
    {
        // 通信参数
        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }

        // 站地址(如果多可以用集合)
        public byte SlaveId1 { get; set; }
        public byte SlaveId2 { get; set; }
        public byte SlaveId3 { get; set; }
        public byte SlaveId4 { get; set; }
    }
}
