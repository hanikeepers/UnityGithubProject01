using UnityEngine;
using UnityEngine.UI;

public class ObjectChanger : MonoBehaviour
{
    public GameObject oldObject; // 원래 오브젝트
    public GameObject newObjectPrefab; // 교체할 오브젝트 프리팹
    public Button changeButton; // 버튼

    private GameObject currentObject; // 현재 활성화된 오브젝트
    private GameObject newObjectInstance; // 교체된 새로운 오브젝트 인스턴스
    private bool isOriginalObjectActive = true; // 원래 오브젝트가 활성화되었는지 여부

    void Start()
    {
        // 시작할 때 원래 오브젝트를 현재 오브젝트로 설정
        currentObject = oldObject;

        // 버튼 클릭 시 오브젝트 교체하는 함수 등록
        changeButton.onClick.AddListener(ChangeObject);
    }

    void ChangeObject()
    {
        if (isOriginalObjectActive)
        {
            // 새로운 오브젝트를 처음 생성하는 경우에만 인스턴스화
            if (newObjectInstance == null)
            {
                newObjectInstance = Instantiate(newObjectPrefab, oldObject.transform.position, oldObject.transform.rotation);
            }

            // 원래 오브젝트를 비활성화하고 새로운 오브젝트를 활성화
            oldObject.SetActive(false);
            newObjectInstance.SetActive(true);
        }
        else
        {
            // 새로운 오브젝트를 비활성화하고 원래 오브젝트를 활성화
            newObjectInstance.SetActive(false);
            oldObject.SetActive(true);
        }

        // 상태를 반전시킴
        isOriginalObjectActive = !isOriginalObjectActive;
    }
}
