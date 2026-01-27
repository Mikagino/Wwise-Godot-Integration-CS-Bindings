#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public abstract partial class WwiseGroupType : WwiseBaseType
{

	private new static readonly StringName NativeName = new StringName("WwiseGroupType");

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="WwiseGroupType"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="WwiseGroupType"/> wrapper type,
	/// a new instance of the <see cref="WwiseGroupType"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="WwiseGroupType"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static WwiseGroupType Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is WwiseGroupType wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(WwiseGroupType);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(WwiseGroupType).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (WwiseGroupType)InstanceFromId(instanceId);
	}

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName GroupRef = "group_ref";
		public new static readonly StringName GroupId = "group_id";
	}

	public new Variant GroupRef
	{
		get => Get(GDExtensionPropertyName.GroupRef).As<Variant>();
		set => Set(GDExtensionPropertyName.GroupRef, value);
	}

	public new long GroupId
	{
		get => Get(GDExtensionPropertyName.GroupId).As<long>();
		set => Set(GDExtensionPropertyName.GroupId, value);
	}

}
