using UnityEngine;
using UnityEngine.InputSystem;
public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float launchForce = 18f;
    public float fireCooldown = 0.5f;
    private float nextFireTime = 0f;
    void Update()
    {
        if (Keyboard.current != null &&
        Keyboard.current.spaceKey.wasPressedThisFrame &&
        Time.time >= nextFireTime)
        {
            GameManager.Instance.UseAmmo();
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }
    void Shoot()
    {
        GameObject projectile = Instantiate(
        projectilePrefab,
        firePoint.position,
        firePoint.rotation
        );
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(
        firePoint.forward * launchForce,
        ForceMode.VelocityChange
        );
        Destroy(projectile, 5f);
    }
}

