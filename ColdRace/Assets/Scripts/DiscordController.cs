using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{

    public Discord.Discord discord;
    public string details;
    public string state;
    // Start is called before the first frame update
    void Start()
    {


        discord = new Discord.Discord(924839115713814578, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = details,
            State = state,
            Timestamps =
            {
                 Start = 5,
             },

            Assets =
            {
                LargeImage = "banner",

            }
        };



        activityManager.UpdateActivity(activity, (res) => {
            if (res == Discord.Result.Ok)
                Debug.Log("Discord Status Set");
            else
                Debug.LogError("Discord fail");
        });

    }


    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }
}
