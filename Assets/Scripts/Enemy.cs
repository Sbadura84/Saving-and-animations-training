using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Color virables
    float c_Hue;
    float m_Saturation;
    float c_Saturation;
    float c_Value;
    Renderer m_Renderer;



    public int maxHealth = 100;
    int currentHealth;


    public NavMeshAgent agent;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();

        currentHealth = maxHealth;

        Color.RGBToHSV(m_Renderer.material.color, out c_Hue, out c_Saturation, out c_Value);
    }

    // Update is called once per frame
    void Update()
    {
        //autofollow
        agent.SetDestination(player.transform.position);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Animation
        hpColor();

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log("Dead");

        //Animation



    }

    void hpColor()
    {
        //disabling color change after dying,
        //note: probably wouldn't ever be needed outside of testing
        //since enemy would be dead and couldn't change his color anymore
        if (currentHealth <= 0)
        {
            m_Saturation = 0;
        }
        else
        //changing saturation based on hp
        m_Saturation = (float)(currentHealth * 0.01);
        //values to color translation
        m_Renderer.material.color = Color.HSVToRGB(c_Hue, m_Saturation, c_Value);
        Debug.Log(m_Saturation);
    }
}
