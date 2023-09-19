using UnityEngine;
public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    private static T instance;
    public static T Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
