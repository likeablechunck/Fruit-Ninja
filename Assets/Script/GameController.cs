using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public Text  scoreReference;
    public int score;
    public GameObject splashReference;
    public Text looseRefrence;
    public int looseCounter;
    public float fruitSpeed;
    bool scoreChanged;
    // Use this for initialization
    void Start ()
    {
        scoreReference.text = "";
        score = 0;
        looseRefrence.text = "";
        looseCounter = 0;
    }

    void incrementScore(int incr)
    {
        score = score + incr;
        scoreReference.text = (score).ToString();
        FruitSpawner fruitSpawner = Camera.main.GetComponent<FruitSpawner>();
        if (score % 5 == 0)
        {
            if (fruitSpawner.displaySpeed > 0.2)
            {
                fruitSpeed = fruitSpawner.displaySpeed - 0.2f;
                fruitSpawner.ChangeSpeed(fruitSpeed);
                
            }
        }

    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.tag == "Fruit")
                {
                    this.GetComponent<MusicController>().changeState("Smash");
                    print("I selected a fruit");
                    Instantiate(splashReference, new Vector3(Random.Range(-1, 1), Random.Range(0.3f, 0.7f), Random.Range(-6.5f, -7.5f)), 
                        transform.rotation);
                    Destroy(hit.transform.gameObject);
                    incrementScore(1);

                }
                else 
                {
                    this.GetComponent<MusicController>().changeState("Scream");
                    looseCounter++;
                    looseRefrence.text = looseCounter.ToString();
                    //It needs to play a weird Sound to tell the player that it hit the wrong item


                }
              
            }


        }
        

        if (GameObject.FindWithTag("Fruit") !=null )
        {
           
            if(GameObject.FindWithTag("Fruit").transform.position.y < -24)
            {
                this.GetComponent<MusicController>().changeState("missedFruit");
                GameObject.FindWithTag("Fruit").tag = "Lost";

                print("I missed a fruit");
                looseCounter++;
                looseRefrence.text = looseCounter.ToString();

            }
            else
            {
                return;
            }
            

        }

        //check the score, if it is a multipications of 5, then reduce the Repeat time so fruits will show up faster
        //if the DisplaySpeed if 0, then return and stop 

        if(looseCounter >= 5)
        {
           
            SceneManager.LoadScene("GameOver");
        }
    }
}
