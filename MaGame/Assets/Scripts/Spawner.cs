using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _speed;
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        public float spawnTime;
    }
    public SpawnableObject[] objectsDown;
    public SpawnableObject[] objectsUp;
    
    private void OnEnable()
    {
        _speed = (GlobalSettings.gameSpeed == 0) ? 1.6f : (GlobalSettings.gameSpeed == 1) ? 1f : 0.8f;
        Invoke(nameof(SpawnUp), 0f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void SpawnDown()
    {
        var temp = Random.Range(0, 4);
        GameObject obstacle = Instantiate(objectsDown[temp].prefab);
        Invoke(nameof(SpawnUp), _speed * Random.Range(objectsDown[temp].spawnTime - 0.3f, objectsDown[temp].spawnTime));
    }

    private void SpawnUp()
    {
        var temp = Random.Range(0, 4);
        GameObject obstacle = Instantiate(objectsUp[temp].prefab);
        Invoke(nameof(SpawnDown),_speed * Random.Range(objectsDown[temp].spawnTime - 0.3f, objectsDown[temp].spawnTime));
    }
}
