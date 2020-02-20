﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : CharacterControllerBase {

    public virtual List<GameObject> TargetsInAgrArea { get; set; }

    protected override void Start() {
        base.Start();
        TargetsInAgrArea = new List<GameObject>();
    }


    protected override void Update() {
        base.Update();
    }

    void MoveToObject(GameObject movementTarget) {
        transform.LookAt(movementTarget.transform);
        Vector3 target = movementTarget.transform.position - transform.position;
        target /= target.magnitude;
        transform.Translate(target * 0.05f);
        //if (Rigidbody.velocity.x > EnemyMaxSpeed || Rigidbody.velocity.y > EnemyMaxSpeed) {
        //}
        //else {
        //    Rigidbody.AddForce(target * EnemySpeed * 1.5f);
        //}
    }
    protected virtual void ApplyEnemyMovement() {
        GameObject movementTarget = TargetsInAgrArea.Count > 0 ? TargetsInAgrArea[0] : null;
        if (movementTarget != null && !TargetsInAttackArea.Contains(movementTarget)) {
            MoveToObject(movementTarget);
        }
    }
    protected override void FixedUpdate() {
        base.FixedUpdate();
        ApplyFightControll();
        ApplyEnemyMovement();
    }
    protected virtual void ApplyFightControll() {
        bool isAtackOccured = DoAttack();
    }
    protected override bool DoAttack() {
        TargetsInAgrArea.RemoveAll(s => s == null);
        return base.DoAttack();        
    }
}
