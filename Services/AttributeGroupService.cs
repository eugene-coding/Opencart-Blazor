using Microsoft.EntityFrameworkCore;

using Opencart.Data;

namespace Opencart.Services;

public class AttributeGroupService
{
    private readonly IDbContextFactory<Database> _database;

    public AttributeGroupService(IDbContextFactory<Database> database)
    {
        _database = database;
    }

    public async Task AddAsync(AttributeGroup attributeGroup)
    {
        using var context = _database.CreateDbContext();

        context.AttributeGroups.Add(attributeGroup);
        await context.SaveChangesAsync();
    }

    public async Task EditAsync(AttributeGroup attributeGroup)
    {
        using var context = _database.CreateDbContext();

        context.AttributeGroups.Update(attributeGroup);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var context = _database.CreateDbContext();

        var attributeGroup = await context.AttributeGroups
            .SingleAsync(attributeGroup => attributeGroup.Id == id);

        if (attributeGroup is not null)
        {
            context.AttributeGroups.Remove(attributeGroup);
            context.SaveChanges();
        }
    }

    public async Task<IReadOnlyCollection<AttributeGroup>> GetAsync()
    {
        using var context = _database.CreateDbContext();

        var attributeGroup = await context.AttributeGroups
            .Include(attributeGroup => attributeGroup.AttributeGroupDescriptions)
            .ToListAsync();

        return attributeGroup;
    }

    public async Task<AttributeGroup?> GetAsync(int id)
    {
        using var context = _database.CreateDbContext();

        var attributeGroup = await context.AttributeGroups
            .Include(attributeGroup => attributeGroup.AttributeGroupDescriptions)
            .SingleOrDefaultAsync(group => group.Id == id);

        return attributeGroup;
    }

    public async Task<AttributeGroupDescription?> GetDescriptionAsync(int attributeGroupId)
    {
        using var context = _database.CreateDbContext();

        return await context.AttributeGroupDescriptions
            .SingleOrDefaultAsync(description => description.AttributeGroupId == attributeGroupId);
    }

    public async Task<int> GetCountAsync()
    {
        using var context = _database.CreateDbContext();

        return await context.AttributeGroups.CountAsync();
    }
}
