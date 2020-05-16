using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
    [SerializeField]
    private float health = 150f;
    public bool dead = false;
    public GameObject sparksObj;
    public ParticleSystem explode;
    public AudioSource deathSound;
    public AudioSource spawnSound;
    public AudioSource hitSource;
    public AudioClip hitSound;
    public GameObject robotMesh;

    // Start is called before the first frame update
    void Start()
    {
        spawnSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        HealthManager();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        hitSource.PlayOneShot(hitSound);
        GameObject sparks = Instantiate(sparksObj, sparksObj.transform.position, sparksObj.transform.rotation);
        Destroy(sparks, 3f);
        Debug.Log(sparksObj.transform.position);
    }

    private void HealthManager()
    {
        if (health <= 0)
        {
            dead = true;
            health = 0.1f;
            robotMesh.SetActive(false);
            explode.Play();
            deathSound.Play();
            Destroy(gameObject, 3f);
        }
    }
}
