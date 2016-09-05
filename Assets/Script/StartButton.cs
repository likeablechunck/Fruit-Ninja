using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    
    bool isPlaying;
    
    void Start()
    {
        isPlaying = false;
    }

	// Use this for initialization
	void Update ()
    {
        MusicController mc = Camera.main.GetComponent<MusicController>();
        if (!isPlaying)
        {
            mc.changeState("startPage");
        }
        else
        {
            return;
        }

        
	
	}
	
	
    public void OnClick()
    {
        
        SceneManager.LoadScene("Main");
    }
}
