using System;
using System.Windows;
using System.Windows.Threading;
using WpfCoreConcepts.ViewModels;

namespace WpfCoreConcepts
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, 
                delegate 
                {
                    int newValue = 0;

                    if (Counter == int.MaxValue)
                    {
                        newValue = 0;
                    }
                    else
                    {
                        newValue = Counter + 1;
                    }
                    SetValue(CounterProperty, newValue);
                }, Dispatcher);
        }

        public int Counter
        {
            get { return (int)GetValue(CounterProperty); }
            set { SetValue(CounterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Counter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CounterProperty =
            DependencyProperty.Register("Counter", typeof(int), typeof(MainWindow), new PropertyMetadata(0));

    }
}
