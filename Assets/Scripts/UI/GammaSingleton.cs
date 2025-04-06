using UnityEngine;
using UnityEngine.UI;

public class GammaSingleton : MonoBehaviour
{
    public static GammaSingleton Instance;

    [SerializeField]
    private Image gammaImage;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
