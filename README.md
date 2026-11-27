Character Animation Project

Introduction
This project was to create a 3D character and implement character animations using blender and using unity to make the character playable and add physics. 
In this project a character was made using make human, imported to blender where a skeleton was created for the character and it was weighted so the character would move correctly when animated.
The character was then exported into unity, where a third person controller was used to allow the character to move around the environment.
New animations were created in blender and imported into unity, where they were added to the character and triggered using button presses, 
a rag doll was implemented so the character can collapse using another button press.

Creating the character in make human
I used make human, a character creation software which allows users to create custom human models by adjusting body shape,
proportions and appearance, to create the character.
Once I was happy with the characters appearance, I exported the model into blender for further development.
Importing the character into Blender
After creating the character in make human, I imported it into blender, 
to prepare the character for animation by creating an armature and weighting the character mesh to the bones. 
The character needed a skeleton to be placed inside it following the structure of the body
and certain bones had to be parented to other bones to allow for more natural movement and easier animation.
                                   

Creating Armature
An armature was created inside the character using blender the armature consisted of different bonesin the characters body like the arms, spine and the legs.
The bones were positioned inside the characters mesh and connected to form a skeleton 
and parented so that moving a main bone would in turn move the smaller attached bones.
Once the armature was complete it was weighted to the characters mesh
using the auto weight tool in blender so that it would follow the movement of the bones, 
some peace’s didn’t attach with the auto weighting and had to be ither deleted or manually attached in edit mode.
                                                                 
Weighting 
Weight painting was used after using the auto weight tool to make sure that some areas like under the arms were sticking to the right bones
, weight panting determines how much influence a bone has over a part of a character when its rotated or moved ,
certain parts of the character needed extra attention because the auto weights attached these areas to the wrong bone so it moved strangely when that bone was rotated , 
like for example the shoes were attached to the thigh bone instead of the foot or the shin , this was adjusted in this stage to be weighted to the correct bones. 

Exporting the character to unity
Once the character and armature were completed in blender, the character was exported as an fbx and imported into unity,
which made the character model, and rig allowed to be used in a unity scene. During the import process,
I checked that the character model, materials and rig were imported correctly.
I downloaded and opened the sample third person controller scene and added the character to the hierarchy replacing the original model in the scene.
                                       
Implementing the Third person controller
To allow the character to move around the Unity environment, I used a Third-Person Controller asset.
This provided a movement system which allowed the character to move around the scene using player.
I put the character in the scene and created a humanoid avatar for the character and assigned the bones, accordingly, 
deleted the old character and replaced it with my character.

Creating Animations in blender
I created custom animations for the character in blender; these animations were created by manipulating the character in blender posing the bones
at different points in the animation timelines. Keyframes were used to record the positions and rotations of the bones at different frames.
Blender then interpolated the movement between these keyframes to create the animation. Once the animations were completed, 
they were exported from Blender and imported into Unity so they could be used within the project.
                                       
Triggering Animations in unity
After importing the animations into Unity, I made a script that lets the user press a button on the keyboard to trigger the animations
by setting a value to true,and connected it to the characters main animation controller. Then in the animator 
I made transitions from the main animations to the new animations using a is true value for the transition to the new animation and when 
the animation completed it would set to false and go back to the idle animation.
                               
Ragdoll implementation
I made the rag doll by using unity’s rag doll creator on the character in the hierarchy then assigned all the bones in the correct fields
and wrote a button controlled script to activate it and disable the animator while it was active.
When the button was pressed, the character's normal movement and animation were disabled, allowing the ragdoll physics
to take control of the character's body which allowed the character to collapse and react naturally to gravity instead of remaining in its normal animated pose.

Challenges and solutions
I had a few challenges while creating this project , one of the first I have already mentioned ,
the weighting of some of the characters parts specifically under the arms was quite difficult as it was connected to the wrong bones 
and pulled upward when the character moved , this was fixed by going into weight paint and re weighting the area to the correct bone , 
a similar thing happened with some of the clothing and the hair although these were fixed by manually attaching them to the bones in editor mode.
                                                  
Another challenge I faced was that I created ik bones and I did not know that they would cause problems in unity and since I
had these ik bones my bone hierarchy was odd as the bones were parented differently this caused issues when importing to unity as the
character refused to animate and unity would not create an avatar for it. To fix this I had to disable all the ik bones on export out of blender,
and I had to re organise and parent some of the bones like the feet bones which for some reason were only parented to the root.

The last challenge I faced was getting the ragdoll to work, when I implemented the rag doll the colliders on the standard unity
third person controller were causing the character to bounce in the air and fall off the map. I fixed this by resizing all the colliders,
so they don’t intersect each other, and hence won’t cause the ragdoll to jump. The head collider ended up spawning really huge, 
and this was the main cause of the error.

                                      
Conclusion
In this project I learned how to create a character using make human,
import it into Blender, create an armature, weight the character and prepare it for animation, 
gained experience exporting assets between Blender and Unity, using a third person controller, 
creating custom bone animations and triggering animations using Keyboard input and 
I learnt how to use and create a ragdoll for characters in my projects.
