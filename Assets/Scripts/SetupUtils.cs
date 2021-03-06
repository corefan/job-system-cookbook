﻿using System;
using System.Collections.Generic;
using UnityEngine;

public static class SetupUtils
{
    public static GameObject[] Place2DCubeGrid(int sideLength)
    {
        var count = sideLength * sideLength;
        var cubes = new List<GameObject>(count);

        var cubeToCopy = MakeStrippedCube();

        for (int i = 0; i < sideLength; i++)
        {
            for (int n = 0; n < sideLength; n++)
            {
                var cube = GameObject.Instantiate(cubeToCopy);
                cube.transform.position = new Vector3(i, n);
                cubes.Add(cube);
            }
        }

        return cubes.ToArray();
    }

    public static GameObject[] PlaceRandomCubes(int count, float radius)
    {
        var cubes = new GameObject[count];
        var cubeToCopy = MakeStrippedCube();

        for (int i = 0; i < count; i++)
        {
            var cube = GameObject.Instantiate(cubeToCopy);
            cube.transform.position = UnityEngine.Random.insideUnitSphere * radius;
            cubes[i] = cube;
        }

        GameObject.Destroy(cubeToCopy);

        return cubes;
    }

    public static GameObject[] PlaceRandomCubes(int count)
    {
        var radius = count / 10f;
        return PlaceRandomCubes(count, radius);
    }

    public static GameObject MakeStrippedCube()
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //turn off shadows entirely
        var renderer = cube.GetComponent<MeshRenderer>();
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        renderer.receiveShadows = false;

        // disable collision
        var collider = cube.GetComponent<Collider>();
        collider.enabled = false;

        return cube;
    }
}
