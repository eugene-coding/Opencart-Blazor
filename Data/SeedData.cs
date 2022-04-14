using Microsoft.EntityFrameworkCore;

namespace Opencart.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new Database(
            serviceProvider.GetRequiredService<
                DbContextOptions<Database>>());

        if (context == null)
        {
            throw new ArgumentNullException("Null RazorPagesMovieContext");
        }

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        SeedAttributeGroups(context);
        SeedAttributeGroupDescriptions(context);

        context.SaveChanges();
    }

    private static void SeedAttributeGroups(Database context)
    {
        if (context.AttributeGroups is null || context.AttributeGroups.Any())
        {
            return;
        }

        context.AttributeGroups.AddRange(AttributeGroup.Seed());
    }

    private static void SeedAttributeGroupDescriptions(Database context)
    {
        if (context.AttributeGroupDescriptions is null || context.AttributeGroupDescriptions.Any())
        {
            return;
        }

        context.AttributeGroupDescriptions.AddRange(AttributeGroupDescription.Seed());
    }
}
