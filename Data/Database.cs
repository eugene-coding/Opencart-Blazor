using Microsoft.EntityFrameworkCore;

namespace Opencart.Data;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options) { }

    public DbSet<AttributeGroup> AttributeGroups => Set<AttributeGroup>();
    public DbSet<AttributeGroupDescription> AttributeGroupDescriptions => Set<AttributeGroupDescription>();

}
