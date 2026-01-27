#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class AkEnvironmentData : GodotObject
{

	private new static readonly StringName NativeName = new StringName("AkEnvironmentData");

	[Obsolete("Wrapper types cannot be constructed with constructors (it only instantiate the underlying AkEnvironmentData object), please use the Instantiate() method instead.")]
	protected AkEnvironmentData() { }

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="AkEnvironmentData"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="AkEnvironmentData"/> wrapper type,
	/// a new instance of the <see cref="AkEnvironmentData"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="AkEnvironmentData"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static AkEnvironmentData Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is AkEnvironmentData wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(AkEnvironmentData);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(AkEnvironmentData).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (AkEnvironmentData)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="AkEnvironmentData"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "AkEnvironmentData" type.</returns>
	public new static AkEnvironmentData Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionMethodName
	{
		public new static readonly StringName CompareByPriority = "compare_by_priority";
	}

	public new bool CompareByPriority(AkEnvironment a, AkEnvironment b) => 
		Call(GDExtensionMethodName.CompareByPriority, [a, b]).As<bool>();

}
