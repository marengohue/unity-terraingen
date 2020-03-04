using Assets.Impl;
using Assets.Scripts.Impl;
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
            generator = new TerrainGenerator()
                .RegisterDecorator(new BiomeDecorator())
                .RegisterDecorator(new HeightmapDecorator(noiseScale: 5, biomePower: 2.3f))
                .RegisterDecorator(new BiomeSplatMapDecorator());
        }

        [UsedImplicitly]
        public void Start()
        {
            var world = generator.Generate(513, 513);
            Terrain.terrainData.SetHeights(0, 0, world.HeightMap);
            Terrain.terrainData.SetAlphamaps(0, 0, world.SplatMap);
        }
    }
}

