namespace TestExecutionAec.Domain.Exceptions
{
    public class TestExecutionAecDomainException : Exception
    {
        public TestExecutionAecDomainException()
        { }

        public TestExecutionAecDomainException(string message)
            : base(message)
        { }

        public TestExecutionAecDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
