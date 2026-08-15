using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CorrectCoin : MonoBehaviour
{
    [SerializeField] UnityEvent _WhenFPushed;
    [SerializeField] Animator _anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _anim.Play("CorrectButton");
            _WhenFPushed.Invoke();
        }
        else
            _anim.Play("No");
        
    }
   
    
}
