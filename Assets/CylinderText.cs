using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CylinderText : MonoBehaviour
{
    public TextMeshPro textMeshPro; // TextMeshPro 오브젝트
    public float radius = 5.0f;     // 텍스트가 배치될 원의 반지름
    public float rotationSpeed = 30.0f; // Y축 회전 속도

    private GameObject[] letters;

    void Start()
    {
        // 텍스트의 문자 개수를 가져옴
        int characterCount = textMeshPro.text.Length;
        float angleStep = 360.0f / characterCount; // 각 문자의 각도 간격

        letters = new GameObject[characterCount];

        // 각 문자를 원형으로 배치
        for (int i = 0; i < characterCount; i++)
        {
            char currentChar = textMeshPro.text[i];

            // 각 문자에 대한 위치 계산 (원형 좌표)
            float angle = i * angleStep * Mathf.Deg2Rad;
            Vector3 charPosition = new Vector3(
                Mathf.Cos(angle) * radius, // X좌표
                0,                         // Y좌표 (고정)
                Mathf.Sin(angle) * radius  // Z좌표
            );

            // 문자 객체 생성 및 배치
            GameObject charObject = new GameObject("Char_" + currentChar);
            charObject.transform.position = charPosition;
            charObject.transform.LookAt(new Vector3(0, charObject.transform.position.y, 0)); // 중심을 향하게 회전

            // TextMeshPro 컴포넌트 추가 및 설정
            TextMeshPro individualText = charObject.AddComponent<TextMeshPro>();
            individualText.text = currentChar.ToString();
            individualText.fontSize = 10;
            individualText.alignment = TextAlignmentOptions.Center;

            // 문자를 배열에 저장 (회전 시 사용)
            letters[i] = charObject;
        }
    }

    void Update()
    {
        // 모든 문자를 Y축 기준으로 회전시킴
        foreach (GameObject letter in letters)
        {
            letter.transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}