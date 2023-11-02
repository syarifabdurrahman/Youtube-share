using Edgar.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Edgar/Examples/Platformer/Post-processing", fileName = "Try")]
public class MyLevelSO : DungeonGeneratorPostProcessingGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        RemoveWallFromDoors(level);
    }

    private void RemoveWallFromDoors(DungeonGeneratorLevelGrid2D level)
    {
        // Get tilemaps yang ingin di delete
        var walls = level.GetSharedTilemaps().Single(x => x.name == "Walls");

        foreach (var roomInstance in level.RoomInstances)
        {
            foreach (var doorInstance in roomInstance.Doors)
            {
                foreach (var point in doorInstance.DoorLine.GetPoints())
                {
                    walls.SetTile(point + roomInstance.Position, null);
                }
            }
        }
    }
}
