using System.Linq;
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
                .RegisterDecorator(new BiomeSplatMapDecorator())
                .RegisterDecorator(new TreePlacerDecorator(worldHeight: 600));
        }

        [UsedImplicitly]
        public void Start()
        {
            var world = generator.Generate(513, 513);
            Terrain.terrainData.SetHeights(0, 0, world.HeightMap);
            Terrain.terrainData.SetAlphamaps(0, 0, world.SplatMap);
            PlaceTrees(world);
            Terrain.Flush();
        }

        private void PlaceTrees(World world)
        {
            var pt = Terrain.terrainData.treePrototypes;
            Terrain.terrainData.SetTreeInstances(world.Trees
                .Select(treePos =>
                    new TreeInstance
                    {
                        position = treePos,
                        prototypeIndex = 0,
                        color = Random.ColorHSV(0.2f, 0.3f, 0.5f, 0.7f, 0.7f, 0.9f),
                        lightmapColor = Color.white,
                        heightScale = 1f,
                        widthScale = 1f,
                        rotation = 0f
                    })
                .ToArray(), true);
        }
    }
}

