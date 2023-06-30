using UnityEngine;


public class DroneTrackPlayer : MonoBehaviour
{
    private Transform playerTransform;
    private Animator animator;
    public Transform droneBody, droneFirePoint;
    public Rigidbody droneBullet;
    public float shotDelay = 2, shotSpeed = 3;

    private void Start()
    {
        enabled = false;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            enabled = true;
            animator.SetBool("angry", true);
            InvokeRepeating("Fire", shotDelay, shotDelay);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform == playerTransform)
        {
            playerTransform = null;
            enabled = false;
            animator.SetBool("angry", false);
            CancelInvoke();
        }
    }

    private void Update()
    {
        droneBody.LookAt(playerTransform);
    }

    private void Fire()
    {
        if (droneBullet)
        {
            var bullet = Instantiate(droneBullet, droneFirePoint.position, droneFirePoint.rotation);
            bullet.velocity = (playerTransform.position - droneFirePoint.position).normalized * shotSpeed;
        }
    }
}