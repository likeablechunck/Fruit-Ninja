using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetryButtom : MonoBehaviour
{
    bool isPlaying;

    void Start()
    {
        isPlaying = false;
    }

    // Use this for initialization
    void Update()
    {
        MusicController mc = Camera.main.GetComponent<MusicController>();
        if (!isPlaying)
        {
            mc.changeState("gameOver");

        }
        else
        {
            return;
        }



    }


    // Use this for initialization

    public void onClick()
    {
        SceneManager.LoadScene("Main");
    }
}
