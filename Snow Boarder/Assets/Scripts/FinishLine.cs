using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float sceneDelay = 1f; 
    [SerializeField] ParticleSystem finishEffect;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("reloadScene", sceneDelay);
            
        }
  
    }

    void reloadScene()
    {
        Debug.Log("You finished!");
        SceneManager.LoadScene(0);
    }
   
}
