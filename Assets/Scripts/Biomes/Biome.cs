namespace Itransition.TerrainGen.Biomes
{
    public abstract class Biome
    {
        public abstract float HeightMin { get; }

        public abstract float HeightMax { get; }

        public abstract float HeightSplatTolerance { get; }

    }
}
