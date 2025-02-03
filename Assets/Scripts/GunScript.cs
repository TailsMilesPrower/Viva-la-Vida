using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    //Refrence to the bullet prefab
    public GameObject bullet;

    //Refrence to the player
    public GameObject player;

    //The speed at which the bullet fires
    public float shootForce;

    //Bools for shooting
    private bool shooting;
    public bool readyToShoot;

    //Refrence to the bullet spawn point
    public Transform bulletSpawn;
    //Refrence to the point that the bullet fires towards
    public Transform shootPoint;

    //Refrence to the UI text that tells you if you can shoot or not
    public TMP_Text canShootText;

    private void Awake()
    {
        //Make sure that the player is able to shoot
        readyToShoot = true;
    }

    private void Update()
    {
        //Calling the input method
        MyInput();

        //If the player is able to shoot, the text displays it so. If not, the text reflects that
        if(readyToShoot == true)
        {
            canShootText.text = "Can shoot: Yes";
        }
        else
        {
            canShootText.text = "Can shoot: No";
        }
    }

    //A method for shooting. If the player has ammo, presses the LMB, and they are currently aiming, the Shoot method is called
    private void MyInput()
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (readyToShoot == true && shooting == true && player.GetComponent<Movement>().aiming == true)
        {
            Shoot();
        }
    }

    //A method that handles shooting
    private void Shoot()
    {
        //Makes it so that the player cannot shoot again until they're done reloading
        //readyToShoot = false;

        //Calculate direction the bullet flies towards
        Vector3 direction = shootPoint.position - bulletSpawn.position;

        //Instantiate bullet
        GameObject currentBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = direction.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
    }
}
