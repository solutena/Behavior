using System;
using System.Collections.Generic;
using UnityEngine;

public class Behavior<T> where T : class
{
	static Dictionary<string, T> Dictionary { get; set; } = new Dictionary<string, T>();
	public string Key { get; set; }
	public static T Get(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			Debug.LogError("����ִ� key �Դϴ�");
			return default;
		}
		if (Dictionary.ContainsKey(key))
			return Dictionary[key];
		else
		{
			Type type = Type.GetType(key);
			if (type == null)
			{
				Debug.LogError("�������� ���� Behavior �Դϴ�(" + key + ")");
				return default;
			}
			T instance = Activator.CreateInstance(type) as T;
			(instance as Behavior<T>).Key = key;
			Dictionary.Add(key, instance);
			return instance;
		}
	}
}