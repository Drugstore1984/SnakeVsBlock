using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _progressBar;
    private SnakeTail snakeTail;
    [SerializeField] private StartPlatform startPlatform;
    private FinishPlatform finishPlatform;
    private float startZ;
    private float finishZ;

    private void Start()
    {
        SetProgressBarParameters();
    }
    void Update()
    {
        float currentZlocal = snakeTail.transform.position.z;
        float t = Mathf.InverseLerp(startZ, finishZ, currentZlocal);
        _progressBar.value = t;
    }
    public void SetProgressBarParameters()
    {
        snakeTail = FindObjectOfType<SnakeTail>();
        startPlatform = FindObjectOfType<StartPlatform>();
        finishPlatform = FindObjectOfType<FinishPlatform>();

        startZ = startPlatform.transform.position.z;
        finishZ = finishPlatform.transform.position.z;
    }
}
