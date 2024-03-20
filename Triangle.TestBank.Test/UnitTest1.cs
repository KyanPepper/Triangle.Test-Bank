namespace Triangle.TestBank.Test;
using Triangle.TestBank.Data.Services;
public class ExamServicesTest
{
    [Fact]
    public void HealthTest()
    {
        var examServices = new ExamServices();
        string result = examServices.HealthCheck();
        Assert.Equal("Hello, World!", result);
    }
}