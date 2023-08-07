using System.Collections.ObjectModel;

namespace Custom_RadioGroup_For_Enumeration.Controls;

public partial class EnumRadioGroup : ContentView
{
    // Enum values as an observable collection
    public ObservableCollection<Enum> EnumValues { get; private set; } = new ObservableCollection<Enum>();
    public Enum SelectedEnumValue { get; set; }

    public static readonly BindableProperty EnumTypeProperty =
        BindableProperty.Create(nameof(EnumType), typeof(Type), typeof(EnumRadioGroup), null, propertyChanged: OnEnumTypeChanged);

    public Type EnumType
    {
        get => (Type)GetValue(EnumTypeProperty);
        set => SetValue(EnumTypeProperty, value);
    }

    public EnumRadioGroup()
    {
        InitializeComponent();
        this.BindingContext = this;  // Important to set for the ItemsSource binding to work.
    }

    private static void OnEnumTypeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (EnumRadioGroup)bindable;
        control.DisplayValues((Type)newValue);
    }

    private void DisplayValues(Type enumType)
    {
        if (!enumType.IsEnum)
        {
            throw new ArgumentException("Provided type must be an enumeration.");
        }

        EnumValues.Clear();
        foreach (Enum value in Enum.GetValues(enumType))
        {
            EnumValues.Add(value);
        }
    }
}
