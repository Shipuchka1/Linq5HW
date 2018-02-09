namespace Linq5HW.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;
    using System.Data.Linq.Mapping;

    [Table(Name ="TablesModel")]
    public partial class TablesModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TablesModel()
        {
            newEquipments = new HashSet<newEquipment>();
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int intModelID { get; set; }

        [Column]
        [StringLength(10)]
        public string strName { get; set; }

        [Column]
        public int? intManufacturerID { get; set; }

        [Column]
        public int? intSMCSFamilyID { get; set; }

        [Column]
        [StringLength(250)]
        public string strImage { get; set; }


      //  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<newEquipment> newEquipments { get; set; }

        public virtual TablesManufacturer TablesManufacturer { get; set; }
    }
}
