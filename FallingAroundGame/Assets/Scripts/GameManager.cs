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

    //[SerializeField] private GameObject playerGO;

    private Transform floorHolder;
    private Transform lavaHolder;

    void Start ()
    {
        //if(playerGO != null)
        //{
        //    Instantiate(playerGO, new Vector3(10, 0f, 10), Quaternion.identity);
        //}

        LavaSetup();
        FloorSetup();
	}

    private void FloorSetup()
    {
        floorHolder = new GameObject("Floors").transform;
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
}
