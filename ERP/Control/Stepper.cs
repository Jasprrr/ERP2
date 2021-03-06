﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ERP.Control
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ERP.Control"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ERP.Control;assembly=ERP.Control"
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
    ///     <MyNamespace:Stepper/>
    ///
    /// </summary>
    public class Stepper : ButtonBase
    {
        static Stepper()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Stepper), new FrameworkPropertyMetadata(typeof(Stepper)));
        }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label", typeof(string), typeof(Stepper), new PropertyMetadata(default(string)));

        public object Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly DependencyProperty StageProperty = DependencyProperty.Register(
            "Stage", typeof(string), typeof(Stepper), new PropertyMetadata(default(string)));

        public object Stage
        {
            get { return (string)GetValue(StageProperty); }
            set { SetValue(StageProperty, value); }
        }

        public static readonly DependencyProperty ErrorProperty = DependencyProperty.Register(
            "Error", typeof(string), typeof(Stepper), new PropertyMetadata(default(string)));

        public object Error
        {
            get { return (string)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }
    }

}
