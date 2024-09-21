
# Starting scene file

### StartScreen

# How to play and what parts of the level to observe technology requirements

> Thunder McQueen is an RPG with a race-style twist. The goal of the game is to win the final race, but in order to stand a chance at winning, the player must first explore new areas on the map and collect upgrades. At the start of the game, the player learns the story behind the game and that their goal is to beat their nemesis Chicken “Lightning” Hicks in the final race. Throughout the gameplay, we demonstrate exciting situations such as collecting an upgrade while avoiding a predatory AI, maneuvering objects in a physics-based environment, and racing on a 3D racetrack. 

# Technical Implementation Guide

### It must be a 3D Game Feel game! (5 pts)

> The game is implemented in 3D
> The goal is clearly defined through interaction with NPC and upon successes or failures, the player will progress or restart certain parts of the game
> The scene StartScreen is created for the player to enter the game through
> If the player feels stuck they can press “ESC” and restart a level

### Precursors to Fun Gameplay (20 pts)

> The goal is clearly defined through interaction with NPC. 
> The player has the ability to make interesting choices. Because the game is a free-world style, the player can explore parts of the map at any point, but certain areas may be locked or unreachable
> The player choices are used to control the car and allow them to make critical choices for completing minigame levels.
> Success is rewarded with new upgrades to the car, failure means having to replay the level.
> The player has the opportunity to learn the controls of the game at the beginning. As they upgrade their car, they will learn new ways to control the car and avoid obstacles. 
> We have done our best to challenge the player at every opportunity. Each minigame we have implemented has a challenge that makes it non-trivial to beat. 

### 3D Character/Vehicle with Real-Time Control (20 pts) 

> The character control is the main part of the game as it is an RPG style game
> The animation and control of the character are our original work. As you play the game the controller gains features, such as jump.
> The animations on the character can be seen while the player is driving the car. The tires rotate in the direction of travel, much like a real car
> Throughout gameplay the animation is smooth.
> The camera is not able to pass through the exterior walls because the player is bounded by invisible walls. This technique is used for many parts of the game to keep the player on the course. 
> Auditory feedback is implemented to react to controller movements and certain objects. As the player drives around, they are able to hear an engine that increases in frequency linearly with the player’s speed. Driving over roadblocks is accompanied by a sound as well. 
> We have demonstrated coupling physics simulations and animations with the car wheels as well as certain parts of the map such as elevators. 

### 3D World with Physics and Spatial Simulation (20 pts) 

> Physics is implemented in many aspects of the game. The player controller demonstrates realistic physics through the use of wheel colliders, which interact with the environment and have tunable parameters such as friction, damping, and center of mass. This allows the player to feel like they are interacting with the environment.
> The physics is represented both physically as well as auditorily. We implement audio for the car driving on different terrains.
> Different terrains also affect the physics of the control, such as roadblocks, which affect the speed and friction of the car, making it hard to control.
> The boundaries of the world prevent the player from falling to negative infinity.
> Interactive environments are included such as elevators, which move when the player stands on them.
> The car is able to move with 6 degrees of freedom. This is done by lowering the center of mass, we can ensure the car will upright itself at all times. 
> Throughout the game, we make sure to update scenes based on time and not framerate. This ensures that if frames are lost, the gameplay will not be affected. 

### Real-time NPC Steering Behaviors / Artificial Intelligence (20 pts)

> We have incorporated AI into two aspects of the gameplay. The first is with the final boss, which uses a state machine to assign tasks based on the player’s success. The AI car will travel to waypoints to race against the player. 
> The boss changes states depending on what stage of the final level the player is on, which affects dialogue and gameplay options.
> We have also implemented an AI into the minigame, which will chase the player and increase its speed based on how successful the player is at avoiding. 
> The wolf AI utilizes root motion to transition between states. Its movement is smooth as it transitions between its states (speed/aggression)
> The difficulty with the player is adjusted based on how well the player is doing.
> The wolf is able to hide behind trees and take advantage of its environment to sneak up on the player. 

### Polish (15 pts)

> Start menu implemented in StartScreen
> The game has a pause and play button that can always be accessed with “ESC”
> There are not any debug outputs visible in the game
> There is no implemented “god-mode” for the player to debug in
> The player has particle effects as they drive around (leaving trail marks on the ground)

# External Assets

> https://assetstore.unity.com/packages/audio/sound-fx/transportation/i6-german-free-engine-sound-pack-106037
> 
> https://assetstore.unity.com/packages/3d/vehicles/land/hq-racing-car-model-no-1203-139221
> 
> https://assetstore.unity.com/packages/3d/vegetation/trees/free-trees-103208
> 
> https://assetstore.unity.com/packages/3d/environments/landscapes/free-rocks-19288
> 
> https://assetstore.unity.com/packages/3d/vehicles/land/farm-machinery-low-poly-tractor-and-planter-94533
> 
> https://assetstore.unity.com/packages/3d/vehicles/controllable-forklift-free-80275
> 
> https://assetstore.unity.com/packages/3d/vehicles/land/arcade-free-racing-car-161085
> 
> https://assetstore.unity.com/packages/tools/ai/navmesh-cleaner-151501
> 
> https://assetstore.unity.com/packages/3d/characters/animals/wolf-animated-45505

#### Car base:

> https://www.youtube.com/watch?v=Z4HA8zJhGEk
> https://github.com/GameDevChef/CarController



## License agreement

> Unity's standard Unity Asset Store End User License Agreement ("EULA")
> 
> Standard Unity Asset Store EULA
> 
> License type
> 
> Extension Asset


