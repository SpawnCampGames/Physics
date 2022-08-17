using UnityEngine;

public class RailController : MonoBehaviour {

    public float modifier;
    public float rotationValue;

    void OnEnable() { }
    void OnDisable() { }
    void Start() { }
    void Update() {

        if (Input.GetKey(KeyCode.S)) {

            rotationValue -= modifier * Time.deltaTime;


        }
        if (Input.GetKey(KeyCode.W)) {

            rotationValue += modifier * Time.deltaTime;

        }

        rotationValue = Mathf.Clamp(rotationValue, 0, 24f);

      

    }

    private void FixedUpdate() {
        transform.localRotation = Quaternion.Euler(new Vector3(rotationValue, 0, 0));
    }
}