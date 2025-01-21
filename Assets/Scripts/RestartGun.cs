using UnityEngine;

public class RestartGun : MonoBehaviour
{
    public GameObject gun;

    public void ResetGun()
    {
        gun.GetComponent<GunScript>().readyToShoot = true;
        Destroy(gameObject);
    }
}
