using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : BaseWeapon // Derived class
{
    [SerializeField] protected GameObject ammo;
    [SerializeField] protected int ammoCount;
    [SerializeField] protected float currentAmmo;
    [SerializeField] protected float reloadSpeed;
    private float reloadTimer = 0;
    private Quaternion bulletAngle;
    private Vector3 bulletPosition;
    // Start is called before the first frame update
    void Start()
    {
        bulletPosition = this.transform.position;
        bulletPosition.y = this.transform.position.y + 0.35f;
        bulletPosition.z = this.transform.position.z + 0.4f;

        var lookPos = transform.position;
        var rotation = Quaternion.LookRotation(lookPos);
        rotation *= Quaternion.Euler(90, 0, 0); // this adds a 90 degrees X rotation
        bulletAngle = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo <= 0) {
            Debug.Log(reloadTimer + " " + reloadSpeed);
            reloadTimer += Time.deltaTime;
            if (reloadTimer > reloadSpeed) {
                currentAmmo = ammoCount;
                reloadTimer = 0;
            }
        }

        if (currentAmmo > 0) {
            attack();
            attackTimeTracker += Time.deltaTime;
        }
    }

    public override void attack() {
        if ((attackTimeTracker + Time.deltaTime) > (nextMinAttackTime)){
            nextMinAttackTime = 0 + attackCooldown;
            attackTimeTracker = 0;

            GameObject bullet = Instantiate(ammo, bulletPosition, bulletAngle);
            var bulletRB = bullet.GetComponent<Rigidbody>();
            if (bulletRB != null) {
                bulletRB.velocity += transform.forward * 50;
            }
            currentAmmo -= 1;

            StartCoroutine(killBill(bullet));
        }
    }

    private IEnumerator killBill(GameObject bullet) {
        yield return new WaitForSeconds(2f);

        DestroyImmediate(bullet);
    }
}
