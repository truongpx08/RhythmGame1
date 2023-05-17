using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Pixelplacement;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Sirenix.OdinInspector;

public class SongManager : Singleton<SongManager>
{
    public AudioSource audioSource;
    public float songDelayInSeconds;
    public double marginOfError; // in seconds

    public int inputDelayInMilliseconds;


    public string fileLocation;
    public float noteTime;
    public float noteSpawnY;
    public float noteTapY;
    private MidiFile midiFile;

    [Button]
    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(Path.Combine(Application.streamingAssetsPath, fileLocation + ".mid"));
        // GetDataFromMidi();
    }

    public List<Note> notes = new List<Note>();

    [Button]
    public void GetDataFromMidi()
    {
        notes.Clear();
        var collection = midiFile.GetNotes();
        foreach (var note in collection)
        {
            notes.Add(new Note { time = note.Time / 1000f, isPass = false });
        }

        if (collection.Count > 0)
            currentNote = notes[0];
        // var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        // notes.CopyTo(array, 0);
        // foreach (var note in array)
        // {
        //     var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, midiFile.GetTempoMap());
        //     var a = (double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds +
        //             (double)metricTimeSpan.Milliseconds / 1000f;
        //     // Debug.Log(note.Time / 1000f);
        // }
    }

    [SerializeField] private float time;

    private void Update()
    {
        if (isPlaying)
        {
            time += Time.deltaTime;
            if (Math.Abs(currentNote.time - time) < 0.01f)
            {
                currentNote.isPass = true;
                var noteIndex = notes.IndexOf(currentNote) + 1;
                Debug.Log(currentNote + " " + noteIndex);
                int nextNoteIndex = noteIndex + 1;
                if (nextNoteIndex < notes.Count - 1)
                    currentNote = notes[nextNoteIndex];
                else
                {
                    Debug.Log("EndGame");
                }
            }
        }
    }

    private bool isPlaying;
    [SerializeField] private Note currentNote;

    [Button]
    private void Play()
    {
        time = 0;
        isPlaying = true;
        audioSource.Play();
    }

    [Button]
    private void Stop()
    {
        isPlaying = false;
        audioSource.Stop();
    }
}

[Serializable]
public class Note
{
    public bool isPass;
    public float time;
}