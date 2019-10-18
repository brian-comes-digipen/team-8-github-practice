/* By: Ryan Scheppler
 * Date: 10/11/19
 * Description: Add to healthbar and set target to make health
 */
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Health Target;

    public float MaxSize = 300f;

    private RectTransform myRT;

    public void HealthUpdate()
    {
        myRT.sizeDelta = new Vector2((float)Target.CurrentHealth / (float)Target.MaxHealth * MaxSize, myRT.sizeDelta.y);
    }

    private void Start()
    {
        myRT = GetComponent<RectTransform>();
    }

    private void Update()
    {
    }
}
