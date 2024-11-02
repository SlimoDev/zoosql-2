using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AnimationInType
{
    None,
    FadeIn,
    SlideIn,
    ScaleIn,
}

public enum AnimationOutType
{
    None,
    FadeOut,
    SlideOut,
    ScaleOut,
}

public enum GameType
{
    None,
    CardsGame,
    QuizGame
}

public interface IConfigDataStore
{
    void SaveConfigData(ConfigData configData);
    ConfigData LoadConfigData();
}