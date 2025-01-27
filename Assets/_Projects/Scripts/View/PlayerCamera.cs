using DefaultNamespace;
using UnityEngine;

public class PlayerCamera : MonoBehaviour,ICamera
{
    public float followSpeed = 2f; // カメラの追従速度
    public Vector2 offset = Vector2.zero; // マウス位置からのオフセット
    
    private Vector2 _targetDown = Vector2.zero; 
    private Vector2 _targetUp = Vector2.zero; 
    private Camera _mainCamera;
    private const float  MinX=1,MaxX=95,MinY=-17,MaxY=41;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) SetInputDown();
        if (Input.GetMouseButton(0))
        {
            Vector3 moveAmount = GetInputMoveAmount();
            MoveCamera(moveAmount);
            _targetDown = _targetUp;
        }
        CameraUtility.LimitMovementRange(transform,MinX,MaxX,MinY,MaxY);
    }

    void SetInputDown()
    {
        Vector3 screenPosition = Input.mousePosition;
        screenPosition.z = Mathf.Abs(_mainCamera.transform.position.z);
        _targetDown = _mainCamera.ScreenToWorldPoint(screenPosition);
    }
    
    Vector2 GetInputMoveAmount()
    {
        Vector3 screenPosition = Input.mousePosition;
        screenPosition.z = Mathf.Abs(_mainCamera.transform.position.z);
        _targetUp = _mainCamera.ScreenToWorldPoint(screenPosition);
        return (_targetDown - _targetUp);
    }

    public void MoveCamera(Vector2 amount)
    {
        transform.position += new Vector3(amount.x, amount.y, 0) * (followSpeed * Time.deltaTime);
    }
}
