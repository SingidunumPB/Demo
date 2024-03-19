namespace Demo.Api.Services;

public class TestProductOne : ITestProduct
{
    public string GetDetails(string id)
    {
        return "Value from Test Product One";
    }
}
