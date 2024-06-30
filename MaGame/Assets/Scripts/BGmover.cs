using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmover : MonoBehaviour
{
    private float _speed;
    [SerializeField] private MeshRenderer _MeshRenderer;
    private Vector2 _MeshOffset;
    // Start is called before the first frame update
    void Start()
    {
        _MeshOffset = _MeshRenderer.sharedMaterial.mainTextureOffset;
    }

    private void OnDisable()
    {
        _MeshRenderer.sharedMaterial.mainTextureOffset = _MeshOffset;
    }
    // Update is called once per frame
    void Update()
    {
        var x = Mathf.Repeat(Time.time * _speed, 1);
        var offset = new Vector2(x, _MeshOffset.y);
        _MeshRenderer.sharedMaterial.mainTextureOffset = offset; 
    }
    private void OnEnable()
    {
        _speed = (GlobalSettings.gameSpeed == 0) ? 0.125f : (GlobalSettings.gameSpeed == 1) ? 0.2f : 0.32f;
    }
}
