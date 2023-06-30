using UnityEngine;


public class ResourceDrain : MonoBehaviour
{
    public string resourceName;
    public float drainPerSecond = 0.3f;
    private PlayerResource resource;

    void Start()
    {
        resource = PlayerResource.Find(resourceName);
    }

    void Update()
    {
        resource.ChangeValue(-drainPerSecond * Time.deltaTime);
    }
}
