# Test-task-shooter
//Hello there, this Assets folder for Unity project Unity 2021.3.8f1 version...
//====================================================================================================================================

//Change name folder to Assets
//Copy this Assets folder & paste it in your new project folder 
//with all changes - (change folder Assets in your project to this Assets folder)...
//====================================================================================================================================
In project need create some layers & change in project settings/Physics:
//====================================================================================================================================
//1) - create Layers for (JailObjects) named it what ever you want
//2) - create Layer for (GroundFloor-1,2,3 & for Ladder) call layer - "Ground" 
//3) - create Layer for (FirstPersonCharacter) call layer "Player"
//4) - create Layer for (Prisoner 1) in folder Prefabs , call layer "Enemy"
//5) - create Layer for (BulletPrefab) in folder Prefabs , call layer "Bullet"

//====================================================================================================================================
//set this parameters in ProjectSettings/Physics:
//1) - set collision bool deactive for (JailObjects) layer what you call (your created name) not collision with "Ground" layer & this layer to
//((JailObjects).layer not collision with (JailObjects).layer);

//2) - set collision bool deactive for "Enemy" layer not collision with "Enemy" layer;

//3) - set collision bool deactive for "Player" layer not collision with "Player" layer & not collision with "Bullet" layer;

//4) - set collision bool deactive for "Bullet" layer not collision with "Bullet" layer & not collision with "Player" layer;
//====================================================================================================================================
//Chose all this layers for their objects;
//Do this for all objects in children;
//====================================================================================================================================
//In Build Settings Add two Scenes from Scenes folder:
//Main menu.scene set - 0
//GamePlay.scene set - 1;
//====================================================================================================================================
//Glad to help you;
//====================================================================================================================================
