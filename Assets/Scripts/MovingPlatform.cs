using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform position1, position2;
    private float speed = 3.0f;
    private bool switchDirection = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

        if (switchDirection == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, position1.position,
                speed * Time.deltaTime);
        }
        else if (switchDirection == true)
        {
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& other.GetComponent<CharacterController>().OnGround())
        {
            other.transform.parent = this.transform;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
