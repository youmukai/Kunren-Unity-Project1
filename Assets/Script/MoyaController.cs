using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoyaController : MonoBehaviour
{
    public Transform target;
    public float offset;
    ParticleSystem.MainModule main;
    private float TimeCount;
    [SerializeField] float timer;
    // private float timer2 = 240f;

    // Start is called before the first frame update
    void Start()
    {
        main = GetComponent<ParticleSystem>().main;
        main.startSize = 0f;
        main.maxParticles = 1;
        transform.parent = null;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        TimeCount += Time.deltaTime;
        if (TimeCount >= timer)
        {
            main.maxParticles = 1000;
            main.startSize = 1.5f;
        }
        Vector3 pos = transform.position;
        pos.y = target.position.y + offset;
        pos.x = target.position.x;
        pos.z = target.position.z;
        transform.position = pos;
        /*
        if (TimeCount >= timer2)
        {
            TimeCount = 0f;
            main.startSize = 0f;
        }
        */
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ItemTag")
        {
            TimeCount = 0f;
            main.maxParticles = 1;
            main.startSize = 0f;
        }
    }
}
