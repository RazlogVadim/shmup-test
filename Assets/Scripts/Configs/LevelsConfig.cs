using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "LevelsConfig", menuName = "Scriptable Objects/LevelsConfig")]
    public class LevelsConfig : ScriptableObject
    {
        public int LevelsAmount;
    }
}