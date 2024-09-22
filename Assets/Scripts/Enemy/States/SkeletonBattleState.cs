using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Transform player;//用于给Player定位，好判断怎么跟上他
    private Enemy_Skeleton enemy;
    private int moveDir;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameObject.Find("Player").transform;//全局找Player位置
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.IsPlayerDetected())
        {
            if(enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                Debug.Log("I Attack;");
                enemy.SetVelocity(0, rb.velocity.y);
                return;
            }
        }

        //if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
        //{
        //    Debug.Log("I Attack");
        //    enemy.SetVelocity(0, rb.velocity.y);
        //    return;
        //}
        if (player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }
        else if (player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
    }
}