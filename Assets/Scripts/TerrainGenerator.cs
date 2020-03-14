using System;
using System.Collections.Generic;
using System.Linq;
using Assets;
using Itransition.TerrainGen.Decorators;

namespace Itransition.TerrainGen
{
    /// <inheritdoc cref="ITerrainGenerator"/>
    public class TerrainGenerator : ITerrainGenerator
    {
        private readonly IList<IDecorator> decorators = new List<IDecorator>();

        public World Generate(int xSize, int ySize, int? seed)
        {
            var worldRandom = seed.HasValue ? new Random(seed.Value) : new Random();
            var world = new World(xSize, ySize, worldRandom);
            return decorators
                .Aggregate(world, (currentWorld, nextDecorator) => nextDecorator.Generate(currentWorld));
        }

        public ITerrainGenerator RegisterDecorator(IDecorator decorator)
        {
            decorators.Add(decorator);
            return this;
        }
    }
}
