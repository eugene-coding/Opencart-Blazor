using System.ComponentModel.DataAnnotations;

namespace Opencart.Data;

public class AttributeGroupDescription
{
    public int Id { get; set; }
    public int AttributeGroupId { get; set; }

    [Required]
    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;

    public AttributeGroup? AttributeGroup { get; set; }

    public static IEnumerable<AttributeGroupDescription> Seed()
    {
        return new List<AttributeGroupDescription>
        {
            new AttributeGroupDescription
            {
                AttributeGroupId = 3,
                Name = "Memory"
            },
            new AttributeGroupDescription
            {
                AttributeGroupId = 4,
                Name = "Technical"
            },
            new AttributeGroupDescription
            {
                AttributeGroupId = 5,
                Name = "Motherboard"
            },
            new AttributeGroupDescription
            {
                AttributeGroupId = 6,
                Name = "Processor"
            },
        };
    }
}
