//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyController : MonoBehaviour
//{
//    // Start is called before the first frame update

//    public float lookRadius = 5f;
//    Transform target;
//    NavMeshAgent agent;
//    public Animator enemyAnim;


//    void Start()
//    {

//        //target = NetworkManager.instance.player.transform;
//       target = GameObject.FindGameObjectWithTag("Player").transform;
//        agent = GetComponent<NavMeshAgent>(); 
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //Debug.Log("-----------------------");
//        //Debug.Log(target.position);
//        //Debug.Log(transform.position);
//        //Debug.Log("----------xxx-------------");
//        //transform.forward = Vector3.ProjectOnPlane(target.position - transform.position),Vector3.up).normalised;
//    }


//    private void OnDrawGizmosSelected()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position, lookRadius);





//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //public SimpleShoot shooter;
    Transform target;
    public GameObject bulletPrefab;
    public GameObject line;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;
    public int variableSpeed = 30;

    

    // Start is called before the first frame update
    void Start()
    {
        SetupRagdoll(true);
        if (barrelLocation == null)
            barrelLocation = transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;

        //agent = GetComponent<NavMeshAgent>(); 
    }

    Vector3 GetTarget()
    {
        return ((target.position - barrelLocation.position) / 3) + new Vector3(0, 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.forward = Vector3.ProjectOnPlane((target.position - transform.position), Vector3.up).normalized;
        //Debug.Log("Target position -------------->" + target.parent.position);


    }

    void SetupRagdoll(bool value)
    {
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = value;
        }
    }

    public void Dead(Vector3 hitpoint)
    {
        Debug.Log("Enemy Player Should be dead by now");
        GetComponent<Animator>().enabled = false;
        SetupRagdoll(false);

        foreach (var item in Physics.OverlapSphere(hitpoint, 0.5f))
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb)
                rb.AddExplosionForce(1000, hitpoint, 0.5f);
        }
        Destroy(gameObject, 5f);
        this.enabled = false;

        
    }

    void EnemyShoot()
    {
        Debug.Log("Shoot triggered AI");
        var directionSpeed = transform.forward * variableSpeed;
        //currentammo--;
        //  GameObject bullet;
        //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        RaycastHit hit;
        GameObject tempFlash;
        GameObject tempBullet;
        //Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        //tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
        if (Physics.Raycast(barrelLocation.position, barrelLocation.forward, out hit, 100f)) //try to add bullet prefab here
        {
            Debug.Log(hit.transform.name);
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
            tempBullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
            tempBullet.GetComponent<Rigidbody>().AddForce(directionSpeed * 100f);
           // tempBullet.GetComponent<Rigidbody>.variableSpeed = (hit.point - transform.position).normalized * 100f;

            Debug.DrawLine(transform.position, hit.point, Color.red);

            Debug.Log(hit.point);
           /*if(line)
            {
                GameObject liner = Instantiate(line);
                liner.GetComponent<LineRenderer>().SetPosition(new Vector3[] { barrelLocation.position, barrelLocation.position});
                Destroy(liner, 0.5f);
            }*/

            CasingRelease();
            //source.PlayOneShot(fire);
            //play shoot sound.
            Target Enemytarget = hit.transform.GetComponent<Target>();
            if (Enemytarget != null)
            {
                //target.TakeDamage(damage);
                Debug.Log(target.name);
            }

            Destroy(tempBullet, 8f);
            Destroy(tempFlash, 1f);
            
        }
        
       

    }
    void CasingRelease()
    {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
        Destroy(casing, 3f);

    }
}
