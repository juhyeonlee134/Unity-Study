using UnityEngine;

public class ShooterRotater : MonoBehaviour
{
    private enum RotateState
    {
        Idle, Horizontal, Vertical, Ready
    };
    [SerializeField]
    private RotateState _state = RotateState.Idle;

    private const float _horizontalRotateSpeed = 360f;
    private const float _verticalRotateSpeed = 360f;

    private void Update()
    {
        switch(_state)
        {
            case RotateState.Idle:
                if (Input.GetButtonDown("Fire1"))
                {
                    _state = RotateState.Horizontal;
                }
                break;
            case RotateState.Horizontal:
                if (Input.GetButton("Fire1"))
                {
                    transform.Rotate(new Vector3(0, _horizontalRotateSpeed * Time.deltaTime, 0));
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    _state = RotateState.Vertical;
                }
                break;
            case RotateState.Vertical:
                if (Input.GetButton("Fire1"))
                {
                    transform.Rotate(new Vector3(-_verticalRotateSpeed * Time.deltaTime, 0, 0));
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    _state = RotateState.Ready;
                }
                break;
            case RotateState.Ready:
                break;
        }
    }
}
