
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Projectile : MonoBehaviour
{
    [SerializeField] Transform ShootPoint;
    [SerializeField] Rigidbody2D Bulletprefab;
    [SerializeField] GameObject target;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 10f);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider != null)
            {
                //mouse move
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log($"hit point: ({hit.point.x}, {hit.point.y})");
                Vector2 projectileVelocity = CalculateProjectileVelocity(ShootPoint.position, hit.point, 1f);
                Rigidbody2D firedBullet = Instantiate(Bulletprefab, ShootPoint.position, Quaternion.identity);
                firedBullet.velocity = projectileVelocity;
            }
        }
    }
    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float t)
    {
        Vector2 distance = target - origin;
        float velocityX = distance.x / t;
        float velocityY = distance.y / t + 0.5f * Mathf.Abs(Physics2D.gravity.y);
        Vector2 result = new Vector2(velocityX, velocityY);
        return result;
    }
    
}