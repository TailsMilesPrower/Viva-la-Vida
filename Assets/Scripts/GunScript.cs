using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    //Bullet
    public GameObject bullet;

    public GameObject player;

    //Bullet force
    public float shootForce;

    //Bools
    private bool shooting;
    public bool readyToShoot;

    //Refrences
    public Transform bulletSpawn;
    public Transform shootPoint;

    public TMP_Text canShootText;

    private void Awake()
    {
        //Make sure the magazine is full
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        if(readyToShoot == true)
        {
            canShootText.text = "Can shoot: Yes";
        }
        else
        {
            canShootText.text = "Can shoot: No";
        }
    }

    private void MyInput()
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (readyToShoot == true && shooting == true && player.GetComponent<Movement>().aiming == true)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Calculate direction from attackPoint to targetPoint
        Vector3 direction = shootPoint.position - bulletSpawn.position;

        //Instantiate bullet
        GameObject currentBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = direction.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
    }
}
