using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorSelect : MonoBehaviour
{

    public GameObject UI;
    public GameObject doctor;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        doctor.SetActive(false);
    }

    public void selectMale()
    {
        UI.SetActive(true);
        doctor.GetComponent<PlayerMovement>().updateIsFemale(false);
        doctor.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void selectFemale()
    {
        UI.SetActive(true);
        doctor.GetComponent<PlayerMovement>().updateIsFemale(true);
        doctor.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
