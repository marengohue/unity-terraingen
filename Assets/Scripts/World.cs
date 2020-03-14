using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Itransition.TerrainGen
{
    /// <summary>
    /// World class containing information about the procedurally generated world
    /// </summary>
    public class World
    {
        /// <summary>
        /// Splat map item count
        /// </summary>
        public const int TextureCount = 3;

        /// <summary>
        /// Randomizer used by the world
        /// </summary>
        public Random Random { get; }

        /// <summary>
        /// SizeX-size of the world heightmap
        /// </summary>
        public int SizeX { get; }

        /// <summary>
        /// SizeY-size of the world heightmap
        /// </summary>
        public int SizeY { get; }

        /// <summary>
        /// SizeX-size of the world splatmap
        /// </summary>
        public int SplatX => SizeX - 1;

        /// <summary>
        /// SizeY-size of the world splatmap
        /// </summary>
        public int SplatY => SizeY - 1;

        /// <summary>
        /// World's mutable heightmap
        /// </summary>
        public float[,] HeightMap { get; }

        /// <summary>
        /// World's mutable splatmap
        /// </summary>
        public float[,,] SplatMap { get; }

        /// <summary>
        /// Tree positions
        /// </summary>
        public IList<Vector3> Trees { get; }

        /// <summary>
        /// Generation process step outputs and world metadata
        /// </summary>
        private readonly IDictionary<string, object> metadata;

        /// <summary>
        /// Initializes a reference of <see cref="World"/>
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        /// <param name="random"></param>
        public World(int sizeX, int sizeY, Random random)
        {
            Random = random;
            SizeX = sizeX;
            SizeY = sizeY;
            HeightMap = new float[sizeX, sizeY];
            SplatMap = new float[sizeX - 1, sizeY - 1, TextureCount];
            Trees = new List<Vector3>();
            metadata = new Dictionary<string, object>();
        }
        
        /// <summary>
        /// Get the metadata value used in the worldgen process by it's name
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public TValue GetMetaValue<TValue>(string name)
            where TValue : class
        {
            if (metadata.ContainsKey(name))
            {
                return metadata[name] as TValue;
            }
            return null;
        }

        /// <summary>
        /// Set a meta value with a given name
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetMetaValue<TValue>(string name, TValue value)
            where TValue : class
        {
            metadata[name] = value;
        }
    }
}
