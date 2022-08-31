using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IMainMenu 
{
   bool ISGAME { get; }
    bool ISEXIT { get; }
    bool ISSOUND { get; }
    void SceneChoose(bool isGame, bool isExit);
    void SoundVolumeSwitch(bool isSound);
}
internal interface Icontroller
{
    float MOUSE_X { get; }
    float MOUSE_Y { get; }
    float MOVE { get; }
    float ROTATE { get; }
    float STRAFE { get; }
    bool JUMP { get; }
    void Move(float move);
    void Strafe(float strafe);
    void Rotate(float mouseX,float mouseY);
    void Jump(bool jump);
}
public interface IPool
{ 
    Vector3 POSITIONCOORDINATE { get; }
    bool FIRE { get; }
    bool INSTANCE { get; }
    Rigidbody RB { get; }
    GameObject GAMEOBJECT { get; }
    Rigidbody Rbs(Rigidbody rb);
    GameObject GetGameobject(GameObject gameobject);
    void Instance(Vector3 positionCoordinate);
    void Inst(bool inst);
    void Fire(bool fire);
}
public interface IAI
{ 
    bool ISATTACK { get; }
    bool ISFOLLOWTARGET { get; }
    void Attack(bool isAttack);
    void FollowTarget(bool isFollowTqrget);
}
public interface IHealth
{ 
    float HEALTH { get; }
    void TakeDamage(float damage);
    void SetStartHealth(float startHealth);
    void DamVal(float value);
}
public interface IHit
{
    float DAMAGE { get; }
    IHealth Ihealth(IHealth ihelth,float damage);
}
public interface ICalculateHP
{
    float HP { get; }
    void CAlculate(float hp);
}
public interface Ipoints
{
    int POINTS { get; }
    void SetPoints(int setPoint);
}
public interface IListener
{
    float MAIN_HP { get; }
    ICalculateHP ICALCUL(ICalculateHP iCalcul);
    IHealth IHEALTH(IHealth iHealth);
    void SetMainHP(float setValue);
    void YourEvent();
}


