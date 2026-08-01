using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // コルーチンに必要

public class FeverAnimator : MonoBehaviour
{
    private Animator _anim;
    private HoleBase[] _allHoles;

    // rnd == 1 が成立したかどうかを記憶する変数
    private bool _isFeverActive = false;
    [SerializeField] UnityEvent _actions;
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        // 【修正】ゲーム内にあるすべての HoleBase（を継承したHole）を自動で探して集める
        _allHoles = FindObjectsByType<HoleBase>(FindObjectsSortMode.None);

        // 見つかったすべての穴に対して、自分自身（this）を登録する
        foreach (HoleBase hole in _allHoles)
        {
            if (hole != null)
            {
                hole.SetFeverAnimator(this);
            }
        }

        // 確認用ログ（7つの穴が見つかれば「見つかった数: 7」と表示されます）
        Debug.Log($"見つかった穴の数: {_allHoles.Length}");

    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.F) || _isFeverActive)
    //    {
    //        //Bool型のパラメーターであるblRotをTrueにする
    //        _anim.SetBool("IsFever", true);
    //        _actions.Invoke();
    //    }
    //    else
    //        _anim.SetBool("IsFever", false);
    //}

    // HoleBase側で rnd == 1 になったときに呼び出される関数
    public void SetFeverFlag(bool active)
    {
        // もし true が送られてきたら、3秒タイマーを開始する
        if (active)
        {
            StartCoroutine(FeverTimerRoutine());
        }
        else
        {
            _isFeverActive = false;
        }
    }
    // 【追加】3秒間だけフラグをTrueにして、自動でFalseに戻すタイマー
    private System.Collections.IEnumerator FeverTimerRoutine()
    {
        _actions.Invoke();
        yield return new WaitForSeconds(2f); // 2秒間ここで待つ
        SceneManager.LoadScene("FeverScene");

    }
}



