using UnityEngine;

public class RestartGun : MonoBehaviour
{
    //A refrence to the gun
    public GameObject gun;

    //A method that makes it so the player can shoot the gun again
    public void ResetGun()
    {
        gun.GetComponent<GunScript>().readyToShoot = true;
        //Destroy(gameObject);
    }
}
