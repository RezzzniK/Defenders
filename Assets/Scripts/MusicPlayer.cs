using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int mPlayersCount=FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None/**using this becaues we need to put argument*/).Length;//getting quant of music players without order
        if (mPlayersCount > 1){
            Destroy(gameObject);//destroying all music players except one to clear the bufffer 
        }else{
            DontDestroyOnLoad(gameObject);//so it will prevent to restart music player and to start play track from the beginig 
        }
    }

 
}
