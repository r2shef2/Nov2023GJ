using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxAmount = 0.1f;

    [SerializeField]
    private Camera mainCamera;

    private float startingX;

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        float distance = cameraPosition.x * parallaxAmount;

        transform.position = new Vector3(startingX + distance, transform.position.y, transform.position.z);
    }
}
