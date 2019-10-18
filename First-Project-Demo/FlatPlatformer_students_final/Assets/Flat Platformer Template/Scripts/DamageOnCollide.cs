/* By: Ryan Scheppler
 * Date: 10/9/19
 * Description: Add to objects meant to damage health.
 */
using UnityEngine;
using UnityEngine.Events;

public class DamageOnCollide : MonoBehaviour
{
    private readonly int DamageAmount = 10;

    private readonly bool DestroyOnCollide;

    public UnityEvent DamageFunctions;

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
            Destroy(base.gameObject);
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
            Destroy(base.gameObject);
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}
