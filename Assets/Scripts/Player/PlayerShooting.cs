using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot;
    public float timeBetweenBullets;
    public float range;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    public int ammoInClip;
    public int maxAmmo;
    bool reloading;
    bool fullAuto;
    public int weaponType;
    float reloadingTime = 2f;


    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();

        ammoInClip = 7;
        maxAmmo = 9999;
        damagePerShot = 20;
        timeBetweenBullets = 0.35f;
        range = 50f;
        reloading = false;
        fullAuto = false;
        weaponType = 1;
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if (!fullAuto)
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire") && timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                Shoot();
            }
        }
        else
        {
            if (CrossPlatformInputManager.GetButton("Fire") && timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                Shoot();
            }
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        if(reloading)
        {
            return;
        }
        if(ammoInClip == 0)
        {
            if(maxAmmo == 0)
            {
                return;
            }
        }

        ammoInClip--;

        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
        if (ammoInClip == 0)
        {
            if (maxAmmo != 0)
            {
                reloading = true;
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadingTime);
        if(weaponType == 1)
        {
            maxAmmo = maxAmmo - (7 - ammoInClip);
            ammoInClip = 7;
        }else if(weaponType == 2)
        {
            if(maxAmmo < (35 - ammoInClip))
            {
                ammoInClip = maxAmmo;
                maxAmmo = 0;
            }
            else
            {
                maxAmmo = maxAmmo - (35 - ammoInClip);
                ammoInClip = 35;
            }
            
        }else if (weaponType == 3)
        {
            if (maxAmmo < (30 - ammoInClip))
            {
                ammoInClip = maxAmmo;
                maxAmmo = 0;
            }
            else
            {
                maxAmmo = maxAmmo - (30 - ammoInClip);
                ammoInClip = 30;
            }

        }else if (weaponType == 4)
        {
            if (maxAmmo < (8 - ammoInClip))
            {
                ammoInClip = maxAmmo;
                maxAmmo = 0;
            }
            else
            {
                maxAmmo = maxAmmo - (8 - ammoInClip);
                ammoInClip = 8;
            }

        }

        reloading = false;
    }

    public void SMGUpgrade()
    {
        fullAuto = true;
        timeBetweenBullets = 0.05f;
        damagePerShot = 30;
        range = 50f;
        ammoInClip = 35;
        maxAmmo = 600;
        weaponType = 2;
    }

    public void RifleUpgrade()
    {
        fullAuto = true;
        timeBetweenBullets = 0.15f;
        damagePerShot = 75;
        range = 100f;
        ammoInClip = 30;
        maxAmmo = 300;
        weaponType = 3;
    }

    public void SemiRifleUpgrade()
    {
        fullAuto = false;
        timeBetweenBullets = 0.3f;
        damagePerShot = 50;
        range = 100f;
        ammoInClip = 8;
        maxAmmo = 128;
        weaponType = 4;
    }

    public void ReloadUpgrade()
    {
        reloadingTime = 1f;
    }

    public void DamageUpgrade()
    {
        damagePerShot = damagePerShot + damagePerShot / 2;
    }

    public void RefillAmmo()
    {
        if (weaponType == 1)
        {
            maxAmmo = 9999;
            ammoInClip = 7;
        }
        else if (weaponType == 2)
        {
            maxAmmo = 600;
            ammoInClip = 35;

        }
        else if (weaponType == 3)
        {
            maxAmmo = 300;
            ammoInClip = 30;
        }
        else if (weaponType == 4)
        {
            maxAmmo = 128;
            ammoInClip = 8;
        }
    }
}
