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
            var biomeMap = new Biome[world.SizeX, world.SizeY];
            var biomeHightmap = new float[world.SizeX, world.SizeY];
            world.ForEachTile((x, y) =>
            {
                var (biome, biomeValue) = GetBiomeFromPoint(world, xOrigin, x, yOrigin, y);
                biomeMap[x, y] = biome;
                biomeHightmap[x, y] = biomeValue;
            });
            world.SetMetaValue(Keys.BiomesMetaKey, biomeMap);
            world.SetMetaValue(Keys.BiomesHeightmapMetaKey, biomeHightmap);
            return world;
        }

        private (Biome, float) GetBiomeFromPoint(World world, float xOrigin, int x, float yOrigin, int y)
        {
            var biomeNoise = Mathf.PerlinNoise(
                xOrigin + 1f * x / world.SizeX * Scale,
                yOrigin + 1f * y / world.SizeY * Scale
            );
            var biome = BiomeIndex.AllBiomes.First(b => biomeNoise >= b.HeightMin && biomeNoise < b.HeightMax);
            return (biome, biomeNoise);
        }
    }
}
