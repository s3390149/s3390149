using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed;
    public MeshRenderer bgRend;

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.y += scrollSpeed * Time.deltaTime;

        mat.mainTextureOffset = offset;
    }
}
//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: Learn to Code Making Games. 
//Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].