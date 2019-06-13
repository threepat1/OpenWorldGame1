using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using NaughtyAttributes;

public class Enemy : MonoBehaviour
{
    
    public Transform healthBarParent; // Refers to Empty Canvas element
    public GameObject healthBarUIPrefab; // Healthbar Prefab to spawn
    public Transform healthBarPoint; // Refers to transform for following health bar 
    public GameObject enemy;

    public Transform target;
    [ProgressBar("Health", 100, ProgressBarColor.Red)]
    public int maxHealth = 100;
    NavMeshAgent agent;

    private int health = 0;
    private Slider healthSlider;
    private Renderer rend;

    public float targetDistance;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Spawn a new Healthbar under 'HealthBarParent'
        GameObject clone = Instantiate(healthBarUIPrefab, healthBarParent);
        // Get Slider component from new Healthbar
        healthSlider = clone.GetComponent<Slider>();
        // Set health to maxHealth
        health = maxHealth;
        // Get the renderer attached to Enemy


    }
    // When the GameObject gets Destroyed
    void OnDestroy()
    {
        // If healthSlider exists
        if(health <= 0)
        {
            Destroy(healthBarUIPrefab);
        }
        // Take the HealthSlider with it
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        targetDistance = Vector3.Distance(target.position, transform.position);
        if (targetDistance < 1.8f)
        {
            attack();
        }
    }
    void LateUpdate()
    {
        // healthSlider.gameObject.SetActive(rend.isVisible);

        // Vector3 screenPosition = Camera.main.WorldToScreenPoint(healthBarPoint.position);
        // healthSlider.transform.position = screenPosition;

        // OR

        // If the renderer (Enemy) is visible
        if (rend.isVisible)
        {        // Activate the HealthBar                 
            healthBarUIPrefab.SetActive(true);
            // Update position of healthbar with enemy
            //GameObject clone = Instantiate(healthBarUIPrefab,,)

        }
        // If it is NOT visible
        else
        {
            // Deactivate the HealthBar
            healthBarUIPrefab.SetActive(false);
        }
        
       
    }
    public void TakeDamage(int damage)
    {
        // Reduce health with damage
        // Update Health Slider
        // If health reaches zero
        // Destroy the GameObject
    }
    public void attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                print("yeahhhh");
            }
        }
    }
}
