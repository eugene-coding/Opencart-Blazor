using Microsoft.AspNetCore.Components;

using Opencart.Services;

namespace Opencart.Pages.Admin.Catalog.AttributeGroup;

[Route(Url)]
public partial class List
{
    public const string Url = "admin/attribute-group";

    IReadOnlyCollection<Data.AttributeGroup>? _attributeGroups;

    [Inject]
    public AttributeGroupService Service { get; init; } = null!;

    [Parameter]
    [SupplyParameterFromQuery]
    public string? Sort { get; init; }

    [Parameter]
    [SupplyParameterFromQuery]
    public string? Order { get; init; }

    [Parameter]
    [SupplyParameterFromQuery]
    public int? Page { get; init; }

    protected override async Task OnInitializedAsync()
    {
        _attributeGroups = await Service.GetAsync();
    }
}
