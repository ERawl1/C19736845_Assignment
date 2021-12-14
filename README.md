# C19736845_Assignment
C19736845 - Evan Rawl, TU984 Game Engines 1

# Description

For my assignment I have created a procedurally generated 3D runner game, the player must avoid the random obstacles heading their way and collecting pickups to increase their score.

# Instructions for Use

The project is running on the Unity 2020.3.18f1 Editor version.
Controls are as follows:
W, A, S, D - Movement
R - Reset Game

# How it works

At the start of the game the initial tiles, mesh, obstacles and pickups are spawned, the player can then navigate through the random assortment of these items to get the highest score they can. Using a For loop the first of the initial tiles are generated, alongside the mesh generator which generates the mesh to the scaled size. Then the obstacles are created and placed in a random point in the index to help with making the obstacles varied. Then pickups are spawned randomly throught out the collider for the tiles and if they are spawned within an obstacles gameobject, they are respawned elsewhere. The speed of the character slowly increases over time and creates more of a challenge over time.

# List of Classes/Assets

| Class/asset | Source |
|-----------|-----------|
| CameraMovement.cs | Self written |
| Pickup.cs | Modified from [SK-Studios](https://github.com/SK-Studios/3D-Endless-Runner-in-Unity) |
| MeshGenerator.cs | From [Brackeys](https://www.youtube.com/watch?v=64NblGkAabk) |
| GroundSpawn.cs | Modified from [SK-Studios](https://github.com/SK-Studios/3D-Endless-Runner-in-Unity) |
| Obstacle.cs | Modified from [SK-Studios](https://github.com/SK-Studios/3D-Endless-Runner-in-Unity) |
| GroundSpawn.cs | Modified from [SK-Studios](https://github.com/SK-Studios/3D-Endless-Runner-in-Unity)|
| GameManager.cs | Modified from [SK-Studios](https://github.com/SK-Studios/3D-Endless-Runner-in-Unity)|
| PlayerMovement.cs | Modified from [SK-Studios](https://github.com/SK-Studios/3D-Endless-Runner-in-Unity)|

# References

https://github.com/SK-Studios/3D-Endless-Runner-in-Unity

https://www.youtube.com/watch?v=64NblGkAabk

# What I am most proud of 

I'm proud of creating a fun little game to help showcase procedural generation, I modified the game to make it a bit more random, and adding a few extra details to make it stand out more and I was quite happy with how it turned out, I'd like to add more features to it.

# Code Example 

```C#

//Finding Axes from InputManager
        //Allows the player to move in each direction except forward and back
        //The player is also clamped so they cannot go outside the bounds of the screen
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        float horizOffset = horizontalMove * speed * Time.deltaTime;
        float vertiOffset = verticalMove * speed * Time.deltaTime;

        float rawHorizPos = transform.position.x + horizOffset;
        float clampedHorizPos = Mathf.Clamp(rawHorizPos, -horizRange, horizRange);

        float rawVertiPos = transform.position.y + vertiOffset;
        float clampedVertiPos = Mathf.Clamp(rawVertiPos, -vertiRange, vertiRange);

        transform.position = new Vector3(clampedHorizPos, clampedVertiPos, transform.position.z);

        Animation();
        
```

```C#
 Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = Random.Range(2, 8);
       
        return point;
```

# Video 

https://youtu.be/GUyU4Huv4uE

# Earlier Proposal
For my procedural generation project, I aim to create a procedurally generated solar system, the planets will be procedurally generated with differing terrains, colours, etc. I hope to depict a scene of an astronaut in space, observing the galaxy before them.
