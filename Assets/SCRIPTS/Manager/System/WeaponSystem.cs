using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [Header("DataWeapon")]
    [SerializeField] private DataWeaponSystem _dataWeaponSystem;
    [SerializeField] private Transform muzzle;

    private float timeSinceLastShoot;

    private void Start() {
        PlayerUsing.ShootInput += Shoot;
        PlayerUsing.ReloadInput += StartReload;
    }

    private void Update() {
        timeSinceLastShoot += Time.deltaTime;
        Debug.DrawRay(muzzle.position, muzzle.forward);
    }
    
    public void StartReload() {
        if (_dataWeaponSystem.reloading) {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload() {
        _dataWeaponSystem.reloading = true;
        yield return new WaitForSeconds(_dataWeaponSystem.reloadTime);
        
        _dataWeaponSystem.currentAmmo = _dataWeaponSystem.maxSizeAmmo;
        _dataWeaponSystem.reloading = false;
    }
    
    private bool CanShoot() => !_dataWeaponSystem.reloading && timeSinceLastShoot > 1f / (_dataWeaponSystem.fireRate / 60f);
    
    public void Shoot() {
        if (_dataWeaponSystem.currentAmmo > 0) {
            if (CanShoot()) {
                if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, _dataWeaponSystem.MaxDistanceHit)) {
                    Debug.Log(hitInfo.transform.name);
                }

                _dataWeaponSystem.currentAmmo--;
                timeSinceLastShoot = 0;
                OnGunShoot();
            }
        }
    }

    private void OnGunShoot() {
        
    }
}
