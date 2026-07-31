using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esfera_Vidrio : BLoque
{
    [Header("Dureza / Rebote")]
    [Range(0f, 1f)] public float rebote = 0.6f;

    [Tooltip("El vidrio liso tiene fricción baja.")]
    [Range(0f, 1f)] public float friccion = 0.1f;

    [Header("Masa / Densidad")]
    public float masa = 8f;

    [Header("Combinación con otras superficies")]
    public PhysicMaterialCombine combinacionFriccion = PhysicMaterialCombine.Minimum;
    public PhysicMaterialCombine combinacionRebote = PhysicMaterialCombine.Maximum;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AplicarPropiedadesFisicas();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update(); 
    }

    public override void RebotarBola()
    {
      
    }

    private void AplicarPropiedadesFisicas()
    {
        // Masa 
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.mass = masa;

        // Physic Material para dureza/rebote/fricción
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            PhysicMaterial vidrioMat = new PhysicMaterial("VidrioPhysicMaterial")
            {
                dynamicFriction = friccion,
                staticFriction = friccion,
                bounciness = rebote,
                frictionCombine = combinacionFriccion,
                bounceCombine = combinacionRebote
            };
            col.material = vidrioMat;
        }
    }
}