/* By: Ryan Scheppler
 * Date: 10/9/19
 * Description: Add to objects meant to have a health.
 */
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100;

    public int CurrentHealth = 100;

    public bool DestroyAtZero = true;

    public UnityEvent DamageFunctions;

    public UnityEvent DeathFunctions;

    public UnityEvent HealFunctions;

    private bool DeathOccured;

    private void Start()
    {
    }

    public void Damage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0 && !DeathOccured)
        {
            CurrentHealth = 0;
            DeathFunctions.Invoke();
            DeathOccured = true;
            if (DestroyAtZero)
            {
                Destroy(base.gameObject);
            }
        }
        else
        {
            DamageFunctions.Invoke();
        }
    }

    public void Heal(int health)
    {
        CurrentHealth += health;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        HealFunctions.Invoke();
    }

    private void Update()
    {
    }
}
