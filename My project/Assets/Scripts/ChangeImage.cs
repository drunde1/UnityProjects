using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image img;
    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
    public Sprite img4;
    // Start is called before the first frame update
    void Start()
    {
        img.sprite = img1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite()
    {
        img.sprite = (img.sprite == img1) ? img2 : (img.sprite == img2) ? img3 : (img.sprite == img3) ? img4 : img1;
    }
}
