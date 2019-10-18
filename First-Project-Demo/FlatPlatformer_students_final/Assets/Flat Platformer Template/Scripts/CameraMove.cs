/* By: Bulat Sultanov
 * Date: 2017
 * Description: Script finds the player and follows it meant for the main camera.
 */
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float damping = 1.5f;

    public Transform _target;

    public Vector2 offset = new Vector2(2f, 1f);

    private bool faceLeft;

    private int lastX;

    private readonly float dynamicSpeed;

    private Camera _cam;

    private void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer();
        _cam = gameObject.GetComponent<Camera>();
    }

    public void FindPlayer()
    {
        lastX = Mathf.RoundToInt(_target.position.x);
        transform.position = new Vector3(_target.position.x + offset.x, _target.position.y + offset.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if ((bool)_target)
        {
            int num = Mathf.RoundToInt(_target.position.x);
            if (num > lastX)
            {
                faceLeft = false;
            }
            else if (num < lastX)
            {
                faceLeft = true;
            }
            lastX = Mathf.RoundToInt(_target.position.x);
            Vector3 position = Vector3.Lerp(b: faceLeft ? new Vector3(_target.position.x - offset.x, _target.position.y + offset.y + dynamicSpeed, transform.position.z) : new Vector3(_target.position.x + offset.x, _target.position.y + offset.y + dynamicSpeed, transform.position.z), a: transform.position, t: damping * Time.deltaTime);
            transform.position = position;
        }
    }
}
