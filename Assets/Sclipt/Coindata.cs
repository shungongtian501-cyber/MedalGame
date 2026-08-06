using UnityEngine;

public class CoinData : MonoBehaviour
{
    public static CoinData Instance;

    public int feverCoin;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}