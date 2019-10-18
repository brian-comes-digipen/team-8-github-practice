/* By: Bulat Sultanov, edited by Ryan Schepppler
 * Last Edited: 10/9/19
 * Description: Script that is input for the player, has many useful features including checking below the player for ground(Default layer), 
 * and handles sword movement and some mirroring in addition to normal platforming
 */
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float WalkSpeed;

    public float JumpForce;

    public AnimationClip _walk;

    public AnimationClip _jump;

    public Animation _Legs;

    public Transform _Blade;

    public Transform _GroundCast;

    public Camera cam;

    public bool mirror;

    public AudioClip sfxJump;

    public AudioClip sfxWalk;

    private bool _canJump;

    private bool _canWalk;

    private readonly bool _isWalk;

    private bool _isJump;

    private float rot;

    private float _startScale;

    private Rigidbody2D rig;

    private Vector2 _inputAxis;

    private RaycastHit2D _hit;

    private LayerMask _layerMask;

    private AudioSource audioSource;

    public bool Active = true;

    public void DisablePlayer()
    {
        Active = false;
    }

    public void EnablePlayer()
    {
        Active = true;
    }

    private void Start()
    {
        _layerMask = LayerMask.GetMask("Default");
        rig = gameObject.GetComponent<Rigidbody2D>();
        _startScale = transform.localScale.x;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!Active)
        {
            return;
        }
        if ((bool)(_hit = Physics2D.Linecast(new Vector2(_GroundCast.position.x, _GroundCast.position.y + 0.2f), _GroundCast.position, _layerMask)))
        {
            if (!_hit.transform.CompareTag("Player"))
            {
                _canJump = true;
                _canWalk = true;
            }
        }
        else
        {
            _canJump = false;
        }
        _inputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (_inputAxis.y > 0f && _canJump)
        {
            _canWalk = false;
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (!Active)
        {
            return;
        }
        Vector3 vector = cam.ScreenToWorldPoint(Input.mousePosition) - _Blade.transform.position;
        vector.Normalize();
        if (cam.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x + 0.2f)
        {
            mirror = false;
        }
        if (cam.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x - 0.2f)
        {
            mirror = true;
        }
        if (!mirror)
        {
            rot = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
            transform.localScale = new Vector3(_startScale, _startScale, 1f);
            _Blade.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
        }
        if (mirror)
        {
            rot = Mathf.Atan2(0f - vector.y, 0f - vector.x) * 57.29578f;
            transform.localScale = new Vector3(0f - _startScale, _startScale, 1f);
            _Blade.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
        }
        if (_inputAxis.x != 0f)
        {
            rig.velocity = new Vector2(_inputAxis.x * WalkSpeed * Time.deltaTime, rig.velocity.y);
            if (_canWalk)
            {
                _Legs.clip = _walk;
                _Legs.Play();
                audioSource.clip = sfxWalk;
                audioSource.Play();
            }
        }
        else
        {
            rig.velocity = new Vector2(0f, rig.velocity.y);
        }
        if (_isJump)
        {
            rig.AddForce(new Vector2(0f, JumpForce));
            _Legs.clip = _jump;
            _Legs.Play();
            audioSource.clip = sfxJump;
            audioSource.Play();
            _canJump = false;
            _isJump = false;
        }
    }

    public bool IsMirror()
    {
        return mirror;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(base.transform.position, _GroundCast.position);
    }
}
