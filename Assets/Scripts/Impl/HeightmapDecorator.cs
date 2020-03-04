using UnityEngine;

namespace Assets.Scripts.Impl
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
            for (var x = 0; x < world.X; x++)
            {
                for (int y = 0; y < world.Y; y++)
                {
                    world.HeightMap[x, y] = GetHeightForBiome(world, x, y, xOrigin, yOrigin);
                }
            }
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
