using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]GameObject CoinPrefab;
    public bool CanSpawn = true;
    void Update()
    {
        //Debug.Log(GameManager.Instance);
        if (Input.GetKeyDown(KeyCode.Space) && CanSpawn == true)
        {
            Instantiate(CoinPrefab);
            CanSpawn = false;
            GameManager.Instance.playerCoin -= 1;
            GameManager.Instance.UpdateUI();
        }
    }
}
