using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinSpawner spawner;
    [SerializeField] AudioSource _SE;

    private void Start()
    {
        spawner = FindFirstObjectByType<CoinSpawner>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            spawner.CanSpawn = true;
        }

        if(collision.gameObject.CompareTag("Pin"))
        {
            Debug.Log("Pinに当たった！");

            _SE.Play();
        }
    }
    
}