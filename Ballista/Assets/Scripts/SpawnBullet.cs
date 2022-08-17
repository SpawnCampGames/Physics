using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bolt;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {

            var pos = transform.position;
            var rot = transform.rotation;

            Instantiate(bolt,pos,rot);
        }
    }


}
