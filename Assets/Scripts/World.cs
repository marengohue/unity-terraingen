using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Assets
{
    public class World
    {
        public const int TextureCount = 3;

        private readonly IDictionary<string, object> metadata;

        public Random Random { get; }

        public int X { get; }

        public int Y { get; }

        public World(int x, int y, Random random)
        {
            Random = random;
            X = x;
            Y = y;
            HeightMap = new float[x, y];
            SplatMap = new float[x - 1, y - 1, TextureCount];
            Trees = new List<Vector2>();
            metadata = new Dictionary<string, object>();
        }

        public float[,] HeightMap { get; set; }

        public float[,,] SplatMap { get; set; }

        public IEnumerable<Vector2> Trees { get; set; }

        public TValue GetMetaValue<TValue>(string name)
            where TValue : class
        {
            if (metadata.ContainsKey(name))
            {
                return metadata[name] as TValue;
            }
            return null;
        }

        public void SetMetaValue<TValue>(string name, TValue value)
            where TValue : class
        {
            metadata[name] = value;
        }
    }
}
