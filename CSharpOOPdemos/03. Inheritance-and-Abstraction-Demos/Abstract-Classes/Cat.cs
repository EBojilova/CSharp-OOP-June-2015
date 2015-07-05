public abstract class Cat : Animal // Poneje e abstracten klas otnovo ne triabva da implementira abstraktnite metodi ot Animal
{
	//Property- ne e abstractno
    public string Breed { get; set; }

    // Abstract method --> should be implemented(with override) in the child classes
	public abstract void SayMyaau();
}
