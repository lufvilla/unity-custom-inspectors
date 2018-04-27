using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class MapGenerator : EditorWindow
{
    private Transform _selection;
    
    // Form Data
    private GameObject _wall;
    private GameObject _floor;
    private int _width = 1;
    private int _height = 1;
    private float _imperfection = 0.5f;

    // Progress bar
    private float _progress = 0;
    private float _total = 0;
    private string _randomString = "";
    
    private const int Limit = 60;

    // Random
    private static readonly System.Random Rnd = new System.Random();
    
    // Just 4 fun
    private List<string> RandomMessages = new List<string>(new string[]
    {
        "Generating Plans for Faster-Than-Light Travel",
        "Polishing Erudite Foreheads",
        "Spawning Your_Cube01",
        "Grrr. Bark. Bark. Grrr.",
        "Doing The Impossible",
        "DING!",
        "Adding Randomly Mispeled Words Into Text",
        "Attaching Beards to Dwarves",
        "Creating Randomly Generated Feature",
        "Does Anyone Actually Read This?",
        "Doing Something You Don't Wanna Know About",
        "Don't Panic",
        "Ensuring Everything Works Perfektly",
        "Ensuring Gnomes Are Still Short",
        "Loading, Don't Wait If You Don't Want To",
        "Look Out Behind You",
        "Looking For Graphics",
        "Now Spawning Fippy_Darkpaw_432,366,578"
    });

    [MenuItem("LevelEditor/Map Generator")]
    public static void DisplayWindow()
    {
        GetWindow<MapGenerator>("Map Generator");
    }

    public void OnGUI()
    {
        _selection = Selection.activeTransform;

        if (_selection == null || !_selection.CompareTag("MAP"))
        {
            EditorGUILayout.HelpBox("Select a valid target in scene to create map", MessageType.Info);
            return;
        }

        GUI.enabled = false;
        EditorGUILayout.ObjectField("Target", _selection, typeof(Transform), true);
        GUI.enabled = true;
        
        
        EditorGUILayout.LabelField("Select map dimensions:");
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical(GUILayout.Width(position.width-10));

        var isValid = true;
        
        _width = EditorGUILayout.IntField("Width", _width);
        if (_width > Limit || _width <= 0)
        {
            isValid = false;
            EditorGUILayout.HelpBox("Width must be more than 0 and less than " + Limit, MessageType.Error);
        }
        
        _height = EditorGUILayout.IntField("Height", _height);
        if (_height > Limit || _height <= 0)
        {
            isValid = false;
            EditorGUILayout.HelpBox("Height must be more than 0 and less than " + Limit, MessageType.Error);
        }
        
        _imperfection = EditorGUILayout.Slider("Floor imperfection", _imperfection, 0, 1);
        
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical(GUILayout.Width(position.width-10));
        
        _wall = (GameObject)EditorGUILayout.ObjectField("Wall Prefab", _wall, typeof(GameObject), false);
        if (_wall == null)
        {
            isValid = false;
            EditorGUILayout.HelpBox("You need to select a wall prefab", MessageType.Info);
        }
        
        _floor = (GameObject)EditorGUILayout.ObjectField("Floor Prefab", _floor, typeof(GameObject), false);
        if (_floor == null)
        {
            isValid = false;
            EditorGUILayout.HelpBox("You need to select a floor prefab", MessageType.Info);
        }
        
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        
        if(GUILayout.Button("Clear"))
        {
            ClearMap();
        }

        GUI.enabled = isValid && _progress >= _total;
        
        if(GUILayout.Button("Clear & Generate!"))
        {
            _progress = 0;
            _total = _width * _height;
            
            _randomString = RandomMessages[UnityEngine.Random.Range(0, RandomMessages.Count)];
            
            ClearMap();
            GenerateMap();
        }
        
        if (_progress >= _total)
        {
            EditorUtility.ClearProgressBar();
        }
    }

    private void ClearMap()
    {
        var tempList = _selection.Cast<Transform>().ToList();
        foreach (var child in tempList)
        {
            DestroyImmediate(child.gameObject);
        }
    }

    private void GenerateMap()
    {
        for (var i = 0; i < _width; i++)
        {
            for (var j = 0; j < _height; j++)
            {
                var newPosition = _selection.transform.position + new Vector3(i, 0, j);
                
                if (i == 0 || j == 0 || i == _width-1 || j == _height-1)
                {
                    Instantiate(_wall, newPosition, Quaternion.identity, _selection);
                }
                else
                {
                    var rndResult = (float)Rnd.NextDouble() % _imperfection;
                    Instantiate((_imperfection > 0.98f || rndResult > 0.25f) ? _wall : _floor, newPosition, Quaternion.identity, _selection);
                }

                _progress++;
                EditorUtility.DisplayProgressBar("Generating Map", _randomString, _progress / _total);
            }
        }
    }

    private void OnSelectionChange()
    {
        Repaint();
    }
}
