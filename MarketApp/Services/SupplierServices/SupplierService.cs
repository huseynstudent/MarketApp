using MarketApp.Context;
using MarketApp.Entities;

namespace MarketApp.Services.SupplierServices;

public class SupplierService : ISupplierService
{
    MarketDbContext _context;

    public SupplierService()
    {
        _context = new MarketDbContext();
    }
    public void CreateSupplier(Supplier Supplier)
    {
        _context.Suppliers.Add(Supplier);
        _context.SaveChanges();
    }

    public void DeleteSupplier(int id)
    {   
        
        var supplier = _context.Suppliers.Find(id);
        if (supplier == null)
        {
            Console.WriteLine("Supplier wasnt found");
            return;
        }
        supplier.IsDeleted = true;
        supplier.DeletedDate = DateTime.Now;
        Console.WriteLine("Supplier was deleted");
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
        if (supplier == null)
        {
            Console.WriteLine("Supplier wasnt found"); 
            return;
        }
        
            supplier.UpdatedDate = DateTime.Now;
            Console.WriteLine("Enter new name:");
            string newName = Console.ReadLine();
            supplier.Name = newName;
            _context.Suppliers.Update(supplier);
                    Console.WriteLine("Supplier updated.");
        
        _context.SaveChanges();
    }

    public void SupplierMenu()
    {
        while (true)
        {
            Console.WriteLine("\nSupplier Menu:");
            Console.WriteLine("1. Add Supplier");
            Console.WriteLine("2. Delete Supplier");
            Console.WriteLine("3. Update Supplier");
            Console.WriteLine("4. Get Supplier By Id");
            Console.WriteLine("5. Get All Suppliers");
            Console.WriteLine("0. Back");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Supplier s = new Supplier();
                    Console.Write("Name: ");
                    s.Name = Console.ReadLine();
                    CreateSupplier(s);
                    Console.WriteLine("Supplier added.");
                    break;
                case 2:
                    Console.Write("Enter Supplier Id to delete: ");
                    DeleteSupplier(int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.Write("Enter Supplier Id to update: ");
                    UpdateSupplier(int.Parse(Console.ReadLine()));
                    break;
                case 4:
                    Console.Write("Enter Supplier Id: ");
                    var supplier = GetSupplierById(int.Parse(Console.ReadLine()));
                    Console.WriteLine(supplier != null ? $"Id: {supplier.Id}, Name: {supplier.Name}" : "Not found.");
                    break;
                case 5:
                    var all = GetAllSuppliers();
                    foreach (var item in all)
                        Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
