using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace WebApp.Models
{
    public class DeviceInfo
    {
        [Key]
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int Sequence { get; set; }
        public int Rssi { get; set; }
        public int StationId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
