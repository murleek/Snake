using System;

namespace Snake.Properties {

    public enum Directions
    {
        Left,
        Right,
        Up,
        Down
    };
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings
    {
        public static bool isGameStarted { get; set; }
        public static bool isDebug { get; set; }
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }

        public static int Score { get; set; }
        public static bool GameOver { get; set; }
        public static Directions direction { get; set; }
        public Settings() {


            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
            Width = 16;
            Height = 16;
            Speed = 5;
            Score = 0;
            isDebug = true;
            GameOver = false;
            isGameStarted = false;
            direction = Directions.Down;
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Add code to handle the SettingChangingEvent event here.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.
        }
    }
}
