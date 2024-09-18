using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public TextMeshPro pushtext;  
    public float speed = 3f;  
    public float range = 0.5f; // 이동 범위

    void Update()
    {
        // 빛이 오른쪽에서 왼쪽으로 왕복 이동
        float zPosition = Mathf.PingPong(Time.time * speed, range) - (range / 2);
        pushtext.transform.position = new Vector3(pushtext.transform.position.x, pushtext.transform.position.y, zPosition);
    }
}