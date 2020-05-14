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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowAmmo();
        ammoCanvas.transform.LookAt(Camera.main.transform);
    }

    public void GunShot()
    {
        RaycastHit hit;
        if (ammoCount > 0)
        {
            if (Physics.Raycast(firingPt.transform.position, firingPt.transform.forward * 1000, out hit, 100))
            {
                RobotScript rbt = hit.transform.GetComponent<RobotScript>();

                if (rbt != null)
                {
                    Debug.Log("Hit");
                }
            }
            --ammoCount;
        }
    }

    private void ShowAmmo()
    {
        ammoText.text = ammoCount.ToString();
    }
}
