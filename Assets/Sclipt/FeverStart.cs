using UnityEngine;

public class FeverStart : MonoBehaviour
{
    [SerializeField] private CoinSpawner coinSpawner;

    private void Start()
    {
        coinSpawner.CanSpawn = false;
    }

    public void AnimationFinished()
    {
        coinSpawner.CanSpawn = true;
    }
}