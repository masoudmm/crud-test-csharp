using CustomerCrud.Application.Dtos;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;

namespace CustomerCrud.Client.Components.Pages.Customer;

public partial class Index
{
    public Action<int> SendDeleteUserRequest { get; set; }

    public MudTable<CustomerDto> customersTable { get; set; }

    private string cutomerSearchString = "";

    private bool TableFilterFunction(CustomerDto element)
        => UserFilterFunc(element, cutomerSearchString);

    private bool UserFilterFunc(CustomerDto element,
        string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;

        if (element.Firstname.Contains(searchString,
            StringComparison.OrdinalIgnoreCase))
            return true;

        if (element.Lastname.Contains(searchString,
            StringComparison.OrdinalIgnoreCase))
            return true;

        if (element.PhoneNumber.Contains(searchString,
            StringComparison.OrdinalIgnoreCase))
            return true;

        if (element.Email.Contains(searchString,
            StringComparison.OrdinalIgnoreCase))
            return true;

        if (element.BankAccountNumber.Contains(searchString,
            StringComparison.OrdinalIgnoreCase))
            return true;

        if (element.DateOfBirth.Date.ToShortDateString().Equals(searchString,
            StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }

    private string message = string.Empty;

    private CustomerDto Customer;
    private IReadOnlyList<CustomerDto> Customers = new List<CustomerDto>();

    protected override async Task OnInitializedAsync()
    {
        Customers = await Http.GetFromJsonAsync<List<CustomerDto>>("/api/Customers");
    }

    protected async Task DeleteCustomer(int id)
    {
        var deletedCustomerId = await Http.DeleteFromJsonAsync<int>($"/api/Customers/Delete/{id}");
        if (deletedCustomerId > 0)
        {
            message = $"Custome {deletedCustomerId} is deleted!";

            StateHasChanged();
        }
    }

    private void Edit(int id)
    {
        NavigationManager.NavigateTo($"/Customer/Edit/{id}");
    }
}
