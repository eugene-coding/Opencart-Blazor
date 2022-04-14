namespace Opencart.Data;

public class AttributeGroup
{
    public int Id { get; set; }
    public int SortOrder { get; set; }

    public AttributeGroupDescription AttributeGroupDescriptions { get; set; }

    public AttributeGroup()
    {
        AttributeGroupDescriptions = new();
    }

    public static IEnumerable<AttributeGroup> Seed()
    {
        return new List<AttributeGroup>
        {
            new AttributeGroup
            {
                Id = 3,
                SortOrder = 2
            },
            new AttributeGroup
            {
                Id = 4,
                SortOrder = 1
            },
            new AttributeGroup
            {
                Id = 5,
                SortOrder = 3
            },
            new AttributeGroup
            {
                Id = 6,
                SortOrder = 4
            }
        };
    }
}
