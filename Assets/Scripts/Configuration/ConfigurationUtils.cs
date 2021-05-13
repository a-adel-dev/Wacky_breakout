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
