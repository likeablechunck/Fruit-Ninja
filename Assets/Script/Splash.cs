using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
    private Color randomAlpha;
    private float currentAlpha;

    void Start()
    {
        randomAlpha = new Color(1, 1, 1, Random.Range(0.3f, 0.5f));
        gameObject.GetComponent<Renderer>().material.color = randomAlpha;
        InvokeRepeating("ReduceAlpha", 0.3f, 0.3f);
    }

    void ReduceAlpha()
    {
        currentAlpha = gameObject.GetComponent<Renderer>().material.color.a;
        
        if (gameObject.GetComponent<Renderer>().material.color.a <= 0.1f)
        {
            Destroy(gameObject);
        } else
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, currentAlpha - 0.1f);
        }
    }
}
