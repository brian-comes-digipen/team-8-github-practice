/* By: Bulat Sultanov
 * Date: 2017
 * Description: Script makes a paralaxing effect on specifically selected objects
 */
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BackGround
{
    public Transform _backGround;

    public float _damping = 0.5f;
}


public class Paralax : MonoBehaviour
{
    public enum Mode
    {
        Horizontal,
        Vertical,
        HorizontalAndVertical
    }

    public Mode parallaxMode;

    public List<BackGround> _backGrounds;

    private float[] scales;

    private Transform cam;

    private Vector3 previousCamPos;

    private Vector3 position;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    private void Start()
    {
        previousCamPos = cam.position;
        scales = new float[_backGrounds.Count];
        for (int i = 0; i < _backGrounds.Count; i++)
        {
            if (_backGrounds[i] != null)
            {
                scales[i] = _backGrounds[i]._backGround.position.z * -1f;
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < _backGrounds.Count; i++)
        {
            if (_backGrounds[i] != null)
            {
                Vector3 vector = (previousCamPos - cam.position) * scales[i];
                switch (parallaxMode)
                {
                    case Mode.Horizontal:
                        position = new Vector3(_backGrounds[i]._backGround.position.x + vector.x, _backGrounds[i]._backGround.position.y, _backGrounds[i]._backGround.position.z);
                        break;
                    case Mode.Vertical:
                        position = new Vector3(_backGrounds[i]._backGround.position.x, _backGrounds[i]._backGround.position.y + vector.y, _backGrounds[i]._backGround.position.z);
                        break;
                    case Mode.HorizontalAndVertical:
                        position = new Vector3(_backGrounds[i]._backGround.position.x + vector.x, _backGrounds[i]._backGround.position.y + vector.y, _backGrounds[i]._backGround.position.z);
                        break;
                }
                _backGrounds[i]._backGround.position = Vector3.Lerp(_backGrounds[i]._backGround.position, position, _backGrounds[i]._damping * Time.deltaTime);
            }
        }
        previousCamPos = cam.position;
    }
}
