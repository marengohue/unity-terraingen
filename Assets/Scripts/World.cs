using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class World
    {
        public const int TextureCount = 3;

        public World(int x, int y)
        {
            HeightMap = new float[x, y];
            SplatMap = new float[x - 1, y - 1, TextureCount];
            Trees = new List<Vector2>();
        }

        public float[,] HeightMap { get; set; }

        public float[,,] SplatMap { get; set; }

        public IEnumerable<Vector2> Trees { get; set; }
}
}
