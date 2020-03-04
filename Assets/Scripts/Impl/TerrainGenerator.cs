namespace Assets.Impl
{
    class TerrainGenerator : ITerrainGenerator
    {
        public float[,] BuildHeightMap(int xSize, int ySize)
        {
            return new float[ySize, xSize];
        }
    }
}
