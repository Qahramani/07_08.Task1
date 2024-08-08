namespace _07_08.Task1.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message = "Not Found"):base(message)
    {
        
    }
}
