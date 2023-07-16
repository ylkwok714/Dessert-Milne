using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string sceneName;
    public string secretLevelPlatform;
    bool onSecretPlatform = false;
    float secretTimer = 5.0f;
    Rigidbody2D rb;
    //private string level1;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //if slime box collider and secret level collider collide then switch scenes?
        //
        if (onSecretPlatform)
        {
            secretTimer -= Time.deltaTime;
            Debug.Log(secretTimer);
            if(secretTimer < 0) secretTimer = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.gameObject.name == secretLevelPlatform)
        {
            //SceneManager.LoadScene(sceneName);
            
        }
        if(collision.transform.gameObject.name == "To Level 1")
        {
            SceneManager.LoadScene("Level1");
        }
        if (collision.transform.gameObject.name == "To Level 0")
        {
            SceneManager.LoadScene("Level0");
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name == "Sign Range")
        {
            //Debug.Log("Entered sign range");
            collision.transform.parent.Find("Speech Bubble").gameObject.SetActive(true);
        }
        //if (collision.transform.gameObject.name == "SecretDialogueTrigger")
        //{
        //    //Debug.Log("Entered sign range");
        //    collision.transform.parent.Find("Speech Bubble").gameObject.SetActive(true);
        //}
        if (collision.transform.gameObject.name == "Before Purple")
        {
            collision.transform.parent.Find("Before").gameObject.SetActive(true);

        }
        if (collision.transform.gameObject.name == "After Purple")
        {
            collision.transform.parent.Find("After").gameObject.SetActive(true);

        }
        if (collision.transform.gameObject.name == secretLevelPlatform)
        {
            onSecretPlatform = true;
        }

        if (collision.transform.gameObject.name == "Ram Collide")
        {
            //SceneManager.LoadScene("Level0");
            Debug.Log("Hitting ram collider");
            //rb.AddForce(transform.up * 40f);
            if(collision.transform.parent.GetComponent<RockBehavior>().stoleDonut == false)
            {
                collision.transform.parent.GetComponent<RockBehavior>().stoleDonut = true;
                DonutCollection.numDonutsCollected--;
                collision.transform.parent.GetComponent<AudioSource>().Play();

            }
            //if (transform.position.x < collision.transform.position.x)
            //    GetComponent<Rigidbody2D>().AddForce(Vector2.up * 40f);
            //if (transform.position.x > collision.transform.position.x)
            //    GetComponent<Rigidbody2D>().AddForce(Vector2.up * 40f);

        }
        if(collision.transform.gameObject.name == "EndGame")
        {
            if(DonutCollection.numDonutsCollected != 10)
            {
                Application.Quit();
            }
            else
            {
                DonutCollection.numDonutsCollected = 0;
                SceneManager.LoadScene("StartMenu");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name == "Sign Range")
        {
            //Debug.Log("Entered sign range");
            collision.transform.parent.Find("Speech Bubble").gameObject.SetActive(false );
        }
        if (collision.transform.gameObject.name == "Before Purple")
        {
            collision.transform.parent.Find("Before").gameObject.SetActive(false);

        }
        if (collision.transform.gameObject.name == "Before Purple")
        {
            collision.transform.parent.Find("After").gameObject.SetActive(false);

        }
        if (collision.transform.gameObject.name == secretLevelPlatform)
        {
            onSecretPlatform = false;
            secretTimer = 5.0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.gameObject.name == secretLevelPlatform && onSecretPlatform && DonutCollection.enteredSecretLevel == false)
        {
            if(secretTimer <= 0)
            {
                DonutCollection.enteredSecretLevel = true;
                Debug.Log(DonutCollection.enteredSecretLevel);
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
