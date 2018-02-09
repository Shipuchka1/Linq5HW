using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq5HW.Model
{
    [Table(Name = "NewTable")]
    public class NewTable
    {

       //"EquipmentID int, GarageRoom nvarchar(100),SerialNo nvarchar(100),"+
       //"TypeHistory int, StartDate date, EndDate date, DaysCount int, Statys int) end");
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int NewTableId { get; set; }

        [Column]
        public int? EquipmentID { get; set; }

        [Column]
        public string GarageRoom { get; set; }

        [Column]
        public string SerialNo { get; set; }

        [Column]
        public int? TypeHistory { get; set; }

        [Column]
        public DateTime? StartDate { get; set; }

        [Column]
        public DateTime? EndDate { get; set; }

        [Column]
        public int? DaysCount { get; set; }

        [Column]
        public int? Statys { get; set; }
    }
}
