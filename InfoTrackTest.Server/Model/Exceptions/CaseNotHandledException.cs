namespace InfoTrackTest.Server.Model.Exceptions;

public class CaseNotHandledException : Exception
{
    public CaseNotHandledException()
    {
    }

    public CaseNotHandledException(string message)
        : base(message)
    {
    }
}