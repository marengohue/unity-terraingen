using UnityEngine;

namespace Assets.Scripts.Impl
{
    class BiomeDecorator : IDecorator
    {
        public const float Scale = 2f;

        public World Generate(World world)
        {
            var xOrigin = (float)world.Random.NextDouble();
            var yOrigin = (float)world.Random.NextDouble();

            var biomeMap = new EnumBiome[world.X, world.Y];
            var biomeHightmap = new float[world.X, world.Y];

            for (var x = 0; x < world.X; x++)
            {
                for (int y = 0; y < world.Y; y++)
                { 
                    var (biome, biomeValue) = GetBiomeFromPoint(world, xOrigin, x, yOrigin, y);
                    biomeMap[x, y] = biome;
                    biomeHightmap[x, y] = biomeValue;
                }
            }

            world.SetMetaValue(Constants.BiomesMetaKey, biomeMap);
            world.SetMetaValue(Constants.BiomesHeightmapMetaKey, biomeHightmap);
            return world;
        }

        private (EnumBiome, float) GetBiomeFromPoint(World world, float xOrigin, int x, float yOrigin, int y)
        {
            var noiseVal = Mathf.PerlinNoise(
                xOrigin + 1f * x / world.X * Scale,
                yOrigin + 1f * y / world.Y * Scale
            );
            if (noiseVal > 0.6)
            {
                return (EnumBiome.Mountain, noiseVal);
            }
            if (noiseVal > 0.3)
            {
                return (EnumBiome.Forest, noiseVal);
            }

            return (EnumBiome.Desert, noiseVal);
        }
    }
}
