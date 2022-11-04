using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level - 1", menuName = "Levels/Gamebord", order = 1)]
public class Gamebordfiles : ScriptableObject
{
    public string bordName;

    public List<int> TileColourList;

    public List<int> TilePowerList;

    public int width;

    public int height;
}
