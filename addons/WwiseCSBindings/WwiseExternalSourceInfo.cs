#pragma warning disable CS0109
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Godot;
using Godot.Collections;

namespace GDExtensionWrappers;

[Tool]
public partial class WwiseExternalSourceInfo : RefCounted
{

	private new static readonly StringName NativeName = new StringName("WwiseExternalSourceInfo");

	private static CSharpScript _wrapperScriptAsset;

	/// <summary>
	/// Try to cast the script on the supplied <paramref name="godotObject"/> to the <see cref="WwiseExternalSourceInfo"/> wrapper type,
	/// if no script has attached to the type, or the script attached to the type does not inherit the <see cref="WwiseExternalSourceInfo"/> wrapper type,
	/// a new instance of the <see cref="WwiseExternalSourceInfo"/> wrapper script will get attaches to the <paramref name="godotObject"/>.
	/// </summary>
	/// <remarks>The developer should only supply the <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</remarks>
	/// <param name="godotObject">The <paramref name="godotObject"/> that represents the correct underlying GDExtension type.</param>
	/// <returns>The existing or a new instance of the <see cref="WwiseExternalSourceInfo"/> wrapper script attached to the supplied <paramref name="godotObject"/>.</returns>
	public new static WwiseExternalSourceInfo Bind(GodotObject godotObject)
	{
		if (!IsInstanceValid(godotObject))
			return null;

		if (godotObject is WwiseExternalSourceInfo wrapperScriptInstance)
			return wrapperScriptInstance;

#if DEBUG
		var expectedType = typeof(WwiseExternalSourceInfo);
		var currentObjectClassName = godotObject.GetClass();
		if (!ClassDB.IsParentClass(expectedType.Name, currentObjectClassName))
			throw new InvalidOperationException($"The supplied GodotObject ({currentObjectClassName}) is not the {expectedType.Name} type.");
#endif

		if (_wrapperScriptAsset is null)
		{
			var scriptPathAttribute = typeof(WwiseExternalSourceInfo).GetCustomAttributes<ScriptPathAttribute>().FirstOrDefault();
			if (scriptPathAttribute is null) throw new UnreachableException();
			_wrapperScriptAsset = ResourceLoader.Load<CSharpScript>(scriptPathAttribute.Path);
		}

		var instanceId = godotObject.GetInstanceId();
		godotObject.SetScript(_wrapperScriptAsset);
		return (WwiseExternalSourceInfo)InstanceFromId(instanceId);
	}

	/// <summary>
	/// Creates an instance of the GDExtension <see cref="WwiseExternalSourceInfo"/> type, and attaches a wrapper script instance to it.
	/// </summary>
	/// <returns>The wrapper instance linked to the underlying GDExtension "WwiseExternalSourceInfo" type.</returns>
	public new static WwiseExternalSourceInfo Instantiate() => Bind(ClassDB.Instantiate(NativeName).As<GodotObject>());

	public new static class GDExtensionPropertyName
	{
		public new static readonly StringName ExternalSrcCookie = "external_src_cookie";
		public new static readonly StringName IdCodec = "id_codec";
		public new static readonly StringName SzFile = "sz_file";
	}

	public new long ExternalSrcCookie
	{
		get => Get(GDExtensionPropertyName.ExternalSrcCookie).As<long>();
		set => Set(GDExtensionPropertyName.ExternalSrcCookie, value);
	}

	public new Variant IdCodec
	{
		get => Get(GDExtensionPropertyName.IdCodec).As<Variant>();
		set => Set(GDExtensionPropertyName.IdCodec, value);
	}

	public new string SzFile
	{
		get => Get(GDExtensionPropertyName.SzFile).As<string>();
		set => Set(GDExtensionPropertyName.SzFile, value);
	}

}
