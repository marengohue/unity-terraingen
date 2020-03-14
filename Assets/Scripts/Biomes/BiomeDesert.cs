namespace Itransition.TerrainGen.Biomes
{
    /// <inheritdoc cref="Biome"/>
    public class BiomeDesert : Biome
    {
        public override string Name => nameof(BiomeDesert);
        public override float HeightMin => 0.0f;
        public override float HeightMax => 0.4f;
        public override float HeightSplatTolerance => 0.15f;
        public override int SplatMapIndex => 1;
    }
}
