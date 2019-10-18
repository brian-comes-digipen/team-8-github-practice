/* By: Ryan Scheppler
 * Date: 10/11/19
 * Description: Add to fly enemy, handles fly specific death things
 */
using System.Collections;
using UnityEngine;

public class FlyDeath : MonoBehaviour
{
    public float DeathDelay = 1f;

    private Animator myAnimator;

    public void OnDeath()
    {
        myAnimator.SetBool("Dead", value: true);
        Destroy(base.gameObject.GetComponent<DamageOnCollide>());
        StartCoroutine(DelayedDestroy());
    }

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(DeathDelay);
        Destroy(base.gameObject);
    }

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
    }
}
