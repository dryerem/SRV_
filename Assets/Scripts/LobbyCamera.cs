using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCamera : MonoBehaviour
{
    public float _mouseSensevityX = 10;
    public float _mouseSensevityY = 10;

    public bool _rotateX = true;
    public bool _rotateY = true;

    public float _minX = -360;
    public float _maxX = 360;
    public float _minY = -30;
    public float _maxY = 40;

    private float _moveX;
    private float _moveY;
    private bool _cameraRotate = false;

    static float GetAngle(float angle, float min, float max)
	{
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;

        return Mathf.Clamp(angle, min, max);
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            _cameraRotate = true;

        else if (Input.GetMouseButtonUp(1))
            _cameraRotate = false;

        if (_cameraRotate)
		{
            if (_rotateX)
                _moveX += Input.GetAxis("Mouse X") * _mouseSensevityX;
            if (_rotateY)
                _moveY -= Input.GetAxis("Mouse Y") * _mouseSensevityY;

            _moveX = GetAngle(_moveX, _minX, _maxX);
            _moveY = GetAngle(_moveY, _minY, _maxY);

            gameObject.transform.rotation = Quaternion.Euler(_moveY, _moveX, 0);
		}
    }
}
