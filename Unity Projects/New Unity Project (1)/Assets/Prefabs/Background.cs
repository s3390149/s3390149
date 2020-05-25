using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] float backgroundSpeed = 0.1f;
    Material myMaterial;
    Vector2 offSet;
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0, backgroundSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
