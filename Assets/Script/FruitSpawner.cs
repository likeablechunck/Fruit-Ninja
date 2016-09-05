using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    //private GameObject appleReference;
    private Vector3 throwForce;
    public GameObject[] prefabs;
    int arrayLength;
    int IndexRandomSelection;
    public float displaySpeed;
    float oldDisplaySpeed;
    bool invokeOnce;
   

    void Start()
    {
        invokeOnce = true;
        displaySpeed = 1.3f;
        prefabs = Resources.LoadAll<GameObject>("Prefab");
        arrayLength =0;
        throwForce = new Vector3(Random.Range(1,4), 4, 0);

    }

    void Update()
    {
        if (invokeOnce)
        {
            InvokeRepeating("SpawnFruit", 1, displaySpeed);
            invokeOnce = false;
        }
        
        
    }


    void SpawnFruit()
    {

        arrayLength = prefabs.Length;
        IndexRandomSelection = Random.Range(0, arrayLength - 1);
        GameObject items = Instantiate(prefabs[IndexRandomSelection], new Vector3(Random.Range(-24  , 21), Random.Range(-17 , 13.5f), 27), Quaternion.identity) as GameObject;
        items.GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);

    }

    public void ChangeSpeed(float speed)
    {
        oldDisplaySpeed = displaySpeed;
        displaySpeed = speed;

        CancelInvoke("SpawnFruit");

        InvokeRepeating("SpawnFruit", 1, displaySpeed);

    }
}