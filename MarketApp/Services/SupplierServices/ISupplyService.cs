using MarketApp.Entities;

namespace MarketApp.Services.SupplierServices;

interface ISupplierService
{
    public void CreateSupplier(Supplier Supplier);
    public List<Supplier> GetAllSuppliers();
    public Supplier GetSupplierById(int id);
    public void UpdateSupplier(int id);
    public void DeleteSupplier(int id);
}
