namespace WebCourseProject.Soap;

public class SoapService : ISoapService
{
    public string Hello(string name)
    {
        return $"Hello, {name}";
    }
}

