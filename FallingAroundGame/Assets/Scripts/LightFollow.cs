using UnityEngine;

public class LightFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed;
    [SerializeField] Vector3 offset;

    [Space]
    private new Light light;
    [SerializeField] private GameObject gameManager;

    void Start()
    {
        light = GetComponent<Light>();
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        if (gameManager.GetComponent<GameManager>().GameOverProperty == true)
        {
            light.GetComponent<Light>().spotAngle += 100f;
        }
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
    }
}
