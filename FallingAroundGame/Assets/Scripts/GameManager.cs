using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int columns = 20;
    [SerializeField] private int rows = 20;

    [Header("FloorSettings")]
    [SerializeField] private GameObject normalFloor;
    [SerializeField] private GameObject lavaFloor;

    [Space]
    [Header("RockSettings")]
    [SerializeField] private GameObject[] rocks;

    private Transform floorHolder;
    private Transform lavaHolder;
    List<GameObject> objs;

    [SerializeField] private float secondsToDestroy;

    void Start ()
    {
        LavaSetup();
        FloorSetup();

        objs = GameObject.FindObjectsOfType<GameObject>().Where(obj => obj.name.Contains("Floor")).ToList();
        StartCoroutine(DestroyFloor());
    }

    private void FloorSetup()
    {
        floorHolder = new GameObject("Ground").transform;
        for(int x=-1; x<columns +1; x++)
        {
            for(int y=-1; y<rows +1; y++)
            {
                GameObject toInstantiate = normalFloor;
                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    toInstantiate = rocks[Random.Range(0, rocks.Length)];
                }

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, 0f, y), Quaternion.identity) as GameObject;
                instance.transform.SetParent(floorHolder);
            }
        }
    }

    private void LavaSetup()
    {
        lavaHolder = new GameObject("Lavas").transform;
        for (int x = -1; x < columns +1; x++)
        {
            for (int y = -1; y < rows +1; y++)
            {
                GameObject instance = Instantiate(lavaFloor, new Vector3(x, -0.5f, y), Quaternion.identity) as GameObject;
                instance.transform.SetParent(lavaHolder);
            }
        }
    }

    private IEnumerator DestroyFloor()
    {
        while(true && objs.Count > 0)
        {
            //Debug.Log(Random.Range(0, objs.Count));
            int randomElement = Random.Range(0, objs.Count);
            objs.ElementAt(randomElement).SetActive(false);

            yield return new WaitForSeconds(secondsToDestroy);
        }
        
    }
}
