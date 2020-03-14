namespace Itransition.TerrainGen.Biomes
{
    /// <inheritdoc cref="Biome"/>
    public class BiomeMountain : Biome
    {
        public override string Name => nameof(BiomeMountain);
        public override float HeightMin => 0.6f;
        public override float HeightMax => 1.0f;
        public override float HeightSplatTolerance => 0.05f;
        public override int SplatMapIndex => 2;
    }
}
