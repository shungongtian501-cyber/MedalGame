using UnityEngine;

public class CoinScanaer : MonoBehaviour
{
   [SerializeField] GameObject disappearingFloor;
    [SerializeField] private CoinSpawner coinSpawner;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Destroy(disappearingFloor);
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            coinSpawner.CanSpawn = true;
        }
    }
}
