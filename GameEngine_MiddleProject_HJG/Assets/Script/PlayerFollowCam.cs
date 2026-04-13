using UnityEngine;
public class PlayerFollowCam : MonoBehaviour
{
    public Transform player;
    public float verticalOffset = 0.1f;   // 카메라 높이 조절

    float cameraOffsetZ = -10.0f;
    // Update is called once per frame
    void Update()
    {

        Vector3 targetPos = new Vector3(player.position.x, player.position.y + verticalOffset, cameraOffsetZ);

        //transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);                            //카메라가 조금 늦게 따라옴

        transform.position = targetPos;



    }
}
