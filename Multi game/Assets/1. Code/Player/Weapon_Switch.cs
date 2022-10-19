using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_Switch : MonoBehaviour
{
    [Header ("Pistol")]
    public GameObject Pistol_Pre;
    public GameObject Pistol_cross;
    public GameObject Pistol_Icon;

    [Header ("Launcher")]
    public GameObject Launcher_Pre;
    public GameObject Launcher_cross;
    public GameObject Launcher_Icon;

    [Header ("Switch rate")]
    public float SwitchRate;
    private float nextSwitch;

    bool Pistolout;
    bool Launcherout;

    void Start()
    {
        //Sets code to know what gun is currently out at the start this being the launcher
        Pistolout = false;
        Launcherout = true;
    }

    void Update()
    {
        //Pistol pullout
        if(Input.GetKey(KeyCode.Q) && !Pistolout && Time.time > nextSwitch){

            //Debug.Log("Pistol is out now");

            Pistol();

        } else{
            //Debug.Log("Pistol is already out");
        }

        //Launcher pullout
        if(Input.GetKey(KeyCode.E) && !Launcherout && Time.time > nextSwitch){

            //Debug.Log("Launcher is out now");

            Launcher();

        } else{
            //Debug.Log("Launcher is already out");
        }
    }

    void Pistol(){

        //This adds whatever value put in switch rate and puts that into next fire which is the timer for switching (as without
        //this once the cooldown has done its time it will not run again so this allows it to run again).
        nextSwitch = Time.time + SwitchRate;

        //Activating the pistol
        Pistol_Pre.SetActive(true);
        Pistol_cross.SetActive(true);
        Pistol_Icon.GetComponent<Image>().color = new Color32(255, 255, 0, 255);

        //Disabling everything to do with launcher
        Launcher_Pre.SetActive(false);
        Launcher_cross.SetActive(false);
        Launcher_Icon.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        //Switching out gun scripts so pistol doesnt shoot grenades
        this.GetComponent<FPS_Shooting>().enabled = false;
        this.GetComponent<Pistol_Shoot>().enabled = true;

        Pistolout = true;
        Launcherout = false;
    }

    void Launcher(){

        nextSwitch = Time.time + SwitchRate;

        //Activating the launcher
        Launcher_Pre.SetActive(true);
        Launcher_cross.SetActive(true);
        Launcher_Icon.GetComponent<Image>().color = new Color32(255, 255, 0, 255);

        //Disabling everything to do with pistol
        Pistol_Pre.SetActive(false);
        Pistol_cross.SetActive(false);
        Pistol_Icon.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        //Switching out gun scripts so launcher doesnt shoot like a pistol
        this.GetComponent<Pistol_Shoot>().enabled = false;
        this.GetComponent<FPS_Shooting>().enabled = true;
        
        Launcherout = true;
        Pistolout = false;
    }
}
