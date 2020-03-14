using Itransition.TerrainGen.Biomes;

namespace Itransition.TerrainGen
{
    /// <summary>
    /// Metadata key constants
    /// </summary>
    public class Constants
    {
        public const string BiomesMetaKey = "biomeMap";

        public const string BiomesHeightmapMetaKey = "biomesHightmap";

        public static string GetBiomeColorMetaKey(Biome b)
        {
            return $"biomeColor_{b.Name}";
        }
    }
}
