using Itransition.TerrainGen.Biomes;
using Itransition.TerrainGen.Extensions;

namespace Itransition.TerrainGen.Decorators
{
    public class BiomeSplatMapDecorator : IDecorator
    {
        public World Generate(World world)
        {
            var biomeMap = world.GetMetaValue<float[,]>(Keys.BiomesHeightmapMetaKey);
            BiomeIndex.AllBiomes.ForEach(biome => { ApplyBiomeAndSaveColormap(world, biomeMap, biome); });
            return world;
        }

        private void ApplyBiomeAndSaveColormap(World world, float[,] biomeMap, Biome biome)
        {
            var biomeColorMap = new float[world.SplatX, world.SplatY];
            world.ForEachSplatTile((x, y) =>
            {
                var color = BlendOntoRange(
                    biomeMap[x, y],
                    biome.HeightMin,
                    biome.HeightMax,
                    biome.HeightSplatTolerance);
                world.SplatMap[x, y, biome.SplatMapIndex] = color;
                biomeColorMap[x, y] = color;
            });
            world.SetMetaValue(Keys.GetBiomeColorMetaKey(biome), biomeColorMap);
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
