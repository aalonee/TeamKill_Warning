using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Template
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        [Description("The message to show to the teamkiller (uses ShotDuration)")]
        public string AttackerShooting { get; set; } = "<color=red>YOU'RE SHOOTING AT YOUR TEAMMATE <color=orange>%target%<color=red>!</color>";

        [Description("The message to show to the target (uses ShotDuration)")]
        public string TargetShot { get; set; } = "<color=red>YOU WERE SHOT BY <color=orange>%attacker%<color=red>!</color>";

        [Description("The message to show to the teamkiller after killing the teammate (uses KillDuration)")]
        public string AttackerKilling { get; set; } = "<color=red>YOU TEAMKILLED YOUR TEAMMATE <color=orange>%target%<color=red>!</color>";

        [Description("The message to show to the targer after getting killed by teamkiller (uses KillDuration)")]
        public string TargetKilled { get; set; } = "<color=red>YOU WERE TEAMKILLED BY <color=orange>%attacker%<color=red>!</color>";

        [Description("Duration of the hint")]
        public float ShotDuration { get; set; } = 0.5f;

        [Description("Duration of the hint")]
        public float KillDuration { get; set; } = 3.0f;
    }
}