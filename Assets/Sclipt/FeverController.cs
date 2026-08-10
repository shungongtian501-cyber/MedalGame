using UnityEngine;
using UnityEngine.Events;

public class FeverController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private UnityEvent onFeverAnimationFinished;

    private void Start()
    {
        animator.SetTrigger("StartFever");
    }

    // Animation Eventから呼ばれる
    public void OnFeverAnimationFinished()
    {
        onFeverAnimationFinished.Invoke();
    }
}