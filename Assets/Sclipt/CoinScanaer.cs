using UnityEngine;

public class CoinScanaer : MonoBehaviour
{
    [SerializeField] GameObject disappearingFloor;

    private CoinSpawner coinSpawner;

    private void Start()
    {
        coinSpawner = FindFirstObjectByType<CoinSpawner>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            disappearingFloor.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            coinSpawner.CanSpawn = true;
        }
    }
}