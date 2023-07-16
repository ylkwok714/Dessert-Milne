using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DonutCollection : MonoBehaviour
{
    public static int numDonutsCollected = 0;
    public static bool enteredSecretLevel = false;
    [SerializeField]
    private TextMeshProUGUI? donutText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        donutText.text = "x " + numDonutsCollected;
    }
    /*private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.transform.tag == "Donut")
        {
            numDonutsCollected++;
            Debug.Log(numDonutsCollected);
        }
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Donut"))
        {
            //collision.transform.parent = this.transform;
            numDonutsCollected++;
            Debug.Log (numDonutsCollected);
            Destroy(collision.gameObject);
        }
    }

}
