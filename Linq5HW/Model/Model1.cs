namespace Linq5HW.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Linq;

    public partial class Model1 : DataContext
    {
        public Model1()
            : base(@"Data Source = DESKTOP-NESB2OL\SQLEXPRESS; Initial Catalog = Linq5; User Id = Natalya; Password = 12345; ")
        {
        }

        public Table<newEquipment> newEquipments { get; set; }
        public Table<TableEquipmentHistory> TableEquipmentHistories { get; set; }
        public Table<TablesManufacturer> TablesManufacturers { get; set; }
        public Table<TablesModel> TablesModels { get; set; }
        public Table<NewTable> NewTables { get; set; }
    }
}
