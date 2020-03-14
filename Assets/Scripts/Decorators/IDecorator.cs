namespace Itransition.TerrainGen.Decorators
{
    /// <summary>
    /// A class that applies a certain transformation to the world when generating
    /// </summary>
    public interface IDecorator
    {
        /// <summary>
        /// Decorates the given world with a certain set of features.
        /// Can modify the world's metadata properties for use in the
        /// future decoration steps
        /// </summary>
        /// <param name="world">world to decorate</param>
        /// <returns></returns>
        World Generate(World world);
    }
}
