using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    [SerializeField]
    //private GameObject splashReference;	
	
    void Start()
    {
		
    }
    
    void Update()
    {
        /* Remove fruit if out of view and add 1 to a counter to show u lost one */
        if (gameObject.transform.position.y < -30)
        {
           
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Line")
        {
			Camera.main.GetComponent<AudioSource>().Play();
			Destroy(gameObject);

 

			
        }
    }
}