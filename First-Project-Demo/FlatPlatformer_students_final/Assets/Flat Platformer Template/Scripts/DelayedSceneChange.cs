/* By: Ryan Scheppler
* Date: 10/9/19
* Description: Add this to objects you need a scene changing function for with a delay
*/
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayedSceneChange : MonoBehaviour
{
    public float Delay;

    public string NextScene = "GameOver";

    public void ChangeScene()
    {
        MonoBehaviour.print("Started");
        StartCoroutine(DelayedChange());
    }

    private IEnumerator DelayedChange()
    {
        MonoBehaviour.print("before delay");
        yield return new WaitForSeconds(Delay);
        MonoBehaviour.print("after");
        SceneManager.LoadScene(NextScene);
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}
