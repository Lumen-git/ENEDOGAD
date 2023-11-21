using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogoManager : MonoBehaviour
{

    [SerializeField] AudioClip audioClip;
    [SerializeField] CanvasGroup logo;
    [SerializeField] Transform spawnLoc;
    [SerializeField] GameObject laserSet;

    private float timer = 2.2f;
    private bool faded = false;
    private bool fadedIn = false;
    private bool FadeIn = false;
    private bool FadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3 && !fadedIn){
            fadedIn = true;
            FadeInM();
            Instantiate(laserSet, spawnLoc.position, Quaternion.identity);
        }
        if (timer >= 5.5 && !faded){
            faded = true;
            fadeOutM();
        }
        if (timer >= 7 && logo.alpha <= 0){
            SceneManager.LoadScene(1);
        }

        if (FadeIn){
            if (logo.alpha < 1){
                logo.alpha += Time.deltaTime;
                if (logo.alpha >= 1){
                    FadeIn = false;
                }
            }
        }

        if (FadeOut){
            if (logo.alpha >= 0){
                logo.alpha -= Time.deltaTime;
                if (logo.alpha <= 0){
                    FadeOut = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other){
        AudioSource.PlayClipAtPoint(audioClip, new Vector3(0,0,0));
    }

    private void FadeInM(){
        FadeIn = true;
    }

    private void fadeOutM(){
        FadeOut = true;
    }

}
