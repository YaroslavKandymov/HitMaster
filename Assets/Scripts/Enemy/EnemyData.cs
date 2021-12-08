using UnityEngine;

[CreateAssetMenu(fileName = "new EnemyData", menuName = "EnemyData", order = 52)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private Enemy _prefab;

    public Enemy Prefab => _prefab;
}
