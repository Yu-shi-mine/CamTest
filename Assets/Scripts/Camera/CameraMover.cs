using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraMover : MonoBehaviour
{
    //�J�����̈ړ���
    [SerializeField, Range(0.1f, 50.0f)]
    private float _positionStep = 50.0f;

    //�}�E�X���x
    [SerializeField, Range(30.0f, 150.0f)]
    private float _mouseSensitive = 90.0f;

    //�J������transform  
    private Transform _camTransform;
    //�}�E�X�̎n�_ 
    private Vector3 _startMousePos;
    //�J������]�̎n�_���
    private Vector3 _presentCamRotation;
    private Vector3 _presentCamPos;
    private Vector3 _origin = new Vector3(5, 0, 5);
    private Vector3 _rotateAxis = Vector3.up;

    void Start()
    {
        _camTransform = this.gameObject.transform;
    }

    void Update()
    {
        CameraRotationMouseControl(); //�J�����̉�] �}�E�X
        CameraSlideMouseControl(); //�J�����̏c���ړ� �}�E�X
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
            //(�ړ��J�n���W - �}�E�X�̌��ݍ��W) / �𑜓x �Ő��K��
            float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height;

            float eulerX = -x * _mouseSensitive;
            float eulerY = y * _mouseSensitive;

            Vector3 RotateAxis = Vector3.Cross(_camTransform.position, Vector3.up);

            _camTransform.RotateAround(_origin, _rotateAxis, eulerX);
            _camTransform.RotateAround(_origin, RotateAxis, eulerY);

            _startMousePos = Input.mousePosition;
            _presentCamRotation.x = _camTransform.transform.eulerAngles.x;
            _presentCamRotation.y = _camTransform.transform.eulerAngles.y;
        }
    }

    //�J�����̈ړ� �}�E�X
    private void CameraSlideMouseControl()
    {
        if (Input.GetMouseButtonDown(2))
        {
            _startMousePos = Input.mousePosition;
            _presentCamPos = _camTransform.position;
        }

        if (Input.GetMouseButton(2))
        {
            //(�ړ��J�n���W - �}�E�X�̌��ݍ��W) / �𑜓x �Ő��K��
            float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height;

            x = x * _positionStep;
            y = y * _positionStep;

            Vector3 velocity = _camTransform.rotation * new Vector3(x, y, 0);
            velocity = velocity + _presentCamPos;
            _camTransform.position = velocity;
        }
    }

    private void CameraPositionMouseControl()
    {
        Vector3 campos = _camTransform.position;
        campos += _camTransform.forward * Input.mouseScrollDelta.y;
        _camTransform.position = campos;
    }
}
