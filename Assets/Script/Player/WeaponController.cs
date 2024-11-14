using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public JoystickRight joystickRight; 
    public Transform playerTransform;   
    public Transform weaponTransform;  

    public SpriteRenderer weaponSpriteRenderer;
    public SpriteRenderer playerSpriteRenderer;

    void Start()
    {
        playerTransform = transform.parent;
        playerSpriteRenderer = transform.parent.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        float horizontal = JoyRights.positionX;
        float vertical = JoyRights.positionY;

        
        if (horizontal != 0 || vertical != 0)
        {
            
            float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;

            
            angle = Mathf.Clamp(angle, -180, 180);

            
            weaponTransform.rotation = Quaternion.Euler(0, 0, angle);

            

        }

        float joystickRightX = JoyRights.positionX;

        
        if (joystickRightX > 0) 
        {
            weaponSpriteRenderer.flipX = false; 
            weaponSpriteRenderer.flipY = false;
            playerSpriteRenderer.flipY = false;
            playerSpriteRenderer.flipX = false;
        }
        else if (joystickRightX < 0) 
        {
            weaponSpriteRenderer.flipX = false; 
            weaponSpriteRenderer.flipY = true;
            playerSpriteRenderer.flipY = false;
            playerSpriteRenderer.flipX = true;
        }
    }

    
    void UpdatePlayerFlip(float horizontal)
    {
        //// Jika joystick ke kanan, pastikan player menghadap kanan
        //if (horizontal > 0 && playerTransform.localScale.x < 0)
        //{
        //    playerTransform.localScale = new Vector3(Mathf.Abs(playerTransform.localScale.x), playerTransform.localScale.y, playerTransform.localScale.z);
        //}
        //// Jika joystick ke kiri, pastikan player menghadap kiri
        //else if (horizontal < 0 && playerTransform.localScale.x > 0)
        //{
        //    playerTransform.localScale = new Vector3(-Mathf.Abs(playerTransform.localScale.x), playerTransform.localScale.y, playerTransform.localScale.z);
        //}
    }
}
