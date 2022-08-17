using UnityEngine;
using System.Collections;

public class Sled : MonoBehaviour
{
    private Rigidbody sledRB;

    public GameObject leftArm;
    public GameObject rightArm;

    public GameObject rail;
    public Vector3 startingPos;
    public float incrementValue;

    public float Y_alongRail_max = -0.01f;
    public float Y_alongRail_min;
    public float speed;
    public float leftArmMin = 0;
    public float leftArmMax = -10;
    public float rightArmMin = 0;
    public float rightArmMax = 10;

    public float flexSpeed;

    public float waitTime;


    public float leftArmLerp;
    public float rightArmLerp;

    bool isReadyToFire;

    void Start(){
        startingPos = transform.localPosition;
        Y_alongRail_min = startingPos.y;
        sledRB = GetComponent<Rigidbody>();
        isReadyToFire = true;
    }

    private void Update() {
        if (sledRB.isKinematic) {

            incrementValue += -Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
            incrementValue = Mathf.Clamp(incrementValue, 0, 1);
        } else {
            incrementValue = 0;
        }


        if (Input.GetKeyDown(KeyCode.Return) && isReadyToFire){
            sledRB.isKinematic = false;
            isReadyToFire = false;
            StartCoroutine(WaitForNextFire());
        }
    }



    void FixedUpdate(){

        float positionOfY;
        if (sledRB.isKinematic) {
            positionOfY = Mathf.Lerp(Y_alongRail_min, Y_alongRail_max, incrementValue);
            leftArmLerp = Mathf.Lerp(leftArmMin, leftArmMax, incrementValue);
            rightArmLerp = Mathf.Lerp(rightArmMin, rightArmMax, incrementValue);
        } else {
            positionOfY = transform.localPosition.y;
            leftArmLerp = Mathf.MoveTowards(leftArmLerp, leftArmMin, flexSpeed);
            rightArmLerp = Mathf.MoveTowards(rightArmLerp, rightArmMin, flexSpeed);
        }

     
   
        transform.localPosition = new Vector3(startingPos.x, positionOfY, startingPos.z);
        transform.rotation = rail.transform.rotation;

        leftArm.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, leftArmLerp));
        rightArm.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, rightArmLerp));

    }

    public IEnumerator WaitForNextFire() {

        yield return new WaitForSeconds(waitTime);
        isReadyToFire = true;
        sledRB.isKinematic = true;
    }
}
