using UnityEngine;

public class MoveLight : MonoBehaviour
{
    public Light pointLight;  // Point Light를 할당
    public float speed = 5f;  // 빛 이동 속도
    public float range = 10f; // 이동 범위

    void Update()
    {
        // 빛이 오른쪽에서 왼쪽으로 왕복 이동
        float xPosition = Mathf.PingPong(Time.time * speed, range) - (range / 2);
        pointLight.transform.position = new Vector3(xPosition, pointLight.transform.position.y, pointLight.transform.position.z);
    }
}
