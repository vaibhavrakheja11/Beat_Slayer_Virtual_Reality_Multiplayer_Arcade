# Beat Slayer Virtual Reality Multiplayer Arcade

## Versions:
Unity : 2018.4.15f1, 2019.2,19f1
Photon Networking: PUN 2 
Oculus Integration 2 (Asset Store)
Oculus RIFT S build 12.0

## Compatible Devices
Oculus RIFT S (Development Device)
Oculus Quest (Android Testing Device)
Oculus Rift (Development Device [Deprecated])
HTC Vive Pro (Steam VR Compatibility)
HTC Vive (Compatible Device)


## Overview
The best VR games are the ones that give you a middle ground between having the full control over the player movement and still standing in single place. While games like beat saber and pistol while provide freedom of layer movement, the transform movement of the game is still controlled by the game where the player continuously moves forward while enemies and objectives spawn on runtime. The speed of the player is directly proportional to the bpm of the audio-track and off-course the difficulty level. This caused nausea- tic feeling to many and hence, if a player feels un-comfortable for the first gameplay, it’s quite obvious that the user would not want to play the game again. To over-come this, we took a step ahead by providing not only providing the player freedom of movement in the game by not keeping it fixed. We divided the overall movement of the player into two sections. Instead of giving the control of these sections to the user on a single controller, we split the task between both the controllers. This made the player move from the left controller and change the angle towards the enemy player by right controller. So now, by just standing in the same spot, we are now able to move according to our will and also change the direction of the player without making any movement in the real life. This is a first-person shooting game, where the player can navigate along the scene, shoot, change weapon, pickup/drop weapons. While being a multiplayer game, other players of the same platform can join in the virtual world and play against each other. The player can navigate through the stage
with the joystick of Oculus Rift(S)/Quest controller, shoot with the trigger buttons and throw grenades or other projectiles with the motion of hand gestures. While the basic setup of the game remains the same as any regular battle royale game, to add spice to the game, we have included 2 additional weapons in the game, which provide an edge over the opponent. The two additional weapons namely, Magic Grab and Bunny-Boots, provide you the ability to grab objects from a far off distance and the ability to slow down the time for other players in order to get a clear shot respectively. We plan to implement the multiplayer version using Photon (PUN- Photon Unity Networking) and achieved the basic room setup, player joining setup and creating clone players and providing them instances through RPC call backs. However, the complete setup of multiplayer with player specific game object instantiation and with specific serializable RPC calls is still an objective to be achieved.


## Installation

Clone the repository in a new folder. Make sure you have the suitable versions of Unity installed. Make sure you have the similar versions.

Version 2019.2.19f1: Supports the entire game with animation rigging for full body haptics using Inverse Kinematics (IKs). 
Version 2018.4.15f1: Would support the basic functions of the game that includes oculus and steam support to play the game. The only feature that won't work in this game is bonework Animation Rigging for full body haptic sense and other full body dynamics.

#### Setting up Oculus and Steam VR
The game can be played with Oculus software provided you are trying to run the game on an oculus device. Once the device is properly connected, Oculus will update the software. Please note that the minimum version of build required for Oculus Rift S (latest device by oculus) is build 12. Having build versions lesser than the value would result in errors related to full body haptic IK and bone animation rigging addon. This game is also compatible with 

#### Playing Beat Slayer
Once you have clonned the repository and installed the required softwares with specified versions, you are good to go, simply press the play button on the editor. Make sure you have already vreated a safe area as the game would explicitly not prompt if a safe area ins't found.


#### Controls
#### RIFT S controller setup
  Left Controller : 
              - Thumbstick : Move the player forwards,backward,left,right
              - Trigger Button 1: Fire from gun
              - Trigger button2 : Distance Grab the object you are pointing at.
  Right Controller : 
              - Thumbstick :  Change Camera angle by 30 Degrees left or right respectively.
              - Trigger Button 1: Fire from gun
              - Trigger button2 : Distance Grab the object you are pointing at.
  Reload : Gesture Mapped
          - Flick your hand 90 degrees towrads the ground and quickly reset it to the normal position. The flick of the hand      is important as the gesture is mapped to that. 




