using IMS.CoreBusiness;
using IMS.UseCases.pluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMSContext db;

        public InventoryRepository(IMSContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            return await this.db.Inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
           string.IsNullOrWhiteSpace(name)).ToListAsync();
        }
        public async Task AddInventoryAsync(Inventory inventory)
        {
            //to prevent different Inventories from having same name

            if (db.Inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase))) return; 
            this.db.Inventories.Add(inventory);
            await this.db.SaveChangesAsync();
        }
        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            //to prevent different Inventories from having same name
            if(db.Inventories.Any(x => x.InventoryId != inventory.InventoryId && x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase))) return;
            var inv = await this.db.Inventories.FindAsync(inventory);
            if (inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;
                await db.SaveChangesAsync();


            }
        }

        public async Task<Inventory?> GetInventoriesByIdAsync(int inventoryid)
        {
            return await this.db.Inventories.FindAsync(inventoryid);
        }
    }
}