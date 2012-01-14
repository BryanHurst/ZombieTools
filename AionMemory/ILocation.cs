// Standard Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AionMemory
{
    public interface ILocation2D
    {
        float X { get; }
        float Y { get; }
    }

    public interface ILocation3D : ILocation2D
    {
        float Z { get; }
    }
}