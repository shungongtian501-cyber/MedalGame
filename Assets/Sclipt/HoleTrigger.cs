using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    private HoleBase hole;

    private void Awake()
    {
        hole = GetComponentInParent<HoleBase>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log($"{other.name} が {gameObject.name} に入った");

            hole.CoinEntered();
        }
    }
}