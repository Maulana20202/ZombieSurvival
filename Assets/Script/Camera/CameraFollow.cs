using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;         
    public float smoothSpeed = 0.125f; 
    public Vector2 minBounds;        
    public Vector2 maxBounds;        

    private void LateUpdate()
    {

        // Dapatkan posisi target kamera berdasarkan posisi pemain
        Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        // Batasi posisi X kamera agar tidak melebihi batas peta
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Pindahkan kamera langsung ke posisi yang diinginkan tanpa lerp
        transform.position = clampedPosition;
    }
}
