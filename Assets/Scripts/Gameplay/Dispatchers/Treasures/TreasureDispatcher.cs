using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Dispatchers.Treasures
{
    public class TreasureDispatcher : Dispatcher
    {
        [SerializeField] private CinemachineVirtualCamera hintCamera;
        private List<GameObject> TreasureSpawnPoints => spawnPoint;

        private int _lastSpawnPoint = -1;

        public override void Spawn(GameObject treasure)
        {
            int location = Random.Range(0, TreasureSpawnPoints.Count);
            if (location == _lastSpawnPoint)
                location = (location + 2) % TreasureSpawnPoints.Count;
            
            GameObject newTreasure = Instantiate(treasure, TreasureSpawnPoints[location].transform);
            hintCamera.Follow = newTreasure.transform;
            hintCamera.LookAt = newTreasure.transform;

            _lastSpawnPoint = location;
        }
    }
}