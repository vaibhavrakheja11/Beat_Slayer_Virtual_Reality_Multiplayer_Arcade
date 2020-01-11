using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{
    public GameObject line;
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;
    public GameObject player;
    public int maxAmmo = 15;
    private int currentAmmo;

    public TMPro.TextMeshPro text;

    public float shotPower = 1000f;
    public float damage = 25f;


    public AudioSource source;
    public AudioClip fire;
    public AudioClip reload;
    public AudioClip noAmmo;
    private int enemies_killed = 0;
    private int headshots = 0;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
        source.PlayOneShot(reload);
        text.text = currentAmmo.ToString();
    }

    void Update()
    {
        text.text = currentAmmo.ToString();

        if(Vector3.Angle(transform.up,Vector3.up) > 100 && currentAmmo != maxAmmo)
        {
            Reload();
        }
        text.text = currentAmmo.ToString();
    }

    public void TriggerShoot()
    {

        GetComponent<Animator>().SetTrigger("Fire");

    }

    public void Shoot()
    {


        if (currentAmmo > 0)
        {
            Vector3 directionSpeed = transform.forward;
            //  GameObject bullet;
            //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
            // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            RaycastHit hit;
            GameObject tempFlash;
            GameObject tempBullet;
            //Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            bool hasHit = Physics.Raycast(barrelLocation.position, barrelLocation.forward, out hit, 100f);
            if (hasHit) //try to add bullet prefab here
            {
                tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
                Debug.Log("plYER HT ------------------------>" + hit.transform.name);
                tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
                //tempBullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
                
                //tempBullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
                source.PlayOneShot(fire);
                currentAmmo--;
                //EnemyController target = hit.transform.GetComponent<EnemyController>();
                EnemyController target = hit.transform.GetComponentInParent<EnemyController>();
                if (target != null)
                {
                    target.Dead(hit.transform.position);
                    enemies_killed++;
                    Debug.Log("Enemies Killed : " + enemies_killed);
                    if (hit.transform.name == "mixamorig:Head")
                    {
                        headshots++;
                        Debug.Log("Headshots : " + headshots);
                    }

                    ScoreCalculater sc = new ScoreCalculater();
                    sc.setScore(enemies_killed, headshots);
                    player.GetComponent<PlayerHealthManager>().increaseHealth();
                   
                }

                if(line)
                {
                    GameObject liner = Instantiate(line);
                    liner.GetComponent<LineRenderer>().SetColors(Color.green,Color.red);
                    liner.GetComponent<LineRenderer>().SetPositions(new Vector3[] { barrelLocation.position, hasHit ? hit.point : barrelLocation.position + barrelLocation.forward * 100 });
                    Destroy(liner, 0.5f);
                }

            }
            // Destroy(tempFlash, 0.5f);
            //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);

        }
        else if(currentAmmo == 0)
        {
            source.PlayOneShot(noAmmo);
        }
    }

    void CasingRelease()
    {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}
