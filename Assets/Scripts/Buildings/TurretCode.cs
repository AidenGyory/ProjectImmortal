using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class TurretCode : MonoBehaviour
{
    public int damage;
    public float fireRate;
    public float bulletSpeed; 
    public Transform turretJoint;
    public Transform gunPoint;
    public GameObject bulletPrefab;
    public List<TurretTargetLabel> _targets;
    private float _timer; 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TurretTargetLabel>())
        {
            _targets.Add(other.GetComponent<TurretTargetLabel>());
            other.GetComponent<EnemyInfo>().TriggerDeath += () => _targets.Remove(other.GetComponent<TurretTargetLabel>()); 
        }
    }


    void Update()
    {
        if (_targets.Count > 0)
        {
            turretJoint.LookAt(_targets[0].transform);
            
        }

        if (_timer < 0)
        {
            if (_targets.Count > 0)
            {
                Shoot(); 
            }
        }
        else
        {
            _timer -= Time.deltaTime; 
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, gunPoint.position, turretJoint.rotation);
        bullet.GetComponent<BulletInfo>().damage = damage; 
        bullet.GetComponent<Movement>().movementSpeed = bulletSpeed; 
        _timer = fireRate; 
    }
}
