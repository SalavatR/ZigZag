using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName =  "Create game configuration")]
public class GameConfig : ScriptableObject
{
    public float ballSpeed;
    public int startTilesCount;

    [Range(1, 100)] public int ScoreObjectChance = 30;
}