using UnityEngine;

public class FeverBreakZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            FindAnyObjectByType<FeverCoinSpawner>().CanSpawn = true;
        }
    }
}
