using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TitlePage : FContainer, FMultiTouchableInterface 
{
	private FSprite _background;
	private FSprite _background2;
	private FSprite _background3;
	private FSprite _background4;
	private FSprite _background5;


	private FLabel _label;
	private FLabel _label2;
	private FSprite _man1;
	private FSprite _bomb1;
	private FSprite _bomb2;

	private int _frameCount = 0;
	private int _frameCount2 = 0;
	private int _score = 0;

	int y = 120;
	int _flag = 3;
	int _flagB = 1;
	int _flagNB = 0;
		
	public TitlePage ()
	{
		_background = new FSprite ("bg2");
		AddChild (_background);

		_background2 = new FSprite ("bg3");
		AddChild (_background2);
		_background2.x = _background.x + 319.0f;

				
		_background3 = new FSprite ("bg3");
		AddChild (_background3);
		_background3.x = _background.x - 319.0f;

		_background4 = new FSprite ("bg2");
		AddChild (_background4);
		_background4.x = _background.x - 638.0f;

		_background5 = new FSprite ("bg2");
		AddChild (_background5);
		_background4.x = _background5.x + 638.0f;
		
		
		_label = new FLabel ("font", "");
		AddChild (_label);

		_label2 = new FLabel ("font", "SCORE = " + _score);
		AddChild (_label2);

		_label2.scale = 0.5f;
		_label2.x = -100.0f;
		_label2.y = 200.0f;
	

		Debug.Log ("label x = " + _label.x);
		_label.anchorX = 0;
		_label.anchorY = 0;
		_label.scale = 0.5f;
		_label.x = -100.0f;
		_label.y = 50.0f;

		_man1 = new FSprite ("Man1");
		AddChild (_man1);

		_bomb1 = new FSprite ("bomb");
		AddChild (_bomb1);
		_bomb1.y = -119.0f;
		_bomb1.x = 479.0f;

		_bomb2 = new FSprite ("bomb");
		AddChild (_bomb2);
		_bomb2.x = -479.0f;
		
		Debug.Log ("start x  " + _man1.x);
		Debug.Log ("start y  " + _man1.y);
		_man1.y = -143.0f;
		_man1.x = 0.0f;
		Debug.Log ("after change x " + _man1.x);
		Debug.Log ("after change y " + _man1.y);

		Futile.touchManager.AddMultiTouchTarget (this);
		Futile.instance.SignalUpdate += HandleUpdate; 
		

	}


	public void HandleMultiTouch (FTouch[] touches)
	{
		foreach (FTouch touch in touches) {



			if (touch.phase == TouchPhase.Began) {
				if (_man1.y < 50)
				{
				if (touch.position.x > 0 )
				{

				if(_flag == 3) _flag = 0;
				y = 120;
				_flagB = 1;
				}
				else
				{
			
				if(_flag == 3) _flag = 0;
				y = 120;
				_flagB = -1;
				}
				}
			}
		}
	}

	public void MoveManForward ()
	{
		Debug.Log ("_flag = " + _flag);

		
		if (_flag==0) {
			y = y / 2;
			_man1.y = _man1.y + y;
			Debug.Log ("y " + y + "; _man2.y " + _man1.y);
			if (y == 1) _flag = 1;
			if (_flagB == 1)
			{
				_background.x -= 10;
				_background2.x = _background.x + 319.0f;;
				_background3.x = _background.x - 319.0f;
				_background4.x = _background.x - 638.0f;
				_background5.x = _background.x + 638.0f;
				_bomb1.x -= 10;
				if (_flagNB == 1)
				{
					_bomb2.y = -119.0f;
					_bomb2.x = _bomb1.x + 100.0f;
				}
				
				if (_bomb1.x < -220.0f)
				{
					_flagNB = 1;
					RemoveChild (_bomb1);
					AddChild (_bomb1);
					//AddChild (_bomb2);
					_bomb1.y = -119.0f;
					_bomb1.x = 479.0f;
					if (_flagNB == 1)
					{
					_bomb2.y = -119.0f;
					_bomb2.x = _bomb1.x + 100.0f;
					}
				}

				if (_bomb1.x < _man1.x && _bomb1.x > -10.0f)
				{
					_score++;
				}

				if (_background.x < -479.0f)
				{
					_background.x = _background.x + 638.0f;
				}
			}
			else
			{
				_background.x += 7;
				_background2.x = _background.x + 319.0f;;
				_background3.x = _background.x - 319.0f;
				_background4.x = _background.x - 638.0f;
				_background5.x = _background.x + 638.0f;
				_bomb1.x += 7;
				if (_flagNB == 1)
				{
					_bomb2.y = -119.0f;
					_bomb2.x = _bomb1.x + 100.0f;
				}
				if (_background.x > 479.0f)
				{
					_background.x = _background.x - 638.0f;
				}
			}		

		} 
		else {
			
			if (_man1.y > -103) {
				y = y * 2;
				
				_man1.y = _man1.y - y;
				if (_man1.y < -110 ) 
				{
					_man1.y = -143;
					_label2.text = "SCORE = " + _score;
					_flag = 3;

				}

				if (_flagB == 1)
				{
					_background.x -= 10;
					_background2.x = _background.x + 319.0f;;
					_background3.x = _background.x - 319.0f;
					_background4.x = _background.x - 638.0f;
					_background5.x = _background.x + 638.0f;
					_bomb1.x -= 10;

					if (_flagNB == 1)
					{
						_bomb2.y = -119.0f;
						_bomb2.x = _bomb1.x + 100.0f;
					}
					
				}
				else
				{
					_background.x += 7;
					_background2.x = _background.x + 319.0f;;
					_background3.x = _background.x - 319.0f;
					_background4.x = _background.x - 638.0f;
					_background5.x = _background.x + 638.0f;
					_bomb1.x += 7;
					if (_flagNB == 1)
					{
						_bomb2.y = -119.0f;
						_bomb2.x = _bomb1.x + 100.0f;
					}

				}
			}
		}

	}

	private void HandleUpdate ()
	{
		//_label.text = "frameCount = " + _frameCount;
		_frameCount = (++_frameCount) % 60;
		//_label.text = "ONLY HERE frameCount = " + _frameCount2;
		_frameCount2 = (++_frameCount2) % 60;

		Vector2 _manPos = _man1.textureRect.position;
		Vector2 _bombPos = _bomb1.textureRect.position;
		Debug.Log ("MP " + _manPos);
		Debug.Log ("BM " + _bombPos);
		Debug.Log ("_man1.x " + _man1.x);
		Debug.Log ("_man1.textureRect.xMin " + _man1.textureRect.xMin);
		Debug.Log ("_bomb1.x " + _bomb1.x);
		Debug.Log ("_bomb1.textureRect.xMin " + _bomb1.textureRect.xMin);
		Debug.Log ("_man1.width " + _man1.width);

	
		if ((Math.Abs (_man1.x - _bomb1.x) < 38.0f) && (Math.Abs (_man1.y - _bomb1.y) < 44.0f) || (Math.Abs (_man1.x - _bomb2.x) < 38.0f) && (Math.Abs (_man1.y - _bomb2.y) < 44.0f)) 
		{

			_label.text = "KABOOOOOOOM!";
			_label2.text = " " + _score + " Lost!";

			_bomb1.shader = FShader.Additive;
			Go.to(_bomb1,1.0f,new TweenConfig().floatProp("scale",2.5f).floatProp("alpha",0.0f).onComplete(HandleBombExplosionComplete));

			_bomb2.shader = FShader.Additive;
			Go.to(_bomb2,1.0f,new TweenConfig().floatProp("scale",2.5f).floatProp("alpha",0.0f).onComplete(HandleBombExplosionComplete));
			RemoveChild (_man1);

		} else {
			_label.text = "";
		}
		MoveManForward ();

	}

	private void HandleBombExplosionComplete (AbstractTween tween)
	{
		Exp1 explodedBomb = (tween as Tween).target as Exp1;

		//RemoveAllChildren ();
		//Exp1.instance.SwitchToTitlePage();

	}


	
}



