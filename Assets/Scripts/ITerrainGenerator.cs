using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

namespace Assets
{
    interface ITerrainGenerator
    {
        /// <summary>
        /// Builds a the terrain data
        /// </summary>
        /// <param name="xSize"></param>
        /// <param name="ySize"></param>
        /// <returns></returns>
        World Generate(int xSize, int ySize);

        /// <summary>
        /// Registers the decorator in the generation pipeline
        /// </summary>
        /// <param name="decorator"></param>
        void RegisterDecorator(IDecorator decorator);
    }
}
