using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomize_anim : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start()
	{
        animator = GetComponent<Animator>();
		animator.Play(0,-1, Random.value);
	}

	// Update is called once per frame

}
