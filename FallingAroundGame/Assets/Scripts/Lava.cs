using UnityEngine;

public class Lava : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.SetActive(false);
        }
    }
}
