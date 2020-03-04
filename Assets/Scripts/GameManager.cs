using Assets.Impl;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets
{
    public class GameManager : MonoBehaviour
    {
        public Terrain Terrain;

        private ITerrainGenerator generator;

        [UsedImplicitly]
        public void Awake()
        {
            generator = new TerrainGenerator();
        }

        [UsedImplicitly]
        public void Start()
        {
            Terrain.terrainData.SetHeights(
                xBase: 0, yBase:0,
                generator.BuildHeightMap());
        }

    }
}

