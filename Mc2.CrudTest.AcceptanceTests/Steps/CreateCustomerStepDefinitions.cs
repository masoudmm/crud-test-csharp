using Mc2.CrudTest.Presentation.Application.ViewModels;

namespace Mc2.CrudTest.AcceptanceTests.Steps;

[Binding]
public class CreateCustomerStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private CreateCustomerViewModel CreateCustomerModel;

    public CreateCustomerStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"I am on the customer management page")]
    public void GivenIAmOnTheCustomerManagementPage()
    {
        //TODO: Mock NavigationManager
    }

    [When(@"I click the ""Create Customer"" button")]
    public void WhenIClickCreateCustomerButton()
    {
        //TODO: Mock NavigationManager
    }

    [When(@"I fill in the customer details")]
    public void WhenIFillInTheCustomerDetails()
    {
        CreateCustomerModel = new CreateCustomerViewModel
        {
            Firstname = "Firstname",
            Lastname = "LastName",
            DateOfBirth = DateTime.UtcNow,
            PhoneNumber = "PhoneNumber",
            Email = "Email",
            BankAccountNumber = "BankAccountNumber"
        };
    }

    [When(@"I click the ""Create"" button")]
    public async Task AndClickCreateButton()
    {
        //TODO: Complete it
    }

    [Then(@"the customer should be created successfully")]
    public void ThenTheCustomerShouldBeCreatedSuccessfully()
    {
        //TODO: Complete it
    }
}

