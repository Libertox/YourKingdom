using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Kingdom.MapHandler
{
    public class TilemapHandler
    {
        public static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
        {
            TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
            int counter = 0;

            foreach (var v in area.allPositionsWithin)
            {
                Vector3Int pos = new Vector3Int(v.x, v.y, 0);
                array[counter] = tilemap.GetTile(pos);
                counter++;
            }

            return array;
        }
        public static void SetTilesBlock(BoundsInt area, TileBase tilesToFile, Tilemap tilemap)
        {
            int size = area.size.x * area.size.y * area.size.z;
            TileBase[] tileArray = new TileBase[size];
            FileTiles(tileArray, tilesToFile);
            tilemap.SetTilesBlock(area, tileArray);
        }
        public static void FileTiles(TileBase[] arr, TileBase tilesToFill)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = tilesToFill;
        }
    }
}