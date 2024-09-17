using UnityEngine;
using TMPro;

public class Textmoving : MonoBehaviour
{
    public TextMeshPro textMeshPro; // 3D TextMeshPro 텍스트 연결

    void Update()
    {
        textMeshPro.transform.position += new Vector3(0, 0, -0.05f);
    }
}
