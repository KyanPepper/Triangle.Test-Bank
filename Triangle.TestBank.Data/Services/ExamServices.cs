namespace Triangle.TestBank.Data.Services;
public class ExamServices
{
    [Coalesce]
    public string HealthCheck()
    {
        return "Hello, World!";
    }


}
