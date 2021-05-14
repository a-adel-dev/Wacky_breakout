using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configData.PaddleMoveUnitsPerSecond; }
    }
    /// <summary>
    /// Determines the Ball bounce speed.
    /// </summary>
    public static float ballImpulseForce
    {
        get { return configData.BallImpulseForce; }
    }

    public static float ballLifeTimeInSeconds 
    { 
        get { return configData.BallLifetimeInSeconds; }
    }

    public static float minSpawnTime
    {
        get { return configData.MinSpawnTime; }
    }

    public static float maxSpawnTime
    {
        get { return configData.MaxSpawnTime; }
    }

    public static ConfigurationData configData { get; set; }
    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configData = new ConfigurationData();

    }
}
