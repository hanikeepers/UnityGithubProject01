using UnityEngine;

public class CubeAction : MonoBehaviour
{
    private bool isGrowing = true;  // 객체가 커지고 있는지 여부를 저장
    private Renderer cubeRenderer;  // 큐브의 렌더러를 저장
    private Color growColor = new Color(0.5f, 0f, 0.5f, 0f);  // 커질 때의 보라색 (투명한 보라색)
    private Color shrinkColor = new Color(1f, 1f, 0f, 1f);    // 작아질 때의 노란색 (완전히 불투명한 노란색)
    private float lerpTime = 100f;  // 색이 변화하는 속도
    private float currentLerpTime = 0f;  // Lerp 경과 시간

    void Start()
    {
        // 큐브의 렌더러를 가져옴
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.color = growColor;  // 초기 색상 설정
    }

    void Update()
    {
        // 색상 변화 처리
        currentLerpTime += Time.deltaTime / lerpTime;

        if (isGrowing)
        {
            // 스케일을 키운다
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            transform.rotation *= Quaternion.Euler(0, 500 * Time.deltaTime, 0);

            // 커질 때 색을 보라색(growColor)으로 점차적으로 변화시킴 (점점 진해짐)
            cubeRenderer.material.color = Color.Lerp(cubeRenderer.material.color, growColor, currentLerpTime);

            // 스케일이 5 이상이면 더 이상 커지지 않게 하고, 줄어들도록 설정
            if (transform.localScale.x >= 2f && transform.localScale.y >= 2f && transform.localScale.z >= 2f)
            {
                isGrowing = false;  // 커지는 상태에서 줄어드는 상태로 변경
                currentLerpTime = 0f;  // 색상 전환을 위한 타이머 초기화
            }
        }
        else
        {
            // 스케일을 줄인다
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            transform.rotation *= Quaternion.Euler(0, -500 * Time.deltaTime, 0);

            // 작아질 때 색을 노란색(shrinkColor)으로 점차적으로 변화시킴 (점점 옅어짐)
            cubeRenderer.material.color = Color.Lerp(cubeRenderer.material.color, shrinkColor, currentLerpTime);

            // 스케일이 1 이하로 줄어들면 다시 커지게 설정
            if (transform.localScale.x <= 1f && transform.localScale.y <= 1f && transform.localScale.z <= 1f)
            {
                isGrowing = true;  // 줄어드는 상태에서 커지는 상태로 변경
                currentLerpTime = 0f;  // 색상 전환을 위한 타이머 초기화
            }
        }

        // Lerp 시간이 1을 넘지 않도록 함
        if (currentLerpTime >= 1f)
        {
            currentLerpTime = 1f;
        }
    }
}
