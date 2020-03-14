using System;

namespace Itransition.TerrainGen.Extensions
{
    public static class WorldExtensions
    {
        /// <summary>
        /// Execute a callback for each of the tiles in the world
        /// </summary>
        /// <param name="world">world to operate on</param>
        /// <param name="callback">callback to exec</param>
        public static void ForEachTile(this World world, Action<int, int> callback)
        {
            for (var x = 0; x < world.X; x++)
            {
                for (int y = 0; y < world.Y; y++)
                {
                    callback(x, y);
                }
            }
        }

        /// <summary>
        /// Execute a callback for each of the splat map tiles in the world
        /// </summary>
        /// <param name="world">world to operate on</param>
        /// <param name="callback">callback to exec</param>
        public static void ForEachSplatTile(this World world, Action<int, int> callback)
        {
            for (var x = 0; x < world.X - 1; x++)
            {
                for (int y = 0; y < world.Y - 1; y++)
                {
                    callback(x, y);
                }
            }
        }
    }
}
