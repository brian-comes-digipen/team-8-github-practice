/* By: Bulat Sultanov
 * Date: 2017
 * Description: Adjusts the mantle of the player
 */
using UnityEngine;

public class Mantle : MonoBehaviour {
    public Player _player;
    public float _offset;
    private bool _isMirror;
    private Rigidbody2D _playerRig;
    private Vector2 _defCoords;

    private void Start()
    {
        _defCoords = transform.localPosition;
        _playerRig = _player.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 velocity = _playerRig.velocity;
        velocity.Normalize();
        _isMirror = _player.mirror;
        if (_isMirror)
        {
            transform.localPosition = new Vector2(_defCoords.x + _offset * velocity.x, transform.localPosition.y);
        }
        if (!_isMirror)
        {
            transform.localPosition = new Vector2(_defCoords.x - _offset * velocity.x, transform.localPosition.y);
        }
    }
}
