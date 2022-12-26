using System;
using System.Collections.Generic;

public class Behavior<T> where T : Behavior<T>
{
	static Dictionary<string, T> Dictionary { get; set; } = new Dictionary<string, T>();
	public string Key { get; set; }
	public static T Get<B>() where B : Behavior<T> => Get(typeof(B).FullName);
	public static T Get(string key)
	{
		if (Dictionary.ContainsKey(key))
			return Dictionary[key];
		else
		{
			Type type = Type.GetType(key);
			T instance = Activator.CreateInstance(type) as T;
			instance.Key = key;
			Dictionary.Add(key, instance);
			return instance;
		}
	}
}
