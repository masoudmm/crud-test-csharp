using Application.ViewModels;

namespace Mc2.CrudTest.AcceptanceTests.Steps;

[Binding]
public class EditCustomerStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private EditCustomerViewModel EditCustomerViewModel;

    public EditCustomerStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I click the first customer details")]
    public void WhenIClickTheFirstCustomerDetails()
    {
        //TODO: Complete it
    }

    [When(@"I edit the customer first name")]
    public void WhenIEditTheCustomerFirstName()
    {
        //TODO: Complete it
    }

    [When(@"I click the Save button")]
    public void WhenIClickTheSaveButton()
    {
        //TODO: Complete it
    }

    [Then(@"the customer should be edited successfully")]
    public void ThenTheCustomerShouldBeEditedSuccessfully()
    {
        //TODO: Complete it
    }
}

