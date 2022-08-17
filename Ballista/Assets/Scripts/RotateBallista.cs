using UnityEngine;

public class RotateBallista : MonoBehaviour
{

    public float modifier;
    public float rotationValue;

    void OnEnable(){}
    void OnDisable(){}
    void Start(){}
    void Update(){

        if (Input.GetKey(KeyCode.Q)) {

            rotationValue -= modifier * Time.deltaTime;


        }
        if (Input.GetKey(KeyCode.E)) {

            rotationValue += modifier * Time.deltaTime;

        }

        rotationValue = Mathf.Clamp(rotationValue, -45, 45);
        transform.localRotation = Quaternion.Euler(new Vector3(0, rotationValue, 0));
    
    }
}
