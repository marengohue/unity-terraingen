using UnityEngine;

namespace Assets.Scripts.Impl
{
    class TreePlacerDecorator : IDecorator
    {
        public readonly float WorldHeight;
        
        public TreePlacerDecorator(float worldHeight)
        {
            WorldHeight = worldHeight;
        }

        public World Generate(World world)
        {
            var forestColors = world.GetMetaValue<float[,]>(Constants.ForestColorMetaKey);

            for (var x = 0; x < world.X; x++)
            {
                for (int y = 0; y < world.Y; y++)
                {
                    if (world.Random.NextDouble() < Mathf.Pow(forestColors[x, y], 3f) * 0.07f)
                    {
                        world.Trees.Add(new Vector3(1f * y / world.Y, world.HeightMap[x, y], 1f * x / world.X));
                    }
                }
            }

            return world;
        }
    }
}
