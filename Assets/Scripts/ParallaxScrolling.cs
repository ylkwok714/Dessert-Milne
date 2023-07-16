using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public GameObject cam;
    public float parallaxNum;
    private float length;
    private float startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float camMovement = cam.transform.position.x*(1-parallaxNum);
        float distance = cam.transform.position.x * parallaxNum;
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
        if(camMovement > startPosition + length)
        {
            startPosition += length;
        }
        else if(camMovement < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
