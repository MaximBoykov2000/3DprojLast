using UnityEngine;


public class TimedLife : MonoBehaviour
{
    public float time = 2;
    void Start()
    {
        Destroy(gameObject, time);
    }
}
