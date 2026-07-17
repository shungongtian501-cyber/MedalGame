using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    [SerializeField] private Hole hole;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            hole.CoinEntered();
        }
    }
}