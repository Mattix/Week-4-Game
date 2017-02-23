using UnityEngine;
using System.Collections;

public class moveOrb : MonoBehaviour
{

    public KeyCode moveL;
    public KeyCode moveR;

    public float HorizVel = 0;
    public int laneNum = 2;
    public string controlLocked = "n";




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(HorizVel, 0, 4);

        if ((Input.GetKeyDown(moveL)) && (laneNum > 1) && (controlLocked == "n"))
        {

            HorizVel = -2;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = "y";

        }
        if ((Input.GetKeyDown(moveR)) && (laneNum < 3) && (controlLocked == "n"))
        {

            HorizVel = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";
        }

    }


    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        HorizVel = 0;
        controlLocked = "n";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
