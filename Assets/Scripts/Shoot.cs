using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Canvas ammoCanvas;
    public Text ammoText;
    private float ammoCount = 15f;
    public Transform firingPt;
    public ParticleSystem muzzleFlash;
    public AudioSource audioSrc;
    public AudioClip shoot;
    private float reloadTimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Reload();
        ShowAmmo();
        ammoCanvas.transform.LookAt(Camera.main.transform);
    }

    public void GunShot()
    {
        RaycastHit hit;
        if (ammoCount > 0)
        {
            muzzleFlash.Play();
            audioSrc.PlayOneShot(shoot);

            if (Physics.Raycast(firingPt.transform.position, firingPt.transform.forward * 5000, out hit, 5000))
            {
                RobotScript rbt = hit.transform.GetComponent<RobotScript>();
                Transform impactPoint = hit.transform;

                if (rbt != null)
                {
                    rbt.TakeDamage(25f);
                }
            }
            --ammoCount;
        }
    }

    private void ShowAmmo()
    {
        ammoText.text = ammoCount.ToString();
    }

    private void Reload()
    {
        if (ammoCount <= 0)
        {
            if (reloadTimer <= 0)
            {
                ammoCount = 15f;
                reloadTimer = 2f;
            }

            else
            {
                reloadTimer -= Time.deltaTime;
            }
        }
    }
}
