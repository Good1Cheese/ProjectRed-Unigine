using System;

namespace XorterDI;

public class XorterDIException : Exception
{
    public XorterDIException() : base()
    { }

    public XorterDIException(string message) : base(message)
    { }
}
