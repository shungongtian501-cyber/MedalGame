using UnityEngine;
using UnityEngine.Events;

public class CorrectCoin : MonoBehaviour
{
    [SerializeField] UnityEvent _WhenFPushed;
    [SerializeField] Animator _anim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _anim.Play("CorrectButton");
            _WhenFPushed.Invoke();
        }
    }
}