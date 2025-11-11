# in-class-activities
## Devlogs
### W1
Write your W1 activity Devlog here.
Hello World!
### W2
Create future Devlog sub-headers with the three # symbols, then write your Devlogs below them.
1. Why are the r, g, and b variables floats instead of ints, bools, or strings?
2. Why is the _bounce variable an int instead of a float, bool, or string?
3. The error you got after Step X of Part 2 told you something useful about why that line of code was broken- what was it?

The variables r, g, and b are all floating-point numbers because in Unity, color values need to represent decimal numbers ranging from 0.0 to 1.0 in order to accurately represent the intensity of the color. The variable _bounces is an integer because it is used to record the number of bounces of the ball, and the number of bounces is always an integer. After step X in the second part, the error message helped me realize that the reason why that line of code was wrong was due to incorrect syntax (such as missing semicolons). This made me understand how important it is to strictly follow the C# grammar rules.

### W3
I belong to Table 5, and I will be answering question 1.
Q: You’re building a rhythm game, and you’re writing a method named DidPlayerHitBeat that tells you whether or not the player accurately hit a beat based on the time that they pressed a key.
The input will include float x and float y. Float x refers to the moment when player's finger touches the screen. Float y refers to the moment when player's finger leaves the screen. In the body part of the method, we will substract y from x to obtain float z. If z is greater than 0.2s, then bool whetherHit equals true. The boolean type whetherHit variable will be the output.
Input: float x (touch time); float y (leave time)
Output type: boolean

For instance, a class is like a cake recipe: it's a template that specifies the required ingredients and the steps to follow. Components are the actual cakes made according to the recipe, each cake has its own ingredient proportions and can be used independently. In this analogy, member variables are the ingredients of the cake, representing the characteristics of each object, such as a cat's health points or a ball's movement speed. Methods are the actions the cake can perform, like cutting, decorating, or baking, corresponding to the behaviors of objects, such as a cat moving and jumping, or its reaction when hit by a ball. 
As for why the small ball becomes particularly bright after bouncing multiple times: each time it collides, the speed of the ball is multiplied by an acceleration coefficient. Once it exceeds a certain threshold, the color brightness will increase. Because the small ball in the scene collides frequently, the speed and brightness effect accumulate continuously. After bouncing many times, it naturally becomes super bright.

### W4
I belong to Table 5, and I will describe line 5, 22, 25 these three lines of code.
Line 5: _moveSpeed is a member variable of type float. [SerializeField] lets us see and adjust it in the Inspector even though it’s private. It controls how fast the cat moves.
Line 22: This line calls the method Input.GetAxis("Vertical") to read player input. The result (a float between -1 and 1) is multiplied by _moveSpeed and Time.deltaTime to calculate smooth movement.
Line 25: This line calls the method Translate() from the Transform component to move the cat forward along the Z-axis by translation.

table #5
1. What solution did you come up with for the collider activity, and why? Specifically- which objects did you add Rigidbodies to, and which object(s) did you check Is Trigger on?
We added Rigidbody to Cat and SoccerBall so that they can be affected by physics and collide with each other. Goal uses BoxCollider and Is Trigger is checked, so that when the ball enters the goal, it can be detected but not blocked.
2. IF your game did not work perfectly the first time you tested it, talk about what you had to fix.
At first, the cat didn't touch the ground when it was in the air. Later, it was discovered that the center of the collider needed to be adjusted, and the height and radius also needed to be gradually adjusted until the cat was in a suitable position. After making these changes, everything worked properly.

### W5
Activity #1
Question: What does transform.Translate() actually do in Unity?
Answer:
It moves the GameObject in its local coordinate space. For example, Vector3.forward means moving forward based on the object’s current rotation. If I want the movement to happen in the world space, I can use transform.Translate(direction, Space.World).

Activity #2
1. What member variable(s) does this class need?
2. What method(s) does this class need? Should it be something that Unity provides (like Start(), Update(), or a collision method), or one you write?
3. What should the method(s) do?

#answer
1. (1) Transform _targetTransform: the Transform of the GameObject the deer should walk toward (e.g., a red mushroom).
   (2) NavMeshAgent _agent: used to control the deer’s movement on the NavMesh.
  
2. Start(): a built-in Unity method that runs once when the game begins. It should find the NavMeshAgent and set its destination.

3.
In Start(), use GetComponent<NavMeshAgent>() to get the NavMeshAgent component attached to the Deer GameObject.  
Then call _agent.SetDestination(_targetTransform.position) so the deer walks toward the target object.  
_targetTransform should be adjustable in the Inspector to choose any target in the scene (like the red mushroom)

### W6
# Activity 1
other tools, and for supplementing contents
Google Doc Link: https://docs.google.com/document/d/1exNqQE_zGuOoztND9FT3ldDwkXjJ6m8a8oRDWERaMyg/edit?tab=t.0

# Activity 2
1. Member Variables  
Transform cat → Player object (Cat); the bat needs to know the player's position.  
float speed → Bat's movement speed, adjustable in the Inspector.  
bool isChasing → Flag to indicate if the bat is chasing the player.  

2. Methods  
- Unity built-in methods:  
Update() → Checks if chasing is active every frame and moves the bat.
- Custom methods:  
StartChasing() → Sets isChasing = true to make the bat start chasing.  
StopChasing() → Sets isChasing = false to make the bat stop chasing.  

3. Method Behavior  
Update(): If isChasing is true and the player exists, the bat moves toward the player.  
StartChasing(): Enables chasing, callable by BatManager or for testing.  
StopChasing(): Disables chasing, controlled by BatManager to manage the bat's behavior.

Pair Programming Notes:
My partner and I first discussed the necessary member variables and methods for the BatW6 class, clarifying our goals: ensuring the bat’s behavior triggers when the player approaches, and enabling the bat to chase the player during movement.  
We collaborated on writing the code—I checked the logic and suggested optimizations (e.g., using Vector3.MoveTowards for the bat’s movement) while my partner handled the final modifications.  
After completing the code, we tested it together to confirm the bat correctly chases the player and stops when StopChasing() is called.

### W7
Activity 1:
[[Link to our Google Doc](https://docs.google.com/document/d/1TsVke4FYWiPQJM1o9TWKmZdGuEjed6uXTYwZxrXfC3I/edit?usp=sharing)] 

My Role: Gameplay System — I designed how the kitty plants flowers, including the flower’s three-stage growth process, scoring system, and interaction cooldown.

Activity 2:
Question: What was wrong with the code in Step 2?
Answer: The Step 2 code only used `transform.up` and didn’t adjust the direction according to the bubble’s surface normal. This caused the Muskrat to move incorrectly on curved surfaces. The correct approach is to redefine the “up” vector based on the bubble’s normal so that movement and gravity follow the bubble’s shape.


## Open-Source Assets
### W1
- Animals: https://assetstore.unity.com/packages/3d/characters/animals/animals-free-animated-low-poly-3d-models-260727 
- Low-poly environment: https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153 
