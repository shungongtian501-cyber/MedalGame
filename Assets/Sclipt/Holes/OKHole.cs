using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OKHole : MonoBehaviour
{
    [SerializeField] private UnityEvent _Activates;
    [SerializeField] private Text ContinueText;
    [SerializeField] GameObject keizokuText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Coin"))
            return;

        StartCoroutine(ContinueFever());
    }

    private IEnumerator ContinueFever()
    {
        
        _Activates.Invoke();
       

        yield return new WaitForSeconds(1f);
        CoinData.Instance.feverCoin += 50;
        ContinueText.text = $"獲得コイン枚数：{CoinData.Instance.feverCoin}";

        keizokuText.SetActive(false);
    }
}