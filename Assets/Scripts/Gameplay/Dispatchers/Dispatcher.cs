using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Dispatchers
{
    public abstract class Dispatcher : MonoBehaviour 
    {
        public List<GameObject> spawnPoint;
        public abstract void Spawn(GameObject gameObjectToSpawn);
    }
}
