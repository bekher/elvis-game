## Elvis vs. Grannies

Name: Greg Bekher
Assignment Name: Programming Assignment 2, Elvis vs. Grannies

A. Required Elements
  - Click to move navigation approach
  - Elvis animations
  	* Jog on move, stop when reached destination
  	* Camera moves with elvis
  - Granny enemies. 
  	* Move towards player when within threshold, stop when out of threshold, use sauntering animation, turn slowly
  	* jumping jack animation when falling
  	* idle animation when not moving
  - Game lost on collision
  - Welcome screen with start button
  - Game lost screen
  - Pause screen
  - Game restart (R), quit (Q), pause (P) on keypress
  - Good looking skybox
  - Mixamo models 

B. Additional elements
  - Button and description for start screen
  - Added dying animation when player lost
  - Added additional logic to prevent moving on game loss and stop grannies
  - Add music

C. Known Issues
  - The camera may begin to rotate when the user clicks too much or when Elvis begins navigating to an area that requires a sharp rotation. I mitigate this slightly by throttling user clicking to once every .5 seconds, but this may still happen. I tried to fix this for a while, but ended up leaving it since it's a minor movement bug.

D. External resources
  - Elvis Presley for "Hound Dog", original 1956. From album "The Essential Elvis Presley 3.0", Disc 1.
  - Unity documentation and official tutorials
  	* https://docs.unity3d.com/Manual/nav-CouplingAnimationAndNavigation.html for the code with the nav mesh movement in Scripts/elvisController.cs and Scripts/elvisAnim.cs.
  - MSDN documentation for C#
  - Mixamo for the models and animations
  - Wispy skybox from the asset store: https://www.assetstore.unity3d.com/en/#!/publisher/4555
  - http://answers.unity3d.com/questions/166666/slow-lookat.html
  for slowing down rotations
  - http://answers.unity3d.com/questions/274809/how-to-make-enemy-chase-player-basic-ai.html for the basic Granny chasing logic
  - http://answers.unity3d.com/questions/578156/how-to-pause-game.html for game pausing

