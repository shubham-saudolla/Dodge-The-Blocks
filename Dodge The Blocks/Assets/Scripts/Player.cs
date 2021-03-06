﻿/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float speed = 15f;
	public float mapWidth = 5f;
	private Rigidbody2D _rb;

	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		Movement();
	}

	public void Movement()
	{
		if(GameManager.instance.gameOver == false)
		{
			float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed; //smoothened out value. Else use rawInput

			Vector2 newPosition = _rb.position + Vector2.right * x;

			newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth); //clamping the horizontal positions

			_rb.MovePosition(newPosition);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Block") //using col.gameObject,tag instead of col.collider.tag
		{
			GameManager.instance.EndGame(); //using the singleton pattern
		}
	}
}
