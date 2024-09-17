using UnityEngine;
using TMPro;

public class TextmovingR : MonoBehaviour
{
    public TextMeshPro textMeshPro; // 3D TextMeshPro 텍스트 연결

    void Update()
    {
        // 텍스트를 Y축으로 회전
        textMeshPro.transform.Rotate(Vector3.up * 90 * Time.deltaTime);
    }
}
