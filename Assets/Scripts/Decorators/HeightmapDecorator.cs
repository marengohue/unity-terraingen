using Itransition.TerrainGen.Extensions;
using UnityEngine;

namespace Itransition.TerrainGen.Decorators
{
    class HeightmapDecorator : IDecorator
    {
        private readonly float scale;

        private readonly float biomePower;

        public HeightmapDecorator(float noiseScale, float biomePower)
        {
            this.biomePower = biomePower;
            scale = noiseScale;
        }

        public World Generate(World world)
        {
            var xOrigin = (float)world.Random.NextDouble();
            var yOrigin = (float)world.Random.NextDouble();

            SetHeights(world, xOrigin, yOrigin);

            return world;
        }

        private void SetHeights(World world, float xOrigin, float yOrigin)
        {
            world.ForEachTile((x, y) =>
            {
                world.HeightMap[x, y] = GetHeightForBiome(world, x, y, xOrigin, yOrigin);
            });
        }

        private float GetHeightForBiome(World world, int x, int y, float xOrigin, float yOrigin)
        {
            var biomeValue = world.GetMetaValue<float[,]>(Constants.BiomesHeightmapMetaKey)[x, y];
            var noiseVal = Mathf.PerlinNoise(
                xOrigin + 1f * x / world.X * scale,
                yOrigin + 1f * y / world.Y * scale
            );
            return Mathf.Pow(biomeValue, biomePower) * noiseVal;
        }
    }
}
