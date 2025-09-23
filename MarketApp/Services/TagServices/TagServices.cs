using MarketApp.Context;
using MarketApp.Entities;
using MarketApp.Services.TagServices;

namespace MarketApp.Services.TagServices;

public class TagService : ITagService
{
    MarketDbContext _context;

    public TagService()
    {
        _context = new MarketDbContext();
    }
    public void CreateTag(Tag Tag)
    {
        _context.Tags.Add(Tag);
        _context.SaveChanges();
    }

    public void DeleteTag(int id)
    {
        var Tag = _context.Tags.Find(id);
        if (Tag != null)
        {
            Tag.IsDeleted = true;
            Tag.DeletedDate = DateTime.Now;
        }
        _context.SaveChanges();
    }

    public List<Tag> GetAllTags()
    {
        return _context.Tags.Where(c => !c.IsDeleted).ToList();
    }

    public Tag GetTagById(int id)
    {
        return _context.Tags.Find(id);
    }

    public void UpdateTag(int id)
    {
        var Tag = _context.Tags.Find(id);
        if (Tag != null)
        {
            Tag.UpdatedDate = DateTime.Now;
            Console.WriteLine("Enter new label:");
            string newlabel = Console.ReadLine();
            Tag.Label = newlabel;
            _context.Tags.Update(Tag);
        }
        _context.SaveChanges();
    }
    public void TagMenu()
    {
        while (true)
        {
            Console.WriteLine("\nTag Menu:");
            Console.WriteLine("1. Add Tag");
            Console.WriteLine("2. Delete Tag");
            Console.WriteLine("3. Update Tag");
            Console.WriteLine("4. Get Tag By Id");
            Console.WriteLine("5. Get All Tags");
            Console.WriteLine("0. Back");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Tag t = new Tag();
                    Console.Write("Label: ");
                    t.Label = Console.ReadLine();
                    CreateTag(t);
                    Console.WriteLine("Tag added.");
                    break;
                case 2:
                    Console.Write("Enter Tag Id to delete: ");
                    DeleteTag(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Tag deleted.");
                    break;
                case 3:
                    Console.Write("Enter Tag Id to update: ");
                    UpdateTag(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Tag updated.");
                    break;
                case 4:
                    Console.Write("Enter Tag Id: ");
                    var tag = GetTagById(int.Parse(Console.ReadLine()));
                    Console.WriteLine(tag != null ? $"Id: {tag.Id}, Label: {tag.Label}" : "Not found.");
                    break;
                case 5:
                    var all = GetAllTags();
                    foreach (var item in all)
                        Console.WriteLine($"Id: {item.Id}, Label: {item.Label}");
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
