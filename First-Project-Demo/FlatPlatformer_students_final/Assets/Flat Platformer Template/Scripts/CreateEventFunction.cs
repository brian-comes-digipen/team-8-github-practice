/* By: Ryan Scheppler
 * Date: 10/9/19
 * Description: Add to objects meant to create things on unity events
 */
using UnityEngine;

public class CreateEventFunction : MonoBehaviour
{
    public GameObject ObjectToMake;
    public void CreateObject()
    {
        Instantiate(ObjectToMake, transform.position, transform.rotation);
    }
}
