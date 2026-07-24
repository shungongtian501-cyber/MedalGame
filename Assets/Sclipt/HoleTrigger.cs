using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    private HoleBase hole;

    // 一度判定したコインを記録
    private HashSet<GameObject> enteredCoins = new HashSet<GameObject>();

    private void Awake()
    {
        hole = GetComponentInParent<HoleBase>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Coin"))
            return;

        // 初めてこのコインを検出したらtrue
        if (enteredCoins.Add(other.gameObject))
        {
            Debug.Log($"{other.name} が {gameObject.name} に入った");

            hole.CoinEntered();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            enteredCoins.Remove(other.gameObject);
        }
    }
}