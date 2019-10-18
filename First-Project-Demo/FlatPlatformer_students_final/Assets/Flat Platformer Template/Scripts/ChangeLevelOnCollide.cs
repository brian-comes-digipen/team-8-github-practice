/* By: Ryan Scheppler
* Date: 10/9/19
* Description: Add to object to cause a level change when the player touches it.
*/
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ChangeLevelOnCollide : MonoBehaviour
{
    public string NextScene = "EndScene";

    public float changeDelay = 0.2f;

    public UnityEvent OnHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnHit.Invoke();
            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(changeDelay);
        SceneManager.LoadScene(NextScene);
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}
