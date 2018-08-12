using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject normalFloor;
    [SerializeField] private GameObject lavaFloor;
    [SerializeField] private int columns = 20;
    [SerializeField] private int rows = 20;
    private Transform floorHolder;
    private Transform lavaHolder;

    void Start ()
    {
        LavaSetup();
        FloorSetup();
	}
	
	void Update ()
    {
        
	}

    private void FloorSetup()
    {
        floorHolder = new GameObject("Floors").transform;
        for(int x=0; x<columns; x++)
        {
            for(int y=0; y<rows; y++)
            {
                GameObject instance = Instantiate(normalFloor, new Vector3(x, 0f, y), Quaternion.identity) as GameObject;
                instance.transform.SetParent(floorHolder);
            }
        }
    }
    private void LavaSetup()
    {
        lavaHolder = new GameObject("Lavas").transform;
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                GameObject instance = Instantiate(lavaFloor, new Vector3(x, -0.5f, y), Quaternion.identity) as GameObject;
                instance.transform.SetParent(lavaHolder);
            }
        }
    }
}
