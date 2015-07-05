public class Person//riadko se praviat celi klasove statichni. Ako se praviat to vsichko v klasa triabva da e statichno
{
    //statichna promenliva universalna za vsichki obekti ot tip Person- ste se uvelichava s 1 pri vsiaka nova instancia na klasa
    private static int instanceCounter = 0;

    public Person(string name = null)
    {
        // ne se zakacha za instanciata this. a se zakacha za klasa Person.
        Person.instanceCounter++;
        this.Name = name;
    }
    // i Propertito e statichno
    public static int PersonCounter
    {
        get
        {
            return Person.instanceCounter;
        }
    }

    public string Name { get; set; }
}