using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BadHole : MonoBehaviour
{
   // [SerializeField] private Text resultText;
    [SerializeField] UnityEvent _Actives;
    [SerializeField] Animator _FadeOut;
    [SerializeField] private GameObject _syuuryouObject;

    public void Start()
    {
        _FadeOut.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Coin"))
            return;

        StartCoroutine(EndFever());
    }

    private IEnumerator EndFever()
    {
        _syuuryouObject.SetActive(true);
        _FadeOut.enabled = true;
       // resultText.text = $"獲得コイン枚数：{CoinData.Instance.feverCoin}";
        _Actives.Invoke();
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("GameScene");
    }
}