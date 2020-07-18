namespace Snake.Properties
{

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
        public bool isGameStarted { get; set; }
        public bool isDebug { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }
        public int Score { get; set; }
        public bool GameOver { get; set; }
        public Directions direction { get; set; }
        public Settings() {
            Width = 16;
            Height = 16;
            Speed = 5;
            Score = 0;
            isDebug = true;
            GameOver = false;
            isGameStarted = false;
            direction = Directions.Down;
        }
    }
}
