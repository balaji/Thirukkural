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

        const string eOrder = "e";
        const string mOrder = "m";
        const string kOrder = "k";
        const string sOrder = "s";

        const bool ShowEnglishTextDefault = true;      

        public AppSettings() {
            // Get the settings for this application.
            settings = IsolatedStorageSettings.ApplicationSettings;
        }
        
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

        public void Save() {
            settings.Save();
        }

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

        public int EOrder {
            get {
                return GetValueOrDefault<int>(eOrder, 1);
            }
            set {
                if (AddOrUpdateValue(eOrder, value)) {
                    Save();
                }
            }
        }

        public int MOrder {
            get {
                return GetValueOrDefault<int>(mOrder, 2);
            }
            set {
                if (AddOrUpdateValue(mOrder, value)) {
                    Save();
                }
            }
        }

        public int KOrder {
            get {
                return GetValueOrDefault<int>(kOrder, 3);
            }
            set {
                if (AddOrUpdateValue(kOrder, value)) {
                    Save();
                }
            }
        }

        public int SOrder {
            get {
                return GetValueOrDefault<int>(sOrder, 4);
            }
            set {
                if (AddOrUpdateValue(sOrder, value)) {
                    Save();
                }
            }
        }
    }
}
