/* By: Ryan Scheppler
 * Date: 10/11/19
 * Description: Add to objects meant move in a pattern you set by the points given to it.
 */
using UnityEngine;

public class PathEnemy : MonoBehaviour
{
    //points are an offset from where the object starts so 0,0 is where it is in the editor
    public Vector3[] Points;

    public float Speed = 5;
    //value that we can be within to change to next destianation
    public float CloseEnough = 0.5f;

    private int currentDestination = 0;

    private Rigidbody2D myRB;

    public bool Active = true;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i] += transform.position;
        }
    }

    private void Update()
    {
        if (Points.Length == 0 || !Active)
        {
            return;
        }
        Vector3 vector = Points[currentDestination] - transform.position;
        if (vector.magnitude <= CloseEnough)
        {
            currentDestination++;
            if (currentDestination >= Points.Length)
            {
                currentDestination = 0;
            }
        }
        myRB.velocity = vector.normalized * Speed;
        if (myRB.velocity.x > 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    public void EnablePath()
    {
        Active = true;
    }

    public void DisablePath()
    {
        print("disable fly");
        Active = false;
        print(Active);
    }
}
