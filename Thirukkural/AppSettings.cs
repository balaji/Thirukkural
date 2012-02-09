using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;

namespace Thirukkural {
    public class AppSettings {
        // Our isolated storage settings
        IsolatedStorageSettings settings;

        // The isolated storage key names of our settings
        const string showEnglishText = "showEnglish";

        // The default value of our settings
        const bool ShowEnglishTextDefault = true;

        /// <summary>
        /// Constructor that gets the application settings.
        /// </summary>
        public AppSettings() {
            // Get the settings for this application.
            settings = IsolatedStorageSettings.ApplicationSettings;
        }

        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddOrUpdateValue(string Key, Object value) {
            bool valueChanged = false;

            // If the key exists
            if (settings.Contains(Key)) {
                // If the value has changed
                if (settings[Key] != value) {
                    // Store the new value
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
                // Otherwise create the key.
            else {
                settings.Add(Key, value);
                valueChanged = true;
            }
            return valueChanged;
        }

        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetValueOrDefault<T>(string Key, T defaultValue) {
            T value;

            // If the key exists, retrieve the value.
            if (settings.Contains(Key)) {
                value = (T)settings[Key];
            }
                // Otherwise, use the default value.
            else {
                value = defaultValue;
            }
            return value;
        }

        /// <summary>
        /// Save the settings.
        /// </summary>
        public void Save() {
            settings.Save();
        }


        /// <summary>
        /// Property to get and set a CheckBox Setting Key.
        /// </summary>
        public bool ShowEnglishText {
            get {
                return GetValueOrDefault<bool>(showEnglishText, ShowEnglishTextDefault);
            }
            set {
                if (AddOrUpdateValue(showEnglishText, value)) {
                    Save();
                }
            }
        }
    }
}
