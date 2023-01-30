using UnityEngine;
using UnityEngine.UI;

public class UJL_TapBar : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Image SlidingIcon;
    [SerializeField] private GameObject superSlider;

    [Header("Variables")]
    private RectTransform initialSliderPosition;

    private void Awake()
    {
        initialSliderPosition.position = Vector3.zero;
    }
}
