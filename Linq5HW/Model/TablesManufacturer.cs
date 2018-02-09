namespace Linq5HW.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;
    using System.Data.Linq.Mapping;

    [Table(Name ="TablesManufacturer")]
    public partial class TablesManufacturer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TablesManufacturer()
        {
            newEquipments = new HashSet<newEquipment>();
            TablesModels = new HashSet<TablesModel>();
        }

        [Column(IsPrimaryKey =true, IsDbGenerated = true)]
        public int intManufacturerID { get; set; }

        [Column]
        [StringLength(50)]
        public string strManufacturerChecklistId { get; set; }

        [Column]
        [StringLength(50)]
        public string strName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<newEquipment> newEquipments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TablesModel> TablesModels { get; set; }
    }
}
