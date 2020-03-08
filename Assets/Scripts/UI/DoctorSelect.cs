using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorSelect : MonoBehaviour
{

    public GameObject UI;
    public GameObject doctor;
    private Vector2 MaleOffset = new Vector2(0.01450627f, -.13f);
    private Vector2 MaleScale = new Vector2(0.1193589f, 0.03369492f);
    private Vector2 MaleOffset_Box = new Vector2(0, .020571f);
    private Vector2 MaleScale_Box = new Vector2(.176781f, .228620f);

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
        doctor.GetComponent<CapsuleCollider2D>().offset = MaleOffset_Box;
        doctor.GetComponent<CapsuleCollider2D>().size = MaleScale_Box;
        doctor.GetComponent<BoxCollider2D>().offset = MaleOffset;
        doctor.GetComponent<BoxCollider2D>().size = MaleScale;

    }

    public void selectFemale()
    {
        UI.SetActive(true);
        doctor.GetComponent<PlayerMovement>().updateIsFemale(true);
        doctor.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
