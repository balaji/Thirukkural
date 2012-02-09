using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Controls;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Thirukkural {
    public interface IText {
        void setEnglishText();
        void clearEnglishText();
    }
}
