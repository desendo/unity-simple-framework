//service locator
using UnityEngine;
static class Manager
{

    public static Scenes scenes;
    public static UIManager ui;
    public static InputManager  input;
    public static SoundManager sound;
    //public static GameParameters vars;
    public static Game game;
    public static SwipeDetector swipes;

    
    static Manager()
    {
        GameObject g = safeFind("_app");
        
        scenes = (Scenes)SafeComponent(g, "Scenes");
        ui = (UIManager)SafeComponent(g, "UIManager");
        input = (InputManager)SafeComponent(g, "InputManager");
        sound = (SoundManager)SafeComponent(g, "SoundManager");
        //create = (Instantiator)SafeComponent(g, "Instantiator");
        game = (Game)SafeComponent(g, "Game");
        swipes = (SwipeDetector)SafeComponent(g, "SwipeDetector");
        //save = (SaveManager)SafeComponent(g, "SaveManager");


    }


    private static GameObject safeFind(string s)
    {
        GameObject g = GameObject.Find(s);
        if (g == null) Debug.LogError("GameObject " + s + "  not on _preload.");
        return g;
    }
    private static Component SafeComponent(GameObject g, string s)
    {
        Component c = g.GetComponent(s);
        if (c == null) Debug.LogError("Component " + s + " not on _preload.");
        return c;
    }

}