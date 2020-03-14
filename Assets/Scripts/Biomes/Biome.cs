namespace Itransition.TerrainGen.Biomes
{
    public abstract class Biome
    {
        /// <summary>
        /// Internal Name of the biome
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Minimal height value to apply this biome's splat map
        /// </summary>
        public abstract float HeightMin { get; }

        /// <summary>
        /// Maximum height value to apply this biome's splat map
        /// </summary>
        public abstract float HeightMax { get; }

        /// <summary>
        /// Maximum distance outside of min-max range that splat map is going to be blended on
        /// </summary>
        public abstract float HeightSplatTolerance { get; }

        /// <summary>
        /// Index of the texture in the splat map
        /// </summary>
        public abstract int SplatMapIndex { get; }

    }
}
