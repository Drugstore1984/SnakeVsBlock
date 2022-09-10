using UnityEngine;

public class ClampPosition : MonoBehaviour
{
    [SerializeField] private float _minBorder, _maxBorder;
    private void FixedUpdate()
    {
        float _xClamp = Mathf.Clamp(transform.position.x, _minBorder, _maxBorder);
        transform.position = new Vector3(_xClamp, transform.position.y, transform.position.z);
    }
}
