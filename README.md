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


## Open-Source Assets
### W1
- Animals: https://assetstore.unity.com/packages/3d/characters/animals/animals-free-animated-low-poly-3d-models-260727 
- Low-poly environment: https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153 
