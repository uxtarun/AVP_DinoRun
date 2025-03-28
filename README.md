# AVP_DinoRun
 
DinoRun 3D

Project Documentation
Audio Video Processing and 3D Animation 

By-
Tarun Verma, 
Yashika Saxena, 
Shreya Kondvilkar

GitHub Repository: https://github.com/uxtarun/AVP_DinoRun
Date: 29 December 2024

**Game Overview**
**Game Title:** 
DinoRun 3D

Introduction: 
DinoRun 3D is a desktop game inspired by the classic Chrome dinosaur runner game. This project aims to bring a unique and nostalgic experience into a 3D environment with enhanced visuals and gameplay. The player controls a 3D dinosaur running through an endless desert landscape, where the main objective is to jump over obstacles and survive as long as possible.

Game Mechanics:
The dinosaur runs automatically in a forward direction across a 3D desert environment.  
Players click spacebar on the keyboard to make the dinosaur jump and avoid obstacles (cacti) scattered throughout the path.
The score is calculated by the time the user is able to survive in the game without crashing onto an obstacle and is displayed on the top right of the screen.
 
The game combines simple mechanics and upbeat sound effects and animations, engaging players in a fast-paced, endless runner experience.


**Team members and work distribution**

Member 1: Tarun Verma
Tarun was responsible for programming the game mechanics.
Member 2: Yashika Saxena
Yashika contributed to the 2D and 3D audio in the game.
Member 3: Shreya Kondvilkar
Shreya worked on the 3D Assets and animations in the game.


**Project folder structure **

The project follows an organized folder structure to manage game assets efficiently:  
Animations: Contains all animation files used in the game, such as the running animation for the dinosaur.  
Audio: Stores background music and jump and game over audios.  
Materials: Includes material files of 3D models (like textures and colors).  
Models: Holds 3D assets for the game, further divided into:  
Cacti: 3D models of the obstacles (cacti).  
Dino: 3D keyframe models of the dinosaur for creating animations.  
Environment: 3D assets used to build the game environment, like the running platform and desert ground.
Prefabs: Prefabs include game objects like the Player, Obstacles, Running Platform, etc.  
Scenes: Contains Unity scene file - Main.  
Scripts: Contains C# scripts that control the game's behavior, such as movement, animation, and scoring.

**Scripts:**
The script folder contains seven C# scripts: 

GameManager: This script is suitable for simple games that require pausing, game-over handling, score display, and restarting functionality.
GroundTile: This script manages spawning obstacles on a ground tile and triggers the spawning of new ground tiles. It also ensures ground tiles are destroyed after a short delay to optimize performance.
GroundSpawner: This script spawns new ground tiles sequentially using a specific spawn point, updating the position dynamically for continuous generation as the player progresses.
MoveGround: This script allows the ground to move and help the game progress. 
Jump: This script allows the player to jump using a spacebar key. 
CountdownDisplay: This script displays the “Get”, “Set”, and “Go” text in the start of the game mapped with the timings of the audio.
ScoreManager: This script manages the score of the game before it starts, during the game and after it ends. 

Starting the game: 
To start the game, open the scene titled ‘Main’ in Unity. This scene serves as the entry point of the game and contains all the essential elements, such as the environment, player (dino), and gameplay mechanics.

In-game controls:
The game features simple and intuitive controls designed for desktop:
Start Game: Press spacebar to start the game.
Dino Jump: Press spacebar to make the Dino jump to avoid colliding with the cacti.


**References** 

Game Inspiration: https://www.youtube.com/watch?v=AfqCbi3uVzc

3D Assets: https://github.com/Priler/dino3d

Dino: https://github.com/Priler/dino3d/tree/master/objects/t-rex

Cactus: https://github.com/Priler/dino3d/blob/master/objects/cactus/cactus.vox

Dessert Platform: https://github.com/Priler/dino3d/blob/master/objects/ground sand.vox

Audio Assets: 

Start Game: https://pixabay.com/sound-effects/game-start-6104/ 

Footsteps Sound: https://pixabay.com/sound-effects/running-in-grass-6237/ 

Tiny Dino audios: https://pixabay.com/sound-effects/small-dino-raspy-calls-39345/ 

Big Dino Growl: https://pixabay.com/sound-effects/robotic-monster-roar-96249/ 

Game Over Audio: https://pixabay.com/sound-effects/game-over-arcade-6435/ 

Mechanics Tutorial:

https://www.youtube.com/watch?v=Ldyw5IFkEUQ

https://www.youtube.com/playlist?list=PLvcJYjdXa962PHXFjQ5ugP59Ayia-rxM3

https://www.youtube.com/watch?v=3N3rUWclSbo

Reference Code: 
Some Code was taken from the YouTube videos, referred to above, some code was written with the help of ChatGPT and most of the code logic was written on our own.


