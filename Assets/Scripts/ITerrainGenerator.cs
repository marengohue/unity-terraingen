using System;

namespace Assets
{
    interface ITerrainGenerator
    {
        float[,] BuildHeightMap(int xSize, int ySize);
    }
}
