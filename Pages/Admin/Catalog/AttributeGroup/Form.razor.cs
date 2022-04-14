using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

using Opencart.Services;

namespace Opencart.Pages.Admin.Catalog.AttributeGroup;

[Route(Url)]
public partial class Form
{
    public const string Url = "admin/attribute-group/edit";

    private bool _isModelExist;
    private Data.AttributeGroup? _model;

    [Parameter]
    [SupplyParameterFromQuery]
    public int? Id { get; set; }

    [Inject]
    public IStringLocalizer<Form> Text { get; init; } = null!;

    [Inject]
    public NavigationManager Navigation { get; init; } = null!;

    [Inject]
    public AttributeGroupService Service { get; init; } = null!;

    protected override async Task OnInitializedAsync()
    {
        if (Id.HasValue)
        {
            _model = await Service.GetAsync(Id.Value);
            _isModelExist = _model is not null;
        }
       
        if (!_isModelExist)
        {
            _model = new();
        }
    }

    private async void HandleValidSubmit(Data.AttributeGroup attributeGroup)
    {
        if (_isModelExist)
        {
            await Service.EditAsync(attributeGroup);
        }
        else
        {
            await Service.AddAsync(attributeGroup);
            _isModelExist = true;
        }

        Navigation.NavigateTo(List.Url);
    }
}
