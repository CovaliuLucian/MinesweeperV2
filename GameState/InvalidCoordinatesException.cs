using System;

namespace GameState
{
    public class InvalidCoordinatesException : Exception
    {
        public InvalidCoordinatesException(int x, int y) : base($"Invalid access at [{x},{y}]")
        {
        }
    }
}