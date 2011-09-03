 



namespace Microsoft.Practices.Prism.Commands
{
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Controls.Primitives;
	using System.Windows.Input;
	
	/// <summary>
	/// Static Class that holds all Dependency Properties and Static methods to allow 
	/// the Loaded event of the  Control class to be attached to a Command. 
	/// </summary>
	/// <remarks>
	/// This class is required, because Silverlight doesn't have native support for Commands. 
	/// </remarks>
	public static class Loaded
	{
		private static readonly DependencyProperty LoadedCommandBehaviorProperty = DependencyProperty.RegisterAttached(
			"LoadedCommandBehavior",
			typeof(LoadedCommandBehavior),
			typeof(Loaded),
			null);


		/// <summary>
		/// Command to execute on click event.
		/// </summary>
		public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
			"Command",
			typeof(ICommand),
			typeof(Loaded),
			new PropertyMetadata(OnSetCommandCallback));

		/// <summary>
		/// Command parameter to supply on command execution.
		/// </summary>
		public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
			"CommandParameter",
			typeof(object),
			typeof(Loaded),
			new PropertyMetadata(OnSetCommandParameterCallback));


		/// <summary>
		/// Sets the <see cref="ICommand"/> to execute on the click event.
		/// </summary>
		/// <param name="control"> Control dependency object to attach command</param>
		/// <param name="command">Command to attach</param>
		public static void SetCommand(Control control, ICommand command)
		{
			control.SetValue(CommandProperty, command);
		}

		/// <summary>
		/// Retrieves the <see cref="ICommand"/> attached to the <see cref="ButtonBase"/>.
		/// </summary>
		/// <param name="control">Control containing the Command dependency property</param>
		/// <returns>The value of the command attached</returns>
		public static ICommand GetCommand(Control control)
		{
			return control.GetValue(CommandProperty) as ICommand;
		}

		/// <summary>
		/// Sets the value for the CommandParameter attached property on the provided <see cref="Control"/>.
		/// </summary>
		/// <param name="control">ButtonBase to attach CommandParameter</param>
		/// <param name="parameter">Parameter value to attach</param>
		public static void SetCommandParameter(Control control, object parameter)
		{
			control.SetValue(CommandParameterProperty, parameter);
		}

		/// <summary>
		/// Gets the value in CommandParameter attached property on the provided <see cref="ButtonBase"/>
		/// </summary>
		/// <param name="control">Control that has the CommandParameter</param>
		/// <returns>The value of the property</returns>
		public static object GetCommandParameter(Control control)
		{
			return control.GetValue(CommandParameterProperty);
		}

		private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			Control control = dependencyObject as Control;
			if (control != null)
			{
				var behavior = GetOrCreateBehavior(control);
				behavior.Command = e.NewValue as ICommand;
			}
		}

		private static void OnSetCommandParameterCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			Control control = dependencyObject as Control;
			if (control != null)
			{
				var behavior = GetOrCreateBehavior(control);
				behavior.CommandParameter = e.NewValue;
			}
		}

		private static LoadedCommandBehavior GetOrCreateBehavior(Control control)
		{
			var behavior = control.GetValue(LoadedCommandBehaviorProperty) as LoadedCommandBehavior;
			if (behavior == null)
			{
				behavior = new LoadedCommandBehavior(control);
				control.SetValue(LoadedCommandBehaviorProperty, behavior);
			}

			return behavior;
		}
	}
	
	public class LoadedCommandBehavior : CommandBehaviorBase<Control>
	{
		public LoadedCommandBehavior(Control targetObject)
			: base(targetObject)
		{
			targetObject.Loaded += OnLoaded;
		}

		private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
		{
			ExecuteCommand();
		}
	}
	/// <summary>
	/// Static Class that holds all Dependency Properties and Static methods to allow 
	/// the Unloaded event of the  Control class to be attached to a Command. 
	/// </summary>
	/// <remarks>
	/// This class is required, because Silverlight doesn't have native support for Commands. 
	/// </remarks>
	public static class Unloaded
	{
		private static readonly DependencyProperty UnloadedCommandBehaviorProperty = DependencyProperty.RegisterAttached(
			"UnloadedCommandBehavior",
			typeof(UnloadedCommandBehavior),
			typeof(Unloaded),
			null);


		/// <summary>
		/// Command to execute on click event.
		/// </summary>
		public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
			"Command",
			typeof(ICommand),
			typeof(Unloaded),
			new PropertyMetadata(OnSetCommandCallback));

		/// <summary>
		/// Command parameter to supply on command execution.
		/// </summary>
		public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
			"CommandParameter",
			typeof(object),
			typeof(Unloaded),
			new PropertyMetadata(OnSetCommandParameterCallback));


		/// <summary>
		/// Sets the <see cref="ICommand"/> to execute on the click event.
		/// </summary>
		/// <param name="control"> Control dependency object to attach command</param>
		/// <param name="command">Command to attach</param>
		public static void SetCommand(Control control, ICommand command)
		{
			control.SetValue(CommandProperty, command);
		}

		/// <summary>
		/// Retrieves the <see cref="ICommand"/> attached to the <see cref="ButtonBase"/>.
		/// </summary>
		/// <param name="control">Control containing the Command dependency property</param>
		/// <returns>The value of the command attached</returns>
		public static ICommand GetCommand(Control control)
		{
			return control.GetValue(CommandProperty) as ICommand;
		}

		/// <summary>
		/// Sets the value for the CommandParameter attached property on the provided <see cref="Control"/>.
		/// </summary>
		/// <param name="control">ButtonBase to attach CommandParameter</param>
		/// <param name="parameter">Parameter value to attach</param>
		public static void SetCommandParameter(Control control, object parameter)
		{
			control.SetValue(CommandParameterProperty, parameter);
		}

		/// <summary>
		/// Gets the value in CommandParameter attached property on the provided <see cref="ButtonBase"/>
		/// </summary>
		/// <param name="control">Control that has the CommandParameter</param>
		/// <returns>The value of the property</returns>
		public static object GetCommandParameter(Control control)
		{
			return control.GetValue(CommandParameterProperty);
		}

		private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			Control control = dependencyObject as Control;
			if (control != null)
			{
				var behavior = GetOrCreateBehavior(control);
				behavior.Command = e.NewValue as ICommand;
			}
		}

		private static void OnSetCommandParameterCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			Control control = dependencyObject as Control;
			if (control != null)
			{
				var behavior = GetOrCreateBehavior(control);
				behavior.CommandParameter = e.NewValue;
			}
		}

		private static UnloadedCommandBehavior GetOrCreateBehavior(Control control)
		{
			var behavior = control.GetValue(UnloadedCommandBehaviorProperty) as UnloadedCommandBehavior;
			if (behavior == null)
			{
				behavior = new UnloadedCommandBehavior(control);
				control.SetValue(UnloadedCommandBehaviorProperty, behavior);
			}

			return behavior;
		}
	}
	
	public class UnloadedCommandBehavior : CommandBehaviorBase<Control>
	{
		public UnloadedCommandBehavior(Control targetObject)
			: base(targetObject)
		{
			targetObject.Unloaded += OnUnloaded;
		}

		private void OnUnloaded(object sender, RoutedEventArgs routedEventArgs)
		{
			ExecuteCommand();
		}
	}
	/// <summary>
	/// Static Class that holds all Dependency Properties and Static methods to allow 
	/// the SelectionChanged event of the  Selector class to be attached to a Command. 
	/// </summary>
	/// <remarks>
	/// This class is required, because Silverlight doesn't have native support for Commands. 
	/// </remarks>
	public static class SelectionChanged
	{
		private static readonly DependencyProperty SelectionChangedCommandBehaviorProperty = DependencyProperty.RegisterAttached(
			"SelectionChangedCommandBehavior",
			typeof(SelectionChangedCommandBehavior),
			typeof(SelectionChanged),
			null);


		/// <summary>
		/// Command to execute on click event.
		/// </summary>
		public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
			"Command",
			typeof(ICommand),
			typeof(SelectionChanged),
			new PropertyMetadata(OnSetCommandCallback));

		/// <summary>
		/// Command parameter to supply on command execution.
		/// </summary>
		public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
			"CommandParameter",
			typeof(object),
			typeof(SelectionChanged),
			new PropertyMetadata(OnSetCommandParameterCallback));


		/// <summary>
		/// Sets the <see cref="ICommand"/> to execute on the click event.
		/// </summary>
		/// <param name="control"> Selector dependency object to attach command</param>
		/// <param name="command">Command to attach</param>
		public static void SetCommand(Selector control, ICommand command)
		{
			control.SetValue(CommandProperty, command);
		}

		/// <summary>
		/// Retrieves the <see cref="ICommand"/> attached to the <see cref="ButtonBase"/>.
		/// </summary>
		/// <param name="control">Selector containing the Command dependency property</param>
		/// <returns>The value of the command attached</returns>
		public static ICommand GetCommand(Selector control)
		{
			return control.GetValue(CommandProperty) as ICommand;
		}

		/// <summary>
		/// Sets the value for the CommandParameter attached property on the provided <see cref="Selector"/>.
		/// </summary>
		/// <param name="control">ButtonBase to attach CommandParameter</param>
		/// <param name="parameter">Parameter value to attach</param>
		public static void SetCommandParameter(Selector control, object parameter)
		{
			control.SetValue(CommandParameterProperty, parameter);
		}

		/// <summary>
		/// Gets the value in CommandParameter attached property on the provided <see cref="ButtonBase"/>
		/// </summary>
		/// <param name="control">Selector that has the CommandParameter</param>
		/// <returns>The value of the property</returns>
		public static object GetCommandParameter(Selector control)
		{
			return control.GetValue(CommandParameterProperty);
		}

		private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			Selector control = dependencyObject as Selector;
			if (control != null)
			{
				var behavior = GetOrCreateBehavior(control);
				behavior.Command = e.NewValue as ICommand;
			}
		}

		private static void OnSetCommandParameterCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			Selector control = dependencyObject as Selector;
			if (control != null)
			{
				var behavior = GetOrCreateBehavior(control);
				behavior.CommandParameter = e.NewValue;
			}
		}

		private static SelectionChangedCommandBehavior GetOrCreateBehavior(Selector control)
		{
			var behavior = control.GetValue(SelectionChangedCommandBehaviorProperty) as SelectionChangedCommandBehavior;
			if (behavior == null)
			{
				behavior = new SelectionChangedCommandBehavior(control);
				control.SetValue(SelectionChangedCommandBehaviorProperty, behavior);
			}

			return behavior;
		}
	}
	
	public class SelectionChangedCommandBehavior : CommandBehaviorBase<Selector>
	{
		public SelectionChangedCommandBehavior(Selector targetObject)
			: base(targetObject)
		{
			targetObject.SelectionChanged += OnSelectionChanged;
		}

		private void OnSelectionChanged(object sender, RoutedEventArgs routedEventArgs)
		{
			ExecuteCommand();
		}
	}
	/// <summary>
	/// Static Class that holds all Dependency Properties and Static methods to allow 
	/// the SelectedItemChanged event of the  TreeView class to be attached to a Command. 
	/// </summary>
	/// <remarks>
	/// This class is required, because Silverlight doesn't have native support for Commands. 
	/// </remarks>
	public static class SelectedItemChanged
	{
		private static readonly DependencyProperty SelectedItemChangedCommandBehaviorProperty = DependencyProperty.RegisterAttached(
			"SelectedItemChangedCommandBehavior",
			typeof(SelectedItemChangedCommandBehavior),
			typeof(SelectedItemChanged),
			null);


		/// <summary>
		/// Command to execute on click event.
		/// </summary>
		public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
			"Command",
			typeof(ICommand),
			typeof(SelectedItemChanged),
			new PropertyMetadata(OnSetCommandCallback));

		/// <summary>
		/// Command parameter to supply on command execution.
		/// </summary>
		public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
			"CommandParameter",
			typeof(object),
			typeof(SelectedItemChanged),
			new PropertyMetadata(OnSetCommandParameterCallback));


		/// <summary>
		/// Sets the <see cref="ICommand"/> to execute on the click event.
		/// </summary>
		/// <param name="control"> TreeView dependency object to attach command</param>
		/// <param name="command">Command to attach</param>
		public static void SetCommand(TreeView control, ICommand command)
		{
			control.SetValue(CommandProperty, command);
		}

		/// <summary>
		/// Retrieves the <see cref="ICommand"/> attached to the <see cref="ButtonBase"/>.
		/// </summary>
		/// <param name="control">TreeView containing the Command dependency property</param>
		/// <returns>The value of the command attached</returns>
		public static ICommand GetCommand(TreeView control)
		{
			return control.GetValue(CommandProperty) as ICommand;
		}

		/// <summary>
		/// Sets the value for the CommandParameter attached property on the provided <see cref="TreeView"/>.
		/// </summary>
		/// <param name="control">ButtonBase to attach CommandParameter</param>
		/// <param name="parameter">Parameter value to attach</param>
		public static void SetCommandParameter(TreeView control, object parameter)
		{
			control.SetValue(CommandParameterProperty, parameter);
		}

		/// <summary>
		/// Gets the value in CommandParameter attached property on the provided <see cref="ButtonBase"/>
		/// </summary>
		/// <param name="control">TreeView that has the CommandParameter</param>
		/// <returns>The value of the property</returns>
		public static object GetCommandParameter(TreeView control)
		{
			return control.GetValue(CommandParameterProperty);
		}

		private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			TreeView control = dependencyObject as TreeView;
			if (control != null)
			{
				var behavior = GetOrCreateBehavior(control);
				behavior.Command = e.NewValue as ICommand;
			}
		}

		private static void OnSetCommandParameterCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			TreeView control = dependencyObject as TreeView;
			if (control != null)
			{
				var behavior = GetOrCreateBehavior(control);
				behavior.CommandParameter = e.NewValue;
			}
		}

		private static SelectedItemChangedCommandBehavior GetOrCreateBehavior(TreeView control)
		{
			var behavior = control.GetValue(SelectedItemChangedCommandBehaviorProperty) as SelectedItemChangedCommandBehavior;
			if (behavior == null)
			{
				behavior = new SelectedItemChangedCommandBehavior(control);
				control.SetValue(SelectedItemChangedCommandBehaviorProperty, behavior);
			}

			return behavior;
		}
	}
	
	public class SelectedItemChangedCommandBehavior : CommandBehaviorBase<TreeView>
	{
		public SelectedItemChangedCommandBehavior(TreeView targetObject)
			: base(targetObject)
		{
			targetObject.SelectedItemChanged += OnSelectedItemChanged;
		}

		private void OnSelectedItemChanged(object sender, RoutedEventArgs routedEventArgs)
		{
			ExecuteCommand();
		}
	}
}