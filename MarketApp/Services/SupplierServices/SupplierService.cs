using MarketApp.Context;
using MarketApp.Entities;

namespace MarketApp.Services.SupplierServices;

public class SupplierService : ISupplierService
{
    MarketDbContext _context;

    public void CreateSupplier(Supplier Supplier)
    {
        _context.Suppliers.Add(Supplier);
        _context.SaveChanges();
    }

    public void DeleteSupplier(int id)
    {   
        var supplier = _context.Suppliers.Find(id);
        if (supplier != null)
        {
            supplier.IsDeleted = true;
            supplier.DeletedDate = DateTime.Now;
        }
        _context.SaveChanges();
    }

    public List<Supplier> GetAllSuppliers()
    {
        return _context.Suppliers.Where(s => !s.IsDeleted).ToList();
    }

    public Supplier GetSupplierById(int id)
    {
        return _context.Suppliers.Find(id);
    }

    public void UpdateSupplier(int id)
    {
        var supplier = _context.Suppliers.Find(id);
        if (supplier != null)
        {
            supplier.UpdatedDate = DateTime.Now;
            Console.WriteLine("Enter new name:");
            string newName = Console.ReadLine();
            supplier.Name = newName;
            _context.Suppliers.Update(supplier);
        }
        _context.SaveChanges();
    }
}
