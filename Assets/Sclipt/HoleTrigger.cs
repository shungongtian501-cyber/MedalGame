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
        // 床が開いている最中は判定しない
        if (GameManager.Instance.IsOpeningFloor) 
            return;

        if (!other.CompareTag("Coin"))
            return;

        Debug.Log($"{other.name} が {gameObject.name} に入った");

        hole.CoinEntered();
    }
}