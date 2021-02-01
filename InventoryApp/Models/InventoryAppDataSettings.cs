namespace InventoryApp.Models
{
    public class InventoryAppDataSettings : IinventoryAppDatabaseSettings
    {
        public string InventoryAppCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IinventoryAppDatabaseSettings
    {
        string InventoryAppCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
