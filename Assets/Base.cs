using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public GameObject HomePage;
    public GameObject FinishPage;
    public GameObject Lvl1;
    public GameObject Lvl2;
    public GameObject Lvl3;
    public GameObject canlvlup;





    void Start()
    {
        HomePage.SetActive(true);
        FinishPage.SetActive(false);
        Lvl1.SetActive(false);
        Lvl2.SetActive(false);
        Lvl3.SetActive(false);
        canlvlup.SetActive(false);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("arrow"))
        {
            HomePage.SetActive(false);
            Lvl1.SetActive(true);

        }
        else if (collision.gameObject.CompareTag("cup1"))
        {
            Lvl1.SetActive(false);
            Lvl2.SetActive(true);

        }
        else if (collision.gameObject.CompareTag("cup2"))
        {
            Lvl2.SetActive(false);
            Lvl3.SetActive(true);


        }
        else if (collision.gameObject.CompareTag("cup3"))
        {
            Lvl3.SetActive(false);
            FinishPage.SetActive(true);

        }
        else if (collision.gameObject.CompareTag("home"))
        {
            FinishPage.SetActive(false);
            HomePage.SetActive(true);

        }
        else if (collision.gameObject.CompareTag("lvlup"))
        {
            canlvlup.SetActive(true);


        }

    }


}
