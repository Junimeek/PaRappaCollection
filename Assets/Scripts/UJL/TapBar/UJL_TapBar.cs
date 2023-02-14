using UnityEngine;
using UnityEngine.UI;

public class UJL_TapBar : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Image SlidingIcon;
    [SerializeField] private GameObject superSlider;

    [Header("Variables")]
    //[SerializeField] private RectTransform initialSliderPosition;
    [SerializeField] private Vector3 initialSliderPosition;
    [SerializeField] private float currentyoffset;
    [SerializeField] private float timePerPixels;

    private FireBeats beatscript;
    private GameManager gameManager;

    private void Awake()
    {
        initialSliderPosition = new Vector3(-95, 88, 0);
        superSlider.transform.localPosition = initialSliderPosition;
        beatscript = FindObjectOfType<FireBeats>();
    }

    private void Start()
    {
        timePerPixels = gameManager.curBPM;
    }

    private void Update()
    {
        currentyoffset = currentyoffset+(((float)beatscript.bpm/4.5f)*Time.deltaTime);
        superSlider.transform.localPosition = new Vector3(-95, currentyoffset, 0);
    }

    private void FixedUpdate()
    {
        //superSlider.transform.localPosition = new Vector3(-95, currentyoffset, 0);
    }
}
