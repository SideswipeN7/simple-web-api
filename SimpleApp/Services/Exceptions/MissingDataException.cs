using System;

namespace SimpleApp.Services
{
    public class MissingDataException : Exception
    {
        public MissingDataException(string message) : base($"Missing data, {message}") { }
    }
}