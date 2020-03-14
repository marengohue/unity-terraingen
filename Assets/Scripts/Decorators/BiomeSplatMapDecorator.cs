using Itransition.TerrainGen.Extensions;

namespace Itransition.TerrainGen.Decorators
{
    public class BiomeSplatMapDecorator : IDecorator
    {
        public World Generate(World world)
        {
            var biomeMap = world.GetMetaValue<float[,]>(Constants.BiomesHeightmapMetaKey);
            var forestColors = new float[world.X, world.Y];

            world.ForEachSplatTile((x, y) =>
            {
                world.SplatMap[x, y, (int)EnumBiome.Mountain] = BlendOntoRange(biomeMap[x, y], 0.6f, 1f, 0.1f);
                var forestColor = BlendOntoRange(biomeMap[x, y], 0.3f, 0.6f, 0.15f);
                world.SplatMap[x, y, (int)EnumBiome.Forest] = forestColor;
                forestColors[x, y] = forestColor;
                world.SplatMap[x, y, (int)EnumBiome.Desert] = BlendOntoRange(biomeMap[x, y], 0f, 0.4f, 0.1f);
            });

            world.SetMetaValue(Constants.ForestColorMetaKey, forestColors);
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
