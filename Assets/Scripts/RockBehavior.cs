using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform position1;
    public Transform position2;
    private float speed = 3.0f;
    private bool switchDirection = false;
    public bool stoleDonut = false;
    private bool moving = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (switchDirection == false && moving)
        {
            GetComponent<SpriteRenderer>().flipX = false;

            transform.position = Vector3.MoveTowards(transform.position, position1.position,
                speed * Time.deltaTime);
        }
        else if (switchDirection == true && moving)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            //transform.Find("Ram Collide")
            transform.position = Vector3.MoveTowards(transform.position, position2.position,
                speed * Time.deltaTime);
        }

        if (transform.position == position1.position)
        {
            switchDirection = true;
        }
        else if (transform.position == position2.position)
        {
            switchDirection = false;
        }
        if(stoleDonut && moving)
        {
            moving = false;
        }
    }
}
