using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Limit1 : MonoBehaviour
{
    [SerializeField] float time;
    ParticleSystem.MainModule main;
    AudioSource[] sounds;
    bool call1;

    // Start is called before the first frame update
    void Start()
    {
        main = GetComponent<ParticleSystem>().main;
        sounds = GetComponents<AudioSource>();
        call1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (main.maxParticles > 100)
        {
            this.time -= Time.deltaTime;
            Debug.Log("count");
            if (this.time < 0 && call1==true)
            {
                sounds[1].Stop();
                sounds[0].Play();
                call1 = false;
                StartCoroutine("GoToGameScene");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sounds[0].Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sounds[1].Stop();
        }
    }
    private IEnumerator GoToGameScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
