using UnityEngine;


public class Initializer : MonoBehaviour
{
    [Header("Objects added must implement IInitializable!")]
    [SerializeReference] private Object[] initializables;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        foreach (IInitializable initializable in initializables)
        {
            initializable.Initialize();
        }
    }

    private void OnValidate()
    {
        for (int i = 0; i < initializables.Length; i++)
        {
            if (!(initializables[i] is IInitializable))
            {
                initializables[i] = null;
                Debug.LogError("Object does not implement IInitializable!");
            }
        }
    }
}