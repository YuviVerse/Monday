using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SeasonData", menuName = "ScriptableObjects/SeasonData")]
    public class SeasonData : ScriptableObject
    {
        public int topScore;
        public int currentSeasonScore;
    }
}
