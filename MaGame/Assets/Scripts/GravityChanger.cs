using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    private bool gravityChanged = false;
    private bool onGround = false;
    private float gravityValue;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && onGround && !(Input.mousePosition.x < 130.62f && Input.mousePosition.y > 973.53f) && !GlobalSettings.isPaused)
        {

            if (gravityChanged)
            {
                Physics.gravity = new Vector2(0, -gravityValue); 
            }
            else
            {
                Physics.gravity = new Vector2(0, gravityValue);
            }

            gravityChanged = !gravityChanged;
        }
    }

    private void OnEnable()
    {
        gravityValue = (GlobalSettings.gameSpeed == 0) ? 18.75f : (GlobalSettings.gameSpeed == 1) ? 30f : 48;
    }

    private void OnDisable()
    {
        Physics.gravity = new Vector2(0, -9.81f);
    }
}
