using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoPantanoso : MonoBehaviour
{
    public Transform PuntoDeDisparo; // Spawn point for the flames

    public GameObject FuegoPrefab; // Reference to the particle prefab

    public float VelocidadBala = 1500f; // Initial speed of the flames

    public float CadenciaDeDisparo = 0.03f; // Firing rate (flames per second)

    private float TiempoDisparo = 0f; // Initialize shot timer

    void Update()
    {
        if (Input.GetButton("Fire1")) // Continuous fire with GetButton
        {
            if (Time.time > TiempoDisparo) // Check if it's time to fire
            {
                GameObject nuevaLlama = Instantiate(FuegoPrefab, PuntoDeDisparo.position, PuntoDeDisparo.rotation); // Create new flame instance
                nuevaLlama.GetComponent<Rigidbody>().AddForce(PuntoDeDisparo.forward * VelocidadBala); // Apply force to propel the flames

                TiempoDisparo = Time.time + CadenciaDeDisparo; // Update shot timer

                // Destroy the flame object after its lifespan (0.75 seconds)
                Destroy(nuevaLlama, 0.75f);
            }
        }
    }
}
