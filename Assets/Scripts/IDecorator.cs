using System;

namespace Assets.Scripts
{
    public interface IDecorator
    {
        World Generate(World world);
    }
}
