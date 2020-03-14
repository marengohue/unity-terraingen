namespace Itransition.TerrainGen.Biomes
{
    /// <inheritdoc cref="Biome"/>
    public class BiomeForest : Biome
    {
        public override string Name => nameof(BiomeForest);
        public override float HeightMin => 0.4f;
        public override float HeightMax => 0.6f;
        public override float HeightSplatTolerance => 0.05f;
        public override int SplatMapIndex => 0;
    }
}
