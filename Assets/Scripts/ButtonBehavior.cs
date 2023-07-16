using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    int dialogueNum = 0;
    //GameObject[] bubbles;

    private void Update()
    {
        if (dialogueNum == 0)
        {
            transform.Find("SB1").gameObject.SetActive(true);

        }
        if (dialogueNum == 1)
        {
            transform.Find("SB1").gameObject.SetActive(false);
            transform.Find("SB2").gameObject.SetActive(true);

        }
        if (dialogueNum == 2)
        {
            SceneManager.LoadScene("Level0");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Cutscene0");
    }

    public void CutsceneScroller()
    {
        //bubbles[0] = transform.Find("SB1").gameObject;
        //bubbles[1] = transform.Find("SB2").gameObject;
        //transform.Find("SB1").gameObject.SetActive(true);
        dialogueNum++;
    }
    
}
