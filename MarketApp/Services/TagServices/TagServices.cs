using MarketApp.Context;
using MarketApp.Entities;
using MarketApp.Services.TagServices;

namespace MarketApp.Services.TagServices;

public class TagService : ITagService
{
    MarketDbContext _context;
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

}
