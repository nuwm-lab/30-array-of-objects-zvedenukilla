using System;


class Cone
{
   private double x0, y0, z0;
   private double x1, y1, z1;
   private double R;


   public Cone(double x0, double y0, double z0,
               double x1, double y1, double z1,
               double R)
   {
       this.x0 = x0;
       this.y0 = y0;
       this.z0 = z0;
       this.x1 = x1;
       this.y1 = y1;
       this.z1 = z1;
       this.R = R;
   }


  
   public double SlantHeight()
   {


       double h = Math.Sqrt(Math.Pow(x1 - x0, 2) +
                            Math.Pow(y1 - y0, 2) +
                            Math.Pow(z1 - z0, 2));


      
       return Math.Sqrt(R * R + h * h);
   }
}


class Program
{
   static void Main()
   {
       Cone cone = new Cone(0, 0, 0, 0, 0, 5, 3);


       Console.WriteLine("Твірна конуса = " + cone.SlantHeight());
   }
}
