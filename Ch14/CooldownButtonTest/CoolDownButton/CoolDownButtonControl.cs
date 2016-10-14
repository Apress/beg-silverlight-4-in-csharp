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

namespace CoolDownButton
{
    [TemplatePart(Name = "Core", Type = typeof(FrameworkElement))]
    [TemplateVisualState(Name = "Normal", GroupName = "NormalStates")]
    [TemplateVisualState(Name = "MouseOver", GroupName = " NormalStates")]
    [TemplateVisualState(Name = "Pressed", GroupName = " NormalStates")]
    [TemplateVisualState(Name = "CoolDown", GroupName = "CoolDownStates")]
    [TemplateVisualState(Name = "Available", GroupName = "CoolDownStates")]
    public class CoolDownButtonControl : Control
    {
        private FrameworkElement corePart;
        private bool isPressed, isMouseOver, isCoolDown;
        private DateTime pressedTime;

        public CoolDownButtonControl()
        {
            DefaultStyleKey = typeof(CoolDownButtonControl);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            CorePart = (FrameworkElement)GetTemplateChild("corePart");

            GoToState(false);
        }

        private FrameworkElement CorePart
        {
            get
            {
                return corePart;
            }

            set
            {
                FrameworkElement oldCorePart = corePart;

                if (oldCorePart != null)
                {
                    oldCorePart.MouseEnter -=
                        new MouseEventHandler(corePart_MouseEnter);
                    oldCorePart.MouseLeave -=
                        new MouseEventHandler(corePart_MouseLeave);
                    oldCorePart.MouseLeftButtonDown -=
                        new MouseButtonEventHandler(
                            corePart_MouseLeftButtonDown);
                    oldCorePart.MouseLeftButtonUp -=
                        new MouseButtonEventHandler(
                            corePart_MouseLeftButtonUp);
                }

                corePart = value;

                if (corePart != null)
                {
                    corePart.MouseEnter +=
                        new MouseEventHandler(corePart_MouseEnter);
                    corePart.MouseLeave +=
                        new MouseEventHandler(corePart_MouseLeave);
                    corePart.MouseLeftButtonDown +=
                        new MouseButtonEventHandler(
                            corePart_MouseLeftButtonDown);
                    corePart.MouseLeftButtonUp +=
                        new MouseButtonEventHandler(
                            corePart_MouseLeftButtonUp);
                }
            }

        }



        private bool CheckCoolDown()
        {
            if (!isCoolDown)
            {
                return false;
            }
            else
            {
                if (DateTime.Now > pressedTime.AddSeconds(CoolDownSeconds))
                {
                    isCoolDown = false;
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        void corePart_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!CheckCoolDown())
            {
                isMouseOver = true;
                GoToState(true);
            }
        }

        void corePart_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!CheckCoolDown())
            {
                isMouseOver = false;
                GoToState(true);
            }
        }

        void corePart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!CheckCoolDown())
            {
                isPressed = true;
                GoToState(true);
            }
        }

        void corePart_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!CheckCoolDown())
            {
                isPressed = false;
                isCoolDown = true;
                pressedTime = DateTime.Now;
                GoToState(true);
            }
        }



        public static readonly DependencyProperty CoolDownSecondsProperty =
            DependencyProperty.Register(
            "CoolDownSeconds",
            typeof(int),
            typeof(CoolDownButtonControl),
            new PropertyMetadata(
            new PropertyChangedCallback(
                CoolDownButtonControl.OnCoolDownSecondsPropertyChanged
                )
            )
        );

        public int CoolDownSeconds
        {
            get
            {
                return (int)GetValue(CoolDownSecondsProperty);
            }
            set
            {
                SetValue(CoolDownSecondsProperty, value);
            }
        }

        private static void OnCoolDownSecondsPropertyChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CoolDownButtonControl cdButton = d as CoolDownButtonControl;

            cdButton.OnCoolDownButtonChange(null);
        }

        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register(
                "ButtonText",
                typeof(string),
                typeof(CoolDownButtonControl),
                new PropertyMetadata(
                    new PropertyChangedCallback(
                        CoolDownButtonControl.OnButtonTextPropertyChanged
                        )
                    )
                );

        public string ButtonText
        {
            get
            {
                return (string)GetValue(ButtonTextProperty);
            }
            set
            {
                SetValue(ButtonTextProperty, value);
            }
        }

        private static void OnButtonTextPropertyChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CoolDownButtonControl cdButton = d as CoolDownButtonControl;
            cdButton.OnCoolDownButtonChange(null);
        }

        protected virtual void OnCoolDownButtonChange(RoutedEventArgs e)
        {
            GoToState(true);
        }

        private void GoToState(bool useTransitions)
        {
            //  Go to states in NormalStates state group
            if (isPressed)
            {
                VisualStateManager.GoToState(this, "Pressed", useTransitions);
            }
            else if (isMouseOver)
            {
                VisualStateManager.GoToState(this, "MouseOver", useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, "Normal", useTransitions);
            }

            //  Go to states in CoolDownStates state group
            if (isCoolDown)
            {
                VisualStateManager.GoToState(this, "CoolDown", useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, "Available", useTransitions);
            }
        }

    }
}
