namespace _07_08.Task1.Exceptions;

public class AlreadyExistException : Exception
{
    public AlreadyExistException(string message = "Already exist"): base(message)
    {
        
    }
}
