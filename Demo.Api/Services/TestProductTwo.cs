namespace Demo.Api.Services;

public class TestProductTwo : ITestProduct
{
    public string GetDetails(string id)
    {
        return "Value from Test Product Two";
    }
}
