using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _speed;
    private float leftEdge;
    // Start is called before the first frame update
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 30f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        _speed = (GlobalSettings.gameSpeed == 0) ? 5f : (GlobalSettings.gameSpeed == 1) ? 8f : 11f;
    }
}
