using UnityEngine;

public class BreakZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            FindAnyObjectByType<CoinSpawner>().CanSpawn = true;
        }
    }
}
