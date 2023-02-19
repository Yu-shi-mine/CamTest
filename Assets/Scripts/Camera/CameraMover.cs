using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraMover : MonoBehaviour
{
    //カメラの移動量
    [SerializeField, Range(0.1f, 50.0f)]
    private float _positionStep = 50.0f;

    //マウス感度
    [SerializeField, Range(30.0f, 150.0f)]
    private float _mouseSensitive = 90.0f;

    private Transform _camTransform;
    private Vector3 _startMousePos;
    private Vector3 _presentCamRotation;
    private Vector3 _presentCamPos;
    private Vector3 _rotationOrigin;
    private Vector3 _rotateAxis = Vector3.up;
    private ScreenUtil _screenUtil;

    void Start()
    {
        _camTransform = this.gameObject.transform;
        _screenUtil = new ScreenUtil();
    }

    void Update()
    {
        CameraRotationMouseControl(); //カメラの回転 マウス
        CameraSlideMouseControl(); //カメラの縦横移動 マウス
        CameraPositionMouseControl();
    }

    private void CameraRotationMouseControl()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _startMousePos = Input.mousePosition;
            _presentCamRotation.x = _camTransform.transform.eulerAngles.x;
            _presentCamRotation.y = _camTransform.transform.eulerAngles.y;
        }

        if (Input.GetMouseButton(1))
        {
            //(移動開始座標 - マウスの現在座標) / 解像度 で正規化
            float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height;

            float eulerX = -x * _mouseSensitive;
            float eulerY = y * _mouseSensitive;

            Vector3 RotateAxis = Vector3.Cross(_camTransform.position, Vector3.up);

            _rotationOrigin = _screenUtil.ScreenCentorToWorldPosition();
            _camTransform.RotateAround(_rotationOrigin, _rotateAxis, eulerX);
            _camTransform.RotateAround(_rotationOrigin, RotateAxis, eulerY);

            _startMousePos = Input.mousePosition;
            _presentCamRotation.x = _camTransform.transform.eulerAngles.x;
            _presentCamRotation.y = _camTransform.transform.eulerAngles.y;
        }
    }

    private void CameraSlideMouseControl()
    {
        if (Input.GetMouseButtonDown(2))
        {
            _startMousePos = Input.mousePosition;
            _presentCamPos = _camTransform.position;
        }

        if (Input.GetMouseButton(2))
        {
            //(移動開始座標 - マウスの現在座標) / 解像度 で正規化
            float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height;

            x = x * _positionStep;
            y = y * _positionStep;

            Vector3 velocity = _camTransform.rotation * new Vector3(x, y, 0);
            velocity = velocity + _presentCamPos;
            if (velocity.y <= 0) { velocity.y = 0.1f; }
            _camTransform.position = velocity;
        }
    }

    private void CameraPositionMouseControl()
    {
        Vector3 campos = _camTransform.position;
        campos += _camTransform.forward * Input.mouseScrollDelta.y;
        if (campos.y <= 0) { campos.y = 0.1f; }
        _camTransform.position = campos;
    }
}
