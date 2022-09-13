using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SnakeMove : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private float _forwardSpeed;

    private Rigidbody _rb;
    private Vector3 _direction;

    private CinemachineVirtualCamera _cmCamera;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
        _cmCamera = FindObjectOfType<CinemachineVirtualCamera>();
        _cmCamera.Follow = transform;
    }
    private void FixedUpdate()
    {
        GetDirection();
        MoveByMouse();
    }
    private void GetDirection()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue))
            {
                _direction = (hitInfo.point - transform.position);
            }
        }
        else
        {
            _direction = Vector3.zero;
        }
    }
    private void MoveByMouse()
    {
        _rb.velocity = new Vector3(_direction.x * _sideSpeed, 0, _forwardSpeed);
    }
    public void SnakeStop()
    {
        _sideSpeed = 0;
        _forwardSpeed = 0;
    }
}
