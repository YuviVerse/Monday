using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Treasure", menuName = "ScriptableObjects/Treasure")]
    public class TreasureCollection : ScriptableObject
    {
        public List<Treasure> treasures;
    }
}

[Serializable]
public class Treasure
{
    public TreasureType type;
    public GameObject prefab;
    public int scoreAmount;
    public Sprite image;
}

public enum TreasureType
{
    CopperCoins,
    SilverCoins,
    GoldCoins
}
