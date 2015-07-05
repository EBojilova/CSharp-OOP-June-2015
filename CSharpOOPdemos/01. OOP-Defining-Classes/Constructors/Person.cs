public class Person
{
	//Fields
    private string name;
	private int age;

	// Default constructor
	public Person()
	{
		//this.name = null; // ne e nujno da se vpisvat, tai kato tezi stoinosti sa zadadeni pod default, ima smisal da se zadavat, ako sa razlichni ot default
        //this.age = 0; // ne e nujno da se vpisvat, tai kato tezi stoinosti sa zadadeni pod default, ima smisal da se zadavat, ako sa razlichni ot default
	}

	// Constructor with parameters
	public Person(string name, int age)
	{
		this.name = name;
		this.age = age;
	}
    //Property
	public string Name
	{
		get { return this.name; }
		set { this.name = value; }
	}
    //Property
	public int Age
	{
		get { return this.age; }
		set { this.age = value; }
	}
}