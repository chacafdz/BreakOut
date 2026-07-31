using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Metal : BLoque
{
    [Header("Dureza / Rebote")]
    [Tooltip("Qué tanto rebota al chocar.")]
    [Range(0f, 1f)] public float rebote = 0.1f;

    [Tooltip("Fricción al deslizarse. ")]
    [Range(0f, 1f)] public float friccion = 0.3f;

    [Header("Masa / Densidad")]
    [Tooltip("El metal es denso, así que conviene una masa alta comparada con madera o tela.")]
    public float masa = 20f;

    [Header("Combinación con otras superficies")]
    public PhysicMaterialCombine combinacionFriccion = PhysicMaterialCombine.Average;
    public PhysicMaterialCombine combinacionRebote = PhysicMaterialCombine.Minimum;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AplicarPropiedadesFisicas();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update(); // conserva la lógica de resistencia <= 0 -> Destroy
    }

    public override void RebotarBola()
    {
        // El metal es duro: la bola rebota casi sin perder energía.
       
    }

    private void AplicarPropiedadesFisicas()
    {
        // Masa (si el bloque tiene Rigidbody)
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.mass = masa;

        // Physic Material para dureza/rebote/fricción
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            PhysicMaterial metalMat = new PhysicMaterial("MetalPhysicMaterial")
            {
                dynamicFriction = friccion,
                staticFriction = friccion,
                bounciness = rebote,
                frictionCombine = combinacionFriccion,
                bounceCombine = combinacionRebote
            };
            col.material = metalMat;
        }
    }
}