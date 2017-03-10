using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class TranslateUIFollowObject : MonoBehaviour
{
    public GameObject target;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 pos = RectTransformUtility.WorldToScreenPoint(Camera.main, target.transform.position);
            rectTransform.position = pos;
        }
    }
}
