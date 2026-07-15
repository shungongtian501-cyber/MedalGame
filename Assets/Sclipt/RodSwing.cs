using UnityEngine;

public class RodSwing : MonoBehaviour
{
    [SerializeField] private float maxAngle = 35f; // 最大角度
    [SerializeField] private float swingSpeed = 2f; // 揺れる速さ

    void Update()
    {
        float angle = Mathf.Sin(Time.time * swingSpeed) * maxAngle;
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}