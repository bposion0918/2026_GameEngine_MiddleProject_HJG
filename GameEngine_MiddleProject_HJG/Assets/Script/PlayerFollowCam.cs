using UnityEngine;
public class PlayerFollowCam : MonoBehaviour
{
    public Transform player;

    float cameraOffset = -2.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, cameraOffset);
        //transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
        transform.position = targetPos;
    }
}
