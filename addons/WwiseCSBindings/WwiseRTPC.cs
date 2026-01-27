#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class WwiseRTPC : WwiseBaseType
{

	private new static readonly StringName NativeName = new StringName("WwiseRTPC");

	[Obsolete("Wrapper types cannot be constructed with constructors (it only instantiate the underlying WwiseRTPC object), please use the Instantiate() method instead.")]
	protected WwiseRTPC() { }

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="WwiseRTPC"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="WwiseRTPC"/> wrapper type,
	/// a new instance of the <see cref="WwiseRTPC"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="WwiseRTPC"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static WwiseRTPC Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is WwiseRTPC wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(WwiseRTPC);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(WwiseRTPC).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (WwiseRTPC)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="WwiseRTPC"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "WwiseRTPC" type.</returns>
	public new static WwiseRTPC Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionMethodName
	{
		public new static readonly StringName SetValue = "set_value";
		public new static readonly StringName GetValue = "get_value";
		public new static readonly StringName SetGlobalValue = "set_global_value";
		public new static readonly StringName GetGlobalValue = "get_global_value";
	}

	public new void SetValue(Node gameObject, double value) => 
		Call(GDExtensionMethodName.SetValue, [gameObject, value]);

	public new double GetValue(Node gameObject) => 
		Call(GDExtensionMethodName.GetValue, [gameObject]).As<double>();

	public new void SetGlobalValue(double value) => 
		Call(GDExtensionMethodName.SetGlobalValue, [value]);

	public new double GetGlobalValue() => 
		Call(GDExtensionMethodName.GetGlobalValue, []).As<double>();

}
