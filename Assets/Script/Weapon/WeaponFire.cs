using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public enum FireMode
    {
        Pistol,
        Shotgun,
        MachineGun
    }

    public FireMode currentFireMode = FireMode.Pistol;  // Mode tembakan yang aktif
    public GameObject bulletPrefab;  // Prefab peluru
    public Transform firePoint;  // Titik dari mana peluru ditembakkan
    public float pistolFireRate = 1f;  // Kecepatan tembak pistol
    public float shotgunFireRate = 0.5f;  // Kecepatan tembak shotgun
    public float machineGunFireRate = 0.1f;  // Kecepatan tembak machine gun

    public float pistolDamage;
    public float shotgunDamage;
    public float machineGunDamage;

    private float nextFireTime;  // Waktu untuk tembak berikutnya
    public bool isFiring = false; // Menentukan apakah sedang menembak atau tidak
    public bool Firing;

    public SpriteRenderer weapon;
    public Sprite[] weaponType;

    private void Start()
    {
        weapon = GetComponent<SpriteRenderer>();

        weaponEvent.onWeaponShoot += FiringTrue;
        weaponEvent.onWeaponRelease += FiringFalse;

        switch (CoinManager.Instance.CurrentSelectedWeapon)
        {
            case 0:
                currentFireMode = FireMode.Pistol;
                weapon.sprite = weaponType[0];
                break;
            case 1:
                currentFireMode = FireMode.Shotgun;
                weapon.sprite = weaponType[1];
                break;
            case 2:
                currentFireMode = FireMode.MachineGun;
                weapon.sprite = weaponType[2];
                break;
        }
    }

    private void OnDestroy()
    {
        weaponEvent.onWeaponShoot -= FiringTrue;
        weaponEvent.onWeaponRelease -= FiringFalse;
    }

    void Update()
    {
        // Memeriksa jika tombol tembak ditekan
        if (Firing)  // Gantilah "Fire1" dengan input button sesuai pengaturan Anda
        {
            if (!isFiring)
            {
                isFiring = true;
                FireWeapon(); // Mulai menembak
            }
        }
        else
        {
            isFiring = false; // Hentikan tembakan jika tombol dilepas
        }
    }

    void FireWeapon()
    {
        
        switch (currentFireMode)
        {
            case FireMode.Pistol:
                FirePistol();
                if (isFiring)
                    Invoke("FireWeapon", pistolFireRate);
                break;
            case FireMode.Shotgun:
                FireShotgun();
                if (isFiring)
                    Invoke("FireWeapon", shotgunFireRate);
                break;
            case FireMode.MachineGun:
                FireMachineGun();
                if(isFiring)
                Invoke("FireWeapon", machineGunFireRate);
                break;
        }

       
    }

    void FirePistol()
    {
        // Tembak 1 peluru dengan kecepatan lambat
        GameObject TheBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        TheBullet.GetComponent<Projectile>().damage = pistolDamage;

    }

    void FireShotgun()
    {
        // Tembak 3 peluru sekaligus
        for (int i = -1; i <= 1; i++)
        {
            Vector3 spread = new Vector3(i * 0.1f, 0, 0);  // Penyebaran peluru shotgun
            GameObject TheBullet = Instantiate(bulletPrefab, firePoint.position + spread, firePoint.rotation);

            TheBullet.GetComponent<Projectile>().damage = shotgunDamage;
        }
    }

    void FireMachineGun()
    {
        // Tembak 1 peluru dengan kecepatan sangat cepat
        GameObject TheBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        TheBullet.GetComponent<Projectile>().damage = machineGunDamage;

    }

    // Mengubah mode tembakan
    public void SwitchFireMode(FireMode newFireMode)
    {
        currentFireMode = newFireMode;
    }

    public void FiringTrue()
    {
        Firing = true;
    }

    public void FiringFalse()
    {
        Firing = false;
    }
}
