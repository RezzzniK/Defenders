using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSceneManager : MonoBehaviour
{
    public void ReloadScene(){
      
        StartCoroutine(ReloadSceneRoutine());
     
    }

    IEnumerator ReloadSceneRoutine(){
        yield return new WaitForSeconds(0.8f);
        int currSceneId=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currSceneId);
    }
    
}
