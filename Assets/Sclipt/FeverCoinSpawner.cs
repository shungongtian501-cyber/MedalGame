using Unity.VisualScripting;
using UnityEngine;

public class FeverCoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject CoinPrefab;
    public bool CanSpawn = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CanSpawn == true)
        {
            Instantiate(CoinPrefab);
            CanSpawn = false;
        }
    }
    public void StartSpawn()
    {
        CanSpawn = true;
    }
}
