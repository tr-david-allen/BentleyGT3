using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bentley.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Bentley.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Bentley.Controls;assembly=Bentley.Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:SliderButton/>
    ///
    /// </summary>
    public class SliderButton : System.Windows.Controls.Primitives.ToggleButton
    {
        public double ButtonWidth
        {
            get
            {
                return (double)GetValue(ButtonWidthProperty);
            }
            set
            {
                SetValue(ButtonWidthProperty, value);
            }
        }

        public static readonly System.Windows.DependencyProperty ButtonWidthProperty =
               System.Windows.DependencyProperty.Register("ButtonWidth", typeof(double),
               typeof(SliderButton), new System.Windows.PropertyMetadata(0.0));

        public string OnLabel
        {
            get
            {
                return (string)GetValue(OnLabelProperty);
            }
            set
            {
                SetValue(OnLabelProperty, value);
            }
        }

        public static readonly System.Windows.DependencyProperty
               OnLabelProperty = System.Windows.DependencyProperty.Register
               ("OnLabel", typeof(string), typeof(SliderButton),
               new System.Windows.PropertyMetadata(""));

        public string OffLabel
        {
            get
            {
                return (string)GetValue(OffLabelProperty);
            }
            set
            {
                SetValue(OffLabelProperty, value);
            }
        }

        public static readonly System.Windows.DependencyProperty OffLabelProperty =
               System.Windows.DependencyProperty.Register("OffLabel", typeof(string),
               typeof(SliderButton), new System.Windows.PropertyMetadata(""));
    }
}
