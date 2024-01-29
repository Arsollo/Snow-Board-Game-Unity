using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float sceneDelay = 1f; 
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Ground" && !hasCrashed ){
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("reloadScene", sceneDelay);
      
        }
    }


    void reloadScene()
    {
        Debug.Log("Collision!");
        SceneManager.LoadScene(0);
    }
}
