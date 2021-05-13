﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10f;
    static float ballImpulseForce = 200f;
    static float ballLifetimeInSeconds = 2f;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    public float BallLifetimeInSeconds
    {
        get { return ballLifetimeInSeconds; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;

        try
        {
            input = File.OpenText(Path.Combine(
                                    Application.streamingAssetsPath, ConfigurationDataFileName));


            string labels = input.ReadLine();
            string values = input.ReadLine();

            SetConfigurationDataFields(values);
        }
        catch(Exception e)
        {

        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    private void SetConfigurationDataFields(string values)
    {
        string[] inputValues = values.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(inputValues[0]);
        ballImpulseForce = float.Parse(inputValues[1]);
        ballLifetimeInSeconds = float.Parse(inputValues[2]);
    }

    #endregion
}
