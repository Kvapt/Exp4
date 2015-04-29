using UnityEngine;
using System.Collections;

public class Exp1 : MonoBehaviour 	{
	
	private FContainer _currentPage;	
	public static Exp1 instance;
	//private FSprite _man2;


	//private int _frameCountnew = 0;
	
	private void Start () {
		

		FutileParams fparams = new FutileParams (false, false, true, true);

		fparams.AddResolutionLevel (480.0f, 1.0f, 1.0f, "");			
		fparams.origin = new Vector2(0.5f, 0.5f);		


		Futile.instance.Init (fparams);
		Futile.atlasManager.LoadAtlas ("Atlases/Sprite6");

		Futile.atlasManager.LoadFont ("font", "font", "Atlases/font", 0, 0);

		instance = new Exp1();

		//_man2 = new FSprite ("Man1");
		//Futile.stage.AddChild (_man2);

		SwitchToTitlePage ();
		
		
	}
	
	public void SwitchToTitlePage ()
	{
		if (_currentPage != null) {
			_currentPage.RemoveFromContainer ();
			Debug.Log ("REMOVED!");
		}
		
		_currentPage = new TitlePage();
		Futile.stage.AddChild (_currentPage);
	}




	void Update () {



	
	}
}
	