using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageViewer : Interactable {

    public Sprite image;

	public override void Interact()
	{
        GameManager.instance.iVCanvas.Activate(image);
	}
}
