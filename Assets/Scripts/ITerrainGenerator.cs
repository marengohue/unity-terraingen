using Itransition.TerrainGen.Decorators;

namespace Itransition.TerrainGen
{
    public interface ITerrainGenerator
    {
        /// <summary>
        /// Builds a the terrain data
        /// </summary>
        /// <param name="xSize"></param>
        /// <param name="ySize"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        World Generate(int xSize, int ySize, int? seed = null);

        /// <summary>
        /// Registers the decorator in the generation pipeline
        /// </summary>
        /// <param name="decorator"></param>
        ITerrainGenerator RegisterDecorator(IDecorator decorator);
    }
}
