using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string output;

            Triangle triangle = new Triangle("Red");
            //triangle.Colour = "Red";
            //output = "this shape is a " + triangle.Colour + " triangle with " + triangle.Sides + " sides";
            //Console.WriteLine(output);

            var rectangle = new Rectangle("Yellow");
            //rectangle.Colour = "Yellow";
            //output = "this shape is a " + rectangle.Colour + " rectangle with " + rectangle.Sides + " sides";
            //Console.WriteLine(output);

            //Shape triangle = new Shape(3, "Red");
            //Shape rectangle = new Shape(4, "Yellow");
            output = "this shape is a " + triangle.Colour + " triangle with " + triangle.Sides + " sides";
            Console.WriteLine(output);
            output = "this shape is a " + rectangle.Colour + " rectangle with " + rectangle.Sides + " sides";
            Console.WriteLine(output);

            Shape aShape = new Triangle("Purple");
            aShape.Draw();

            aShape = new Rectangle("Tartan");
            aShape.Draw();

            IDrawable drawable = new PurpleTriangle();
            Shape shape = new PurpleTriangle();
            Triangle tri = new PurpleTriangle();
            PurpleTriangle ptri = new PurpleTriangle();

            drawable = new Triangle("Tartan");
            shape = new Triangle("Tartan");
            tri = new Triangle("Tartan");
            //ptri = new Triangle("Tartan");

            drawable = new Rectangle("Tartan");
            shape = new Rectangle("Tartan");
            //tri = new Rectangle("Tartan");
            //ptri = new Triangle("Tartan");

            Object obj = new PurpleTriangle();
            //obj.Draw();

            Vehicle vehicle = new Car(4);
            vehicle.Drive();
            
            Console.ReadLine();
        }
    }
}
