namespace Linq5HW.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.Linq.Mapping;
    using System.Data.Entity.Spatial;
    using System.ComponentModel.DataAnnotations;

    [Table(Name ="newEquipment")]
    public partial class newEquipment
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public newEquipment()
        //{
        //    TableEquipmentHistories = new HashSet<TableEquipmentHistory>();
        //}

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int intEquipmentID { get; set; }

        [Column]
        [StringLength(50)]
        public string intGarageRoom { get; set; }

         [Column]
        public int intManufacturerID { get; set; }

        [Column]
        public int intModelID { get; set; }

        [Column]
        [StringLength(4)]
        public string strManufYear { get; set; }

        [Column]
        public int intSNPrefixID { get; set; }

        [Column]
        [StringLength(20)]
        public string strSerialNo { get; set; }

        [Column]
        public int intEquipmentTypeID { get; set; }

        public int intSMCSFamilyID { get; set; }

        [Column]
        public int intSizeID { get; set; }

        [Column(DbType = "date")]
        public DateTime? CreateDate { get; set; }

        [Column]
        public double intMetered { get; set; }

        [Column(DbType = "date")]
        public DateTime LastDate { get; set; }

        [Column]
        public double intLastMetered { get; set; }

        [Column]
        public double intTotalMetered { get; set; }

        [Column]
        public int? intlimitDay { get; set; }

        [Column]
        public int? intlimitWeek { get; set; }

        [Column]
        public bool bitActive { get; set; }

        [Column]
        public bool bitPreservation { get; set; }

        [Column]
        public bool bitMeter { get; set; }

        [Column]
        public bool bitKTG { get; set; }

        [Column]
        public bool isDelete { get; set; }

        [Column]
        public int intLocationId { get; set; }

        [Column]
        [StringLength(1050)]
        public string strDescription { get; set; }

        [Column]
        public double? floatCostTires { get; set; }

        [Column]
        public int? intCostTiresCurrency { get; set; }

        [Column]
        public double? floatAverageDivergence { get; set; }

        [Column]
        public double? floatFullPrice { get; set; }

        [Column]
        public int? intFullPriceCurrency { get; set; }

       
        [Column(DbType = "date")]
        public DateTime? dateStartUpDate { get; set; }

        [Column]
        public int? intServiceLife { get; set; }

        [Column]
        public int? intHoweverOddsAcceleration { get; set; }

        [Column]
        public bool bitMethodAmortization { get; set; }

        
        public virtual TablesManufacturer TablesManufacturer { get; set; }

        
        public virtual TablesModel TablesModel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableEquipmentHistory> TableEquipmentHistories { get; set; }
    }
}
