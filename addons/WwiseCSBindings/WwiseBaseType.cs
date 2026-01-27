#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public abstract partial class WwiseBaseType : Resource
{

	private new static readonly StringName NativeName = new StringName("WwiseBaseType");

	[Obsolete("Wrapper types cannot be constructed with constructors (it only instantiate the underlying WwiseBaseType object), please use the Instantiate() method instead.")]
	protected WwiseBaseType() { }

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="WwiseBaseType"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="WwiseBaseType"/> wrapper type,
	/// a new instance of the <see cref="WwiseBaseType"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="WwiseBaseType"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static WwiseBaseType Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is WwiseBaseType wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(WwiseBaseType);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(WwiseBaseType).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (WwiseBaseType)InstanceFromId(instanceId);
	}

	public new static class GDExtensionSignalName
	{
		public new static readonly StringName WsPostResourceInit = "ws_post_resource_init";
	}

	public new delegate void WsPostResourceInitSignalHandler();
	private WsPostResourceInitSignalHandler _wsPostResourceInitSignal;
	private Callable _wsPostResourceInitSignalCallable;
	public event WsPostResourceInitSignalHandler WsPostResourceInitSignal
	{
		add
		{
			if (_wsPostResourceInitSignal is null)
			{
				_wsPostResourceInitSignalCallable = Callable.From(() => 
					_wsPostResourceInitSignal?.Invoke());
				Connect(GDExtensionSignalName.WsPostResourceInit, _wsPostResourceInitSignalCallable);
			}
			_wsPostResourceInitSignal += value;
		}
		remove
		{
			_wsPostResourceInitSignal -= value;
			if (_wsPostResourceInitSignal is not null) return;
			Disconnect(GDExtensionSignalName.WsPostResourceInit, _wsPostResourceInitSignalCallable);
			_wsPostResourceInitSignalCallable = default;
		}
	}

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName Name = "name";
		public new static readonly StringName Id = "id";
		public new static readonly StringName Guid = "guid";
		public new static readonly StringName Dummy = "dummy";
	}

	public new string Name
	{
		get => Get(GDExtensionPropertyName.Name).As<string>();
		set => Set(GDExtensionPropertyName.Name, value);
	}

	public new long Id
	{
		get => Get(GDExtensionPropertyName.Id).As<long>();
		set => Set(GDExtensionPropertyName.Id, value);
	}

	public new string Guid
	{
		get => Get(GDExtensionPropertyName.Guid).As<string>();
		set => Set(GDExtensionPropertyName.Guid, value);
	}

	public new bool Dummy
	{
		get => Get(GDExtensionPropertyName.Dummy).As<bool>();
		set => Set(GDExtensionPropertyName.Dummy, value);
	}

}
