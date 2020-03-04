using System.Security.Claims;
using UnityEngine;

namespace Assets.Scripts.Impl
{
    public class BiomeSplatMapDecorator : IDecorator
    {
        public World Generate(World world)
        {
            var biomeMap = world.GetMetaValue<float[,]>(Constants.BiomesHeightmapMetaKey);

            for (var x = 0; x < world.X - 1; x++)
            {
                for (int y = 0; y < world.Y - 1; y++)
                {
                    world.SplatMap[x, y, (int) EnumBiome.Mountain] = BlendOntoRange(biomeMap[x, y], 0.6f, 1f, 0.1f);
                    world.SplatMap[x, y, (int) EnumBiome.Forest] = BlendOntoRange(biomeMap[x, y], 0.3f, 0.6f, 0.1f);
                    world.SplatMap[x, y, (int) EnumBiome.Desert] = BlendOntoRange(biomeMap[x, y], 0f, 0.3f, 0.1f);
                }
            }

            return world;
        }

        private float BlendOntoRange(float value, float min, float max, float tolerance)
        {
            if (value >= min && value <= max)
            {
                return 1f;
            }

            if (value < min && value > min - tolerance)
            {
                return 1f - (min - value) / tolerance;
            }

            if (value > max && value < max + tolerance)
            {
                return 1f - (value - max) / tolerance;
            }

            return 0f;
        }
    }
}
