using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]GameObject CoinPrefab;
    public bool CanSpawn = true;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && CanSpawn == true)
        {
            Transform.Instantiate(CoinPrefab);
            CanSpawn = false;
        }
        Debug.Log(CanSpawn);
    }
}
