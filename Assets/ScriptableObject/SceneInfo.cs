
using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence")]

public class SceneInfo : ScriptableObject
{
    public bool spawnDefault = false;
    public bool hasVisited = false;
    public Vector2 spawnPoint = new Vector2();
}
