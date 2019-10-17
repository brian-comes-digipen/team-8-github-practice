/* By: Bulat Sultanov
 * Date: 2017
 * Description: Rotates windmill over the update function
 */
using UnityEngine;

public class WindMill : MonoBehaviour {
    public float _Speed;
    private float _currDist, _dist;

    private void Update()
    {
        if (Mathf.Round(_currDist) == Mathf.Round(_dist) || _currDist == 0f)
        {
            _dist = Random.Range(0f, 2.7f);
        }
        _currDist = Mathf.Lerp(_currDist, _dist, Time.deltaTime * 0.3f);
        transform.Rotate(0f, 0f, _Speed * Time.deltaTime + _currDist);
    }
}
