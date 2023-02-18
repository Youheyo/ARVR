using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TurretButtonHandler : MonoBehaviour
{

    [Header("Tower Initialization")]
    [SerializeField] VirtualButtonBehaviour[] vButtons;
    [SerializeField] GameObject[] TurretObjects;
    Transform[] fireOrigin = new Transform[3];

    [Header("Bullet Properties")]
    [SerializeField] GameObject bulletPrefab;

    public float bulletSpeed = 1.0f;

    [Header("Shot Cooldown")]
    public float cdDuration1 = 1.0f;
    public float cdDuration2 = 1.0f;
    public float cdDuration3 = 1.0f;

    bool towerLAvailable = true;
    bool towerMAvailable = true;
    bool towerRAvailable = true;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var vButton in vButtons)
        {
            vButton.RegisterOnButtonPressed(OnButtonPressed);
            vButton.RegisterOnButtonReleased(OnButtonReleased);
        }

        for(int i = 0; i < TurretObjects.Length; i++){
            fireOrigin[i] = TurretObjects[i].transform.Find("BulletOrigin");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonPressed(VirtualButtonBehaviour button)
    {
        //Debug.Log("Virtual Button Pressed : " + button.VirtualButtonName);
        switch(button.VirtualButtonName){
            case "TowerButton1":
                if(towerLAvailable){
                    GameObject shot = Instantiate(bulletPrefab, fireOrigin[0].position, fireOrigin[0].rotation);
                    shot.gameObject.GetComponent<Rigidbody>().AddForce(fireOrigin[0].transform.forward * bulletSpeed);
                    StartCoroutine(StartShotCD(0));
                }
            break;

            case "TowerButton2":
                if(towerMAvailable){
                    GameObject shot = Instantiate(bulletPrefab, fireOrigin[1].position, fireOrigin[1].rotation);
                    shot.gameObject.GetComponent<Rigidbody>().AddForce(fireOrigin[1].transform.forward * bulletSpeed);
                    StartCoroutine(StartShotCD(1));
                }
            break;

            case "TowerButton3":
                if(towerRAvailable){
                    GameObject shot = Instantiate(bulletPrefab, fireOrigin[2].position, fireOrigin[2].rotation);
                    shot.gameObject.GetComponent<Rigidbody>().AddForce(fireOrigin[2].transform.forward * bulletSpeed);
                    StartCoroutine(StartShotCD(2));
                }
            break;
        }
    }


    void OnButtonReleased(VirtualButtonBehaviour button) {
        //Debug.Log("Virtual Button Released : " + button.VirtualButtonName);

    }

    IEnumerator StartShotCD(int towerNum){
        switch(towerNum){
            case 0:
            towerLAvailable = false;
            yield return new WaitForSeconds(cdDuration1);
            towerLAvailable = true;
            break;
            
            case 1:
            towerMAvailable = false;
            yield return new WaitForSeconds(cdDuration2);
            towerMAvailable = true;
            break;
            
            case 2:
            towerRAvailable = false;
            yield return new WaitForSeconds(cdDuration3);
            towerRAvailable = true;
            break;
        default:
            print("Unknown Shot CD");
            break;
        }
    }
}
