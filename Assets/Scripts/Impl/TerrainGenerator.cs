using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;

namespace Assets.Impl
{
    /// <inheritdoc cref="ITerrainGenerator"/>
    public class TerrainGenerator : ITerrainGenerator
    {
        private readonly IList<IDecorator> decorators = new List<IDecorator>();

        public World Generate(int xSize, int ySize)
        {
            var world = new World(xSize, ySize);
            return decorators
                .Aggregate(world, (currentWorld, nextDecorator) => nextDecorator.Generate(currentWorld));
        }

        public void RegisterDecorator(IDecorator decorator)
        {
            decorators.Add(decorator);
        }
    }
}
