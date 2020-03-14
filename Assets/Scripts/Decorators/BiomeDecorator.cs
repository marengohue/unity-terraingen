using System.Linq;
using Itransition.TerrainGen.Biomes;
using Itransition.TerrainGen.Extensions;
using UnityEngine;

namespace Itransition.TerrainGen.Decorators
{
    class BiomeDecorator : IDecorator
    {
        public const float Scale = 2f;

        public World Generate(World world)
        {
            var xOrigin = (float)world.Random.NextDouble();
            var yOrigin = (float)world.Random.NextDouble();
            var biomeMap = new Biome[world.X, world.Y];
            var biomeHightmap = new float[world.X, world.Y];
            world.ForEachTile((x, y) =>
            {
                var (biome, biomeValue) = GetBiomeFromPoint(world, xOrigin, x, yOrigin, y);
                biomeMap[x, y] = biome;
                biomeHightmap[x, y] = biomeValue;
            });
            world.SetMetaValue(Constants.BiomesMetaKey, biomeMap);
            world.SetMetaValue(Constants.BiomesHeightmapMetaKey, biomeHightmap);
            return world;
        }

        private (Biome, float) GetBiomeFromPoint(World world, float xOrigin, int x, float yOrigin, int y)
        {
            var biomeNoise = Mathf.PerlinNoise(
                xOrigin + 1f * x / world.X * Scale,
                yOrigin + 1f * y / world.Y * Scale
            );
            var biome = BiomeIndex.AllBiomes.First(b => biomeNoise >= b.HeightMin && biomeNoise < b.HeightMax);
            return (biome, biomeNoise);
        }
    }
}
