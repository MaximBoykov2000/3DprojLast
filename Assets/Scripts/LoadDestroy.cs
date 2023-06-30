using UnityEngine;


public class LoadDestroy : MonoBehaviour
{
    [SerializeField] private int id = -1;
    private void OnValidate()
    {
        if (id == -1) id = GetInstanceID();
    }
    private string SaveKey() => "d" + id.ToString();
    private void OnDestroy()
    {
        PlayerPrefs.SetInt(SaveKey(), 0);
    }
    private void Awake()
    {
        if (PlayerPrefs.HasKey(SaveKey()))
        {
            Destroy(gameObject);
        }
    }
}
