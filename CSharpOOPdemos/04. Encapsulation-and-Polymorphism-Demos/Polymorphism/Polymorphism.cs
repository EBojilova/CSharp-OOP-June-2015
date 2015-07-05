using System;
using System.Linq;

public class Polymorphism
{
    public static void Main()
    {
        // Dostapvat se pot toci nachin, tai kato klasovete sa bez constructori s parametri, a samo s propertita
        // Moje da se dostapi i s konstructor bez parametri:
        var c = new Circle();
        c.Radius = 3;

        // Tova savpada s:
        var d = new Circle { Radius = 3 };
        Console.WriteLine(c.CalcSurface());

        // Moje da se zapishe i taka:
        // Figure e=new Circle();// no niama da moga da dostapia radiusa, tai kato toi ne e definiran vav Figure
        // Moje dori da definirame obekt i kato Interface, no te imame dostap samo do metodite v interfaca
        Figure[] figures =
            {
                new Square { Size = 3 }, new Circle { Radius = 2 }, new Rectangle { Width = 2, Height = 3 }, 
                new Circle { Radius = 3.5 }, new Square { Size = 2.5 }, new Square { Size = 4 }
            };

        foreach (var figure in figures)
        {
            Console.WriteLine(
                "Figure = {0} surface = {1:F2}", 
                figure.GetType().Name.PadRight(10, ' '), 
                figure.CalcSurface());
        }

        foreach (var figure in figures)
        {
            Console.WriteLine(figure.ToString()); // override sme ToString samo v Square
        }

        var circles = figures.Where(fig => fig is Circle).Cast<Circle>();

        // is ste hvane i naslednicite na Circle, ako ima takiva, primerno SpecialCircle, no kolekciata vse oste e ot figuri, i zatova go castvame
        foreach (var circle in circles)
        {
            // Moje i tuka da se castne, kato vmesto var se napishe Circle vav foreacha
            //Ako ne e castvano moje i tuka da se castva s var c1=circle as Circle;//operatora az varshi i proverka i kastvane(po-dobrar ot is), ako ne moje da go castne vrasta null
            circle.Radius = 5;
        }
    }
}