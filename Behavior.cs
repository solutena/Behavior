using System;
using System.Collections.Generic;

public class Behaviour<T> where T : Behaviour<T>
{
	static Dictionary<string, T> Dictionary { get; set; } = new Dictionary<string, T>();
	public string Key { get; set; }
	public static T Get<B>() where B : Behaviour<T>
	{
		string key = typeof(B).FullName;
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
