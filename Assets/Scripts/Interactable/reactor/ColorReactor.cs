using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorReactor : StateReactor {

    public Color active;
    public Color inactive;
    private MeshRenderer meshRenderer;


	protected override void Awake()
	{
        base.Awake();
        meshRenderer = GetComponent<MeshRenderer>();
        React();

	}

	public override void React()
	{
        if(switcher.state){
            meshRenderer.material.color = active;
        }else{
            meshRenderer.material.color = inactive;
        }
	}
}
