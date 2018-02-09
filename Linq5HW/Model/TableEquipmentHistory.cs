namespace Linq5HW.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;
    using System.Data.Linq.Mapping;

    [Table(Name = "TableEquipmentHistory")]
    public partial class TableEquipmentHistory
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int intEquipmentHistoryId { get; set; }

        [Column]
        public int? intEquipmentID { get; set; }

        [Column]
        public int? intTypeHistory { get; set; }

        [Column(DbType = "date")]
        public DateTime? dStartDate { get; set; }

        [Column(DbType = "date")]
        public DateTime? dEndDate { get; set; }

        [Column]
        public int? intDaysCount { get; set; }

        [Column]
        public int? intStatys { get; set; }

        [Column]
        public int? intUserId { get; set; }

        [Column(DbType = "date")]
        public DateTime? dCahengeDate { get; set; }

       // public virtual newEquipment newEquipment { get; set; }
    }
}
