using UnityEngine;
using System.Collections;

public class MouseDrag : MonoBehaviour
{
    public Renderer rend;

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnMouseDrag()
    {
        rend.material.color -= Color.yellow * Time.deltaTime;
    }
}
