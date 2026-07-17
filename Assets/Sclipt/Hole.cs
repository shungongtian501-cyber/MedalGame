using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private GameObject floor;

    private int coinCount = 0;

    public void CoinEntered()
    {
        
        coinCount++;

        if (coinCount >= 2)
        {
            floor.SetActive(false);
        }
        Debug.Log(coinCount);
    }

    public void ResetHole()
    {
        coinCount = 0;
        floor.SetActive(true);
    }
}