using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Rotation : MonoBehaviour
{
    public GameObject Bus;
    public GameObject Taxi;
    public GameObject Police;
    public float rotationSpeed = 5f;
    private GameObject currentObject;
    private bool isButtonRRPressed = false;
    private bool isButtonRLPressed = false;
    private bool isInfo = false;
    public TMP_Text ScrollText;
    public GameObject ScrollVieww;
    private string BusInfo = "Model Name: Bus\nModel Color: Blue A\nModel Size: Large";
    private string TaxiInfo = "Model Name: Taxi car\nModel Color: Yellow A\nModel Size: Standart";
    private string PoliceInfo = "Model Name: Police car\nModel Color: White-Black A\nModel Size: Standart";
    private Vector3 lastMousePosition;
    private Vector3 startPosition;
    private Vector3 prevPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentObject = Taxi;
        Taxi.SetActive(true);
        Bus.SetActive(false);
        Police.SetActive(false);
        ScrollVieww.SetActive(isInfo);
        ScrollText.text = TaxiInfo;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentObject.SetActive(false); 
            currentObject = (currentObject == Taxi) ? Police : (currentObject == Police) ? Bus : Taxi;
            currentObject.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            currentObject.transform.Rotate(Vector3.up, -delta.x * rotationSpeed * Time.fixedDeltaTime);
            lastMousePosition = Input.mousePosition;
        }
        foreach (var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                startPosition = touch.position;
                prevPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 delta = new Vector3(touch.position.x, touch.position.y, 0) - prevPosition;
                transform.Rotate(Vector3.up, -delta.x * rotationSpeed * Time.deltaTime);
                prevPosition = touch.position;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isButtonRRPressed)
        {
            currentObject.transform.Rotate(Vector3.up, 90 * Time.fixedDeltaTime);
            
        }
        if (isButtonRLPressed)
        {
            currentObject.transform.Rotate(Vector3.up, -90 * Time.fixedDeltaTime);
        }
    }

    public void RotateRightDown()
    {
        isButtonRRPressed = true;
    }

    public void RotateRightUp()
    {
        isButtonRRPressed = false;
    }

    public void RotateLeftDown()
    {
        isButtonRLPressed = true;
    }

    public void RotateLeftUp()
    {
        isButtonRLPressed = false;
    }

    public void ChangeObject()
    {
        currentObject.SetActive(false); 
        var temp = currentObject.transform.rotation;
        currentObject = (currentObject == Taxi) ? Police : (currentObject == Police) ? Bus : Taxi;
        ScrollText.text = (currentObject == Taxi) ? TaxiInfo : (currentObject == Police) ? PoliceInfo : BusInfo;
        currentObject.transform.rotation = temp;
        currentObject.SetActive(true);
    }

    public void InfoClick()
    {
        isInfo = (isInfo) ? false : true;
        ScrollVieww.SetActive(isInfo);
    }
}
