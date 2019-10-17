/* By: Ryan Scheppler
* Date: 10/9/19
* Description: Add this to objects you need a scene changing function for with a delay
*/
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayedSceneChange : MonoBehaviour
{
    public float Delay = 0.0f;
    //name of level to load
    public string NextScene = "GameOver";
    
    public void ChangeScene()
    {
        print("Started");
        StartCoroutine(DelayedChange());
    }

    private IEnumerator DelayedChange()
    {
        print("before delay");
        yield return new WaitForSeconds(Delay);
        print("after");
        SceneManager.LoadScene(NextScene);
    }
}
