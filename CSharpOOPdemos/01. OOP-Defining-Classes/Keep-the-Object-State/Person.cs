﻿using System;

public class Person
{
	//Fields
    private string name;
	private int age;
	//Constructor
	public Person(string name, int age)
	{
		this.name = name;
		this.age = age;
	}
    //Property with protection and validation
	public string Name
	{
		get { return this.name; }
		set
		{
			if (String.IsNullOrEmpty(value))
			{
				throw new ArgumentException("Name cannot be empty!");
			}
			if (value.Length < 2)
			{
				throw new ArgumentException("Name too short! It should be at least 2 letters");
			}
			if (value.Length >= 50)
			{
				throw new ArgumentException("Name too long! It should be less than 50 letters");
			}
			foreach (char ch in value)
			{
				if (!IsLetterAllowedInNames(ch))
				{
					throw new ArgumentException("Invalid name! Use only letters, space and hyphen");
				}
			}

			this.name = value;
		}
	}
    //Property with protection and validation
	public int Age
	{
		get { return this.age; }
		set
		{
			if (value < 0 || value > 120)
			{
				throw new ArgumentException("Invalid age! It should be in the range [0...120].");
			}
			this.age = value;
		}
	}
    //Method
	private bool IsLetterAllowedInNames(char ch)
	{
		bool isAllowed =
			char.IsLetter(ch) || ch == '-' || ch == ' ';
		return isAllowed;
	}
}