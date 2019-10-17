/* By: Ryan Scheppler
 * Date: 10/9/19
 * Description: Add to objects meant to damage health.
 */
using UnityEngine;
using UnityEngine.Events;


public class DamageOnCollide : MonoBehaviour
{
    readonly int DamageAmount = 10;
    readonly bool DestroyOnCollide = false;
    //functions to run when damage is caused
    public UnityEvent DamageFunctions;
    //functions to run when object is set to destroy itself
    public UnityEvent DestroyFunctions;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health component = collision.gameObject.GetComponent<Health>();
        if (component != null)
        {
            component.Damage(DamageAmount);
            DamageFunctions.Invoke();
        }
        if (DestroyOnCollide)
        {
            DestroyFunctions.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health component = collision.gameObject.GetComponent<Health>();
        if (component != null)
        {
            component.Damage(DamageAmount);
            DamageFunctions.Invoke();
        }
        if (DestroyOnCollide)
        {
            DestroyFunctions.Invoke();
            Destroy(gameObject);
        }
    }
}
