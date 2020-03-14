using System.Collections.Generic;

namespace Itransition.TerrainGen.Biomes
{
    public static class BiomeIndex
    {
        public static BiomeForest Forest = new BiomeForest();

        public static BiomeDesert Desert = new BiomeDesert();

        public static BiomeMountain Mountain = new BiomeMountain();

        public static List<Biome> AllBiomes = new List<Biome>
        {
            Forest,
            Desert,
            Mountain
        };
    }
}
