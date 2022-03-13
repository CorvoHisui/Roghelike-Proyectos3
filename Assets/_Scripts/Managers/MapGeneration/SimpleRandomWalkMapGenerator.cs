using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleRandomWalkMapGenerator : AbstractMapGenerator
{
    [SerializeField]
    protected SimpleRandomWalkSO randomWalkParameters;

    protected override void RunProceduralGeneration(){
        HashSet<Vector2Int> floorPositions=RunRandomWalk(randomWalkParameters,startPosition);
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions,tilemapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int position)
    {
        var currPosition=position;
        HashSet<Vector2Int> floorPositions=new HashSet<Vector2Int>();
        for (int i = 0; i < parameters.iterations; i++)
        {
            var path=ProceduralGeneratedAlgorithms.SimpleRandomWalk(currPosition,parameters.walkLength);
            floorPositions.UnionWith(path); //add if not duplicate

            if(parameters.startRandomlyEachIteration){
                currPosition=floorPositions.ElementAt(UnityEngine.Random.Range(0,floorPositions.Count));
            }

        }
        return floorPositions;
    }
}
