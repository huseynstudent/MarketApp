using MarketApp.Entities;

namespace MarketApp.Services.TagServices;
interface ITagService
{
    public void CreateTag(Tag Tag);
    public List<Tag> GetAllTags();
    public Tag GetTagById(int id);
    public void UpdateTag(int id);
    public void DeleteTag(int id);
}
