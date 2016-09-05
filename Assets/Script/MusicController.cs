using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MusicController : MonoBehaviour
{
    public string state;
    bool screamPlayedBefore;
    bool smashPlayedBefore;
    bool missedFruitPlayedBefore;
    bool hasStartMenuDisplayed;
    public AudioSource gameAudio;
    public AudioClip screamClip;
    public AudioClip smashClip;
    public AudioClip missedFruitClip;
    //public AudioClip normalGameClip;
    public AudioClip startGameClip;
    public AudioClip gameOverCLip;


    // Use this for initialization
    void Start ()
    {
        //changeState("normalGame");
        screamPlayedBefore = false;
        smashPlayedBefore = false;
        missedFruitPlayedBefore = false;
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (state == "startPage")
        {
            startPage();
        }
        else if (state == "Scream")
        {
            Scream();
        }
        else if (state == "Smash")
        {
            Smash();
        }
        else if (state == "missedFruit")
        {
            missedFruit();
        }
        else if (state == "gameOver")
        {
            gameOver();
        } else if (state == "bequiet")
        {
            beQuiet();
        }
    }

    public void changeState(string newState)
    {
        state = newState; 

    }

    public void startPage()
    {
        playClipOnce(startGameClip);
    }

    public void Scream()
    {
        playClipOnce(screamClip);
    }


    public void playClipOnce(AudioClip clip)
    {
        print(string.Format("play  {0}", clip.name));

        if (gameAudio != null)
        {
            if (gameAudio.clip == clip)
            {
                if (!gameAudio.isPlaying)
                {
                    gameAudio.Play();
                    changeState("bequiet");
                }
            }
            else
            {
                gameAudio.clip = clip;

            }
        }
        //else
        //{
        //    SceneManager.LoadScene("GameOver");
        //}
    }

    public void Smash()
    {
        playClipOnce(smashClip);
    }

    public void missedFruit()
    {
        playClipOnce(missedFruitClip);
    }

    public void gameOver()
    {
        playClipOnce(gameOverCLip);
    }

    public void beQuiet()
    {
        // do nothing
    }
}
